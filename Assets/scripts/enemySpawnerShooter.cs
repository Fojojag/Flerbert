using UnityEngine;

public class enemySpawnerShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;

    void Start()
    {

    }


    void Update()
    {

    }
    void OnBecameVisible()
    {

            EnemyShooter shooter = Instantiate(enemy, transform.position, transform.rotation).GetComponent<EnemyShooter>();
            shooter.InitializeShooter(player);
        
    }
}
