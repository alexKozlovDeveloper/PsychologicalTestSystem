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
    class TestingRepository : ITestingRepository
    {
        public void AddUser(string firstName, string lastName, string groupNumber)
        {
            using (var db = new TestingDbContext())
            {
                UserT user = new UserT()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    GroupNumber = groupNumber
                };

                db.Users.Add(user);

                db.SaveChanges();
            }            
        }

        public void AddQuestion(string message, string firstAnswer, string secondAnswer, 
            string thirdAnswer, string firstReportMessage, string secondReportMessage, string thirdReportMessage)
        {
            using (var db = new TestingDbContext())
            {
                QuestionT question = new QuestionT()
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
            }
        }

        public void AddTestingResult(Guid userId, Guid questionId, int checedAnswer)
        {
            using (var db = new TestingDbContext())
            {
                TestingT testing = new TestingT()
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questionId,
                    UserId = userId,
                    ChekedAnswer = checedAnswer
                };

                db.Testing.Add(testing);

                db.SaveChanges();
            }
        }

        public Question GetQuestion(Guid id)
        {
            using (var db = new TestingDbContext())
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

        public Testing GetTesting(Guid id)
        {
            using (var db = new TestingDbContext())
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

        public User GetUser(Guid id)
        {
            using (var db = new TestingDbContext())
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
    }
}
