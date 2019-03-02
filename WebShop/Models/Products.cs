using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebShop.Models
{
    public class Products
    {
        public Dictionary<string, Product> collection { get; set; }

        public Products(string path)
        {
            path = HostingEnvironment.MapPath(path);
            collection = new Dictionary<string, Product>();

            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');
                Product p = new Product(tokens[0], tokens[1], Double.Parse(tokens[2]));
                collection.Add(p.id, p);
            }
            sr.Close();
            fs.Close();
        }
    }
}