using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MesgService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MesgService" in both code and config file together.
    public class MesgService : IMesgService
    {
        public string CS = "data source=.; database=ProjectDB; Integrated Security=SSPI;";

        public List<Product> GetMessages()
        {
            List<Product> ls = new List<Product>();
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblMessages order by messageId", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Product p = new Product();
                        p.id = Convert.ToInt32(rdr["messageId"]);
                        p.name = Convert.ToString(rdr["message"]);
                        ls.Add(p);
                    }
                }

            }
            return ls;

        }

        public int AddMessage(String message)
        {
            List<Product> ls = new List<Product>();
            int generatedId = 0;
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@message",message);
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@messageId";
                para.SqlDbType = SqlDbType.Int;
                para.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(para);
                con.Open();
                int rowsAdded = cmd.ExecuteNonQuery();
                
                if (rowsAdded == 1)
                {
                    generatedId = Convert.ToInt32(para.Value);
                }
            }
            return generatedId;
        }


        public int DeleteMessage(string id)
        {
            int count=0;
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("delete from tblMessages where messageId = " + id, con);
                con.Open();
                count = cmd.ExecuteNonQuery();
                
            }

            return count;
            
        }
    }
}
