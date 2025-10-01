using UnityEngine;

public class AvisoMegaMente : MonoBehaviour
{
    public GameObject tiro;
    public GameObject tiroCair;
    public Transform boo1;
    public Transform boo2;
    public Transform boo3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inimigo")
        {
            Instantiate(tiroCair, boo1.position, boo1.rotation);
            Instantiate(tiroCair, boo2.position, boo2.rotation);
            Instantiate(tiroCair, boo3.position, boo3.rotation);
        }
    }
}
