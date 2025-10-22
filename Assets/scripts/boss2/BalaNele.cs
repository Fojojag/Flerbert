using Unity.VisualScripting;
using UnityEngine;

public class BalaNele : MonoBehaviour
{

    [SerializeField] GameObject EvilTiroRight;
    [SerializeField] GameObject EvilTiroLeft;
    public boss2 BossPosition;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fuzilamento()
    {
        if (BossPosition.Right == true)
        {
            Instantiate(EvilTiroRight, transform.position, EvilTiroRight.transform.rotation);
        }
        else if (BossPosition.Left == true)
        {
            Instantiate(EvilTiroLeft, transform.position, EvilTiroLeft.transform.rotation);

        }
    }
    

}
