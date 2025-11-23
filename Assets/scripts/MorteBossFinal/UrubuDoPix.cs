using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UrubuDoPix : MonoBehaviour
{
    public Image rend;
    Color J;
    public Image cooldown;
    public bool coolingDown;
    public float waitTime = 30.0f;
    public float opacity = 0f;
    public float ue;
    public Perereca uiui;

    void Start()
    {
        J = rend.color;
    }

    // Update is called once per frame
    void Update()
    {
        rend.color = J;

        if (coolingDown == true && uiui.AbreOCu == true)
        {
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount += ue / waitTime * Time.deltaTime;
            if(cooldown.fillAmount >= 0.3f && opacity <= 1)
            {
                
                J.a += 0.005f;
                opacity = J.a;
            }
        }
        if (opacity >= 1)
        {
            SceneManager.LoadScene("StroryFinal");
        }
    }


}
