using System;

namespace Gameplay.Common.Interfaces
{
    public interface ISwitchable
    {
        public bool IsActive { get; set; }
        public void SwitchOff();
        public void SwitchOn();
    }
}