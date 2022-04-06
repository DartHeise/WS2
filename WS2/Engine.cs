
namespace WS2
{
    public class Engine
    {
        public string Number { get; }
        public double Power { get; }
        public Engine(string number, double power)
        {
            Number = number;
            Power = power;
        }
        public string EngineInfo()
        {
            return $"Двигатель {Number} с мощностью {Power}";
        }
    }
}
