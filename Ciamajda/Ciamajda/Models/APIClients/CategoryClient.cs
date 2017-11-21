using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;
namespace Ciamajda.Models.APIClients
{
    public class CategoryClient
    {
        private string Base_URL = "http://localhost:49473/api/";

        public IEnumerable<Category> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Categories").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Category Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Categories/getCategory/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Category>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Category Category)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Categories", Category).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Category Category)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Categories/" + Category.Id, Category).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Category> GetCategoryList(string id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Categories/getCategories/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                return null;
            }
            catch
            {

              

                return null;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Categories/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
