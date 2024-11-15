using UnityEngine;

namespace Runtime.MonoSingleton
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance) return _instance;
                _instance = FindFirstObjectByType(typeof(T)) as T;
                return _instance;
            }
        }
    }
}