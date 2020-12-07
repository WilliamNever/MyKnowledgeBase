using ConsoleForDNetFrameWork.DBModels;
using ConsoleForDNetFrameWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForDNetFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            DoContextTest();
            //ObjectCastTest();
            //MapperTest();
            //KeyValuePairTest();

            //OutPutTEST();

            EndInfor();
        }

        private static void OutPutTEST()
        {
            Console.WriteLine(System.Web.HttpUtility.HtmlEncode("  "));
            Console.WriteLine(System.Web.HttpUtility.UrlEncode("  "));
            Console.WriteLine(System.Web.HttpUtility.UrlPathEncode("  "));

            string[] tests = new string[] { "aa", "b b", "c c", "dd" };
            string cont = "ids=" + string.Join("&ids=", tests.Select(x => System.Web.HttpUtility.UrlPathEncode(x)));
            Console.WriteLine(cont);
        }

        private static void KeyValuePairTest()
        {
            KeyValuePair<string, int> atc;

            Console.WriteLine("nothing");
        }

        private static void MapperTest()
        {
            Func<string, int> SToInt = str => {
                return int.TryParse(str, out int tmp) ? 0 : tmp;
            };

            AutoMapper.MapperConfiguration cfg = new AutoMapper.MapperConfiguration(
                x =>
                {
                    x.CreateMap<InfModelsStuffFrom, InfModelsStuffTo>()
                    .ForMember(dest => dest.Age, m => m.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Age))
                    .ForMember(dest => dest.OtherMemo, m => m.MapFrom(src => SToInt(src.OtherMemo)))
                    .ReverseMap()
                    ;
                    //x.CreateMap<InfModelsStuffTo, InfModelsStuffFrom>()
                    //;
                }
                );

            InfModelsStuffFrom aa = new InfModelsStuffFrom
            {
                FirstName = "aa",
                Id = 19,
                Age = 33,
                OtherMemo = "To Memo something."
            };

            InfModelsStuffTo bb = cfg.CreateMapper().Map<InfModelsStuffTo>(aa);
            //var cc = aa;
            //bb.Id += 10;
            //cc.Id++;

            InfModelsStuffFrom dd = cfg.CreateMapper().Map<InfModelsStuffFrom>(aa);
            InfModelsStuffFrom ee = cfg.CreateMapper().Map<InfModelsStuffFrom>(bb);
        }

        private static void ObjectCastTest()
        {
            object rInfor = null;
            RInfor infor = rInfor as RInfor;
            Console.WriteLine(infor == null);
        }

        private static void DoContextTest()
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnString"].ConnectionString;
            Console.WriteLine(conn);

            //DBCTXTContextTest(conn, 0, 20);
            //Console.WriteLine("---------------------------------------------------------");
            //AddRInfor(new RInfor
            //{
            //    Author = "RAuthor",
            //    BookName = "Advanced C# for .Net Core - 5 For Version 5",
            //    Briefs = "Briefs.....",
            //    IsRented = true,
            //    RentDate = DateTime.Now,
            //    UserID = 5
            //}, conn);
            //AddingAddresses(conn);
            DBCTestForRInfor(conn, UsID: 1, UserName: "UsDBC5");
        }

        private static void AddingAddresses(string conn)
        {
            DBCTXTContext dbc = new DBCTXTContext(conn);
            var addr = new Addresses
            {
                AddIdentity = Guid.NewGuid(),
                Addr = "addr Address",
                Email = "ae@email.com",
                Phone = "12345678901",
                UserId = 1
            };
            dbc.Addresses.Add(addr);
            dbc.SaveChanges();
            Console.WriteLine($"New Address id is {addr.Id}");
        }

        private static void DBCTestForRInfor(string connString, int UsID = 0, string UserName = "")
        {
            DBCTXTContext dbc = new DBCTXTContext(connString);
            UserInfors auser;

            //if (UsID > 0)
            //{
                Console.WriteLine($"** Use UsID = {UsID} **");
            var users = dbc.UserInfors.Include(e => e.RentInfors).ThenInclude(de => de.RtDetails).Include(e => e.Addresses)
                .ToListAsync().Result;
                    //.FirstOrDefault(x => x.Id == UsID);
            Console.WriteLine(users[0].RentInfors.Count);
            Console.WriteLine(users[0].RentInfors.ToList()[0].User.Password);
            //}
            //else
            //{
            //    Console.WriteLine($"** Use UserName = {UserName} **");
            //    auser = dbc.UserInfors.Include(e => e.RentInfors).Include(e => e.Addresses)
            //        .FirstOrDefault(x => x.UserName.Equals(UserName));
            //}
            /*
            if (auser != null)
            {
                Console.Write($"{auser.Id} | {auser.UserName} | {auser.Password} | ");
                Console.Write($"{auser.LastName} | {auser.FirstName} | ");
                Console.Write($"{auser.LoginDate} | ");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------");

                var usRentInfor = auser.RentInfors;
                var usAddresses = auser.Addresses;
                if (usRentInfor != null)
                {
                    foreach (var rent in usRentInfor)
                    {
                        Console.Write($"{rent.ID} | {auser.UserName}/{rent.UserID} | {rent.BookName} | {rent.Author} | ");
                        Console.Write($"{rent.Briefs} | {rent.IsRented} | {rent.RentDate} | ");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("---------------------------------------------------------");
                if (usAddresses != null)
                {
                    foreach (var addr in usAddresses)
                    {
                        Console.Write($"{addr.Id} | {auser.UserName}/{addr.UserId} | {addr.Email} | ");
                        Console.Write($"{addr.Addr} | {addr.Phone} | {addr.AddIdentity} | ");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("---------------------------------------------------------");
            }
            */
            //var addr = dbc.Addresses.Include(e => e.User).FirstOrDefault(x => x.Id == 1);
            //var us = addr.User;
        }

        private static void AddRInfor(RInfor rInfor, string connString)
        {
            DBCTXTContext dbc = new DBCTXTContext(connString);
            dbc.RentInfors.Add(rInfor);
            dbc.SaveChanges();
        }

        private static void DBCTXTContextTest(string connString, int page, int pageSize)
        {
            Console.WriteLine();
            DBCTXTContext dbc = new DBCTXTContext(connString);
            var num = dbc.UserInfors.Count();
            Console.WriteLine($"ALL Records is {num}");

            #region adding user and rinfor and addresses
            /*

            int sequenceID = 13;

            var user = new UserInfors
            {
                FirstName = "dbc",
                LastName = "last dbc",
                LoginDate = DateTime.Now,
                Password = "pwd dbc",
                UserName = $"UsDBC{sequenceID}",
                Addresses = new List<Addresses> {
                    new Addresses
                        {
                            //AddIdentity = Guid.NewGuid(),
                            Addr = $"addr Address 1 - {sequenceID}",
                            Email = "ae@email.com",
                            Phone = "12345678901",
                        },
                    new Addresses
                        {
                            //AddIdentity = Guid.NewGuid(),
                            Addr = $"addr Address 2 - {sequenceID}",
                            Email = "ae@email.com",
                            Phone = "12345678901",
                        }
                    ,
                    new Addresses
                        {
                            //AddIdentity = Guid.NewGuid(),
                            Addr = $"addr Address 3 - {sequenceID}",
                            Email = "ae@email.com",
                            Phone = "12345678901",
                        }
                },
                RentInfors = new List<RInfor> {
                    new RInfor
                    {
                        Author = "RAuthor",
                        BookName = $"Advanced C# for .Net Core - 1 / {sequenceID}",
                        Briefs = "Briefs.....",
                        IsRented = true,
                        RentDate = DateTime.Now,
                    }
                    ,
                    new RInfor
                    {
                        Author = "RAuthor",
                        BookName = $"Advanced C# for .Net Core - 2 / {sequenceID}",
                        Briefs = "Briefs.....",
                        IsRented = true,
                        RentDate = DateTime.Now,
                    }
                    ,
                    new RInfor
                    {
                        Author = "RAuthor",
                        BookName = $"Advanced C# for .Net Core - 3 / {sequenceID}",
                        Briefs = "Briefs.....",
                        IsRented = true,
                        RentDate = DateTime.Now,
                    }
                }
            };
            dbc.UserInfors.Add(user);
            dbc.SaveChanges();
            Console.WriteLine($"***************New UserID is {user.Id}");

            DBCTestForRInfor(connString, UsID: user.Id, UserName: user.UserName);

            //*/
            #endregion

            var users = dbc.UserInfors
                /*
                .FromSql("select * from UserInfors where id>@p1", new SqlParameter[] {
                new SqlParameter {
                    ParameterName ="@p1",
                    Value=15,
                    DbType= System.Data.DbType.Int32
                }
            })*/
                .Skip((page > 0 ? page - 1 : 0) * pageSize).Take(pageSize);
            foreach (var auser in users)
            {
                Console.Write($"{auser.Id} | {auser.UserName} | {auser.Password} | ");
                Console.Write($"{auser.LastName} | {auser.FirstName} | ");
                Console.Write($"{auser.LoginDate} | ");
                Console.WriteLine();
            }

            //num = dbc.UserInfors.Count();
            //Console.WriteLine(num);
        }


        private static void EndInfor()
        {
            Console.WriteLine();
            Console.WriteLine($"Any key to exit......");
            Console.ReadKey();
        }
    }
}
