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
        public void NameUnitTest()
        {
            string name = "ㄆkasz";
            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidateName(name);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkowego nie jest zgodny z za這瞠niami");
        }
        [Test]
        public void SurnameUnitTest()
        {
            string surname = "Kowalski";
            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidateName(surname);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkowego nie jest zgodny z za這瞠niami");
        }
        [Test]
        public void PhoneNumberUnitTest()
        {
            string phone_number = "666999111";
            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidatePhoneNumber(phone_number);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkowego nie jest zgodny z za這瞠niami");
        }
        [Test]
        public void EmailValidateUnitTest()
        {
            string email = "emailunittest@test.pl";
            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidateEmail(email);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkowego nie jest zgodny z za這瞠niami");
        }
        [Test]
        public void PeselValidationUnitTest()
        {
            string pesel = "00010128675";
            DateTime date = new DateTime(1900,01,01); //year,month,day
            string sex = "M";

            Boolean expected_result = true;
            Boolean actual_result = Patient.ValidatePesel(pesel,date,sex);

            Assert.AreEqual(expected_result, actual_result, "Wynik testu jednostkowego nie jest zgodny z za這瞠niami");
        }
    }
}