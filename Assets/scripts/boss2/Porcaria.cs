using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Porcaria : MonoBehaviour
{
public SpriteRenderer rend;
    Color c;
    public bool isActive = false;
    [SerializeField] public GameObject target;
    [SerializeField] private Vector3 startPoint;
    public Vector3 agoravai;
    public float chegou = 0;
    public float speed;
    public bool isHorizontal;
    public float timerSumir;

    [SerializeField] Transform Rotationtarget;
    float rotatioStartTime;
    Quaternion StartRoation;
    [SerializeField] float speed2;
    public void Start()
    {
        //startPoint = transform.position;
        c = rend.color;
    }


    void Update()
    {
        rend.color = c;


        if (Time.time - rotatioStartTime < 100000)
        {
            Vector2 dir = Rotationtarget.position - transform.position;
            Quaternion targetRotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90);
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
        speed = 0;
        StartCoroutine(fadeOut());
    }
        
    
IEnumerator fadeOut()
{

    while (c.a > 0)
    {
        c.a -= Time.deltaTime;

        yield return null;
    }
}
}
