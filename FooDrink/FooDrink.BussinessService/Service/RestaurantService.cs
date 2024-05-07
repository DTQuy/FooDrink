using FooDrink.BusinessService.Interface;
using FooDrink.Database.Models;
using FooDrink.DTO.Request.Restaurant;
using FooDrink.DTO.Response.Restaurant;
using FooDrink.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FooDrink.BusinessService.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<RestaurantGetListResponse>> GetRestaurantsAsync(RestaurantGetListRequest request)
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync(request);
            var responseList = new List<RestaurantGetListResponse>();
            foreach (var restaurant in restaurants)
            {
                responseList.Add(new RestaurantGetListResponse
                {
                    RestaurantName = restaurant.RestaurantName,
                    Latitude = restaurant.Latitude,
                    Longitude = restaurant.Longitude,
                    Address = restaurant.Address,
                    City = restaurant.City,
                    Country = restaurant.Country,
                    Hotline = restaurant.Hotline,
                    AverageRating = restaurant.AverageRating
                });
            }
            return responseList;
        }

        public async Task<RestaurantGetByIdResponse> GetRestaurantByIdAsync(RestaurantGetByIdRequest request)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                return null;
            }
            return new RestaurantGetByIdResponse
            {
                RestaurantName = restaurant.RestaurantName,
                Latitude = restaurant.Latitude,
                Longitude = restaurant.Longitude,
                Address = restaurant.Address,
                City = restaurant.City,
                Country = restaurant.Country,
                Hotline = restaurant.Hotline,
                AverageRating = restaurant.AverageRating
            };
        }

        public async Task<bool> DeleteRestaurantByIdAsync(Guid id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return false;
            }
            restaurant.Status = true;
            var result = await _restaurantRepository.EditAsync(restaurant);
            return result;
        }

        public async Task<RestaurantAddResponse> AddRestaurantAsync(RestaurantAddRequest request)
        {
            var restaurant = new Restaurant
            {
                Id = Guid.NewGuid(),
                RestaurantName = request.RestaurantName,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                Hotline = request.Hotline,
                Status = false,
                CreatedBy = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = null,
                UpdatedAt = DateTime.UtcNow,

            };
            var addedRestaurant = await _restaurantRepository.AddAsync(restaurant);
            return new RestaurantAddResponse
            {
                Id = addedRestaurant.Id.ToString(),
                RestaurantName = addedRestaurant.RestaurantName,
                Latitude = addedRestaurant.Latitude,
                Longitude = addedRestaurant.Longitude,
                Address = addedRestaurant.Address,
                City = addedRestaurant.City,
                Country = addedRestaurant.Country,
                Hotline = addedRestaurant.Hotline,
                AverageRating = addedRestaurant.AverageRating,
                ImageList = addedRestaurant.ImageList,
                TotalRevenue = addedRestaurant.TotalRevenue,
                DailyRevenue = addedRestaurant.DailyRevenue,
                MonthlyRevenue = addedRestaurant.MonthlyRevenue
            };
        }

        public async Task<RestaurantUpdateResponse> UpdateRestaurantAsync(RestaurantUpdateRequest request)
        {
            var existingRestaurant = await _restaurantRepository.GetByIdAsync(request.Id);
            if (existingRestaurant == null)
            {
                return null;
            }

            existingRestaurant.RestaurantName = request.RestaurantName;
            existingRestaurant.Latitude = request.Latitude;
            existingRestaurant.Longitude = request.Longitude;
            existingRestaurant.Address = request.Address;
            existingRestaurant.City = request.City;
            existingRestaurant.Country = request.Country;
            existingRestaurant.Hotline = request.Hotline;

            var isEdited = await _restaurantRepository.EditAsync(existingRestaurant);
            if (!isEdited)
            {
                return null;
            }

            return new RestaurantUpdateResponse
            {
                Id = existingRestaurant.Id,
                RestaurantName = existingRestaurant.RestaurantName,
                Latitude = existingRestaurant.Latitude,
                Longitude = existingRestaurant.Longitude,
                Address = existingRestaurant.Address,
                City = existingRestaurant.City,
                Country = existingRestaurant.Country,
                Hotline = existingRestaurant.Hotline
            };
        }
    }
}
