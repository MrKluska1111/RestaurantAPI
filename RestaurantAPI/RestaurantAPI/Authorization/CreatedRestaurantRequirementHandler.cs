using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using System.Security.Claims;

namespace RestaurantAPI.Authorization
{
    public class CreatedRestaurantRequirementHandler : AuthorizationHandler<CreatedRestaurantsRequirement>
    {
        private RestaurantDbContext _dbContext;

        public CreatedRestaurantRequirementHandler(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedRestaurantsRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var createdRestaurant = _dbContext
                .Restaurants
                .Count(r => r.CreatedById == userId);

            if(createdRestaurant < requirement.MinimumRestaurantsCreated)
            {
                throw new ForbidException();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
