using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2
{
    public class Car : Transport
    {
        public Engine Engine { get; }
        public Wheel[] Wheels { get; }
        public Car(Engine engine, string name, int maxSpeed, Wheel[] wheels) : base(name, maxSpeed)
        {
            Engine = new Engine(engine.Number, engine.Power);
            Wheels = new Wheel[wheels.Length];
            for (int i = 0; i < Wheels.Length; i++)
                Wheels[i] = new Wheel(wheels[i].WheelType, wheels[i].Model, wheels[i].Diameter);
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
            WheelChecker();
            base.ChangeSpeed(delta);
        }
        private void WheelChecker()
        {
            double wheelDiameter = Wheels[0].Diameter;
            foreach (Wheel wheel in Wheels)
            {
                if (wheelDiameter != wheel.Diameter)
                    throw new ArgumentException("Невозможно поехать: диаметры шин не совпадают");
            }
        }

        public void ChangeWheel(int currentWheelIndex, Wheel newWheel)
        {
            if (CurrentSpeed != 0)
                throw new ArgumentException("Невозможно поменять колесо: машина не остановилась");
            Console.WriteLine("Замена колеса...");
            Wheels[currentWheelIndex] = new Wheel(newWheel.WheelType, newWheel.Model, newWheel.Diameter);
            Console.WriteLine("Колесо успешно заменено");
        }
    }
}
