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
    public class OrderService /*: IOrderService*/
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task AddOrderAsync(OrderDto order)
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
                WorkerCommentTimeAfter = order.WorkerCommentTimeAfter
            };

            return _orderRepository.AddAsync(newOrder);
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

        public Task<List<Order>> GetOrdersAsync(int userId, int roleId)
        {
            throw new NotImplementedException();
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
        }
    }
}
