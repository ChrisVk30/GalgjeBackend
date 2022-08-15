using GalgjeGame.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalgjeGame.Core.Tests
{
    [TestClass]
    public class Services_EncryptServiceTests
    {
        EncryptService _encryptService;
        [TestInitialize]
        public void TestInitialize()
        {
            _encryptService = new EncryptService();
        }

        [TestMethod]
        public void EncryptString_EnteringUnencryptedString_ReturnEncryptedString()
        {
            var unencryptedString = "text";
            Assert.AreNotEqual(unencryptedString, _encryptService.EncryptString(unencryptedString));
            Assert.IsNotNull(_encryptService.EncryptString(unencryptedString));
        }

        [TestMethod]
        public void DecryptString_EnteringEncryptedString_ReturnUnencryptedStringText()
        {
            var encryptedString = "t+/p61zDRu1A3Z2L3bX9loKcB9axVJFxrVMZ3NSZp6E=";
            Assert.AreNotEqual(encryptedString, _encryptService.DecryptString(encryptedString));
            Assert.AreEqual("text", _encryptService.DecryptString(encryptedString));
            Assert.IsNotNull(_encryptService.DecryptString(encryptedString));
        }
    }
}