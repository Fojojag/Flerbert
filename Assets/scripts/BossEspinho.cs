using UnityEngine;

public class BossEspinho : MonoBehaviour
{
    public AudioClip espinhosfx;
    public bool playaudio;
    public bool isActive = false;
    [SerializeField] private Vector3 atarget;
    [SerializeField] private Vector3 startPoint;
    public Vector3 agoravai;
    public float chegou = 0;
    public Espinhostart espinhoMain;
    public bool thisIsFlipped = false;
    public void iniciar()
    {
        startPoint = transform.position;
        isActive = true;
        playaudio = true;


    }


    void FixedUpdate()
    {
        if (espinhoMain.isFlipped && !thisIsFlipped)
        {
            flip();
        }
        else
        if (espinhoMain.isFlipped == false && thisIsFlipped)
        {
            flip();
        }

        Vector3 atarget = new Vector3(startPoint.x, -12, 0);
        if (isActive && transform.position.y < atarget.y && chegou == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, atarget, 5);

        }

        if (isActive && transform.position.y == atarget.y && chegou == 0)
        {
            som();
            chegou = 3;
        }

        if (chegou > 0)
        {
            chegou -= Time.deltaTime;
        }

        if (isActive && transform.position.y > startPoint.y && chegou < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 5);


        }
        if (transform.position.y == startPoint.y && isActive)
        {
            isActive = false;
            chegou = 0;
            playaudio = true;
            

        }

    }
    void flip()
    {
        startPoint.x = -startPoint.x;
        thisIsFlipped = !thisIsFlipped;
    }
    void som()
    {
        if (playaudio)
        {
            AudioSource.PlayClipAtPoint(espinhosfx, transform.position, 1);
            playaudio = false;
        }
    }
}
