using NUnit.Framework;

using UnityEngine;

public class Espinhostart : MonoBehaviour
{
    public BossEspinho espinho1;
    public BossEspinho espinho2;
    public BossEspinho espinho3;
    public BossEspinho espinho4;
    public BossEspinho espinho5;
    public Boss_Teste boss;
    public bool isFlipped = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void iniciar()
    {
        espinho1.iniciar();
        espinho2.iniciar();
        espinho3.iniciar();
        espinho4.iniciar();
        espinho5.iniciar();



    }

    // Update is called once per frame
    void Update()
    {
        if (boss.IsFacingRight == true && !isFlipped)
        {
            flip();
            transform.position = new Vector3(-45.2f, -31.5f, 0);

        }
        else
        if (boss.IsFacingRight == false && isFlipped)
        {
            flip();
            transform.position = new Vector3(45.2f, -31.5f, 0);

        }
    }
    void flip()
    {
        transform.Rotate(0, 180, 0);
        isFlipped = !isFlipped;
    }
}
