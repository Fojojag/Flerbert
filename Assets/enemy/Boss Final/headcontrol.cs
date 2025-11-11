using UnityEngine;

public class headcontrol : MonoBehaviour
{
    public FinalBoss bossScript;
    public bool podeAtacar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void attackStart()
    {
        podeAtacar = true;
        bossScript.attackControl(podeAtacar);
    }
        void attackEnd()
    {
        podeAtacar = false;
        bossScript.attackControl(podeAtacar);
    }
}
