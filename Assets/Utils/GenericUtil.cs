using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Util
{
    public static class GenericUtil<T>
    {
        public static T GetOrDefault(T value, string name)
        {
            if (value != null)
            {
                return value;
            }

            Debug.LogError(typeof(T) + " not implemented on " + name);

            return default;
        }
    }
}