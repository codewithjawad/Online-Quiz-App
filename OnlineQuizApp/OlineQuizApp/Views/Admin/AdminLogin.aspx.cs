using System;
using System.Web.UI;

namespace OlineQuizApp.Views.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        Models.Functions con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the instance of the AdminLoginManager singleton
                var loginManager = Models.AdminLoginManager.GetInstance();

                // Validate admin login using the singleton instance
                if (loginManager.ValidateAdminLogin(CEmailTb.Value, PassTb.Value))
                {
                    // Redirect to the ViewCandidates page if login is successful
                    Response.Redirect("ViewCandidates.aspx");
                }
                else
                {
                    // Display error message if login fails
                    errormsg.InnerText = "Wrong Credentials or Admin already logged in!";
                }

                // Clear the input fields
                CEmailTb.Value = string.Empty;
                PassTb.Value = string.Empty;
            }
            catch (Exception ex)
            {
                // Display exception message in case of an error
                errormsg.InnerText = ex.Message;
            }
        }
    }
}
