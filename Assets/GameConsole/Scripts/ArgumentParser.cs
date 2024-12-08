using System;
using System.Globalization;
using UnityEngine;

namespace GameConsole
{
    public static class ArgumentParser
    {
        public static object Parse<TValue>(string argument)
        {
            if (typeof(TValue) == typeof(string))
            {
                return argument;
            }

            if (typeof(TValue) == typeof(int))
            {
                return int.Parse(argument, CultureInfo.InvariantCulture);
            }

            if (typeof(TValue) == typeof(float))
            {
                argument = argument.Replace(',', '.');
                return float.Parse(argument, CultureInfo.InvariantCulture);
            }

            if (typeof(TValue) == typeof(decimal))
            {
                argument = argument.Replace(',', '.');
                return decimal.Parse(argument, CultureInfo.InvariantCulture);
            }

            if (typeof(TValue) == typeof(double))
            {
                argument = argument.Replace(',', '.');
                return double.Parse(argument, CultureInfo.InvariantCulture);
            }

            if (typeof(TValue) == typeof(bool))
            {
                return bool.Parse(argument);
            }

            if (typeof(TValue) == typeof(Color))
            {
                if (!argument.StartsWith('#'))
                {
                    argument = $"#{argument}";
                }

                if (ColorUtility.TryParseHtmlString(argument, out Color color))
                {
                    return color;
                }
            }

            throw new Exception("Can't parse");
        }
    }
}