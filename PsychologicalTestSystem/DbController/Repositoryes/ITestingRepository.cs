using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.TableEntityes;

namespace DbController.Repositoryes
{
    public interface ITestingRepository
    {
        User AddUser(string firstName, string lastName, Guid groupId);
        Question AddQuestion(string message, string firstAnswer, string secondAnswer, string thirdAnswer, 
            string firstReportMessage, string secondReportMessage, string thirdReportMessage);
        Testing AddTestingResult(Guid userId, Guid questionId, int checedAnswer);
        Group AddGroup(string number);
        Test AddTest(string name);

        void AddQuestionToTest(Guid questionId, Guid testId);
        
        Question GetQuestion(Guid id);
        Testing GetTestingResult(Guid id);
        User GetUser(Guid id);
        Group GetGroup(Guid id);
        Test GetTest(Guid id);

        IEnumerable<User> GetUserByGroup(Guid groupId);

        IEnumerable<Group> GetAllGroup();
        IEnumerable<Test> GetAllTest();
    }
}
