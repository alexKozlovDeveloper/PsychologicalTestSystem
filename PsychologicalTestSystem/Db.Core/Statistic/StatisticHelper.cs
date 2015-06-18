using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Statistic
{
    public class StatisticHelper
    {
        private ITestingRepository _repository;

        public StatisticHelper(ITestingRepository repository)
        {
            _repository = repository;
        }

        public List<TestingChartItem> GetGroupStatistic(List<Guid> groups, Guid testId)
        {
            var res = new List<TestingChartItem>();

            var users = _repository.GetUsers(groups);

            var passingsTest = new List<PassingTest>();

            foreach (var user in users)
            {
                var pt = _repository.GetLastPassingTest(user.Id, testId);

                if (pt != null)
                {
                    passingsTest.Add(pt);                    
                }
            }

            var count = passingsTest.Count;

            var testing = new List<Testing>();

            foreach (var item in passingsTest)
            {
                if (item != null)
                {
                    testing.AddRange(_repository.GetTestings(item.Id));
                }
            }

            var mainProblem = new Dictionary<Guid, int>();
            var weakProblem = new Dictionary<Guid, int>();

            foreach (var item in testing)
            {
                var ques = _repository.GetQuestion(item.QuestionId);

                if (item.ChekedAnswer == ques.StrongProblemNumber)
                {
                    if (mainProblem.Keys.Contains(ques.Id) == false)
                    {
                        mainProblem.Add(ques.Id, 1);
                    }
                    else
                    {
                        mainProblem[ques.Id]++;
                    }
                }
                
                if (item.ChekedAnswer == ques.WeakProblemNumber)
                {
                    if (weakProblem.Keys.Contains(ques.Id) == false)
                    {
                        weakProblem.Add(ques.Id, 1);
                    }
                    else
                    {
                        weakProblem[ques.Id]++;
                    }
                }                
            }
            //[37] = {[af717668-ad2e-425b-8026-5363e85edace, 6]}
            //foreach (var item in mainProblem)
            //{
            //    var ques = _repository.GetQuestion(item.Key);

            //    int main = (item.Value * 100) / count;

            //    int weak = 0;

            //    if (weakProblem.Keys.Contains(item.Key) == true)
            //    {
            //        weak = (weakProblem[item.Key] * 100) / count;
            //    }

            //    var pers = new TestingChartItem
            //    {
            //        HighPercent = main,
            //        AveragePercent = weak,
            //        Number = ques.SortIndex
            //    };

            //    res.Add(pers);
            //}

            var allQues = _repository.GetQuestions(testId);

            foreach (var item in allQues)
            {
                var main = 0;

                if (mainProblem.Keys.Contains(item.Id) == true)
                {
                    main = (mainProblem[item.Id] * 100) / count;

                    if (main > 100)
                    {
                        main = 100;
                    }
                }

                var weak = 0;

                if (weakProblem.Keys.Contains(item.Id) == true)
                {
                    weak = (weakProblem[item.Id] * 100) / count;

                    if (weak > 100)
                    {
                        weak = 100;
                    }
                }

                var pers = new TestingChartItem
                {
                    HighPercent = main,
                    AveragePercent = weak,
                    Number = item.SortIndex
                };

                res.Add(pers);
            }

            res.Sort();

            return res;
        }
    }
}
