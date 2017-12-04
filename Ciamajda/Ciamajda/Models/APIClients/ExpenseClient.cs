using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;
namespace Ciamajda.Models.APIClients
{
    public class ExpenseClient
    {
        private string Base_URL = "http://localhost:49473/api/";

        public IEnumerable<Expense> FindAll(List<int> accounts)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Expenses/GetExpenses", accounts).Result;




                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Expense>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Expense Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("expenses/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Expense>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Expense expense)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("expenses", expense).Result;
                System.Diagnostics.Debug.WriteLine("err");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Expense expense)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("expenses/" + expense.Id, expense).Result;
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
                HttpResponseMessage response = client.DeleteAsync("expenses/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    
    }
}

