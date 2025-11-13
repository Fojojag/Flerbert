using Unity.VisualScripting;
using UnityEngine;

public class PohaDeGitHubDoKRL : MonoBehaviour
{

    [SerializeField] GameObject BossCu;
    [SerializeField] GameObject ParedeCu;
    [SerializeField] GameObject PohinhaCu1;
    [SerializeField] GameObject PohinhaCu2;
    [SerializeField] GameObject PohinhaCu3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossCu)
        {
            
        }
        else
        {
            Destroy(ParedeCu);
            Destroy(PohinhaCu1);
            Destroy(PohinhaCu2);
            Destroy(PohinhaCu3);
        }
    }
}
