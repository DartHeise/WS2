
namespace WS2
{
    public enum WheelType
    {
        Winter,
        Summer
    }
    public class Wheel
    {
        public WheelType WheelType { get; }
        public string Model { get; }
        public double Diameter { get; }
        public Wheel(WheelType wheelType, string model, double diameter)
        {
            WheelType = wheelType;
            Model = model;
            Diameter = diameter;
        }
        public string WheelInfo()
        {
            string type = WheelType == WheelType.Winter ? "Зимнее" : "Летнее";
            return $"{type} колесо модели {Model} с диаметром {Diameter} метров";
        }
    }
}
