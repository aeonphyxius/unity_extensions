using UnityEngine;

namespace DimensionDrive.Core
{
    public class SingletonAsComponent<T> : MonoBehaviour where T : SingletonAsComponent<T>
    {
        private static T instance;

        protected static SingletonAsComponent<T> SingletonInstance
        {
            get
            {
                if (!instance)
                {
                    T[] managers = FindObjectsOfType(typeof(T)) as T[];

                    if (managers != null)
                    {
                        if (managers.Length == 1)
                        {
                            instance = managers[0];
                            return instance;
                        }
                        else if (managers.Length > 1)
                        {
                            Debug.LogError("Already one singleton of " + typeof(T).Name + " in this scene. Only 1 singleton at the time :)");
                            for (int i = 0; i < managers.Length; ++i)
                            {
                                T manager = managers[i];
                                Destroy(manager.gameObject);
                            }
                        }
                    }

                    GameObject go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                    DontDestroyOnLoad(instance.gameObject);
                }
                return instance;
            }

            set
            {
                instance = value as T;
            }
        }
    }
}
