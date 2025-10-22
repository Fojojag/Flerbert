using Unity.VisualScripting;
using UnityEngine;

public class bossCheck : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] public static bool TrocarFase;
    [SerializeField] public static bool fadeinFinal = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss == null)
        {
            TrocarFase = true;
            FadeFases.fadeinFinal = true;
            Debug.Log("CUCUCUCU");
        }
    }
}
