using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Convert;
using DbController.TableEntityes;
using DbController.Tables;
using DbController.Tables.Context;

namespace DbController.Repositoryes
{
    public class TestingRepository : ITestingRepository
    {
        public User AddUser(string firstName, string lastName, Guid groupId)
        {
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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

        public Testing AddTestingResult(Guid userId, Guid questionId, int checedAnswer)
        {
            using (var db = new TestingDbContext7())
            {
                var testing = new TestingT()
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questionId,
                    UserId = userId,
                    ChekedAnswer = checedAnswer
                };

                db.Testing.Add(testing);

                db.SaveChanges();

                return DbConverter.GetTesting(testing);
            }
        }

        public Group AddGroup(string number)
        {
            using (var db = new TestingDbContext7())
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
        
        public Test AddTest(string name)
        {
            using (var db = new TestingDbContext7())
            {
                var test = new TestT()
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };

                db.Tests.Add(test);

                db.SaveChanges();

                return DbConverter.GetTest(test);
            }
        }

        public void AddQuestionToTest(Guid questionId, Guid testId)
        {
            using (var db = new TestingDbContext7())
            {
                var qt = new QuestionToTestT
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questionId,
                    TestId = testId
                };

                db.QuestionsToTests.Add(qt);
            }
        }


        public User GetUser(Guid id)
        {
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
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
            using (var db = new TestingDbContext7())
            {
                var res = new List<Test>();

                foreach (var item in db.Tests)
                {
                    res.Add(DbConverter.GetTest(item));
                }

                return res;
            }
        }


        private TestT GetTestT(Guid testId, TestingDbContext7 db)
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

        private QuestionT GetQuestionT(Guid questionId, TestingDbContext7 db)
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
    }
}
