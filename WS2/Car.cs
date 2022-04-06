using System.Text;

namespace WS2
{
    public class Car : Transport
    {
        protected WheelChecker wheelChecker;
        public Engine Engine { get; }
        public Wheel[] Wheels { get; }
        public Car(Engine engine, string name, int maxSpeed, Wheel[] wheels, SpeedChecker speedChecker, WheelChecker wheelChecker) : base(name, maxSpeed, speedChecker)
        {
            this.wheelChecker = wheelChecker;
            Engine = new Engine(engine.Number, engine.Power);
            Wheels = new Wheel[wheels.Length];
            for (int i = 0; i < Wheels.Length; i++)
                Wheels[i] = new Wheel(wheels[i].WheelType, wheels[i].Model, wheels[i].Diameter);
        }
        public Car() : base("BMW X5", 60, new SpeedChecker())
        {
            wheelChecker =  new WheelChecker();
            Engine = new Engine("5673A5", 272);
            Wheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
                Wheels[i] = new Wheel(WheelType.Winter, "Continental", 17);
        }
        public override string PrintInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Автомобиль {Name}");
            stringBuilder.AppendLine($"Максимальная скорость автомобиля: {MaxSpeed}");
            stringBuilder.AppendLine($"Текущая скорость автомобиля: {CurrentSpeed}");
            stringBuilder.AppendLine(Engine.EngineInfo());
            for (int i = 0; i < Wheels.Length; i++)
            {
                stringBuilder.AppendLine($"{i + 1} колесо: {Wheels[i].WheelInfo()}");
            }
            return stringBuilder.ToString(); ;
        }

        public override void ChangeSpeed(int delta)
        {
            wheelChecker.CheckWheelDiameters(Wheels);
            base.ChangeSpeed(delta);
        }

        public void ChangeWheel(int currentWheelIndex, Wheel newWheel)
        {
            if (!speedChecker.IsCurrentSpeedEqualsZero(this))
                throw new ArgumentException("Невозможно поменять колесо: машина не остановилась");
            Console.WriteLine($"Замена {currentWheelIndex + 1}-го колеса...");
            Wheels[currentWheelIndex] = new Wheel(newWheel.WheelType, newWheel.Model, newWheel.Diameter);
            Console.WriteLine("Колесо успешно заменено");
        }
    }
}
