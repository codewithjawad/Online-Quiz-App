using OlineQuizApp.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace OlineQuizApp.Views
{
    public partial class Register : System.Web.UI.Page
    {
        Models.Functions con;
        public void Page_Load(object sender, EventArgs e)
        {   
           con = new Models.Functions();
        }

        public void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                string name = CNameTb.Value;
                string email = CEmailTb.Value;
                string password = PasswordTb.Value;
                string college = CollegeTb.Value;
                string query = string.Format("INSERT INTO CandidateTbl (CandName, CandEmail, CandPass, CandCollege) VALUES ('{0}', '{1}', '{2}', '{3}')",name, email, password, college);
                con.SetData(query);
                errormsg.InnerText = "Successfully Added ... Login Now";
                CNameTb.Value = string.Empty;
                CEmailTb.Value = string.Empty;
                PasswordTb.Value = string.Empty;
                CollegeTb.Value = string.Empty;
            }

            
             
            catch(Exception ex) { 
                errormsg.InnerText = ex.Message;
            }

        }
    }
 }