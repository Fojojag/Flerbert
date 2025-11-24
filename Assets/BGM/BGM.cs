using UnityEngine;
using UnityEngine.SceneManagement;
public class BGM : MonoBehaviour
{
    public static BGM Instance { get; private set; }
    public GameObject checkpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // Destroy new duplicate
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
