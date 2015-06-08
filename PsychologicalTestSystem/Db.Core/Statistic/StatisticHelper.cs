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
                passingsTest.Add(_repository.GetLastPassingTest(user.Id, testId));
            }

            var testing = new List<Testing>();

            foreach (var item in passingsTest)
            {
                testing.AddRange(_repository.GetTestings(item.Id));
            }

            return res;
        }
    }
}
