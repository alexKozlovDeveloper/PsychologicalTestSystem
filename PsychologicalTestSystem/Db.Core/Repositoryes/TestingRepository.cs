using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Convert;
using Db.Core.TableEntityes;
using Db.Core.Tables;
using Db.Core.Tables.Context;
using System.IO;
using Db.Core.Loading;
using Db.Core.Helpers;
using Helpers.Keys;

namespace Db.Core.Repositoryes
{
    public class TestingRepository : ITestingRepository
    {
        public User AddUser(string firstName, string lastName, Guid groupId)
        {
            using (var db = new CoreDbContextV7())
            {
                var user = new UserT()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    GroupId = groupId
                };

                db.Users.Add(user);

                db.SaveChanges();

                return DbConverter.GetUser(user);
            }
        }

        public Question AddQuestion(string message, string firstAnswer, string secondAnswer,
            string thirdAnswer, string firstReportMessage, string secondReportMessage, string thirdReportMessage)
        {
            using (var db = new CoreDbContextV7())
            {
                var question = new QuestionT()
                {
                    Id = Guid.NewGuid(),
                    FirstAnswer = firstAnswer,
                    SecondAnswer = secondAnswer,
                    ThirdAnswer = thirdAnswer,
                    FirstReportMessage = firstReportMessage,
                    SecondReportMessage = secondReportMessage,
                    ThirdReportMessage = thirdReportMessage,
                    Message = message
                };

                db.Questions.Add(question);

                db.SaveChanges();

                return DbConverter.GetQuestion(question);
            }
        }

        public Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId)
        {
            using (var db = new CoreDbContextV7())
            {
                var testing = new TestingT()
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questionId,
                    ChekedAnswer = checedAnswer,
                    PassingTestId = passingTestId
                };

                db.Testing.Add(testing);

                db.SaveChanges();

                return DbConverter.GetTesting(testing);
            }
        }

        public Group AddGroup(string number)
        {
            using (var db = new CoreDbContextV7())
            {
                var group = new GroupT()
                {
                    Id = Guid.NewGuid(),
                    Number = number
                };

                db.Groups.Add(group);

                db.SaveChanges();

                return DbConverter.GetGroup(group);
            }
        }

        public Test AddTest(string name, string introduction)
        {
            using (var db = new CoreDbContextV7())
            {
                var test = new TestT()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Introduction = introduction
                };

                db.Tests.Add(test);

                db.SaveChanges();

                return DbConverter.GetTest(test);
            }
        }

        public void AddQuestionToTest(Guid questionId, Guid testId)
        {
            using (var db = new CoreDbContextV7())
            {
                var qt = new QuestionToTestT
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questionId,
                    TestId = testId
                };

                db.QuestionsToTests.Add(qt);
                db.SaveChanges();
            }
        }


        public User GetUser(Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                UserT res = null;

                foreach (var item in db.Users)
                {
                    if (item.Id == id)
                    {
                        res = item;
                    }
                }

                return DbConverter.GetUser(res);
            }
        }

        public Question GetQuestion(Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                QuestionT res = null;

                foreach (var item in db.Questions)
                {
                    if (item.Id == id)
                    {
                        res = item;
                    }
                }

                return DbConverter.GetQuestion(res);
            }
        }

        public Testing GetTestingResult(Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                TestingT res = null;

                foreach (var item in db.Testing)
                {
                    if (item.Id == id)
                    {
                        res = item;
                    }
                }

                return DbConverter.GetTesting(res);
            }
        }

        public Group GetGroup(Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                GroupT res = null;

                foreach (var item in db.Groups)
                {
                    if (item.Id == id)
                    {
                        res = item;
                    }
                }

                return DbConverter.GetGroup(res);
            }
        }

        public Test GetTest(Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                TestT res = null;

                foreach (var item in db.Tests)
                {
                    if (item.Id == id)
                    {
                        res = item;
                    }
                }

                return DbConverter.GetTest(res);
            }
        }


        public IEnumerable<User> GetUserByGroup(Guid groupId)
        {
            using (var db = new CoreDbContextV7())
            {
                var result = new List<User>();

                foreach (var user in db.Users)
                {
                    if (user.GroupId == groupId)
                    {
                        result.Add(DbConverter.GetUser(user));
                    }
                }

                return result;
            }
        }

        public IEnumerable<Question> GetQuestionByTest(Guid testId)
        {
            using (var db = new CoreDbContextV7())
            {
                var result = new List<Question>();

                foreach (var qt in db.QuestionsToTests)
                {
                    if (qt.TestId == testId)
                    {
                        result.Add(GetQuestion(qt.QuestionId));
                    }
                }

                return result;
            }
        }


        public IEnumerable<Group> GetAllGroup()
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<Group>();

                foreach (var item in db.Groups)
                {
                    res.Add(DbConverter.GetGroup(item));
                }

                return res;
            }
        }

        public IEnumerable<Test> GetAllTest()
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<Test>();

                foreach (var item in db.Tests)
                {
                    res.Add(DbConverter.GetTest(item));
                }

                return res;
            }
        }

        public IEnumerable<Question> GetAllQuestion()
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<Question>();

                foreach (var item in db.Questions)
                {
                    res.Add(DbConverter.GetQuestion(item));
                }

                return res;
            }
        }

        public IEnumerable<Question> GetQuestions(Guid testId)
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<Question>();
 
                foreach (var questionsToTest in db.QuestionsToTests)
                {
                    if (questionsToTest.TestId == testId)
                    {
                        res.Add(GetQuestion(questionsToTest.QuestionId));
                    }
                }

                return res;
            }
        }

        public bool IsAvailableGroup(Guid testId, Guid groupId)
        {
            using (var db = new CoreDbContextV7())
            {
                var res = false;

                foreach (var availableTest in db.AvailableTestToGroup)
                {
                    if (availableTest.TestId == testId && availableTest.GroupId == groupId)
                    {
                        res = true;
                    }
                }

                return res;
            }
        }

        public IEnumerable<Testing> GetAllTesting()
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<Testing>();

                foreach (var item in db.Testing)
                {
                    res.Add(DbConverter.GetTesting(item));
                }

                return res;
            }
        }

        public IEnumerable<PassingTest> GetAllPassingTest()
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<PassingTest>();

                foreach (var item in db.PassingsTest)
                {
                    res.Add(DbConverter.GetPassingTest(item));
                }

                return res;
            }
        }

        public IEnumerable<Testing> GetTesting(Guid passingTestId)
        {
            using (var db = new CoreDbContextV7())
            {
                var res = new List<Testing>();

                foreach (var item in db.Testing)
                {
                    if (item.PassingTestId == passingTestId)
                    {
                        res.Add(DbConverter.GetTesting(item));
                    }
                }

                return res;
            }
        }

        public PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date)
        {
            using (var db = new CoreDbContextV7())
            {
                var passingTest = new PassingTestT()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    TestId = testId,
                    Date = date
                };

                db.PassingsTest.Add(passingTest);

                db.SaveChanges();

                return DbConverter.GetPassingTest(passingTest);
            }
        }

        public int GetQuestionsCount(Guid testId)
        {
            using (var db = new CoreDbContextV7())
            {
                var count = 0;

                foreach (var item in db.QuestionsToTests)
                {
                    if (item.TestId == testId)
                    {
                        count++;
                    }
                }

                return count;
            }  
        }

        private TestT GetTestT(Guid testId, CoreDbContextV7 db)
        {
            TestT res = null;

            foreach (var item in db.Tests)
            {
                if (item.Id == testId)
                {
                    res = item;
                }
            }

            return res;
        }

        private QuestionT GetQuestionT(Guid questionId, CoreDbContextV7 db)
        {
            QuestionT res = null;

            foreach (var item in db.Questions)
            {
                if (item.Id == questionId)
                {
                    res = item;
                }
            }

            return res;
        }


        public void WriteToFolder(string folderPath)
        {
            DbToXmlLoader.SaveDbToFolder(this, folderPath);
        }


        public void ReadFromFolder(string folderPath)
        {
            var newUsersFolder = folderPath + "\\" + FolderNames.NewUsers;

            var newUsers = Directory.GetFiles(newUsersFolder);

            foreach (var item in newUsers)
            {
                var newUser = FileReaderHelper.ReadFromFileWithDeserialize<User>(item);

                this.AddUser(newUser.FirstName, newUser.LastName, newUser.GroupId, newUser.Id);
            }


            var newTestingFolder = folderPath + "\\" + FolderNames.NewTesting;

            var newTestings = Directory.GetFiles(newTestingFolder);

            foreach (var item in newTestings)
            {
                var newTesting = FileReaderHelper.ReadFromFileWithDeserialize<Testing>(item);

                this.AddTestingResult(newTesting.QuestionId, newTesting.ChekedAnswer, newTesting.PassingTestId, newTesting.Id);
            }


            var newPassingTestFolder = folderPath + "\\" + FolderNames.NewPassingTest;

            var newPassingTests = Directory.GetFiles(newPassingTestFolder);

            foreach (var item in newPassingTests)
            {
                var newPassingTest = FileReaderHelper.ReadFromFileWithDeserialize<PassingTest>(item);

                this.AddPassingTest(newPassingTest.UserId, newPassingTest.TestId, newPassingTest.Date, newPassingTest.Id);
            }
        }


        public User AddUser(string firstName, string lastName, Guid groupId, Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                foreach (var item in db.Users)
                {
                    if (item.Id == id)
                    {
                        return null;
                    }
                }

                var user = new UserT()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    GroupId = groupId
                };

                db.Users.Add(user);

                db.SaveChanges();

                return DbConverter.GetUser(user);
            }
        }

        public Testing AddTestingResult(Guid questionId, int checedAnswer, Guid passingTestId, Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                foreach (var item in db.Testing)
                {
                    if (item.Id == id)
                    {
                        return null;
                    }
                }

                var testing = new TestingT()
                {
                    Id = id,
                    QuestionId = questionId,
                    ChekedAnswer = checedAnswer,
                    PassingTestId = passingTestId
                };

                db.Testing.Add(testing);

                db.SaveChanges();

                return DbConverter.GetTesting(testing);
            }
        }

        public PassingTest AddPassingTest(Guid userId, Guid testId, DateTime date, Guid id)
        {
            using (var db = new CoreDbContextV7())
            {
                foreach (var item in db.PassingsTest)
                {
                    if (item.Id == id)
                    {
                        return null;
                    }
                }

                var passingTest = new PassingTestT()
                {
                    Id = id,
                    UserId = userId,
                    TestId = testId,
                    Date = date
                };

                db.PassingsTest.Add(passingTest);

                db.SaveChanges();

                return DbConverter.GetPassingTest(passingTest);
            }
        }
    }
}
