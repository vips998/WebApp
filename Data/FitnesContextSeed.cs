using Microsoft.Extensions.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using WebApp.Models;
using NuGet.Versioning;

namespace WebApp.Data
{
    public static class FitnesContextSeed
    {
        public static async Task SeedAsync(FitnesContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.Service.Any())
                {
                    return;
                }

                var coachs = new Coach[]
                {
 new Coach
 {ServiceID = 2, FIO = "Романов Александр Геннадьевич", Age = "35", Telephone = "+7(4932)269-760", Mail = "fizvos.ispu.ru"},
 new Coach
 {ServiceID = 1, FIO = "Белов Михаил Сергеевич", Age = "38", Telephone = "+7(4932)269-760", Mail = "sport.ispu.ru"},
 new Coach
 {ServiceID = 3, FIO = "Слуцкий Леонид Викторович", Age = "51", Telephone = "+7(999)999-99-99", Mail = "sluz_leon@mail.ru"},
 new Coach
 {ServiceID = 4, FIO = "Майк Тайсон", Age = "56", Telephone = "+7(545)555-55-55", Mail = "make_tyson@mail.ru"},
  new Coach
 {ServiceID = 5, FIO = "Брюс Ли", Age = "45", Telephone = "+7(912)444-44-44", Mail = "bruce_lee@mail.ru"},
            };
                foreach (Coach k in coachs)
                {
                    context.Coach.Add(k);
                }
                await context.SaveChangesAsync();

                var services = new Service[]
                {
 new Service{CoachID = 2, Name = "Фитнес", Price = 1000, Description = "Поможет держать своё тело в тонусе"},
 new Service{CoachID = 1, Name = "Тренажёрный зал", Price = 2000, Description = "Для любителей позаниматься с железом"},
 new Service{CoachID = 3, Name = "Бассейн", Price = 1500, Description = "Если нужно развить навыки плавания"},
 new Service{CoachID = 4, Name = "Бокс", Price = 1200, Description = "Помогает побороть стресс, страх, обрести силу воли"},
 new Service{CoachID = 5, Name = "Карате", Price = 1800, Description = "Развивает выносливость и мускулатуру"}
                };
                foreach (Service b in services)
                {
                    context.Service.Add(b);
                }
                await context.SaveChangesAsync();



                /*var users = new User[]
                {
 new User { FIO = "Карпов Владислав Дмитриевич", Birthday = new DateTime(2002,07,20), Age = "20" , Mail = "vips998@mail.ru",
     Passport = "3416201066", Telephone = "+7(962)189-28-71", Balance = 5000},
 new User
 {FIO = "Замыцкий Илья Сергеевич", Birthday = new DateTime(2002,08,02), Age = "20" , Mail = "zam_ilia@mail.ru",
     Passport = "3416200666", Telephone = "+7(800)555-35-35", Balance = 10000},
 new User
 {FIO = "Комаров Валерий Александрович", Birthday = new DateTime(2002,06,22), Age = "20" , Mail = "kom_valer@mail.ru",
     Passport = "3410111111", Telephone = "+7(843)645-83-23", Balance = 8000},
 new User
 {FIO = "Михайлов Елисей Иванович", Birthday = new DateTime(2002,08,14), Age = "20" , Mail = "mich_el@mail.ru",
     Passport = "3412123321", Telephone = "+7(952)812-10-01", Balance = 6000},
 new User
 {FIO = "Иванов Дмитрий Сергеевич", Birthday = new DateTime(2002,10,01), Age = "20" , Mail = "ivanov_d@mail.ru",
     Passport = "3419599732", Telephone = "+7(941)410-05-60", Balance = 9000}
            };
                foreach (User p in users)
                {
                    context.User.Add(p);
                }
                await context.SaveChangesAsync();*/

/*
                var records = new Record[]
     {
 new Record
 { ServiceID = 1, UserID = 1, Date = new DateTime(2023,01,01), Price = 2000},
 new Record
 { ServiceID = 2, UserID = 2, Date = new DateTime(2023,02,01), Price = 1000},
 new Record
 { ServiceID = 3, UserID = 3, Date = new DateTime(2023,03,01), Price = 1500},
 new Record
 { ServiceID = 4, UserID = 4, Date = new DateTime(2023,05,01), Price = 1200},
  new Record
 { ServiceID = 5, UserID = 5, Date = new DateTime(2023,02,01), Price = 1800}
 };
                foreach (Record g in records)
                {
                    context.Records.Add(g);
                }
                await context.SaveChangesAsync();*/

            }
            catch
            {
                throw;
            }
        }
    }
}

