using System;
using System.Web;
using System.Web.UI;

namespace OlineQuizApp.Views.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the instance of the AdminLoginManager singleton
                var loginManager = Models.AdminLoginManager.GetInstance();

                // Logout the admin
                loginManager.LogoutAdmin();

                // Redirect to the login page
                Response.Redirect("../Login.aspx");
            }
            catch (Exception ex)
            {
                // Handle the error (optional)
                // Log the error or display a message
                Console.WriteLine(ex.Message);
            }
        }
    }
}
