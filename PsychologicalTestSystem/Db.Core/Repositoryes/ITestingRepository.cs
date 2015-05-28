using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;

namespace Db.Core.Repositoryes
{
    public interface ITestingRepository
    {
        User AddUser(string firstName, string lastName, Guid groupId);
        User AddUser(string firstName, string lastName, Guid groupId, Guid id);
        Question AddQuestion(string message, string firstAnswer, string secondAnswer, string thirdAnswer,
            string firstReportMessage, string secondReportMessage, string thirdReportMessage);
        Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId);
        Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId, Guid id);
        Group AddGroup(string number);
        Test AddTest(string name, string introduction);

        void AddQuestionToTest(Guid questionId, Guid testId);

        Question GetQuestion(Guid id);
        Testing GetTestingResult(Guid id);
        User GetUser(Guid id);
        Group GetGroup(Guid id);
        Test GetTest(Guid id);

        IEnumerable<User> GetUserByGroup(Guid groupId);

        IEnumerable<Group> GetAllGroup();
        IEnumerable<Test> GetAllTest();
        IEnumerable<Question> GetAllQuestion();

        IEnumerable<Question> GetQuestions(Guid testId);

        bool IsAvailableGroup(Guid testId, Guid groupId);

        IEnumerable<Testing> GetAllTesting();
        IEnumerable<PassingTest> GetAllPassingTest();
        IEnumerable<Testing> GetTesting(Guid passingTestId);
        PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date);
        PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date, Guid id);

        int GetQuestionsCount(Guid testId);

        void WriteToFolder(string folderPath);
        void ReadFromFolder(string folderPath);

        List<TestingChartItem> GetTestStatistics(Guid testId, List<Guid> groups);
    }
}
