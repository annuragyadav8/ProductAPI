using System.Data;
using System.Data.SqlClient;
using DtosLayer;

namespace RepositoryLayer
{
    public class ProductRepository : IProductRepository
    {
        public  readonly string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<ProductClass> GetProducts()
        {
            List<ProductClass> product = new List<ProductClass>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductClass pro = new ProductClass()
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString(),
                        ProductDescription = reader["ProductDescription"].ToString(),
                    };
                    product.Add(pro);
                }
            }

            return product;
        }
       
        public List<ProductClass> AddProduct(ProductClass product)
        {
            List<ProductClass> products = new List<ProductClass>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return products;
        }

        public List<ProductClass> UpdateProduct(ProductClass product)
        {
            List<ProductClass> products = new List<ProductClass>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return products;
        }

        public List<ProductClass> DeleteProduct(int id)
        {
            List<ProductClass> products = new List<ProductClass>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return products;
        }

        public List<ProductClass> GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
