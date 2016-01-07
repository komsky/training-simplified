using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Web.Tests.Controllers
{
    [TestClass]
    public class KalkulatorTest
    {
        [TestMethod]
        public void DodaawnieTest()
        {
            //arrange
            Kalkulator mojKalkulator = new Kalkulator();

            var kalkulatorMock = new Mock<Kalkulator>();
            kalkulatorMock.Setup(x => x.Dodawanie(It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Returns(0);

            int pierwsza = 2;
            int druga = 2;
            int spodziewany = 4;
            //act

            int wynik = kalkulatorMock.Object.Dodawanie(pierwsza, druga);
            //assert

            Assert.AreEqual(spodziewany, wynik, "Błąd dodawania");
        }
    }
}
