using OlineQuizApp.Models;
using OlineQuizApp.Views.Candidate;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace OlineQuizApp.Views.Candidate
{
    public partial class Test : System.Web.UI.Page
    {
        Models.Functions con;
        private static int i = 0;
        private int quiz = CandidateHome.QId;
        private Nextquestion nextCommand;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack)
            {
                i = 0; // Reset the question index
                score = 0; // Reset the score
                Get_question();
            }
            nextCommand = new Nextquestion(this);
        }

        static int c;
        static int score = 0;

        private void correct()
        {
            if (Ans1Rb.Checked)
            {
                c = 1;
            }
            else if (Ans2Rb.Checked)
            {
                c = 2;
            }
            else if (Ans3Rb.Checked)
            {
                c = 3;
            }
            else if (Ans4Rb.Checked)
            {
                c = 4;
            }
        }

        private void inserttest()
        {
            try
            {
                int candidate = Login.CandId;
                int quiz = CandidateHome.QId;

                // Check if the candidate exists in the CandidateTbl
                string checkCandidateQuery = string.Format("SELECT COUNT(*) FROM CandidateTbl WHERE CandId = {0}", candidate);
                DataTable candidateTable = con.GetData(checkCandidateQuery);

                if (candidateTable.Rows.Count > 0 && Convert.ToInt32(candidateTable.Rows[0][0]) > 0)
                {
                    // Correct SQL query with proper date formatting and parameter usage
                    string query = string.Format("INSERT INTO TestTbl (Candidate, Quiz, TestDate, Score) VALUES ({0}, {1}, '{2}', {3})", candidate, quiz, DateTime.Now.ToString("yyyy-MM-dd"), score);
                    con.SetData(query);
                }
                else
                {
                    errmsg.InnerText = "Candidate ID does not exist in CandidateTbl.";
                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        public void Next_question()
        {
            string query = string.Format("SELECT * FROM QuestionTbl WHERE Quiz = {0}", quiz);
            DataTable Questions = con.GetData(query);
            int questnumber = Questions.Rows.Count;

            if (i < questnumber)
            {
                if (Ans1Rb.Checked || Ans2Rb.Checked || Ans3Rb.Checked || Ans4Rb.Checked)
                {
                    correct();
                    if (c == int.Parse(Questions.Rows[i][7].ToString()))
                    {
                        score++;
                    }
                    i++;

                    if (i < questnumber)
                    {
                        QuesTb.InnerText = Questions.Rows[i][2].ToString();
                        Ans1Lb1.InnerText = Questions.Rows[i][3].ToString();
                        Ans2Lb1.InnerText = Questions.Rows[i][4].ToString();
                        Ans3Lb1.InnerText = Questions.Rows[i][5].ToString();
                        Ans4Lb1.InnerText = Questions.Rows[i][6].ToString();

                        // Check if the next question is the last one
                        if (i == questnumber - 1)
                        {
                            SubmitButton1.Text = "Submit";
                        }
                    }
                    else
                    {
                        // HTML content for testdiv
                        string testContent = @"<div style='text-align: center;'>
            <img src='../../Assests/Images/crown.png' alt='King Icon' style='height: 50px; width: 50px; display: block; margin: 0 auto; position: relative; top: 35px;'/>
            <div style='font-size: 20px; height: 200px; padding-left: 50px; padding-top: 60px;'>
                Thanks For Giving Test <br />Score: You got <strong>" + score + "</strong> marks out of <strong>" + questnumber + "</strong> </ div ></ div > ";

                        testdiv.InnerHtml = testContent;

                        // Show the Go to Home button in btndiv
                        btndiv.Visible = true;
                        btndiv.InnerHtml = @"<div  style='text-align: center; margin-top: 20px; position: relative; top: -80px;'>
            <a href='CandidateHome.aspx' class='btn btn-success' style='font-size: 18px; padding: 10px 20px;  color: white; text-decoration: none; border-radius: 5px;'>Go to Home</a>
        </div>";

                        // Hide the other buttons if needed
                        // previousButton2.Visible = false; // Optionally hide other buttons if needed

                        // Set the text for QuesTb
                        QuesTb.InnerText = "Result";
                        QuesTb.Style.Add("text-align", "center");
                        QuesTb.Style.Add("font-size", "24px");

                        // Call the inserttest method
                        inserttest();
                    }


                    Ans1Rb.Checked = false;
                    Ans2Rb.Checked = false;
                    Ans3Rb.Checked = false;
                    Ans4Rb.Checked = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('No Answer Selected')", true);
                }
            }
        }


        private void Get_question()
        {
            string query = string.Format("SELECT * FROM QuestionTbl WHERE Quiz = {0}", quiz);
            DataTable Questions = con.GetData(query);
            int questnumber = Questions.Rows.Count;
            if (i < questnumber)
            {
                QuesTb.InnerText = Questions.Rows[i][2].ToString();
                Ans1Lb1.InnerText = Questions.Rows[i][3].ToString();
                Ans2Lb1.InnerText = Questions.Rows[i][4].ToString();
                Ans3Lb1.InnerText = Questions.Rows[i][5].ToString();
                Ans4Lb1.InnerText = Questions.Rows[i][6].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            nextCommand?.Execute();
        }

        public void Previous_question()
        {
            // Fetch all questions for the current quiz
            string query = string.Format("SELECT * FROM QuestionTbl WHERE Quiz = {0}", quiz);
            DataTable Questions = con.GetData(query);

            if (Questions.Rows.Count > 0) // Ensure there are questions available
            {
                if (i > 0) // Ensure that you are not on the first question
                {
                    i--; // Move to the previous question
                }

                // Display the current question and its answers
                QuesTb.InnerText = Questions.Rows[i][2].ToString();
                Ans1Lb1.InnerText = Questions.Rows[i][3].ToString();
                Ans2Lb1.InnerText = Questions.Rows[i][4].ToString();
                Ans3Lb1.InnerText = Questions.Rows[i][5].ToString();
                Ans4Lb1.InnerText = Questions.Rows[i][6].ToString();

                // Restore the previously selected answer
                switch (c)
                {
                    case 1:
                        Ans1Rb.Checked = true;
                        break;
                    case 2:
                        Ans2Rb.Checked = true;
                        break;
                    case 3:
                        Ans3Rb.Checked = true;
                        break;
                    case 4:
                        Ans4Rb.Checked = true;
                        break;
                    default:
                        Ans1Rb.Checked = false;
                        Ans2Rb.Checked = false;
                        Ans3Rb.Checked = false;
                        Ans4Rb.Checked = false;
                        break;
                }

                // Handle "Previous" button visibility and enable/disable state
                previousButton2.Visible = true;
                previousButton2.Enabled = i > 0; // Disable the button if on the first question

                // Update the "Next" button text
                if (i == Questions.Rows.Count - 1)
                {
                    SubmitButton1.Text = "Submit";
                }
                else
                {
                    SubmitButton1.Text = "Next";
                }

                // Show "Next" button and ensure it is always visible
                SubmitButton1.Visible = true;
            }
        }







        protected void previousButton2_Click(object sender, EventArgs e)
        {
            nextCommand?.previous();
        }
    }
}