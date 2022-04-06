
namespace WS2
{
    public class SpeedChecker
    {
        public void CheckSpeedBorders(IMovable movable)
        {
            if (movable.CurrentSpeed > movable.MaxSpeed)
                throw new ArgumentException("Превышена максимальная скорость!");
            else if (movable.CurrentSpeed < movable.MinSpeed)
                throw new ArgumentException("Объект уже остановился!");
        }

        public bool IsCurrentSpeedEqualsZero(IMovable movable)
        {
            return movable.CurrentSpeed == 0;
        }
    }
}
