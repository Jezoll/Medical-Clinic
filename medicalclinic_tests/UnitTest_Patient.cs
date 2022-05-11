using NUnit.Framework;
using medicalclinic_back;
using System;

namespace medicalclinic_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PhoneNumberUnitTest()
        {
            string phone_number = "6669991110";
            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidatePhoneNumber(phone_number);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkowego nie jest zgodny z za³o¿eniami");
        }
    }
}