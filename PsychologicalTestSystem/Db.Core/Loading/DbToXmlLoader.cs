using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Helpers;
using Db.Core.Repositoryes;
using Db.Core.TableEntityes;

namespace Db.Core.Loading
{
    public class DbToXmlLoader
    {
        public static XmlTest LoadTest(ITestingRepository repository, Guid testId)
        {
            var test = repository.GetTest(testId);

            var res = new XmlTest
            {
                TestInfo = test
            };

            res.Questions.AddRange(repository.GetQuestions(test.Id));

            var groups = repository.GetAllGroup();

            foreach (var group in groups)
            {
                var isAvailable = repository.IsAvailableGroup(test.Id, group.Id);
                res.AvailableGroups.Add(new XmlTest.AvailableGroup { GroupInfo = group, IsAvailable = isAvailable });
            }

            return res;
        }

        public static XmlGroup LoadGroup(ITestingRepository repository, Guid groupId)
        {
            var group = repository.GetGroup(groupId);

            var item = new XmlGroup
            {
                GroupInfo = group
            };

            item.Users.AddRange(repository.GetUserByGroup(group.Id));

            return item;
        }

        public static void SaveDbToFolder(ITestingRepository repository, string folderPath)
        {
            if (Directory.Exists(folderPath) == false)
            {
                return;
            }

            //Tests

            var testsFolder = folderPath + @"\Tests";

            if (Directory.Exists(testsFolder) == false)
            {
                Directory.CreateDirectory(testsFolder);
            }

            var tests = repository.GetAllTest();

            foreach (var test in tests)
            {
                var xmlTest = LoadTest(repository, test.Id);

                var filePath = string.Empty;

                if (test.Name.Length <= 10)
                {
                    filePath = testsFolder + @"\" + test.Name + "_" + test.Id + ".xml";
                }
                else
                {
                    filePath = testsFolder + @"\" + test.Name.Substring(0, 10) + "_" + test.Id + ".xml";
                }

                FileReaderHelper.WriteInFileWithSerialize(xmlTest, filePath);
            }

            //Groups

            var groupsFolder = folderPath + @"\Groups";

            if (Directory.Exists(groupsFolder) == false)
            {
                Directory.CreateDirectory(groupsFolder);
            }

            var groups = repository.GetAllGroup();

            foreach (var item in groups)
            {
                var xmlGroup = LoadGroup(repository, item.Id);

                var fileName = string.Format("{0}\\{1}{2}.xml", groupsFolder, "Group", item.Id.ToString());

                FileReaderHelper.WriteInFileWithSerialize(xmlGroup, fileName);
            }
        }
    }
}
