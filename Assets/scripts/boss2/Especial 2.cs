using UnityEngine;

public class Especial2 : MonoBehaviour
{

    [SerializeField] Transform target;
    float rotatioStartTime;
    Quaternion StartRoation;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        if (Time.time - rotatioStartTime < 100000)
        {
            Vector2 dir = target.position - transform.position;
            Quaternion targetRotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);
            transform.rotation = Quaternion.Slerp(StartRoation, targetRotation, Time.time - rotatioStartTime);
        }
        else
        {
            rotatioStartTime = Time.time;
            StartRoation = transform.rotation;
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "alvos")
        {
            Destroy(gameObject);
        }
    } 
    }

    // Update is called once per frame


