using OlineQuizApp.Views.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace OlineQuizApp.Models
{
    public class Nextquestion:Icommand
    {
        private  Test test;

        public Nextquestion(Test test)
        {
            this.test = test;
        }
        public void Execute()
        {
            test.Next_question();
            
        }
        public void previous()
        {
            test.Previous_question();
        }
    }
}