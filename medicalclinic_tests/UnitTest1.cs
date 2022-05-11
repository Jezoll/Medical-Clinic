using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using medicalclinic_back;

namespace medicalclinic_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void passwordValidationIsCorrect()
        {
            var result = RecoveryPassword.passwordValidation("Test12345!");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void tooShortPassword()
        {
            var result = RecoveryPassword.passwordValidation("Test12!");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void passwordWithoutSpecialMark()
        {
            var result = RecoveryPassword.passwordValidation("Test12345");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void passwordWithoutTheUpperCase()
        {
            var result = RecoveryPassword.passwordValidation("test12345!");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void PasswordInputsAreTheSame()
        {
            var result = RecoveryPassword.isPasswordTheSame("test", "test");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void oneInputIsDiffrentFromTheOther()
        {
            var result = RecoveryPassword.isPasswordTheSame("test", "test123");
            Assert.IsTrue(result);
        }
    }
}
