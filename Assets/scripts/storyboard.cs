using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class storyboard : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    public float timer = 1f;
    [SerializeField] public static bool fadeIn;
    [SerializeField] public static bool fadeOut;
    [SerializeField] public static float timeFade = 5f;
    [SerializeField] Sprite[] quadros;
    Sprite newSprite;
    [SerializeField] public float numeroQuadro = 1f;


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

        //segundo quadro 2
        if (numeroQuadro == 1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+1];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 3
        if (numeroQuadro == 2f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+2];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }



        //terceiro quadro 4
        if (numeroQuadro == 3f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+3];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 5
        if (numeroQuadro == 4f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+4];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 6
        if (numeroQuadro == 5f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+5];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 7
        if (numeroQuadro == 6f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+6];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 8
        if (numeroQuadro == 7f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+7];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 9
        if (numeroQuadro == 8f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+8];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 10
        if (numeroQuadro == 9f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+9];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 11
        if (numeroQuadro == 10f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+10];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 12
        if (numeroQuadro == 11f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+11];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }


        //terceiro quadro 13
        if (numeroQuadro == 12f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+12];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }
        

        //terceiro quadro 14
        if (numeroQuadro == 13f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                if (timer <= 0)
                {
                    timer = 0.1f;
                    newSprite = quadros[+13];
                    gameObject.GetComponent<Image>().sprite = newSprite;
                    FadeIn();
                    numeroQuadro++;
                }
            }
        }



    }


}
