using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Repositoryes
{
    class FolderTestingRepository : ITestingRepository
    {
        private string XmlDbFolder;

        public FolderTestingRepository(string xmlDbFolder)
        {
            XmlDbFolder = xmlDbFolder;
        }

        public TableEntityes.User AddUser(string firstName, string lastName, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Question AddQuestion(string message, string firstAnswer, string secondAnswer, string thirdAnswer, string firstReportMessage, string secondReportMessage, string thirdReportMessage)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Group AddGroup(string number)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Test AddTest(string name, string introduction)
        {
            throw new NotImplementedException();
        }

        public void AddQuestionToTest(Guid questionId, Guid testId)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Question GetQuestion(Guid id)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Testing GetTestingResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Group GetGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.Test GetTest(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.User> GetUserByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.Group> GetAllGroup()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.Test> GetAllTest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.Question> GetAllQuestion()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.Question> GetQuestions(Guid testId)
        {
            throw new NotImplementedException();
        }

        public bool IsAvailableGroup(Guid testId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.Testing> GetAllTesting()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.PassingTest> GetAllPassingTest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableEntityes.Testing> GetTesting(Guid passingTestId)
        {
            throw new NotImplementedException();
        }

        public TableEntityes.PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public int GetQuestionsCount(Guid testId)
        {
            throw new NotImplementedException();
        }
    }
}
