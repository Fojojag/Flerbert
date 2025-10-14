using UnityEngine;

public class triggersombra : MonoBehaviour
{
    public sombra sombraMain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sombraMain.isActive = true;
        }

    }
}
