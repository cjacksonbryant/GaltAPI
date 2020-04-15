using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace companyAPI.Controllers
{
    // Pharmacy results object
    public class results
    {
        public string PharmacyName { get; set; }
        public string PharmacyType { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string AddressType { get; set; }
        public string Number { get; set; }
        public string WebsiteURL { get; set; }

        public results(string PharmacyName, string PharmacyType, string StreetAddressLine1, string StreetAddressLine2, string City, string State, string Zip, string AddressType, string Number, string WebsiteURL, string error)
        {
            
            this.PharmacyName = PharmacyName;
            this.PharmacyType = PharmacyType;
            this.StreetAddressLine1 = StreetAddressLine1;
            this.StreetAddressLine2 = StreetAddressLine2;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            this.AddressType = AddressType;
            this.Number = Number;
            this.WebsiteURL = WebsiteURL;
        }
    }
    public class ValuesController : ApiController
    {
        // GET api/values/
        [HttpGet]
        [Route("api/values")]
        // Query that populates all pharmacy location markers and pharmacy information
        // GET api/values
        public List<results> Get()
        // Get all pharmacy information
        {
            // Opens MySQL Connection
            MySqlConnection conn = WebApiConfig.conn();

            // Enables command entry and creates a new command object
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT p.PharmacyName, p.PharmacyType, c.StreetAddressLine1, c.StreetAddressLine2, c.City, c.State, c.Zip, c.AddressType, c2.`Number`, p.WebsiteURL FROM Pharmacies p, CapstoneTable1 c, CapstoneTable2 c2 WHERE p.PharmacyID = c.PharmacyID AND p.PharmacyID = c2.PharmacyID AND c.AddressType = 'Physical Address' AND c2.NumberType = 'Phone Number';";

            // Enters results into a list
            var results = new List<results>();

            // Error handling for unestablished connection to database
            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, null, null, null, null, null, null, null, ex.ToString()));
            }

            // Reads data
            MySqlDataReader fetch_query = query.ExecuteReader();

            // Adds data to 'results' list
            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["PharmacyName"].ToString(), fetch_query["PharmacyType"].ToString(), fetch_query["StreetAddressLine1"].ToString(), fetch_query["StreetAddressLine2"].ToString(), fetch_query["City"].ToString(), fetch_query["State"].ToString(), fetch_query["Zip"].ToString(), fetch_query["AddressType"].ToString(), fetch_query["Number"].ToString(), fetch_query["WebsiteURL"].ToString(),null));
            }

            // Results object is returned with all necessary values
            return results;
        }
        // GET/api/values/direct
        [HttpGet]
        [Route("api/values/direct")]
        public List<results> GetGaltDirect()
        // Get all pharmacy information
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT p.PharmacyName, p.PharmacyType, c.StreetAddressLine1, c.StreetAddressLine2, c.City, c.State, c.Zip, c.AddressType, c2.`Number`, p.WebsiteURL FROM Pharmacies p, CapstoneTable1 c, CapstoneTable2 c2 WHERE p.PharmacyID = c.PharmacyID AND p.PharmacyID = c2.PharmacyID AND c.AddressType = 'Physical Address' AND c2.NumberType = 'Phone Number' AND p.PharmacyType = 'Galt Direct';";

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["PharmacyName"].ToString(), fetch_query["PharmacyType"].ToString(), fetch_query["StreetAddressLine1"].ToString(), fetch_query["StreetAddressLine2"].ToString(), fetch_query["City"].ToString(), fetch_query["State"].ToString(), fetch_query["Zip"].ToString(), fetch_query["AddressType"].ToString(), fetch_query["Number"].ToString(), fetch_query["WebsiteURL"].ToString(), null));
            }

            return results;
        }
        // GET/api/values/hub
        [HttpGet]
        [Route("api/values/hub")]
        public List<results> GetHub()
        // Get all pharmacy information
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT p.PharmacyName, p.PharmacyType, c.StreetAddressLine1, c.StreetAddressLine2, c.City, c.State, c.Zip, c.AddressType, c2.`Number`, p.WebsiteURL FROM Pharmacies p, CapstoneTable1 c, CapstoneTable2 c2 WHERE p.PharmacyID = c.PharmacyID AND p.PharmacyID = c2.PharmacyID AND c.AddressType = 'Physical Address' AND c2.NumberType = 'Phone Number' AND p.PharmacyType = 'Hub';";

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["PharmacyName"].ToString(), fetch_query["PharmacyType"].ToString(), fetch_query["StreetAddressLine1"].ToString(), fetch_query["StreetAddressLine2"].ToString(), fetch_query["City"].ToString(), fetch_query["State"].ToString(), fetch_query["Zip"].ToString(), fetch_query["AddressType"].ToString(), fetch_query["Number"].ToString(), fetch_query["WebsiteURL"].ToString(), null));
            }

            return results;
        }
        //GET/api/values/partner
        [HttpGet]
        [Route("api/values/partner")]
        public List<results> GetPartnerPharmacy()
        // Get all pharmacy information
        {
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT p.PharmacyName, p.PharmacyType, c.StreetAddressLine1, c.StreetAddressLine2, c.City, c.State, c.Zip, c.AddressType, c2.`Number`, p.WebsiteURL FROM Pharmacies p, CapstoneTable1 c, CapstoneTable2 c2 WHERE p.PharmacyID = c.PharmacyID AND p.PharmacyID = c2.PharmacyID AND c.AddressType = 'Physical Address' AND c2.NumberType = 'Phone Number' AND p.PharmacyType = 'Partner Pharmacy';";

            var results = new List<results>();

            try
            {
                conn.Open();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, null, null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["PharmacyName"].ToString(), fetch_query["PharmacyType"].ToString(), fetch_query["StreetAddressLine1"].ToString(), fetch_query["StreetAddressLine2"].ToString(), fetch_query["City"].ToString(), fetch_query["State"].ToString(), fetch_query["Zip"].ToString(), fetch_query["AddressType"].ToString(), fetch_query["Number"].ToString(), fetch_query["WebsiteURL"].ToString(), null));
            }

            return results;
        }

        // GET api/values/56
        /* public List<results> Get(int pharmacyID)
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
