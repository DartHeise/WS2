using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS2.Tests
{
    [TestClass()]
    public class WheelCheckerTests
    {
        [TestMethod()]
        public void DifferentWheelDiameters()
        {
            //Arrange
            var wheelChecker =new WheelChecker();
            //Act
            try
            {
                wheelChecker.CheckWheelDiameters(new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 18),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 19),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
            //Assert
                Assert.Fail("Должно было выброситься исключение!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Невозможно поехать: диаметры шин не совпадают", ex.Message);
            }
        }
        [TestMethod()]
        public void SameWheelDiameters()
        {
            //Arrange
            var wheelChecker = new WheelChecker();
            //Act
            wheelChecker.CheckWheelDiameters(new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
        }
    }
}