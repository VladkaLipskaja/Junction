﻿//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Space Rabbits">
//     Copyright (c) Space Rabbits. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using STARAAPP.Entities;
using STARAAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace STARAAPP.Services
{
    public interface IOrderService
    {
        Task AddOrderAsync(OrderDto order, int reporterId);
        Task UpdateOrderAsync(OrderDto order);
        Task<Order> GetOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersAsync(int userId);
    }
}
