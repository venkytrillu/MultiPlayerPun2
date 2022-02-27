using UnityEngine;

public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    [SerializeField] private bool IsDontDestroyOnLoad = false;
    private static T instance;
    public static T Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<T> ();
                if (instance == null) {
                    GameObject obj = new GameObject ();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }
 
    public virtual void Awake ()
    {
        if (instance == null) {
            instance = this as T;
            if (IsDontDestroyOnLoad)
            {
                DontDestroyOnLoad (this.gameObject);
            }
        } else {
            Destroy (gameObject);
        }
    }
}     

