using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Medlware
{
    class Program
    {
        public static List<Func<RequestDelegate, RequestDelegate>> _list = new List<Func<RequestDelegate, RequestDelegate>>();
        static void Main(string[] args)
        {

            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("1");
                    return next.Invoke(context);
                };
            });


            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("2");
                    return next.Invoke(context);
                };
            });

            RequestDelegate end = (context) =>
            {
                Console.WriteLine("end...");
                return Task.CompletedTask;
            };

            foreach (var middleware in _list)
            {
                end = middleware.Invoke(end);
            }


            end.Invoke(new Context());


        }

        public static void Use(Func<RequestDelegate, RequestDelegate> middlware)
        {
            _list.Add(middlware);
        }
    }
}
