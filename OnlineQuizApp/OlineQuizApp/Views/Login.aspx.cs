using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OlineQuizApp.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
        }
        public static int CandId;

        private bool VerifyReCaptcha(string response)
        {
            string secretKey = "6LfUhfQpAAAAAJiMdnPgy2iAb8JYuZXxPAzI326x";
            var client = new WebClient();
            var reply = client.DownloadString(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var captchaResponse = new JavaScriptSerializer().Deserialize<ReCaptchaResponse>(reply);
            return captchaResponse.Success;
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string recaptchaResponse = Request["g-recaptcha-response"];
                if (!VerifyReCaptcha(recaptchaResponse))
                {
                    errormsg.InnerText = "Please verify you are not a robot.";
                    return;
                }

                string pass = PassTb.Value;
                string email = CEmailTb.Value;
                string query = string.Format("SELECT CandId, CandName, CandEmail, CandCollege FROM CandidateTbl WHERE CandEmail='{0}' AND CandPass='{1}'", email, pass);
                DataTable dt = con.GetData(query);

                if (dt.Rows.Count == 0)
                {
                    errormsg.InnerText = "Wrong Credentials!!!";
                }
                else
                {
                    CandId = int.Parse(dt.Rows[0][0].ToString());
                    Response.Redirect("Candidate/CandidateHome.aspx");
                }
                CEmailTb.Value = string.Empty;
                PassTb.Value = string.Empty;
            }
            catch (Exception ex)
            {
                errormsg.InnerText = ex.Message;
            }
        }

        public class ReCaptchaResponse
        {
            public bool Success { get; set; }
            public List<string> ErrorCodes { get; set; }
        }
    }
}
