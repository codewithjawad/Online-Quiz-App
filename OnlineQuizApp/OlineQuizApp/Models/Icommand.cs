using OlineQuizApp.Views.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlineQuizApp.Models
{
    public interface Icommand
    {
        void Execute();
        void previous();
    }
}
