using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnBecameVisible()
    {
        
            Instantiate(enemy, transform.position, transform.rotation);

    }
}
