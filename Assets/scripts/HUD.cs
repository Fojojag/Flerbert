using UnityEngine;

public class HUD : MonoBehaviour
{
    public RectTransform hud;
    public buster charge;
    public SpriteRenderer spr;
    public Sprite lvl0;
    public Sprite lvl1;
    public Sprite lvl2;
    public GameObject olhos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charge.chargeLvl == 0)
        {
             olhos.transform.position = new Vector3 (olhos.transform.position.x, transform.position.y +1, olhos.transform.position.z );
            spr.sprite = lvl0;
        }
        else
        if (charge.chargeLvl == 1)
        {
            olhos.transform.position = new Vector3 (olhos.transform.position.x, transform.position.y + 1.7f, olhos.transform.position.z );
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
