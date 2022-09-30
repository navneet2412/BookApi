using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookApi.Models
{
    public class CategorySqlImpl : ICategoryRepo
    {
        SqlConnection conn;
        SqlCommand com;

        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            com = new SqlCommand();
        }
        public Category AddCategory(Category catogery)
        {
            com.CommandText = "insert into Catogery values('"+catogery.CategoryName+"','"+catogery.Description+"','"+catogery.CategoryImage+"','"+catogery.Status+"','"+catogery.Position+"','"+catogery.CreatedAt+"')";
            com.Connection = conn;
            conn.Open();
            int row = com.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return catogery;
            }
            else
            {
                return null;
            }
        }

        public string DeleteCategory(int id)
        {
            com.CommandText = "delete from Catogery where Id='" + id + "'";
            com.Connection = conn;
            conn.Open();
            int row = com.ExecuteNonQuery();
            conn.Close();
            string res = row + "category deleted!";
            return res;
        }

        public List<Category> GetAllCategory()
        {
            List<Category> categories = new List<Category>();
            com.CommandText = "select * from Catogery ";
            com.Connection = conn;
            conn.Open();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string categoryName = dr["CategoryName"].ToString();
                string discription = dr["Description"].ToString();
                string categoryImage = dr["CategoryImage"].ToString();
                string status = dr["Status"].ToString();
                int position = Convert.ToInt32(dr["Position"]);
                string createdat = dr["CreatedAt"].ToString();
                categories.Add(new Category(id, categoryName, discription, categoryImage, status, position, createdat));
            }
            conn.Close();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            com.CommandText = "select * from Catogery where Id='" + id+"'";
            com.Connection = conn;
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                
                string categoryName = reader["CategoryName"].ToString();
                string discription = reader["Description"].ToString();
                string categoryImage = reader["CategoryImage"].ToString();
                string status = reader["Status"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                string createdat = reader["CreatedAt"].ToString();
                Category category=  new Category(id, categoryName, discription, categoryImage, status, position, createdat);
                return category;
            }
            conn.Close();
            return null;
        }

        public Category UpdateCategory(int id, Category category)
        {
            com.CommandText = "update Catogery set CategoryName ='" + category.CategoryName + "',Description='" + category.Description + "',CategoryImage='" + category.CategoryImage + "',Status='" + category.Status + "',Position='" + category.Position + "',CreatedAt='" + category.CreatedAt + "' where Id='" + id + "'";
            com.Connection = conn;
            conn.Open();
            int row = com.ExecuteNonQuery();
            conn.Close();

            if (row > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }
    }
}