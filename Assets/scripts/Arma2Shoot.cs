using UnityEngine;

public class Arma2Shoot : MonoBehaviour
{
    public float shootRate;
    private float shootTimer;
    [SerializeField] private GameObject projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            shootTimer = shootRate;
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
