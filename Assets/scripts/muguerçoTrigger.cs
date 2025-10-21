using UnityEngine;

public class muguerçoTrigger : MonoBehaviour
{
    public muguerço muguerçoMain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            muguerçoMain.canAttack = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            muguerçoMain.canAttack = false;
        }
    }
}
