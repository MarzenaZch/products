
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using web1.Models;

public class CategoryController : Controller
{
    public List<Categoryname> GetAllCategories()

    {
        SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;

        command.CommandText=@"Select * FROM Production.Categories";
        command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
      
        List <Categoryname> categoryName=new List<Categoryname>();
        while(reader.Read())
        {
           Categoryname temp1= new Categoryname();
            temp1.CategoryID=int.Parse(reader["categoryid"].ToString());
            temp1.CategoryName=reader["categoryname"].ToString();
            temp1.Description=reader["description"].ToString();
            
        categoryName.Add(temp1);
        }


        return categoryName;

    }
}