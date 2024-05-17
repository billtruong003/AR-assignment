using UnityEngine;

namespace AssignmentLearn
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        private static readonly object lockObj = new object();
        private static bool applicationIsQuitting = false;
        [SerializeField] private bool dontDestroyOnLoad = true; // Mặc định là true

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                        "' already destroyed on application quit." +
                        " Won't create again - returning null.");
                    return null;
                }

                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError("[Singleton] Something went really wrong " +
                                " - there should never be more than 1 singleton!" +
                                " Reopening the scene might fix it.");
                            return instance;
                        }

                        if (instance == null)
                        {
                            GameObject singleton = new GameObject();
                            instance = singleton.AddComponent<T>();
                            singleton.name = "(singleton) " + typeof(T).ToString();

                            Singleton<T> singletonComponent = singleton.GetComponent<Singleton<T>>();
                            if (singletonComponent.dontDestroyOnLoad)
                            {
                                DontDestroyOnLoad(singleton);
                            }

                            Debug.Log("[Singleton] An instance of " + typeof(T) +
                                " is needed in the scene, so '" + singleton +
                                "' was created with DontDestroyOnLoad: " + singletonComponent.dontDestroyOnLoad);
                        }
                        else
                        {
                            Debug.Log("[Singleton] Using instance already created: " +
                                instance.gameObject.name);
                        }
                    }

                    return instance;
                }
            }
        }

        public void SetDontDestroyOnLoad(bool value)
        {
            dontDestroyOnLoad = value;
        }

        protected virtual void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
}