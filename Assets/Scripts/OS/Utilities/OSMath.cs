using UnityEngine;

namespace OS.Utilities
{
    public static class OSMath
    {
        public static int Repeat(int value, int minValue, int maxValue)
        {
            return value > maxValue ? minValue : value < minValue ? maxValue : value;
        }
    }
}
