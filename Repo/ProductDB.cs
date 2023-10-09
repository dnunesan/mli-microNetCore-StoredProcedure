using mli_microNetCore_StoredProcedure.Model;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mli_microNetCore_StoredProcedure.Repo
{
    public class ProductDB : ImemoryProduct
    {
        private string infoConnection;

        public ProductDB(AccesData conectionSQL) {
            infoConnection = conectionSQL.publicConectionSQL;
        }

        private SqlConnection conection() { 
            return new SqlConnection(infoConnection);   
        }

        bool ImemoryProduct.createProduct(Product p)
        {
            SqlConnection sqlConnection = conection();
            SqlCommand Comm = null;
            try
            {
                sqlConnection.Open();   
                Comm = sqlConnection.CreateCommand();                
                //Comm.CommandText = "dbo.spCreateProduct_2";
                Comm.CommandText = "dbo.spCreateProduct";

                // Set the command type to be a stored procedure.
                Comm.CommandType = CommandType.StoredProcedure;

                // Add the parameters to the command.
                Comm.Parameters.AddWithValue("@Name", p.Name);
                Comm.Parameters.AddWithValue("@Description", p.Description);
                Comm.Parameters.AddWithValue("@Price", p.Price);
                Comm.Parameters.AddWithValue("@SKU", p.SKU);
                SqlParameter outputParameter = new SqlParameter("@Result", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output,
                    Value = false
                };
                Comm.Parameters.Add(outputParameter);

                // Execute the stored procedure.
                Comm.ExecuteNonQuery();

                // Get the value of the output parameter.
                bool result = (bool)outputParameter.Value;
                Console.WriteLine("Output Parameter Value: " + result);
                return result;  


            }
            catch (Exception ex)
            {
                  throw new Exception("A fatal error ocurred during execution" + ex.ToString());
            }
            finally 
            {
                Comm.Dispose();
                sqlConnection.Close();  
                sqlConnection.Dispose();    
            }  
        }

        public void deleteProduct(Product p)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> getAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public Product getProduct(string sku)
        {
            throw new System.NotImplementedException();
        }

        public void updateProduct(Product p)
        {
            throw new System.NotImplementedException();
        }       
    }
}
