using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;
namespace Ciamajda.Models.APIClients
{
    public class PlaceClient
    {
        private string Base_URL = "http://localhost:49473/api/";

        public IEnumerable<Place> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Places").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Place>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Place Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Places/getPlace/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Place>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Place Place)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Places", Place).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Place Place)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Places/" + Place.Id, Place).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Place> GetPlaceList(string id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(Base_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Places/getPlaces/" + id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Place>>().Result;
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
                HttpResponseMessage response = client.DeleteAsync("Places/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
