using System.Collections;
using UnityEngine;

public class TiroRotationEspecial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform target;
    [SerializeField] GameObject alvoEsquerda;
    [SerializeField] GameObject alvoDireita;
    [SerializeField] Transform Demonio;
    float rotatioStartTime;
    Quaternion StartRoation;
    [SerializeField] float speed = 0f;


    void Update()
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



        if (boss2.TiroAlvoAlvo == 1)
        {
            target.position = alvoEsquerda.transform.position;
            speed = 300;
            this.transform.position = alvoEsquerda.transform.position;
            boss2.TiroAlvoAlvo = 0;
            StartCoroutine(GoToCenter());
        }
        else if (boss2.TiroAlvoAlvo == 2)
        {
            target.position = alvoDireita.transform.position;
            speed = 300;
            this.transform.position = alvoDireita.transform.position;
            boss2.TiroAlvoAlvo = 0;
            StartCoroutine(GoToCenter());
            
        }
        else if (boss2.Mid == false)
        {
            speed = 1000;
        }

    }
    IEnumerator GoToCenter()
    {
        yield return new WaitForSeconds(2f);
        target.position = Demonio.position;
    }
}
