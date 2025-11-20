using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Perereca : MonoBehaviour
{

    public Image cooldown;
    public bool coolingDown;
    public float waitTime = 30.0f;
    public float opacity = 0f;
    public bool desce = false;
    public Image rend;
    Color J;
    public bool AbreOCu = false;



    void Start()
    {
        J = rend.color;
    }

    // Update is called once per frame
    void Update()
    {

        rend.color = J;

        if (coolingDown == true)
        {
            if(cooldown.fillAmount <= 1 && desce == false)
            {
            cooldown.fillAmount += 80.0f / waitTime * Time.deltaTime;
            }
            if(cooldown.fillAmount == 1)
            {
                desce = true;
                AbreOCu = true;
            }
            
            if(cooldown.fillAmount >= 1 && desce == true)
            {
                StartCoroutine(uiui());
            }

            if(cooldown.fillAmount >= 0.3f && opacity <= 1)
            {    
                J.a -= 0.01f;
                opacity = J.a;
            }
        }
    }

    IEnumerator uiui()
    {
        yield return new WaitForSeconds(0.5f);
        cooldown.fillAmount -= 80.0f / waitTime * Time.deltaTime;
    }


}
