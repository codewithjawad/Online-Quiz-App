using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace OlineQuizApp.Views.Admin
{
    public partial class Quiz : System.Web.UI.Page
    {
        Models.Functions con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowQuix();
            }
        }

        private void ShowQuix()
        {
            string query = "SELECT QId AS ID, Qname AS QuizName, QQtNbr AS Quantity, QMarksByAnswer AS QuestionMarks FROM QuizTbl";
            Quizlist.DataSource = con.GetData(query);
            Quizlist.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string quiz = QuizTb.Value;
                int quet = int.Parse(QuestTb.Value);
                int answer = int.Parse(AnsByQuestTb.Value);

                if (quet > 0 && answer > 0)
                {
                    if (!Regex.IsMatch(quiz, @"^\d+$"))
                    {
                        string query = string.Format("INSERT INTO QuizTbl (Qname, QQtNbr, QMarksByAnswer) VALUES ('{0}', '{1}', '{2}')", quiz, quet, answer);
                        con.SetData(query);
                        errmsg.InnerText = "Quiz Added!!!";
                    }
                    else
                    {
                        errmsg.InnerText = "Error: Quiz name must be a non-numeric string.";
                    }

                    QuizTb.Value = string.Empty;
                    QuestTb.Value = string.Empty;
                    AnsByQuestTb.Value = string.Empty;
                    ShowQuix();
                }
                else
                {
                    errmsg.InnerText = "Enter Valid Value!!!";
                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        protected void Quizlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuizTb.Value = Quizlist.SelectedRow.Cells[2].Text;
            QuestTb.Value = Quizlist.SelectedRow.Cells[3].Text;
            AnsByQuestTb.Value = Quizlist.SelectedRow.Cells[4].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string quiz = QuizTb.Value;
                int quet = int.Parse(QuestTb.Value);
                int answer = int.Parse(AnsByQuestTb.Value);

                if (quet > 0 && answer > 0)
                {
                    if (!Regex.IsMatch(quiz, @"^\d+$"))
                    {
                        string query = string.Format("UPDATE QuizTbl SET Qname= '{0}', QQtNbr = '{1}', QMarksByAnswer = '{2}' WHERE QId = '{3}'", quiz, quet, answer, Quizlist.SelectedRow.Cells[1].Text);
                        con.SetData(query);
                        errmsg.InnerText = "Quiz Updated!!!";
                    }
                    else
                    {
                        errmsg.InnerText = "Error: Quiz name must be a non-numeric string.";
                    }

                    QuizTb.Value = string.Empty;
                    QuestTb.Value = string.Empty;
                    AnsByQuestTb.Value = string.Empty;
                    ShowQuix();
                }
                else
                {
                    errmsg.InnerText = "Enter Valid Value!!!";
                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the selected row and cell values are valid
                if (Quizlist.SelectedRow != null && Quizlist.SelectedRow.Cells.Count > 1)
                {
                    // Retrieve the Quiz ID from the selected row
                    int quizId = int.Parse(Quizlist.SelectedRow.Cells[1].Text);

                    // Define the query to call the stored procedure
                    string query = "EXEC DeleteQuizAndQuestions @QId";

                    // Set up the SQL command with parameters
                    using (SqlConnection connection = new SqlConnection(con.ConStr)) // Assuming 'con' has a property ConnectionString
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@QId", quizId);

                            // Open the connection
                            connection.Open();

                            // Execute the command
                            cmd.ExecuteNonQuery();

                            // Close the connection
                            connection.Close();
                        }
                    }

                    // Display success message
                    errmsg.InnerText = "Quiz Deleted!!!";

                    // Clear input fields
                    QuizTb.Value = string.Empty;
                    QuestTb.Value = string.Empty;
                    AnsByQuestTb.Value = string.Empty;

                    // Refresh the quiz list
                    ShowQuix();
                }
                else
                {
                    errmsg.InnerText = "No quiz selected!";
                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }
    }
}
