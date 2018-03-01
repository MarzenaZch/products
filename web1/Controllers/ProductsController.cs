using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using web1.Models;

public class ProductsController : Controller
{
    public string getSomeText()
    {
        return "ala ma kota";
    }


    public string[] GetVeggies()
    {
        return new string[] { "pomidor", "marchewka", "jablko" };
    }

    public List<Product> GetAllProducts(string searchedPhrase)
    {
        SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;

        command.CommandText=$@"Select productid, productname, supplierid, categoryid,unitprice, discontinued
From Production.Products WHERE productname like '%{searchedPhrase}%'";
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
}