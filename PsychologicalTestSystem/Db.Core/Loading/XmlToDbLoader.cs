using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Helpers;
using Db.Core.Repositoryes;
using System.IO;

namespace Db.Core.Loading
{
    public class XmlToDbLoader
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

        public static List<XmlTest> LoadTestsFromFolder(string folderPath)
        {
            var res = new List<XmlTest>();

            var files = Directory.GetFiles(folderPath);

            foreach (var item in files)
            {
                var test = FileReaderHelper.ReadFromFileWithDeserialize<XmlTest>(item);

                res.Add(test);
            }

            return res;
        }

        public static List<XmlGroup> LoadGroupsFromFolder(string folderPath)
        {
            var res = new List<XmlGroup>();

            var files = Directory.GetFiles(folderPath);

            foreach (var item in files)
            {
                var test = FileReaderHelper.ReadFromFileWithDeserialize<XmlGroup>(item);

                res.Add(test);
            }

            return res;
        }
    }
}
