using UnityEngine;

namespace Common
{
    public class InputConfig : MonoBehaviour
    {
        public static string HorizontalAxis => "Horizontal";
        public static string VerticalAxis => "Vertical";
        public static string MouseX => "Mouse X";

        public static KeyCode AttackKey => KeyCode.Mouse0;
    }
}
