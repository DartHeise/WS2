
namespace WS2
{
    public abstract class Transport : IMovable
    {
        protected SpeedChecker speedChecker;
        public string Name { get; }
        public int MaxSpeed { get; }
        public int MinSpeed { get; } = 0;
        public int CurrentSpeed { get; private set; } = 0;

        public Transport(string name, int maxSpeed, SpeedChecker speedChecker)
        {
            this.speedChecker = speedChecker;
            Name = name;
            MaxSpeed = maxSpeed;
        }
        public virtual void ChangeSpeed(int delta)
        {
            CurrentSpeed += delta;
            speedChecker.CheckSpeedBorders(this);
            Console.WriteLine($"Текущая скорость {Name}: {CurrentSpeed} км/ч");
        }
        public abstract string PrintInfo();
    }
}
