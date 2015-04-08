using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;
using Db.Core.Tables;

namespace Db.Core.Convert
{
    static class DbConverter
    {
        public static T Convert<T, TS>(TS item) where T : new()
        {
            var result = new T();

            var fields = item.GetType().GetProperties();

            foreach (var propertyInfo in fields)
            {
                var resProp = result.GetType().GetProperty(propertyInfo.Name);

                if (propertyInfo.PropertyType == resProp.PropertyType)
                {
                    var value = propertyInfo.GetValue(item);

                    result.GetType().GetProperty(propertyInfo.Name).SetValue(result, value);
                }
            }

            return result;
        }

        public static AvailableTestToGroup GetAvailableTestToGroup(AvailableTestToGroupT item)
        {
            return Convert<AvailableTestToGroup, AvailableTestToGroupT>(item);
        }

        public static Group GetGroup(GroupT item)
        {
            return Convert<Group, GroupT>(item);
        }

        public static PassingTest GetPassingTest(PassingTestT item)
        {
            return Convert<PassingTest, PassingTestT>(item);
        }

        public static Question GetQuestion(QuestionT item)
        {
            return Convert<Question, QuestionT>(item);
        }

        public static QuestionToTest GetQuestionToTest(QuestionToTestT item)
        {
            return Convert<QuestionToTest, QuestionToTestT>(item);
        }

        public static Test GetTest(TestT item)
        {
            return Convert<Test, TestT>(item);
        }

        public static Testing GetTesting(TestingT item)
        {
            return Convert<Testing, TestingT>(item);
        }
        
        public static User GetUser(UserT item)
        {
            if (item == null)
            {
                return null;
            }

            return Convert<User, UserT>(item);
        }
    }
}
