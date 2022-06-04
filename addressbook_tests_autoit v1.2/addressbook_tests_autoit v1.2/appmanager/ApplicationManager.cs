using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WinTtitle = "Free Address Book";

        private AutoItX3 aux;

        private GroupHelper groupHelper;
        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"D:\repos\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WinTtitle);
            aux.WinActivate(WinTtitle);
            aux.WinWaitActive(WinTtitle);


            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WinTtitle, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux { get { return aux; } }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

    }
}
