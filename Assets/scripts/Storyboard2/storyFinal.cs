using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storyFinal : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    public float timer = 1f;
    [SerializeField] public static bool fadeIn;
    [SerializeField] public static bool fadeOut;
    [SerializeField] public static float timeFade = 5f;
    [SerializeField] Sprite[] quadros;
    Sprite newSprite;
    [SerializeField] public float numeroQuadro = 1f;




    public void frente()
    {
        //segundo quadro 2
        if (numeroQuadro == 1f)
        {
            FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                SceneManager.LoadScene("MenuLinguagem");
                    
                    FadeIn();
                    
                }
        }
        
    }

    public void FadeIn()
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
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasgroup.alpha == 0 && timer <= 0)
        {
            FadeIn();
        }

        if (fadeIn == true && fadeOut == true)
        {
            canvasgroup.alpha = 0;
        }


        if (timer >= 0)
            {
                timer -= Time.deltaTime;
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
