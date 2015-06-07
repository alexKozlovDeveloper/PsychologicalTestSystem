using Db.Core.Repositoryes;
using Db.Core.TableEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdministrator.DataGridEntityes
{
    class QuestionToTestInfo
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static string GetMessage(ITestingRepository repository, QuestionToTest qtot)
        {
            var test = repository.GetTest(qtot.TestId);
            var question = repository.GetQuestion(qtot.QuestionId);

            var mes = string.Empty;

            mes += "Тест: ";

            if (test.Name.Length > 40)
            {
                mes += test.Name.Substring(0,39) + "...";
            }
            else
            {
                mes += test.Name;
            }

            mes += Environment.NewLine + "Вопрос: ";

            if (question.Message.Length > 40)
            {
                mes += question.Message.Substring(0, 39) + "...";
            }
            else
            {
                mes += question.Message;
            }

            return mes;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
