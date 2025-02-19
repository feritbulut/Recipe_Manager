using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Utilities
{
    public class Client
    {
        public const string BaseImageURL = "https://www.themealdb.com/images/ingredients/";
        public const string BaseApiURL = "https://www.themealdb.com/api/json/v2/1/";

        public static HttpClient Generate
        {
            get
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(BaseApiURL);


                return client;
            }
        }
    }
}
