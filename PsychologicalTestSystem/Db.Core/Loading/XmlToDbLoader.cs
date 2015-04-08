using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Helpers;
using Db.Core.Repositoryes;

namespace Db.Core.Loading
{
    class XmlToDbLoader
    {
        public static void LoadTestingResultToDb(ITestingRepository repository, string filePath)
        {
            var testingResult = FileReaderHelper.ReadFromFileWithDeserialize<XmlTestingResult>(filePath);

            var user = repository.GetUser(testingResult.UserInfo.Id);

            if (user == null)
            {
                user = repository.AddUser(testingResult.UserInfo.FirstName, testingResult.UserInfo.LastName, testingResult.UserInfo.GroupId);
            }

            var passingTest = repository.AddPassingTest(user.Id, testingResult.TestId, testingResult.Date);

            foreach (var result in testingResult.TestingResults)
            {
                repository.AddTestingResult(result.QuestionId, result.ChekedAnswer, passingTest.Id);
            }
        }
    }
}
