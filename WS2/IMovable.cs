
namespace WS2
{
    public interface IMovable
    {
        public int MinSpeed { get; }
        public int MaxSpeed { get; }
        public int CurrentSpeed { get; }
        public void ChangeSpeed(int delta);
    }
}
