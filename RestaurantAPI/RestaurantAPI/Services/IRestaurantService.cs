﻿using RestaurantAPI.Models;
using System.Security.Claims;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto, int userId);
        PagedResult<RestaurantDto> GetAll(RestaurantQuery query);
        RestaurantDto GetById(int id);
        void Delete(int id, ClaimsPrincipal user);
        void Update(int id, UpdateRestaurant updateRestaurant, ClaimsPrincipal user);
    }
}