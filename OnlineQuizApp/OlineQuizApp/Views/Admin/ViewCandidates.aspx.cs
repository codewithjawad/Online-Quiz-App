using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OlineQuizApp.Views.Admin
{
    public partial class ViewCandidates : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            ShowCandidates();
        }
        private void ShowCandidates()
        {
            string query = "select CandId as ID,CandName as Name,CandEmail as Email,CandPass as Password,CandCollege as College from CandidateTbl";
            CandidateList.DataSource = con.GetData(query);
            CandidateList.DataBind();
        }


    }
}