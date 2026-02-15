using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Utilities.AssetsManagement
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string path) where T : Object => Resources.Load<T>(path);
    }
}
