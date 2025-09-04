using UnityEngine;

public class gunvolt : MonoBehaviour
{
        [SerializeField] private GameObject projectile;
        [SerializeField] private GameObject projectile2;
        [SerializeField] private Transform firepoint1;
        [SerializeField] private Transform firepoint2;
        [SerializeField] private Transform firepoint3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }


    void shot1()
    {
        Instantiate(projectile, firepoint1.position, firepoint1.rotation);
    }

    void shot2()
    {
        Instantiate(projectile, firepoint2.position, firepoint2.rotation);
    }

    
    void choque()
    {
        Instantiate(projectile2, firepoint3.position, firepoint3.rotation);
    }

}
