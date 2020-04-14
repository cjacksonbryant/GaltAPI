using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace companyAPI
{
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            string conn_string = "server=chiefrxinstance-us-east-1b.cua0xdfndykf.us-east-1.rds.amazonaws.com;port=3306;database=chiefrxdatabase;username=capstoneUser1;password=Ro11T!de";

            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "ActionAPI",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
