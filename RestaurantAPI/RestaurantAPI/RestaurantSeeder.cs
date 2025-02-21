using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();

                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();

                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role() { Name = "User" },
                new Role() { Name = "Manager" },
                new Role() { Name = "Admin" }
            };

            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC is an American fast food restaurant...",
                    ContactEmail = "contact@kfc.com",
                    ContactNumber = "123",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Description = "Description...",
                            Price = 10.30m
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Description = "Description...",
                            Price = 5.30m
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "McDonald is an American fast food restaurant...",
                    ContactEmail = "contact@mcdonald.com",
                    ContactNumber = "111",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Hamburger",
                            Description = "Description...",
                            Price = 6.90m
                        },
                        new Dish()
                        {
                            Name = "Cheaps",
                            Description = "Description...",
                            Price = 5.10m
                        },
                    },
                    Address = new Address()
                    {
                        City = "Wrocław",
                        Street = "Arctowskiego 12",
                        PostalCode = "35-661"
                    }
                }
            };

            return restaurants;
        }
    }
}
