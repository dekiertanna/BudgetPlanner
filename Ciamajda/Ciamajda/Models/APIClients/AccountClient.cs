using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;
namespace Ciamajda.Models.APIClients
{
    public class AccountClient
    {
        //localhost:49473/api/
        private string Base_URL = "http://localhost:49473/api/";

        public IEnumerable<Account> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("accounts").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Account>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Account Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("accounts/getaccount/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Account>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Account account)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("accounts", account).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Account account)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("accounts/" + account.Id, account).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Account> GetAccountList(string id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("accounts/getaccounts/"+id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Account>>().Result;
                return null;
            }
            catch
            {

                System.Diagnostics.Debug.WriteLine("This will be displayed in output window");

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
                HttpResponseMessage response = client.DeleteAsync("accounts/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }


    }
}
