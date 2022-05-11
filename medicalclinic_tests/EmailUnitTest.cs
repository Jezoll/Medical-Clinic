using NUnit.Framework;
using medicalclinic_back;
using System;

namespace medicalclinic_tests
{
    public class Tests1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmailValidateUnitTest()
        {
            string email = "emailunittest@test.pl";
            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidateEmail(email);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkwoego nie jest zgodny z walidacj¹ maila");
        }
    }
}