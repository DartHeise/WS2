
namespace WS2
{
    public class Program
    {
        static void Main()
        {
            var car = new Car
            (new Engine("5673A5", 272), "BMW X5", 160, new Wheel[]
            {
                new Wheel(WheelType.Winter, "Continental", 18),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17),
                new Wheel(WheelType.Winter, "Continental", 17)
            }, new SpeedChecker(), new WheelChecker());

            Console.WriteLine(car.PrintInfo());

            car.ChangeWheel(0, new Wheel(WheelType.Winter, "Continental", 17));

            for (int i = 0; i < 5; i++)
            {
                car.ChangeSpeed(20);
            }
        }
    }
}
