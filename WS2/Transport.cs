using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2
{
    public abstract class Transport : IMovable
    {
        public string Name { get; }
        public int MaxSpeed { get; }
        public int CurrentSpeed { get; private set; } = 0;

        public Transport(string name, int maxSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
        }

        public virtual void ChangeSpeed(int delta)
        {
            CurrentSpeed += delta;
            SpeedChecker(CurrentSpeed);
            Console.WriteLine($"Текущая скорость {Name}: {CurrentSpeed} км/ч");
        }
        private void SpeedChecker(int currentSpeed)
        {
            if (currentSpeed > MaxSpeed)
                throw new ArgumentException($"{Name} перегрелся!");
            else if (currentSpeed < IMovable.MinSpeed)
                throw new ArgumentException($"{Name} уже остановился!");
        }
        public abstract string PrintInfo();
    }
}
