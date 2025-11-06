using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTriggerPlayer : MonoBehaviour
{
    [SerializeField] public static bool fadeinFinal = false;
    [SerializeField] public static bool TrocarFase;
    public float fase;
    public GameObject spawn;

    void Awake()
    {
        spawn = GameObject.Find("SpawnPlayer");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TrocarFase = true;
            FadeFases.FadeIn();
            Destroy(gameObject);
            if (fase == 1)
            {
                spawn.transform.position = new Vector3(203.2f, -9.2f, -23.5f);
            }
            if (fase == 1.5)
            {
                spawn.transform.position = new Vector3(-42.3f, 6.9f, -23.5f);
            }
             if (fase == 2.5)
            {
                spawn.transform.position = new Vector3(-40.3f, 73.4f, -23.5f);
            }
            
        }
    }

}
