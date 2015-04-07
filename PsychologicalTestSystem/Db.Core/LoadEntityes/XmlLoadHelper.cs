using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Repositoryes;

namespace Db.Core.LoadEntityes
{
    class XmlLoadHelper
    {
        public static TestXml LoadTestFromDb(ITestingRepository repository, Guid testId)
        {
            var test = repository.GetTest(testId);

            var res = new TestXml
            {
                Name = test.Name,
                Id = test.Id
            };

            res.Questions.AddRange(repository.GetQuestions(test.Id));

            return res;
        }

        public static void LoadTestingResultToDb(ITestingRepository repository, TestXml result)
        {

        }
    }
}
