//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Space Rabbits">
//     Copyright (c) Space Rabbits. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using STARAAPP.Entities;
using STARAAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STARAAPP.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderToUser> _orderToUserRepository;
        private readonly IRepository<User> _userRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderToUser> orderToUserRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _orderToUserRepository = orderToUserRepository;
            _userRepository = userRepository;
        }

        public async Task AddOrderAsync(OrderDto order, int reporterId)
        {
            var newOrder = new Order
            {
                Comments = order.Comments,
                CompletionTime = order.CompletionTime,
                Cost = order.Cost,
                CustomerComment = order.CustomerComment,
                CustomerCommentTime = order.CustomerCommentTime,
                CustomerMark = order.CustomerMark,
                Description = order.Description,
                TimeFrom = order.TimeFrom,
                TimeTo = order.TimeTo,
                Latitude = order.Latitude,
                Longitude = order.Longitude,
                Measurements = order.Measurements,
                Title = order.Title,
                WorkerCommentAfter = order.WorkerCommentAfter,
                WorkerCommentBefore = order.WorkerCommentBefore,
                WorkerCommentTimeBefore = order.WorkerCommentTimeBefore,
                WorkerCommentTimeAfter = order.WorkerCommentTimeAfter,
                ReporterID = reporterId
            };

            OrderToUser orderToUser = null;

            if (order.WorkerID != null)
            {
                newOrder.IsAssigned = true;

                orderToUser = new OrderToUser
                {
                    UserID = order.WorkerID.Value,
                    TimeStart = order.TimeFrom,
                    Duration = order.Duration,
                    Status = order.Status
                };
            }

            await _orderRepository.AddAsync(newOrder);

            if (order.WorkerID != null)
            {
                orderToUser.OrderID = newOrder.ID;

                await _orderToUserRepository.AddAsync(orderToUser);
            }
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = (await _orderRepository.GetAsync(x => x.ID == id)).FirstOrDefault();

            if (order == null)
            {
                throw new OrderException(OrderErrorCode.NoSuchOrder);
            }

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync(int userId)
        {
            var user = (await _userRepository.GetAsync(u => u.ID == userId)).FirstOrDefault();

            switch ((UserRoleType)user.RoleId)
            {
                case UserRoleType.Worker:
                    var orderIds = (await _orderToUserRepository.GetAsync(x => x.UserID == userId)).Select(x => x.OrderID).ToList();
                    return (await _orderRepository.GetAsync(x => orderIds.Contains(x.ID))).ToList();
                case UserRoleType.Customer:
                    return (await _orderRepository.GetAsync(x => x.ReporterID == userId)).ToList();
                default:
                    return (await _orderRepository.ListAllAsync()).ToList();
            }
        }

        public async Task UpdateOrderAsync(OrderDto order)
        {
            var existingOrder = (await _orderRepository.GetAsync(x => x.ID == order.ID)).FirstOrDefault();

            if (existingOrder == null)
            {
                throw new OrderException(OrderErrorCode.NoSuchOrder);
            }

            existingOrder.Comments = order.Comments;
            existingOrder.CompletionTime = order.CompletionTime;
            existingOrder.Cost = order.Cost;
            existingOrder.CustomerComment = order.CustomerComment;
            existingOrder.CustomerCommentTime = order.CustomerCommentTime;
            existingOrder.CustomerMark = order.CustomerMark;
            existingOrder.Description = order.Description;
            existingOrder.TimeFrom = order.TimeFrom;
            existingOrder.TimeTo = order.TimeTo;
            existingOrder.Latitude = order.Latitude;
            existingOrder.Longitude = order.Longitude;
            existingOrder.Measurements = order.Measurements;
            existingOrder.Title = order.Title;
            existingOrder.WorkerCommentAfter = order.WorkerCommentAfter;
            existingOrder.WorkerCommentBefore = order.WorkerCommentBefore;
            existingOrder.WorkerCommentTimeBefore = order.WorkerCommentTimeBefore;
            existingOrder.WorkerCommentTimeAfter = order.WorkerCommentTimeAfter;

            var orderToUser = (await _orderToUserRepository.GetAsync(x => x.OrderID == order.ID)).FirstOrDefault();

            if (orderToUser != null)
            {
                if (order.WorkerID == null)
                {
                   await _orderToUserRepository.DeleteAsync(orderToUser);
                }
                else
                {
                    orderToUser.UserID = order.WorkerID.Value;
                    orderToUser.TimeStart = order.TimeFrom;
                    orderToUser.Duration = order.Duration;
                    orderToUser.Status = order.Status;

                    await _orderToUserRepository.UpdateAsync(orderToUser);
                }
            }
            else if (order.WorkerID != null)
            {
                orderToUser = new OrderToUser
                {
                    UserID = order.WorkerID.Value,
                    TimeStart = order.TimeFrom,
                    Duration = order.Duration,
                    Status = order.Status,
                    OrderID = order.ID
                };

                await _orderToUserRepository.AddAsync(orderToUser);
            }

            existingOrder.IsAssigned = order.WorkerID != null;

            await _orderRepository.UpdateAsync(existingOrder);
        }
    }
}
