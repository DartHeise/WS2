using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS2.Tests
{
    [TestClass()]
    public class SpeedCheckerTests
    {
        [TestMethod()]
        public void CurrentSpeedEqualsSeventyWithMaxSpeed60()
        {
            //Arrange
            var car = new Car();
            //Act
            try
            {
                car.ChangeSpeed(70);
                Assert.Fail("Должно было выброситься исключение!");
            }
            //Assert
            catch (Exception ex)
            {
                Assert.AreEqual("Превышена максимальная скорость!", ex.Message);
            }
        }
        [TestMethod()]
        public void CurrentSpeedEqualsMinusTenWithMinSpeed0()
        {
            //Arrange
            var car = new Car();
            //Act
            try
            {
                car.ChangeSpeed(-10);
                Assert.Fail("Должно было выброситься исключение!");
            }
            //Assert
            catch (Exception ex)
            {
                Assert.AreEqual("Объект уже остановился!", ex.Message);
            }
        }
        [TestMethod()]
        public void ChangeWheelWithCurrentSpeedEqualsZero()
        {
            //Arrange
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 60, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 18),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            }, new SpeedChecker(), new WheelChecker());
            //Act
            car.ChangeWheel(1, new Wheel(WheelType.Winter, "Continental", 17));
            //Assert
            Assert.AreEqual(17, car.Wheels[1].Diameter);
        }
        [TestMethod()]
        public void ChangeWheelWithCurrentSpeedNotEqualsZero()
        {
            //Arrange
            var car = new Car();
            try
            {
                //Act
                car.ChangeSpeed(20);
                car.ChangeWheel(1, new Wheel(WheelType.Winter, "Continental", 17));
                //Assert
                Assert.Fail("Должно было выброситься исключение!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Невозможно поменять колесо: машина не остановилась", ex.Message);
            }
        }
    }
}