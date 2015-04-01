using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.TableEntityes;
using DbController.Tables;

namespace DbController.Convert
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

        public static User GetUser(UserT item)
        {
            var res = Convert<User, UserT>(item);

            return res;
        }

        public static Question GetQuestion(QuestionT item)
        {
            var res = Convert<Question, QuestionT>(item);

            return res;
        }

        public static Testing GetTesting(TestingT item)
        {
            return Convert<Testing, TestingT>(item);
        }

        public static Group GetGroup(GroupT item)
        {
            return Convert<Group, GroupT>(item);
        }

        public static Test GetTest(TestT item)
        {
            var res = Convert<Test, TestT>(item);

            //res.Questions = new List<Question>();

            //if (item.Questions != null)
            //{
            //    foreach (var question in item.Questions)
            //    {
            //        res.Questions.Add(GetQuestion(question));
            //    }
            //}

            return res;
        }
    }
}
