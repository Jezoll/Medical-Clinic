using medicalclinic_back;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace medicalclinic_tests
{
    [TestClass]
    public class EmailValidationTests
    {
        [TestMethod]
        public void EmailWithoutAt()
        {
            string email = "jan.kowalskiwp.pl";

            Assert.IsFalse(Employee.validateEmail(email), "Email posiada znak @.");
        }

        [TestMethod]
        public void EmailWithOneAt()
        {
            string email = "jan.kowalski@wp.pl";

            Assert.IsTrue(Employee.validateEmail(email), "Email nie posiada znaku @.");
           
        }

        [TestMethod]
        public void EmailWithManyAts()
        {
            string email = "jan@kowalski@wp.pl";

            Assert.IsFalse(Employee.validateEmail(email), "Email nie zawiera wielu @.");
        }

    }
}