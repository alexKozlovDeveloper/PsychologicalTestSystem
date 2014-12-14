using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogic.TestEntityes
{
    [Serializable]
    public class Question
    {
        public string QuestionMessage { get; set; }

        public Answer FirstAnswer { get; set; }
        public Answer SecondAnswer { get; set; }
        public Answer ThirdAnswer { get; set; }

        public Question()
        { 
        
        }
    }
}
