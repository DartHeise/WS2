using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2
{
    public interface IMovable
    {
        public const int MinSpeed = 0;
        public int MaxSpeed { get; }
        public int CurrentSpeed { get; }
        public void ChangeSpeed(int delta);
    }
}
