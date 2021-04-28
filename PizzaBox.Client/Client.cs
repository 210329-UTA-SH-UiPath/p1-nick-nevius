using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBox.Client
{
    public class Client
    {
        private readonly string url = "https://localhost:44330/api/";

        public Client()
        {
        }

        public IEnumerable<Models.Pizza> GetAllPizzas()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Pizza");
            response.Wait();

            var result = response.Result;// this holds the output

            if (result.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<Models.Pizza[]>();
                var readStr = result.Content.ReadAsStringAsync();
                readStr.Wait();

                var deserialized = JsonConvert.DeserializeObject<Models.Pizza[]>(readStr.Result);
                

                //var superHeroes = readTask.Result;
                return deserialized;
            }
                
            return null;
        }

        public IEnumerable<Models.Customer> GetAllCustomers()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Customer");
            response.Wait();

            var result = response.Result;// this holds the output

            if (result.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<Models.Pizza[]>();
                var readStr = result.Content.ReadAsStringAsync();
                readStr.Wait();

                var deserialized = JsonConvert.DeserializeObject<Models.Customer[]>(readStr.Result);


                //var superHeroes = readTask.Result;
                return deserialized;
            }

            return null;
        }

        public IEnumerable<Models.Order> GetAllOrders()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Order");
            response.Wait();

            var result = response.Result;// this holds the output

            if (result.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<Models.Pizza[]>();
                var readStr = result.Content.ReadAsStringAsync();
                readStr.Wait();

                var deserialized = JsonConvert.DeserializeObject<Models.Order[]>(readStr.Result);


                //var superHeroes = readTask.Result;
                return deserialized;
            }

            return null;
        }

        public IEnumerable<Models.Store> GetAllStores()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Store");
            response.Wait();

            var result = response.Result;// this holds the output

            if (result.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<Models.Pizza[]>();
                var readStr = result.Content.ReadAsStringAsync();
                readStr.Wait();

                var deserialized = JsonConvert.DeserializeObject<Models.Store[]>(readStr.Result);


                //var superHeroes = readTask.Result;
                return deserialized;
            }

            return null;
        }

    }
}
