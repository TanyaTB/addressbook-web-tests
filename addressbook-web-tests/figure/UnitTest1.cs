using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests.figure
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            double total =999;
            bool VipClient = true;
            if (total > 1000 || VipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма" + total);
            }
            else
            {
                System.Console.Out.Write("Скидки нет, общая сумма" + total);
            }
        }
    }
}
//&& или
// || и 