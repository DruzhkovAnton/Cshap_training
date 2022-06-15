using NUnit.Framework;
using System;
using System.Text;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFOR_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomNumericString(int max)
        {
            StringBuilder builder = new StringBuilder();
            Char[] pwdChars = new Char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < max; i++)
            {
                builder.Append(pwdChars[rnd.Next(0, 9)]);
            }
            return builder.ToString();
        }
    }
}
