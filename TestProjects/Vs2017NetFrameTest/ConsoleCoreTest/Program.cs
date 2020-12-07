using ConsoleCoreTest.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ConsoleCoreTest
{
    class Program
    {
        private static IServiceCollection services;
        static Program()
        {
            services = new ServiceCollection();
            services.AddDbContext<DBCTXTContext>(
                options =>
                {
                    options.UseSqlServer("No Connection String");
                }
                );
        }
        static void Main(string[] args)
        {
            //Test1();
            Test2();

            EndInfor();
        }

        private static void Test2()
        {
            var dbContext1 = services.BuildServiceProvider().GetRequiredService<DBCTXTContext>();
            var dbContext2 = services.BuildServiceProvider().GetRequiredService<DBCTXTContext>();
            var dbContext3 = services.BuildServiceProvider().GetRequiredService<DBCTXTContext>();
            var dbContext4 = services.BuildServiceProvider().GetRequiredService<DBCTXTContext>();
            var dbContext5 = services.BuildServiceProvider().GetRequiredService<DBCTXTContext>();
        }

        private static void Test1()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("APP.json");

            var config = builder.Build();

            //读取配置
            Console.WriteLine(config["ConnetionString:name"]);
            Console.WriteLine(config["ConnetionString:value"]);
            //DBCTXTContextTest(config, 0, 20);
        }

/*
        private static void DBCTXTContextTest(IConfigurationRoot config, int page, int pageSize)
        {
            Console.WriteLine();
            DBCTXTContext dbc = new DBCTXTContext(config["ConnetionString:value"]);

            var num = dbc.UserInfors.Count();
            Console.WriteLine($"ALL Records is {num}");

            //var user = new UserInfors
            //{
            //    FirstName = "dbc",
            //    LastName = "last dbc",
            //    LoginDate = DateTime.Now,
            //    Password = "pwd dbc",
            //    UserName = "UsDBC3"
            //};
            //dbc.UserInfors.Add(user);
            //dbc.SaveChanges();
            //Console.WriteLine($"New UserID is {user.Id}");

            var users = dbc.UserInfors.Skip((page > 0 ? page - 1 : 0) * pageSize).Take(pageSize);
            foreach (var user in users)
            {
                Console.Write($"{user.Id} | {user.UserName} | {user.Password} | ");
                Console.Write($"{user.LastName} | {user.FirstName} | ");
                Console.Write($"{user.LoginDate} | ");
                Console.WriteLine();
            }

            //num = dbc.UserInfors.Count();
            //Console.WriteLine(num);
        }
*/

        private static void EndInfor()
        {
            Console.WriteLine();
            Console.WriteLine($"Any key to exit......");
            Console.ReadKey();
        }
    }
}
