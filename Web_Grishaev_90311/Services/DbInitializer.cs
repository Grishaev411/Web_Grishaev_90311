using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabsV05.DAL.Data;
using WebLabsV05.DAL.Entities;

namespace Web_Grishaev_90311.Services
{
    public class DbInitializer
    {
       
public static async Task Seed(ApplicationDbContext context,
          UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager)
        {
            //проверка наличия групп объектов 
            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
new DishGroup {GroupName="Стартеры"},
new DishGroup {GroupName="Салаты"},
new DishGroup { GroupName = "Супы" },
new DishGroup { GroupName = "Основные блюда" },
new DishGroup { GroupName = "Напитки" },
new DishGroup { GroupName = "Десерты" }
                });
                await context.SaveChangesAsync();
            }

            // проверка наличия объектов 
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                    new Dish {DishName="Суп-харчо",
                    Description="Очень острый, супер вкусный",
                    Calories =200, DishGroupId=3, Image="Суп.jpg" },
                    new Dish {DishName="Борщ",
                    Description="Много мяса и сметаны",
                    Calories =330, DishGroupId=3, Image="Борщ.jpg" },
                    new Dish {DishName="Котлета пожарская", Description="Мясо - 80%, Морковь - 20%",
                    Calories =635, DishGroupId=4, Image="Котлета.jpg" }, 
                    new Dish {DishName="Макароны по-флотски", Description="С сыром",
                    Calories =524, DishGroupId=4, Image="Макароны.jpg" }, 
                    new Dish {DishName="Компот",
                    Description="Клубничный быстро растворимый, 2 литра",
                    Calories =180, DishGroupId=5, Image="Компот.jpg" }
                });
                await context.SaveChangesAsync();
            }
            // создать БД, если она еще не создана 

            context.Database.EnsureCreated();
            // проверка наличия ролей 
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }

            // проверка наличия пользователей 
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru 
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru"); await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
    


