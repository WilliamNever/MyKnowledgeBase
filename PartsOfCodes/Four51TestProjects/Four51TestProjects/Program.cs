using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesFromFour51.SRFour51Product;
using ServicesFromFour51.WRFour51Product;
using System.Configuration;
using System.Net;

namespace Four51TestProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //  ??  To restrict the security protocol   ??
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            /**/
            ProductSoapClient srp =
                new ProductSoapClient("ProductSoap", System.Configuration.ConfigurationManager.AppSettings["ProductServiceURL"])
                ;
            var prArrays = srp.SearchVariantsByProduct((new ArrayOfString { "1" }), ConfigurationManager.AppSettings["SharedSecret"]);
            //var bding = srp.Endpoint.Binding;
            srp.Close();
            

            /*
            Product wrp = new Product();
            //wrp.Timeout = 1200000;
            wrp.Url = System.Configuration.ConfigurationManager.AppSettings["ProductServiceURL"];
            var prArrays = wrp
                //.ListProducts(ConfigurationManager.AppSettings["SharedSecret"]);
                .SearchVariantsByProduct(new string[] { }, ConfigurationManager.AppSettings["SharedSecret"]);
            */

            Console.WriteLine(prArrays.Length);
            
            Console.ReadLine();
        }
    }
}
