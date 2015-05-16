using Db.Core.Loading;
using Db.Core.TableEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Repositoryes
{
    public class FolderTestingRepository : ITestingRepository
    {
        private string XmlDbFolder;

        private List<XmlTest> _tests;
        private List<XmlGroup> _groups;

        private List<User> _newUsers;

        public FolderTestingRepository(string xmlDbFolder)
        {
            XmlDbFolder = xmlDbFolder;

            _tests = XmlToDbLoader.LoadTestsFromFolder(XmlDbFolder + "\\Tests");
            _groups = XmlToDbLoader.LoadGroupsFromFolder(XmlDbFolder + "\\Groups");

            _newUsers = new List<User>();
        }

        public TableEntityes.User AddUser(string firstName, string lastName, Guid groupId)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                GroupId = groupId
            };

            _newUsers.Add(user);

            return user;
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
            User res = null;

            foreach (var item in _groups)
            {
                foreach (var user in item.Users)
                {
                    if (user.Id == id)
                    {
                        res = user;
                        break;
                    }
                }
            }

            if (res == null)
            {
                foreach (var user in _newUsers)
                {
                    if (user.Id == id)
                    {
                        res = user;
                        break;
                    }
                }
            }

            return res;
        }

        public TableEntityes.Group GetGroup(Guid id)
        {
            Group res = null;

            foreach (var item in _groups)
            {
                if (item.GroupInfo.Id == id)
                {
                    res = item.GroupInfo;
                    break;
                }
            }

            return res;
        }

        public TableEntityes.Test GetTest(Guid id)
        {
            Test res = null;

            foreach (var item in _tests)
            {
                if (item.TestInfo.Id == id)
                {
                    res = item.TestInfo;
                    break;
                }
            }

            return res;
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
