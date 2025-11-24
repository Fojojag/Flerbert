using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeFases : MonoBehaviour
{
    public GameObject BGM;
    public GameObject spawn;
    public CanvasGroup canvasgroup;
    [SerializeField] public static bool fadeIn;
    [SerializeField] public bool fadeOut;
    [SerializeField] public float timeFade = 1f;
    [SerializeField] public static bool fadeinFinal;
    [SerializeField] public GameObject player;
    [SerializeField] public static bool TrocarFase;
    public float stage; //0 = reload, 1 = fase 1, 1.5 = boss 1, 2 = fase 2, 2.5 = boss 2, 3 = boss 3
    public float timer = 1f;

    void Awake()
    {
        FadeOut();
    }
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
            Destroy(spawn);
            if (stage == 0)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (stage == 1)
            {
                
                SceneManager.LoadScene("Fase1");
                
            }
            if (stage == 1.5)
            {
                Destroy(BGM);
                SceneManager.LoadScene("Boss1");
                
            }
            if (stage == 2)
            {
                Destroy(BGM);
                SceneManager.LoadScene("Stroryboard2");
                
            }
            if(stage == 2.5) 
            {
                Destroy(BGM);  
                SceneManager.LoadScene("Boss2");
                
            }
            if(stage == 3)
            {
                Destroy(BGM);
                SceneManager.LoadScene("BossFinal");
                
            }

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
                canvasgroup.alpha -= timeFade * Time.deltaTime/1.5f;
                if (canvasgroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }



    }

}
