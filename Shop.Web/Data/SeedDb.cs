

namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDb
    {

        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly UserManager<User> userManager;
        private Random random;
        // seedb se le inyecta la conexion a la base de datos
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            // findbyemail busqueme si ya hay un usuario
            var user = await this.userHelper.GetUserByEmailAsync("antony_esnaider_11@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Antony",
                    LastName = "Ancajima",
                    Email = "antony_esnaider_11@hotmail.com",
                    UserName = "antony_esnaider_11@hotmail.com",
                    PhoneNumber = "963604498"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X",user);
                this.AddProduct("Magic mouse",user);
                this.AddProduct("iWatch series 4",user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name,User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user

            });
        }


    }
}
