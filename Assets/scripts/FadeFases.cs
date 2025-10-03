using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeFases : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    [SerializeField] public static bool fadeIn;
    [SerializeField] public bool fadeOut;
    [SerializeField] public float timeFade = 1f;
    [SerializeField] public static bool fadeinFinal;
    [SerializeField] public GameObject player;
    [SerializeField] public static bool TrocarFase;
    public float timer = 1f;

    public static void FadeIn()
    {
        fadeIn = true;
    }


    public void FadeOut()
    {
        fadeOut = true;
    }

    //primero quadro 1
    void Start()
    {
        FadeOut();
        fadeinFinal = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= 0 && canvasgroup.alpha >= 1)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SceneManager.LoadScene("Boss1");
        }


        if (fadeinFinal == true)
        {
            FadeIn();
        }


        if (fadeIn == true)
        {
            if (canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += timeFade * Time.deltaTime;
                if (canvasgroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut == true)
        {
            if (canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= timeFade * Time.deltaTime;
                if (canvasgroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }



    }

}
