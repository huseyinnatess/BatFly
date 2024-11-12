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
                _instance = FindObjectOfType<T>();
                if (_instance) return _instance;
                var newGo = new GameObject(typeof(T).Name);
                _instance = newGo.AddComponent<T>();
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}