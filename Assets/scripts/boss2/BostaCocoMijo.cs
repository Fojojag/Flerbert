using UnityEngine;

public class BostaCocoMijo : MonoBehaviour
{

    [SerializeField] GameObject paredeCu;
    [SerializeField] GameObject BossPito;
    [SerializeField] GameObject caralinho1;
    [SerializeField] GameObject caralinho2;
    [SerializeField] GameObject caralinho3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossPito)
        {

        }
        else
        {
            Destroy(paredeCu);
            Destroy(caralinho1);
            Destroy(caralinho2);
            Destroy(caralinho3);
        }
    }
}
