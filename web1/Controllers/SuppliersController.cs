
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using web1.Models;

public class SuppliersController : Controller
{
    public List<Suppliers> GetAllSuppliers()

    {
        SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;

        command.CommandText=$@"Select supplierid, companyname FROM Production.Suppliers";
        command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
      
        List <Suppliers> supplierName=new List<Suppliers>();
      while(reader.Read())
        {
           Suppliers temp2= new Suppliers();
            temp2.Supplierid=int.Parse(reader["supplierid"].ToString());
            temp2.companyname=reader["companyname"].ToString();
          
            
        supplierName.Add(temp2);
        }


        return supplierName;

    }
}