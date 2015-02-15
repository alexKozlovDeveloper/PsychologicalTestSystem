using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.TableEntityes;

namespace DbController.Repositoryes
{
    interface ITestingRepository
    {
        void AddUser(string firstName, string lastName, string groupNumber);
        void AddQuestion(string message, string firstAnswer, string secondAnswer, string thirdAnswer, 
            string firstReportMessage, string secondReportMessage, string thirdReportMessage);

        void AddTestingResult(Guid userId, Guid questionId, int checedAnswer);

        Question GetQuestion(Guid id);
        Testing GetTesting(Guid id);
        User GetUser(Guid id);
    }
}
