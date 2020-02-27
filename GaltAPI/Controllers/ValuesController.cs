using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace companyAPI.Controllers
{
    public class results
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string addressType { get; set; }
        public string error { get; set; }

        public results(string addressLine1, string addressLine2, string city, string state, string zip, string addressType, string error)
        {
            
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.addressType = addressType;
        }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<results> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT * FROM Address";

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["addressLine1"].ToString(), fetch_query["addressLine2"].ToString(), fetch_query["city"].ToString(), fetch_query["state"].ToString(), fetch_query["zip"].ToString(), fetch_query["addressType"].ToString(), null));
            }

            return results;
        }

        // GET api/values/56
        public List<results> Get(int pharmacyID)
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT addressLine1, addressLine2, city, state, zip, addressType FROM Address WHERE pharmacyID = @pharmacyID";

            query.Parameters.AddWithValue("@pharmacyID", pharmacyID);

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["addressLine1"].ToString(), fetch_query["addressLine2"].ToString(), fetch_query["city"].ToString(), fetch_query["state"].ToString(), fetch_query["zip"].ToString(), fetch_query["addressType"].ToString(), null));
            }

            return results;
        }

        // POST api/values
       /* [System.Web.Http.HttpPost]
        public void Post([FromBody]string pharmacyName, string pharmacyAddress, string pharmacyCategory)
        {

            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "INSERT INTO locations (pharmacyName, pharmacyAddress, pharmacyCategory) VALUES (@pharmacyName, @pharmacyAddress, @pharmacyCategory)";

            query.Parameters.AddWithValue("@pharmacyName", pharmacyName);
            query.Parameters.AddWithValue("@pharmacyAddress", pharmacyAddress);
            query.Parameters.AddWithValue("@pharmacyCategory", pharmacyCategory);


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


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string pharmacyName, string pharmacyAddress, string pharmacyCategory)
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "DELET pharmacyName, pharmacyAddress, pharmacyCategory FROM locations WHERE id = @id";

            query.Parameters.AddWithValue("@id", id);
            query.Parameters.AddWithValue("@pharmacyName", pharmacyName);
            query.Parameters.AddWithValue("@pharmacyAddress", pharmacyAddress);
            query.Parameters.AddWithValue("@pharmacyCategory", pharmacyCategory);

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

        }

        // DELETE api/values/5
        [System.Web.Http.HttpDelete]
        public void Delete(int id, string pharmacyName, string pharmacyAddress, string pharmacyCategory)
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "DELETE pharmacyName, pharmacyAddress, pharmacyCategory FROM locations WHERE id = @id";

            query.Parameters.AddWithValue("@id", id);
            query.Parameters.AddWithValue("@pharmacyName", pharmacyName);
            query.Parameters.AddWithValue("@pharmacyAddress", pharmacyAddress);
            query.Parameters.AddWithValue("@pharmacyCategory", pharmacyCategory);

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

           
        } */
    }
}
