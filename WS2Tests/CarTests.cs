using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS2.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void ChangeSpeedFromZeroToTwentyWithMaxSpeed60()
        {
            //Arrange
            var car = new Car();
            //Act
            car.ChangeSpeed(20);
            //Assert
            Assert.AreEqual(20, car.CurrentSpeed);
        }
        [TestMethod()]
        public void ChangeSpeedFromZeroToMaxSpeed()
        {
            //Arrange
            var car = new Car();
            //Act
            car.ChangeSpeed(60);
            //Assert
            Assert.AreEqual(60, car.CurrentSpeed);
        }
        [TestMethod()]
        public void ChangeSpeedFromZeroToMinSpeed()
        {
            //Arrange
            var car = new Car();
            //Act
            car.ChangeSpeed(0);
            //Assert
            Assert.AreEqual(0, car.CurrentSpeed);
        }
    }
}