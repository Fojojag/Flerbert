using UnityEngine;

public class safezone : MonoBehaviour
{
    public EnemyShooter shooter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shooter.canShoot = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shooter.canShoot = true;
        }
    }
}
