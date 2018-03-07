using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using web1.Models;
using Newtonsoft.Json;

public class ProductsController : Controller
{
    
    [HttpGet]
    public List<Product> GetAllProducts(string searchedPhrase, int categoryid, int supplierid)
    {
        SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;

        command.CommandText=$@"Select productid, productname, supplierid, categoryid,unitprice, discontinued
From Production.Products WHERE productname like '%{searchedPhrase}%' AND categoryid={categoryid} AND supplierid={supplierid}";
        command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
      
        List <Product> productNames=new List<Product>();
        while(reader.Read())
        {
            Product temp= new Product();
            temp.ProductID=int.Parse(reader["productid"].ToString());
            temp.ProductName=reader["productname"].ToString();
            temp.SupplierID=int.Parse(reader["supplierid"].ToString());
            temp.CategoryID=int.Parse(reader["categoryid"].ToString());
            temp.UnitPrice=double.Parse(reader["unitprice"].ToString());
            temp.Discontinued=bool.Parse(reader["discontinued"].ToString());
        productNames.Add(temp);
        }


        return productNames;

    }
    [HttpPost]
    public Product AddProduct([FromBody] Product product)

    {
         System.Data.SqlClient.SqlConnection sqlConnection1 = 
                new System.Data.SqlClient.SqlConnection("Server=DESKTOP-LDF80HU\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Production.Products productname, supplierid, categoryid,unitprice, discontinued VALUES {NewProduct}";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        return product;
    }
}