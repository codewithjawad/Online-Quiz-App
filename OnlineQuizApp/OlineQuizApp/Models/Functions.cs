using OlineQuizApp.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace OlineQuizApp.Models
{
    public class Functions
    {
        private  SqlConnection  con;
        private SqlCommand _command;
        private DataTable Dt;
        public  string ConStr;
        private SqlDataAdapter _adapter;
        public Functions() {
            ConStr = @"Data Source=JAWWAD-PC\SQLEXPRESS;Initial Catalog=onlinequiz;Integrated Security=True;TrustServerCertificate=False";
            con = new SqlConnection(ConStr);
            _command = new SqlCommand
            {
                Connection = con
            };
        }
        public int SetData(string Query) {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           _command.CommandText = Query;
            int cnt = _command.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
        public DataTable GetData(string Query)
        {
             Dt = new DataTable();
            _adapter = new SqlDataAdapter(Query,ConStr);
            _adapter.Fill(Dt);
            return Dt;
        }

    }
}