using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OlineQuizApp.Views.Admin
{
    public partial class Questions : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if(!IsPostBack)
            {
                Get_quiz();
                ShowQuestion();
            }
           
        }
        private void Get_quiz()
        {
            string query = "select * from QuizTbl";
            QuiznameTb.DataTextField = con.GetData(query).Columns["Qname"].ToString();
            QuiznameTb.DataValueField = con.GetData(query).Columns["QId"].ToString();
            QuiznameTb.DataSource = con.GetData(query);
            QuiznameTb.DataBind();      
    }
        private void ShowQuestion()
        {
            string query = "select * from QuestionTbl";
            Questionslist.DataSource = con.GetData(query);
            Questionslist.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {       string quiz = QuiznameTb.SelectedItem.Value;
                    String quest = QuestTb.Value;
                    String ans1 = Ans1Tb.Value;
                    String ans2 = Ans2Tb.Value;
                    String ans3 = Ans3Tb.Value;
                    String ans4 = Ans4Tb.Value;
                    int correct_ans = int.Parse(CorrectTb.Value);
                if (correct_ans == 1 || correct_ans == 2 || correct_ans == 3 || correct_ans == 4)
                {

                    string query = string.Format("INSERT INTO QuestionTbl (Quiz,Question,Ans1,Ans2,Ans3,Ans4,CorrectAns) VALUES ('{0}', '{1}', '{2}','{3}', '{4}', '{5}','{6}')", quiz, quest, ans1, ans2, ans3, ans4, correct_ans);
                    con.SetData(query);
                    errmsg.InnerText = "Question Added!!!";

                }
                else
                {
                    errmsg.InnerText = "Error: Correct Answer must be 1, 2, 3, or 4.";
                }
                QuiznameTb.SelectedItem.Value = string.Empty;
                QuestTb.Value = string.Empty;
                Ans1Tb.Value = string.Empty;
                Ans2Tb.Value = string.Empty;
                Ans3Tb.Value = string.Empty;
                Ans4Tb.Value = string.Empty;
                CorrectTb.Value = string.Empty;
                ShowQuestion();
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        protected void Questionslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuiznameTb.DataValueField  = Questionslist.SelectedRow.Cells[2].Text;
            QuestTb.Value = Questionslist.SelectedRow.Cells[3].Text;
            Ans1Tb.Value = Questionslist.SelectedRow.Cells[4].Text;
            Ans2Tb.Value = Questionslist.SelectedRow.Cells[5].Text;
            Ans3Tb.Value = Questionslist.SelectedRow.Cells[6].Text;
            Ans4Tb.Value = Questionslist.SelectedRow.Cells[7].Text;
            CorrectTb.Value = Questionslist.SelectedRow.Cells[8].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string quiz = QuiznameTb.SelectedItem.Value;
                String quest = QuestTb.Value;
                String ans1 = Ans1Tb.Value;
                String ans2 = Ans2Tb.Value;
                String ans3 = Ans3Tb.Value;
                String ans4 = Ans4Tb.Value;
                int correct_ans = int.Parse(CorrectTb.Value);
                if (correct_ans == 1 || correct_ans == 2 || correct_ans == 3 || correct_ans == 4)
                {

                    string query = string.Format("UPDATE QuestionTbl set Quiz ='{0}',Question ='{1}',Ans1 ='{2}',Ans2 ='{3}',Ans3 ='{4}',Ans4 ='{5}',CorrectAns ='{6}' where QuestionId = '{7}'", quiz, quest, ans1, ans2, ans3, ans4, correct_ans, Questionslist.SelectedRow.Cells[1].Text);
                    con.SetData(query);
                    errmsg.InnerText = "Question Updated!!!";

                }
                else
                {
                    errmsg.InnerText = "Error: Correct Answer must be 1, 2, 3, or 4.";
                }
                QuiznameTb.SelectedItem.Value = string.Empty;
                QuestTb.Value = string.Empty;
                Ans1Tb.Value = string.Empty;
                Ans2Tb.Value = string.Empty;
                Ans3Tb.Value = string.Empty;
                Ans4Tb.Value = string.Empty;
                CorrectTb.Value = string.Empty;
                ShowQuestion();
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
                string quiz = QuiznameTb.SelectedItem.Value;
                String quest = QuestTb.Value;
                String ans1 = Ans1Tb.Value;
                String ans2 = Ans2Tb.Value;
                String ans3 = Ans3Tb.Value;
                String ans4 = Ans4Tb.Value;
                int correct_ans = int.Parse(CorrectTb.Value);
                string query = string.Format(" Delete from QuestionTbl where QuestionId = '{0}'", Questionslist.SelectedRow.Cells[1].Text);
                con.SetData(query);
                errmsg.InnerText = "Question Deleted!!!";
                QuiznameTb.SelectedItem.Value = string.Empty;
                QuestTb.Value = string.Empty;
                Ans1Tb.Value = string.Empty;
                Ans2Tb.Value = string.Empty;
                Ans3Tb.Value = string.Empty;
                Ans4Tb.Value = string.Empty;
                CorrectTb.Value = string.Empty;
                ShowQuestion();
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }

        }
    }
}