using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;
namespace Ciamajda.Models.APIClients
{
    public class IncomeClient
    {
        private string Base_URL = "http://localhost:49473/api/";

        public IEnumerable<Income> FindAll(List<int> accounts)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Incomes/GetIncomes",accounts).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Income>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Income Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("incomes/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Income>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Income Income)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("incomes", Income).Result;
                System.Diagnostics.Debug.WriteLine("err");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Income Income)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("incomes/" + Income.Id, Income).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
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
                HttpResponseMessage response = client.DeleteAsync("incomes/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }


    }
}

