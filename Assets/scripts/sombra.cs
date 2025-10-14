using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class sombra : MonoBehaviour
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
    public void Start()
    {
        startPoint = transform.position;
        c = rend.color;
    }


    void FixedUpdate()
    {
        rend.color = c;

        if (!isHorizontal)

        {
            Vector3 atarget = new Vector3(startPoint.x, target.transform.position.y, 0);
            if (isActive && transform.position.y < target.transform.position.y && chegou == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, atarget, speed);

            }

            if (isActive && transform.position.y == atarget.y && chegou == 0)
            {

                chegou = 3;
            }
        }

        if (isHorizontal)

        {
            Vector3 atarget = new Vector3(target.transform.position.x, startPoint.y, 0);
            if (isActive && transform.position.x != target.transform.position.x && chegou == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, atarget, speed);

            }

            if (isActive && transform.position.x == atarget.x && chegou == 0)
            {

                chegou = 3;
            }
        }

        if (chegou > 0)
        {
            chegou -= Time.deltaTime;
        }

        if (chegou < 0)
        {
            StartCoroutine(fadeOut());


        }
        if (c.a <= 0)
        {
            Destroy(gameObject);
        }


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
