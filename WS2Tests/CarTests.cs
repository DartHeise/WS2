using Microsoft.VisualStudio.TestTools.UnitTesting;
using WS2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void ChangeSpeedFromZeroToTwentyWithMaxSpeed60()
        {
            //Arrange
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 60, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
            //Act
            car.ChangeSpeed(20);
            //Assert
            Assert.AreEqual(20, car.CurrentSpeed);
        }
        [TestMethod()]
        public void ChangeSpeedFromZeroToSeventyWithMaxSpeed60()
        {
            //Arrange
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 60, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
            //Act
            try
            {
                car.ChangeSpeed(70);
                Assert.Fail("Должно было выброситься исключение!");
            }
            //Assert
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"{car.Name} перегрелся!", ex.Message);
            }
            catch
            {
                Assert.Fail("Выброшено неизвестное исключение!");
            }
        }
        [TestMethod()]
        public void ChangeSpeedFromZeroToMinusTenWithMinSpeed0()
        {
            //Arrange
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 60, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
            //Act
            try
            {
                car.ChangeSpeed(-10);
                Assert.Fail("Должно было выброситься исключение!");
            }
            //Assert
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"{car.Name} уже остановился!", ex.Message);
            }
            catch
            {
                Assert.Fail("Выброшено неизвестное исключение!");
            }
        }
        [TestMethod()]
        public void ChangeSpeedWithDifferentWheelDiameters()
        {
            //Arrange
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 60, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 18),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 19),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
            //Act
            try
            {
                car.ChangeSpeed(20);
                Assert.Fail("Должно было выброситься исключение!");
            }
            //Assert
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Невозможно поехать: диаметры шин не совпадают", ex.Message);
            }
            catch
            {
                Assert.Fail("Выброшено неизвестное исключение!");
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
            });
            //Act
            car.ChangeWheel(1, new Wheel(WheelType.Winter, "Continental", 17));
            //Assert
            Assert.AreEqual(17, car.Wheels[1].Diameter);
        }
        [TestMethod()]
        public void ChangeWheelWithCurrentSpeedNotEqualsZero()
        {
            //Arrange
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 60, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            });
            try
            {
                //Act
                car.ChangeSpeed(20);
                car.ChangeWheel(1, new Wheel(WheelType.Winter, "Continental", 17));
                //Assert
                Assert.Fail("Должно было выброситься исключение!");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Невозможно поменять колесо: машина не остановилась", ex.Message);
            }
            catch
            {
                Assert.Fail("Выброшено неизвестное исключение!");
            }
        }
    }
}