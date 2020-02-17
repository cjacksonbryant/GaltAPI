using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace GaltAPI.Controllers
{
    public class results
    {
        public string pharmacyName { get; set; }
        public string pharmacyAddress { get; set; }
        public string pharmacyCategory { get; set; }

        public string error { get; set; }

        public results(string pharmacyName, string pharmacyAddress, string pharmacyCategory, string error)
        {
            
            this.pharmacyName = pharmacyName;
            this.pharmacyAddress = pharmacyAddress;
            this.pharmacyCategory = pharmacyCategory;
            this.error = error;
        }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<results> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT pharmacyName, pharmacyAddress, pharmacyCategory FROM locations";

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["pharmacyName"].ToString(), fetch_query["pharmacyAddress"].ToString(), fetch_query["pharmacyCategory"].ToString(), null));
            }

            return results;
        }

        // GET api/values/56
        public List<results> Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT pharmacyName, pharmacyAddress, pharmacyCategory FROM locations WHERE id = @id";

            query.Parameters.AddWithValue("@id", id);

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["pharmacyName"].ToString(), fetch_query["pharmacyAddress"].ToString(), fetch_query["pharmacyCategory"].ToString(), null));
            }

            return results;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            
        }
    }
}
