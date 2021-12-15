using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Util
{
    public static class LayerUtil
    {
        public static void ChangeLayer(GameObject gameObject, string layerName)
        {
            int newLayer = LayerMask.NameToLayer(layerName);
            gameObject.layer = newLayer;
            foreach (Transform child in gameObject.transform.GetComponentsInChildren<Transform>())
            {
                child.gameObject.layer = newLayer;
            }
        }
    }
}
