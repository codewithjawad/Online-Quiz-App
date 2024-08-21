using OlineQuizApp.Views.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OlineQuizApp.Views.Candidate
{
    public partial class CandidateHome : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack)
            {
                Get_quiz();
            }

        }
        public static string Quiz = "";
        public static int QId = 0;
        private void Get_quiz()
        {
            string query = "select * from QuizTbl";
            QuiznameTb.DataTextField = con.GetData(query).Columns["Qname"].ToString();
            QuiznameTb.DataValueField = con.GetData(query).Columns["QId"].ToString();
            QuiznameTb.DataSource = con.GetData(query);
            QuiznameTb.DataBind();
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            Quiz = QuiznameTb.SelectedItem.ToString();
            QId = Convert.ToInt32(QuiznameTb.SelectedValue.ToString());
            Response.Redirect("Test.aspx");
        }
    }
}