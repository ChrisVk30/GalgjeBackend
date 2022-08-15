using GalgjeGame.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Tests
{
    [TestClass]
    public class Services_GameServiceTests
    {
        private Mock<IGameRepository> _mockGameRepository;
        private Mock<IWordsRepository> _mockWordRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockGameRepository = new Mock<IGameRepository>();
            _mockWordRepository = new Mock<IWordsRepository>();
        }

        [TestMethod]
        public void TestMethod()
        {

        }

    }
}
