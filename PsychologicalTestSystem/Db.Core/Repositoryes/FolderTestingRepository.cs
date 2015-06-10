using Db.Core.Helpers;
using Db.Core.Loading;
using Db.Core.TableEntityes;
using Helpers.Keys;
using System;
using System.Collections.Generic;
using System.IO;
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
        private List<PassingTest> _newPassingTests;
        private List<Testing> _newTesting;

        public FolderTestingRepository(string xmlDbFolder)
        {
            XmlDbFolder = xmlDbFolder;

            _tests = XmlToDbLoader.LoadTestsFromFolder(XmlDbFolder + "\\Tests");
            _groups = XmlToDbLoader.LoadGroupsFromFolder(XmlDbFolder + "\\Groups");

            _newUsers = new List<User>();
            _newPassingTests = new List<PassingTest>();
            _newTesting = new List<Testing>();
        }

        public User AddUser(string firstName, string lastName, Guid groupId)
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

        public Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId)
        {
            var t = new Testing 
            {
                Id = Guid.NewGuid(),
                ChekedAnswer = checedAnswer,
                PassingTestId = passingTestId,
                QuestionId = questionId
            };

            _newTesting.Add(t);

            return t;
        }

        public Group AddGroup(string number)
        {
            throw new NotImplementedException();
        }

        public Test AddTest(string name, string introduction)
        {
            throw new NotImplementedException();
        }

        public void AddQuestionToTest(Guid questionId, Guid testId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(Guid id)
        {
            throw new NotImplementedException();
        }

        public Testing GetTestingResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid id)
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

        public Group GetGroup(Guid id)
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

        public Test GetTest(Guid id)
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

        public IEnumerable<User> GetUserByGroup(Guid groupId)
        {
            var res = new List<User>();

            foreach (var item in _groups)
            {
                if (item.GroupInfo.Id == groupId)
                {
                    res.AddRange(item.Users);
                    break;
                }
            }

            foreach (var item in _newUsers)
            {
                if (item.GroupId == groupId)
                {
                    res.Add(item);
                }
            }

            return res;
        }

        public IEnumerable<Group> GetAllGroup()
        {
            var res = new List<Group>();

            foreach (var item in _groups)
            {
                res.Add(item.GroupInfo);
            }

            return res;
        }

        public IEnumerable<Test> GetAllTest()
        {
            var res = new List<Test>();

            foreach (var item in _tests)
            {
                res.Add(item.TestInfo);
            }

            return res;
        }

        public IEnumerable<Question> GetAllQuestion()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestions(Guid testId)
        {
            var res = new List<Question>();

            foreach (var item in _tests)
            {
                if (item.TestInfo.Id == testId)
                {
                    res.AddRange(item.Questions);
                }
            }

            return res;
        }

        public bool IsAvailableGroup(Guid testId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Testing> GetAllTesting()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PassingTest> GetAllPassingTest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Testing> GetTesting(Guid passingTestId)
        {
            throw new NotImplementedException();
        }

        public PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date)
        {
            var pt = new PassingTest
            {
                Id = Guid.NewGuid(),
                Date = date,
                TestId = testId,
                UserId = userId
            };

            _newPassingTests.Add(pt);

            return pt;
        }

        public int GetQuestionsCount(Guid testId)
        {
            throw new NotImplementedException();
        }


        public void WriteToFolder(string folderPath)
        {
            var newUserPath = folderPath + @"\" + FolderNames.NewUsers;

            if (Directory.Exists(newUserPath) == false)
            {
                Directory.CreateDirectory(newUserPath);
            }

            foreach (var item in _newUsers)
            {
                var filePath = newUserPath + @"\" + item.Id + ".xml";

                FileReaderHelper.WriteInFileWithSerialize(item, filePath);            
            }



            var newPassingTestPath = folderPath + @"\" + FolderNames.NewPassingTest;

            if (Directory.Exists(newPassingTestPath) == false)
            {
                Directory.CreateDirectory(newPassingTestPath);
            }

            foreach (var item in _newPassingTests)
            {
                var filePath = newPassingTestPath + @"\" + item.Id + ".xml";

                FileReaderHelper.WriteInFileWithSerialize(item, filePath);
            }



            var newTestingPath = folderPath + @"\" + FolderNames.NewTesting;

            if (Directory.Exists(newTestingPath) == false)
            {
                Directory.CreateDirectory(newTestingPath);
            }

            foreach (var item in _newTesting)
            {
                var filePath = newTestingPath + @"\" + item.Id + ".xml";

                FileReaderHelper.WriteInFileWithSerialize(item, filePath);
            }
        }


        public void ReadFromFolder(string folderPath)
        {
            _tests = XmlToDbLoader.LoadTestsFromFolder(XmlDbFolder + "\\Tests");
            _groups = XmlToDbLoader.LoadGroupsFromFolder(XmlDbFolder + "\\Groups");
        }


        public User AddUser(string firstName, string lastName, Guid groupId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId, Guid id)
        {
            throw new NotImplementedException();
        }

        public PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date, Guid id)
        {
            throw new NotImplementedException();
        }


        public List<TestingChartItem> GetTestStatistics(Guid testId, List<Guid> groups)
        {
            throw new NotImplementedException();
        }


        public void RemoveGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }


        public void RemoveUser(Guid userId)
        {
            throw new NotImplementedException();
        }


        public Question AddQuestion(string message, string firstAnswer, string secondAnswer, string thirdAnswer, string firstReportMessageToUser, string secondReportMessageToUser, string firstReportMessageToAdmin, string secondReportMessageToAdmin, int problemNumber, int weakProblemNumber, int sortIndex)
        {
            throw new NotImplementedException();
        }


        public void RemoveTest(Guid testId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<QuestionToTest> GetAllQuestionToTest()
        {
            throw new NotImplementedException();
        }


        public void RemoveQuestionToTest(Guid questionToTestId)
        {
            throw new NotImplementedException();
        }


        public QuestionToTest GetQuestionToTest(Guid id)
        {
            throw new NotImplementedException();
        }


        public PassingTest GetLastPassingTest(Guid userId, Guid TestId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Testing> GetTestings(Guid passingTestId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<User> GetUsers(IEnumerable<Guid> groups)
        {
            throw new NotImplementedException();
        }


        public void AddTest(Test test)
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(Question ques)
        {
            throw new NotImplementedException();
        }

        public bool IsExistTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public bool IsExistQuestion(Guid quesId)
        {
            throw new NotImplementedException();
        }





        public void AddQuestionToTest(QuestionToTest ques)
        {
            throw new NotImplementedException();
        }

        public bool IsExistQuestionToTest(Guid quesToTestId)
        {
            throw new NotImplementedException();
        }
    }
}
