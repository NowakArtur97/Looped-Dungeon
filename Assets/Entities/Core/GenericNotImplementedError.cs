using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public static class GenericNotImplementedError<T>
    {
        public static T TryGet(T value, string name)
        {
            if (value != null)
            {
                return value;
            }

            return default;
        }
    }
}