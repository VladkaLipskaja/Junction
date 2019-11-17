using Microsoft.AspNetCore.Mvc;
using STARAAPP.Models;
using STARAAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STARAAPP.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// The security service
        /// </summary>
        private ISecurityService _securityService;

        /// <summary>
        /// The order service
        /// </summary>
        private IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="securityService">The security service.</param>
        public OrdersController(ISecurityService securityService, IOrderService orderService)
        {
            _orderService = orderService;
            _securityService = securityService;
        }



        [HttpGet]
        public async Task<JsonResult> GetOrders()
        {
            try
            {
                int userId = _securityService.GetUserId(User);

                var orders = await _orderService.GetOrdersAsync(userId);

                var result = new GetOrdersResponse
                {
                    Orders = orders.Select(o => new GetOrdersResponse.Order
                    {
                        Comments = o.Comments,
                        CompletionTime = o.CompletionTime,
                        Cost = o.Cost,
                        CustomerComment = o.CustomerComment,
                        CustomerCommentTime = o.CustomerCommentTime,
                        CustomerMark = o.CustomerMark,
                        Description = o.Description,
                        Latitude = o.Latitude,
                        Longitude = o.Longitude,
                        TimeFrom = o.TimeFrom,
                        TimeTo = o.TimeTo,
                        Measurements = o.Measurements,
                        Title = o.Title,
                        WorkerCommentAfter = o.WorkerCommentAfter,
                        WorkerCommentBefore = o.WorkerCommentBefore,
                        WorkerCommentTimeAfter = o.WorkerCommentTimeAfter,
                        WorkerCommentTimeBefore = o.WorkerCommentTimeBefore,
                        ReporterID = o.ReporterID,
                        IsAssigned = o.IsAssigned
                    }).ToList()
                };

                return this.JsonApi(result);
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);

                var result = new GetOrderByIdResponse
                {
                    Comments = order.Comments,
                    CompletionTime = order.CompletionTime,
                    Cost = order.Cost,
                    CustomerComment = order.CustomerComment,
                    CustomerCommentTime = order.CustomerCommentTime,
                    CustomerMark = order.CustomerMark,
                    Description = order.Description,
                    Latitude = order.Latitude,
                    Longitude = order.Longitude,
                    TimeFrom = order.TimeFrom,
                    TimeTo = order.TimeTo,
                    Measurements = order.Measurements,
                    Title = order.Title,
                    WorkerCommentAfter = order.WorkerCommentAfter,
                    WorkerCommentBefore = order.WorkerCommentBefore,
                    WorkerCommentTimeAfter = order.WorkerCommentTimeAfter,
                    WorkerCommentTimeBefore = order.WorkerCommentTimeBefore,
                    ReporterID = order.ReporterID,
                    IsAssigned = order.IsAssigned
                };

                return this.JsonApi(result);
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
            catch (OrderException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddOrder([FromBody]AddOrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                int userId = _securityService.GetUserId(User);

                var order = new OrderDto
                {
                    Comments = request.Comments,
                    CompletionTime = request.CompletionTime,
                    Cost = request.Cost,
                    CustomerComment = request.CustomerComment,
                    CustomerCommentTime = request.CustomerCommentTime,
                    CustomerMark = request.CustomerMark,
                    CustomerPhoto = request.CustomerPhoto,
                    Description = request.Description,
                    IsAssigned = request.IsAssigned,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Measurements = request.Measurements,
                    Photo = request.Photo,
                    TimeFrom = request.TimeFrom,
                    TimeTo = request.TimeTo,
                    Title = request.Title,
                    WorkerCommentAfter = request.WorkerCommentAfter,
                    WorkerCommentBefore = request.WorkerCommentBefore,
                    WorkerCommentTimeAfter = request.WorkerCommentTimeAfter,
                    WorkerCommentTimeBefore = request.WorkerCommentTimeBefore,
                    WorkerPhotoAfter = request.WorkerPhotoAfter,
                    WorkerPhotoBefore = request.WorkerPhotoBefore,
                    WorkerID = request.WorkerID,
                    Duration = request.Duration,
                    Status = request.Status
                };

                await _orderService.AddOrderAsync(order, userId);

                return this.JsonApi();
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
        }

        [HttpPut("{id}")]
        public async Task<JsonResult> UpdateOrder(int id, [FromBody]UpdateOrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var order = new OrderDto
                {
                    ID = id,
                    Comments = request.Comments,
                    CompletionTime = request.CompletionTime,
                    Cost = request.Cost,
                    CustomerComment = request.CustomerComment,
                    CustomerCommentTime = request.CustomerCommentTime,
                    CustomerMark = request.CustomerMark,
                    CustomerPhoto = request.CustomerPhoto,
                    Description = request.Description,
                    IsAssigned = request.IsAssigned,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Measurements = request.Measurements,
                    Photo = request.Photo,
                    TimeFrom = request.TimeFrom,
                    TimeTo = request.TimeTo,
                    Title = request.Title,
                    WorkerCommentAfter = request.WorkerCommentAfter,
                    WorkerCommentBefore = request.WorkerCommentBefore,
                    WorkerCommentTimeAfter = request.WorkerCommentTimeAfter,
                    WorkerCommentTimeBefore = request.WorkerCommentTimeBefore,
                    WorkerPhotoAfter = request.WorkerPhotoAfter,
                    WorkerPhotoBefore = request.WorkerPhotoBefore,

                    WorkerID = request.WorkerID,
                    Duration = request.Duration,
                    Status = request.Status
                };

                await _orderService.UpdateOrderAsync(order);

                return this.JsonApi();
            }
            catch (SecurityException exception)
            {
                return this.JsonApi(exception);
            }
            catch (OrderException exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}
