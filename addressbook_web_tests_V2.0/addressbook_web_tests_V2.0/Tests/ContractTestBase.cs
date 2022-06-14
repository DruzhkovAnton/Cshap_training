using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBookWebTests
{

    public class ContractTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContractsUi_Db()
        {
            if (PERFOR_LONG_UI_CHECKS)
            {
                List<ContractData> fromUI = app.Contract.GetContractList();
                List<ContractData> fromDB = ContractData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
