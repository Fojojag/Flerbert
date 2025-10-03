using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTriggerPlayer : MonoBehaviour
{
    [SerializeField] public static bool fadeinFinal = false;
    [SerializeField] public static bool TrocarFase;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TrocarFase = true;
            FadeFases.FadeIn();
            Destroy(gameObject);
            
        }
    }

}
