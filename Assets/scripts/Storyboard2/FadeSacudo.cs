using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeSacudo : MonoBehaviour
{
    public Image rend;
    Color J;
    public float opacity = 0f;
    public bool shrek = false;

    void Start()
    {
        J = rend.color;
        shrek = true;
    }

    // Update is called once per frame
    void Update()
    {
        rend.color = J;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(3f);
        if(opacity <= 1 && shrek == true)
            {
                
                J.a += 0.005f;
                opacity = J.a;
            }
    }


}
