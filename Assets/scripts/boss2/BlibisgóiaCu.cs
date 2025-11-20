using UnityEngine;

public class BlibisgóiaCu : MonoBehaviour
{

    [SerializeField] GameObject Boss;
    [SerializeField] GameObject ParedeDireita;
    [SerializeField] GameObject pohinha1;
    [SerializeField] GameObject pohinha2;
    [SerializeField] GameObject pohinha3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss)
        {
            
        }
        else
        {
            Destroy(ParedeDireita);
            Destroy(pohinha1);
            Destroy(pohinha2);
            Destroy(pohinha3);
        }
    }
}
