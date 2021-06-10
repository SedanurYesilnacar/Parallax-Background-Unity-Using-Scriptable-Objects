using System.Collections;
using UnityEngine;

namespace Parallax.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if(!instance)
                {
                    instance = FindObjectOfType<T>();
                    if(!instance)
                    {
                        instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    }
                    DontDestroyOnLoad(instance);
                }
                return instance;
            }

            private set
            {
                if(instance)
                {
                    Destroy(value.gameObject);
                    return;
                }
                instance = value;
                DontDestroyOnLoad(instance);
            }
        }

        private void Awake()
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit()
        {
            instance = null;
        }
    }
}