using UnityEngine;

public class HUD : MonoBehaviour
{
    public buster charge;
    public SpriteRenderer spr;
    public Sprite lvl0;
    public Sprite lvl1;
    public Sprite lvl2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charge.chargeLvl == 0)
        {
            spr.sprite = lvl0;
        }
        else
        if (charge.chargeLvl == 1)
        {
            spr.sprite = lvl1;
        }
        else
        if (charge.chargeLvl == 2)
        {
            spr.sprite = lvl2;
           if (charge.isCharging == false)
             {
                spr.sprite = lvl1;
            } 
        }         
    }
}
