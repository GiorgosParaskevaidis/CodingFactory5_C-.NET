using FirstWebDBApp.Models;
using System.Data.SqlClient;
using WebStarterDBApp.Service.DBHelper;

namespace FirstWebDBApp.DAO
{
    public class CustomerDAOImpl : ICustomerDAO
    {
        public void Delete(int id)
        {
            string sql = "DELETE FROM CUSTOMERS WHERE ID = @id";

            using SqlConnection? conn = DBHelper.GetConnection();
            if (conn is not null) conn.Open();

            using SqlCommand command = new(sql, conn);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public IList<Customer> GetAll()
        {
            string sql = "SELECT * FROM CUSTOMERS";
            var customers = new List<Customer>();
            Customer? customer;

            using SqlConnection? conn = DBHelper.GetConnection();
            if (conn is not null) conn.Open();

            using SqlCommand command = new(sql, conn);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customer = new()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                    Firstname = reader.GetString(reader.GetOrdinal("FIRSTNAME")),
                    Lastname = reader.GetString(reader.GetOrdinal("LASTNAME")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                    Region = reader.GetString(reader.GetOrdinal("REGION"))
                };
                customers.Add(customer);
            }
            return customers;
        }

        public Customer? GetById(int id)
        {
            string? sql = "SELECT * FROM CUSTOMERS WHERE ID = @id";
            Customer? customer = null;

            using SqlConnection? conn = DBHelper.GetConnection();
            if (conn is not null) conn.Open();

            using SqlCommand command = new(sql, conn);
            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read()) 
            {
                customer = new()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                    Firstname = reader.GetString(reader.GetOrdinal("FIRSTNAME")),
                    Lastname = reader.GetString(reader.GetOrdinal("LASTNAME")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                    Region = reader.GetString(reader.GetOrdinal("REGION"))
                };
            }
            return customer;
        }

        public Customer? Insert(Customer? customer)
        {
            if (customer == null) return null;
            string sql = "INSERT INTO CUSTOMERS (FIRSTNAME, LASTNAME, AGE, REGION) VALUES (@firstname, @lastname, @age, @region); " +
                "SELECT SCOPE_IDENTITY();";

            Customer? customerToReturn = null;
            int insertedId = 0;

            using SqlConnection? conn = DBHelper.GetConnection();
            if (conn is not null) conn.Open();

            using SqlCommand command = new(sql, conn);
            command.Parameters.AddWithValue("@firstname", customer.Firstname);
            command.Parameters.AddWithValue("@lastname", customer.Lastname);
            command.Parameters.AddWithValue("@age", customer.Age);
            command.Parameters.AddWithValue("@region", customer.Region);

            object insertedObj = command.ExecuteScalar();
            if (insertedObj is not null)
            {
                if (!int.TryParse(insertedObj.ToString(), out insertedId))
                {
                    throw new Exception("Error in insert id");
                }
            }

            string? sqlSelect = "SELECT * FROM CUSTOMERS WHERE ID = @id";

            using SqlCommand sqlCommand = new(sqlSelect, conn);
            sqlCommand.Parameters.AddWithValue("@id", insertedId);

            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                customerToReturn = new()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                    Firstname = reader.GetString(reader.GetOrdinal("FIRSTNAME")),
                    Lastname = reader.GetString(reader.GetOrdinal("LASTNAME")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                    Region = reader.GetString(reader.GetOrdinal("REGION"))
                };
            }
            return customerToReturn;
        }

        public Customer? Update(Customer customer)
        {
            if (customer == null) return null;
            string sql = "UPDATE CUSTOMERS SET FIRSTNAME = @firstname, LASTNAME = @lastname, AGE = @age, REGION = @region WHERE ID = @id";

            Customer customerToReturn = customer;

            using SqlConnection? conn = DBHelper.GetConnection();
            if (conn is not null) conn.Open();

            using SqlCommand command = new(sql, conn);
            command.Parameters.AddWithValue("@firstname", customer.Firstname);
            command.Parameters.AddWithValue("@lastname", customer.Lastname);
            command.Parameters.AddWithValue("@age", customer.Age);
            command.Parameters.AddWithValue("@region", customer.Region);
            command.Parameters.AddWithValue("@id", customer.Id);

            command.ExecuteNonQuery();
            return customerToReturn;
        }
    }
}
