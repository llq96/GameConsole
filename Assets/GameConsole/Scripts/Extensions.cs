using UnityEngine;

namespace GameConsole
{
    public static class Extensions
    {
        public static string WithColor(this string str, Color color)
        {
            var colorStr = ColorUtility.ToHtmlStringRGBA(color);
            return $"<color=#{colorStr}>{str}</color>";
        }
    }
}