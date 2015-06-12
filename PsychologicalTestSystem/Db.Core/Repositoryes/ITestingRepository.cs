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
            string firstReportMessageToUser, string secondReportMessageToUser,
            string firstReportMessageToAdmin, string secondReportMessageToAdmin, 
            int problemNumber, int weakProblemNumber, int sortIndex);
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
        QuestionToTest GetQuestionToTest(Guid id);

        IEnumerable<User> GetUserByGroup(Guid groupId);

        IEnumerable<Group> GetAllGroup();
        IEnumerable<Test> GetAllTest();
        IEnumerable<Question> GetAllQuestion();
        IEnumerable<QuestionToTest> GetAllQuestionToTest();

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

        void RemoveGroup(Guid groupId);
        void RemoveUser(Guid userId);
        void RemoveTest(Guid testId);
        void RemoveQuestionToTest(Guid questionToTestId);

        PassingTest GetLastPassingTest(Guid userId, Guid TestId);
        IEnumerable<Testing> GetTestings(Guid passingTestId);

        IEnumerable<User> GetUsers(IEnumerable<Guid> groups);

        void AddTest(Test test);
        void AddQuestion(Question ques);
        void AddQuestionToTest(QuestionToTest ques);

        bool IsExistTest(Guid testId);
        bool IsExistQuestion(Guid quesId);
        bool IsExistQuestionToTest(Guid quesToTestId);

        void AddAvailableGroup(Guid GroupId, Guid TestId);
        void RemoveAvailableGroup(Guid itemId);
        void RemoveAvailableGroup(Guid GroupId, Guid TestId);
        void RemovePassingTest(Guid passingTestId);
        void RemoveQuestion(Guid questionId);
    }
}
