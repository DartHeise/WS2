
namespace WS2
{
    public class WheelChecker
    {
        public void CheckWheelDiameters(Wheel[] wheels)
        {
            double wheelDiameter = wheels[0].Diameter;
            foreach (Wheel wheel in wheels)
            {
                if (wheelDiameter != wheel.Diameter)
                    throw new ArgumentException("Невозможно поехать: диаметры шин не совпадают");
            }
        }
    }
}
