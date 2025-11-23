using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBoss : MonoBehaviour
{

//CORPO--------------------------------------------------------------
    public Animator headAnim;
    public Animator bodyAnim;
//TENTACULOS--------------------------------------------------------------
    public Animator tentAnim1;
    public Animator tentAnim2;
    public GameObject tentacu1;
    public GameObject tentacu2;
//FIREPOINTS--------------------------------------------------------------
    public Transform firepoint;
    public Transform firepoint2Esqu;
    public Transform firepoint2Dir;
//BALAS--------------------------------------------------------------
    [SerializeField] private AudioClip balaSFX; 
    public GameObject bala;
    public GameObject bala2;
    public GameObject bala3;
    public GameObject olho;
    public GameObject linha;
//LASER--------------------------------------------------------------
    public GameObject flashLaser;
    public SpriteRenderer flashrend;
    public GameObject laser;
//FOGO--------------------------------------------------------------
    public GameObject fogo1;
    public GameObject fogo2;
    public GameObject fogo3;
//PAREDES--------------------------------------------------------------
    public GameObject paredes;
//MÃOS--------------------------------------------------------------
    public GameObject maoEsq;
    public GameObject maoDir;
    private Animator maoEsqu_Anim;
    private Animator maoDir_Anim;
    public GameObject maoAndano;
//DEDOS--------------------------------------------------------------
    public GameObject Esqu1;
    public GameObject Esqu2;
    public GameObject Esqu3;
    public GameObject Esqu4;
    public GameObject Esqu5;

    public GameObject Dir1;
    public GameObject Dir2;
    public GameObject Dir3;
    public GameObject Dir4;
    public GameObject Dir5;

//VARIAVEIS--------------------------------------------------------------
    [SerializeField] private float timer;
    private bool startTimer = false;
    public float shootRate;
    public float shootRate6;
    private bool speen = false;
    public bool podeAtacar;
    [SerializeField] private bool speen2 = false;
    [SerializeField] private bool speen3 = false;
    public float pattern1Timer;
    public float pattern1Speed;
    public float pattern2Timer;
    public float pattern6Timer;
    public float pattern2Speed;
    public float pattern5Speed;
    public float pattern6Speed;
    public int PickedMove;
    int PickedMoveIndex;
    public bool ativado = true;
   [SerializeField] private bool ataque2 = false;
    Color c;
    [SerializeField] List<int> MovePicker;
//------------------------------------------------

    void Start()
    {
        maoDir_Anim = maoDir.GetComponent<Animator>();
        maoEsqu_Anim = maoEsq.GetComponent<Animator>();

        c = flashrend.color;
        flashrend.color = c;
        c.a = 0; 
        makeList();
    }

    void FixedUpdate()
    {
        flashrend.color = c;   
        flashLaser.transform.eulerAngles = new Vector3(0f, 0f, flashLaser.transform.eulerAngles.z + 5);
        if (speen)
        {
            firepoint.eulerAngles = new Vector3(0f, 0f, firepoint.eulerAngles.z + 1);
        }
        if (speen2)
        {
            firepoint2Esqu.eulerAngles = new Vector3(0f, 0f, firepoint2Esqu.eulerAngles.z + 0.5f);
            firepoint2Dir.eulerAngles = new Vector3(0f, 0f, firepoint2Dir.eulerAngles.z - 0.5f);
        }
        if (speen3)
        {
            firepoint2Esqu.eulerAngles = new Vector3(0f, 0f, firepoint2Esqu.eulerAngles.z - 0.5f);
            firepoint2Dir.eulerAngles = new Vector3(0f, 0f, firepoint2Dir.eulerAngles.z + 0.5f);
        }
    }
    //RESETAR A LISTA -------------------------------------------------------
    void makeList()
    {
        Debug.Log("make list");
        MovePicker = new List<int>();
        for (int i = 1; i <= 7; ++i)
        {
            MovePicker.Add(i);
        }
        StartCoroutine(wait());
        return;
    }
    //ESPERAR -------------------------------------------------------
    IEnumerator wait()
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(1);
        randomMove();
    }

    //RANDOMIZAÇÃO -------------------------------------------------------
    void randomMove()
    {
        if(!ativado) return;
        Debug.Log("randomMove");

        // Return a bad card if the list wasn't made yet
        if (MovePicker == null) PickedMove = 0;

        // Return a bad card if the list is already empty
        if (MovePicker.Count <= 0)
        {
            makeList();
            return;
        }
        // Return a random card that's left and remove it so we don't pick it again
        PickedMoveIndex = Random.Range(0, MovePicker.Count);
        PickedMove = MovePicker[PickedMoveIndex];
        MovePicker.RemoveAt(PickedMoveIndex);
        StartCoroutine(Select());
        return;
    }
    //SELEÇÃO DE ATAQUE -------------------------------------------------------
    IEnumerator Select()
    {
        if(!ativado) yield break;
        if (PickedMove == 1)
        {
            headAnim.SetBool("bullet", true);
            yield return new WaitForSeconds(1);
            StartCoroutine(Pattern1());
            yield break;
        }
        else
        if (PickedMove == 2)
        {
            headAnim.SetBool("bullet", true);
            yield return new WaitForSeconds(1);
            StartCoroutine(Pattern2());
            StartCoroutine(Pattern22());
            yield break;
        }
        if (PickedMove == 3)
        {
            StartCoroutine(Pattern3());
            yield break;
        }
        if (PickedMove == 4)
        {
            headAnim.SetTrigger("laser");
            yield return new WaitForSeconds(1);
            StartCoroutine(Pattern4());
            yield break;
        }
        if (PickedMove == 5)
        {

            yield return new WaitForSeconds(1);
            StartCoroutine(Pattern5());
            yield break;
        }
        if (PickedMove == 6)
        {

            yield return new WaitForSeconds(1);
            StartCoroutine(Pattern6());
            yield break;
        }
        if (PickedMove == 7)
        {

            yield return new WaitForSeconds(1);
            StartCoroutine(Pattern7());
            yield break;
        }


    }
    //ATAQUE 1 --------------------------------------------------
    IEnumerator Pattern1()
    {
        if(!ativado) yield break;

        Debug.Log("1");
        firepoint.eulerAngles = new Vector3(0, 0, 30);
        speen = true;
        for (float i = pattern1Timer; i > 0; i--)
        {
            if (podeAtacar )
            {
                projetil2 tiro1 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro1.GetComponent<projetil2>().speed = -pattern1Speed;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro2 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro2.GetComponent<projetil2>().speed = pattern1Speed;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro3 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro3.GetComponent<projetil2>().speed = -pattern1Speed;
                tiro3.GetComponent<projetil2>().isHorizontal = true;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro4 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro4.GetComponent<projetil2>().speed = pattern1Speed;
                tiro4.GetComponent<projetil2>().isHorizontal = true;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
            }
                yield return new WaitForSeconds(shootRate);
            

        }
        headAnim.SetBool("bullet", false);
        firepoint.eulerAngles = new Vector3(0, 0, 40);
        speen = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(wait());
    }
    //ATAQUE 2 --------------------------------------------------
    IEnumerator Pattern2()
    {
        if(!ativado) yield break;
        Debug.Log("2");
        ataque2 = true;
        firepoint.eulerAngles = new Vector3(0, 0, 0);
        for (float i = pattern2Timer; i > 0; i--)
        {

            if (i == 0 || i == 40) { speen2 = true; speen3 = false; }
            if (i == 20 || i == 60) { speen2 = false; speen3 = true; }
            if (podeAtacar)
            {
            projetilbounce tiro1 = Instantiate(bala2, firepoint2Esqu.position, firepoint2Esqu.rotation).GetComponent<projetilbounce>();
            tiro1.GetComponent<projetilbounce>().speed = -pattern1Speed;
            tiro1.GetComponent<projetilbounce>().isHorizontal = true;
            AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
            projetilbounce tiro2 = Instantiate(bala2, firepoint2Dir.position, firepoint2Dir.rotation).GetComponent<projetilbounce>();
            tiro2.GetComponent<projetilbounce>().speed = pattern1Speed;
            tiro2.GetComponent<projetilbounce>().isHorizontal = true;
            AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
            }

            yield return new WaitForSeconds(shootRate);

        }
        ataque2 = false;
        headAnim.SetBool("bullet", false);
        firepoint2Esqu.eulerAngles = new Vector3(0, 0, 355);
        firepoint2Dir.eulerAngles = new Vector3(0, 0, 5);
        speen2 = false;
        speen3 = false;

        yield return new WaitForSeconds(1);
        StartCoroutine(wait());
    }
    IEnumerator Pattern22()
    {
        if(!ativado) yield break;
        float angle = 0;


        while (ataque2 == true)
        {

        if (angle == 1) { firepoint.eulerAngles = new Vector3(0f, 0f, firepoint.eulerAngles.z + 10); }
        if (angle == 2) { firepoint.eulerAngles = new Vector3(0f, 0f, firepoint.eulerAngles.z - 20); }
         yield return new WaitForSeconds(1.5f);
            if (ataque2 == true)
            {
                projetil2 tiro1 = Instantiate(bala3, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro1.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, firepoint.eulerAngles.z);
                tiro1.GetComponent<projetil2>().speed = -pattern1Speed;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro2 = Instantiate(bala3, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro2.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, firepoint.eulerAngles.z + 20);
                tiro2.GetComponent<projetil2>().speed = -pattern1Speed;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro3 = Instantiate(bala3, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
                tiro3.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, firepoint.eulerAngles.z - 20);
                tiro3.GetComponent<projetil2>().speed = -pattern1Speed;
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                angle++;
            }
            yield return null;

        }
        yield break;

    }
    //ATAQUE 3 --------------------------------------------------
    IEnumerator Pattern3()
    {
        if(!ativado) yield break;
        tentAnim1.SetBool("surgir", true);
        yield return new WaitForSeconds(1);
        tentAnim2.SetBool("surgir", true);
        yield return new WaitForSeconds(1.5f);
        tentAnim1.SetBool("surgir", false);
        tentAnim1.SetBool("attack", true);
        yield return new WaitForSeconds(1f);
        tentAnim2.SetBool("attack", true);


        tentAnim1.SetBool("surgir", false);
        tentAnim2.SetBool("surgir", false);
        yield return new WaitForSeconds(1.5f);
        tentAnim2.SetBool("attack", false);
        tentAnim1.SetBool("attack", false);
        StartCoroutine(wait());

    }

    //ATAQUE 4 --------------------------------------------------
    IEnumerator Pattern4()
    {
        if(!ativado) yield break;
        c.a = 1;
        while (c.a > 0)
        {
            c.a -= 0.07f;

            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        laser.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        fogo1.SetActive(true);
        fogo1.GetComponent<Animator>().SetBool("fogo", true);
        fogo2.SetActive(true);
        fogo2.GetComponent<Animator>().SetBool("fogo", true);
        fogo3.SetActive(true);
        fogo3.GetComponent<Animator>().SetBool("fogo", true);
        
        yield return new WaitForSeconds(2);
        headAnim.SetTrigger("laserOff");
        laser.SetActive(false);
        yield return new WaitForSeconds(1);


        fogo1.GetComponent<Animator>().SetBool("fogo", false);

        fogo2.GetComponent<Animator>().SetBool("fogo", false);

        fogo3.GetComponent<Animator>().SetBool("fogo", false);

        yield return new WaitForSeconds(1);

        fogo1.SetActive(false);
        fogo2.SetActive(false);
        fogo3.SetActive(false);

        StartCoroutine(wait());

    }
    //ATAQUE 5 --------------------------------------------------
    IEnumerator Pattern5()
    {
        if(!ativado) yield break;
        firepoint.localPosition = new Vector3(0, -17.6f, 0);
        headAnim.SetTrigger("olhar");
        GameObject avisoR = GameObject.Find("AvisoR");
        GameObject avisoL = GameObject.Find("AvisoL");
        GameObject NovoAviso = Instantiate(avisoL, avisoL.transform.position,avisoR.transform.rotation);
        NovoAviso.GetComponent<SpriteRenderer>().enabled = true;
        GameObject NovoAviso2 = Instantiate(avisoR, avisoR.transform.position,avisoR.transform.rotation);
        NovoAviso2.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1);
        paredes.GetComponent<Rigidbody2D>().gravityScale = 30;
        yield return new WaitForSeconds(0.5f);
        Destroy(NovoAviso);
        Destroy(NovoAviso2);
        yield return new WaitForSeconds(1);
        Debug.Log("5");
        firepoint.eulerAngles = new Vector3(0, 0, 0);
        for (float i = 5; i > 0; i--)
        {
            headAnim.SetTrigger("cuspe");
            while (podeAtacar == false)
            {
                yield return null;
            }
            olho tiro = Instantiate(olho, firepoint.position, Quaternion.identity).GetComponent<olho>();
            tiro.GetComponent<olho>().speed = -pattern5Speed;
            AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
            headAnim.SetTrigger("olhar");
            yield return new WaitForSeconds(1);



        }
        headAnim.SetTrigger("idle");
        paredes.GetComponent<Rigidbody2D>().gravityScale = -30;
        yield return new WaitForSeconds(1);
        headAnim.SetTrigger("idle");
        firepoint.localPosition = new Vector3(0,0, 0);
        StartCoroutine(wait());
    }


    //ATAQUE 6 --------------------------------------------------
    IEnumerator Pattern6()
    {
        if(!ativado) yield break;

        float posDir;
        float posEsqu;
        posDir = Random.Range(1, 5);
        posEsqu = Random.Range(1, 5);

        firepoint.eulerAngles = new Vector3(0, 0, 0);
        Debug.Log("6");
        maoDir_Anim.SetTrigger("tiro");
        maoEsqu_Anim.SetTrigger("tiro");
        for (float o = 3; o > 0; o--)
        {
            posDir = Random.Range(1, 5);
            posEsqu = Random.Range(1, 5);

            if (posDir == 1) { maoDir.transform.position = new Vector3(77, 64, 0); }
            if (posEsqu == 1) { maoEsq.transform.position = new Vector3(-73, 64, 0); }
            if (posDir == 2) { maoDir.transform.position = new Vector3(77, 37, 0); }
            if (posEsqu == 2) { maoEsq.transform.position = new Vector3(-73, 37, 0); }
            if (posDir == 3) { maoDir.transform.position = new Vector3(57, 58, 0); }
            if (posEsqu == 3) { maoEsq.transform.position = new Vector3(-53, 58, 0); }
            if (posDir == 4) { maoDir.transform.position = new Vector3(77, 17, 0); }
            if (posEsqu == 4) { maoEsq.transform.position = new Vector3(-73, 17, 0); }
            if (posDir == 5) { maoDir.transform.position = new Vector3(53, 35, 0); }
            if (posEsqu == 5) { maoEsq.transform.position = new Vector3(-49, 35, 0); }

            if (o == 3) { maoDir.transform.eulerAngles = new Vector3(0f, 0f, 27); }
            if (o == 3) { maoEsq.transform.eulerAngles = new Vector3(0f, 0, -27); }
            if (o == 2) { maoDir.transform.eulerAngles = new Vector3(0f, 0f, +16); }
            if (o == 2) { maoEsq.transform.eulerAngles = new Vector3(0f, 0, -16); }
            if (o == 1) { maoDir.transform.eulerAngles = new Vector3(0f, 0f, -38); }
            if (o == 1) { maoEsq.transform.eulerAngles = new Vector3(0f, 0, +38); }

            GameObject linha1 = Instantiate(linha, Esqu1.transform.position, Esqu1.transform.rotation);
            linha1.transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 117);
            GameObject linha2 = Instantiate(linha, Esqu2.transform.position, Esqu2.transform.rotation);
            linha2.transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 67);
            GameObject linha3 = Instantiate(linha, Esqu3.transform.position, Esqu3.transform.rotation);
            linha3.transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 57);
            GameObject linha4 = Instantiate(linha, Esqu4.transform.position, Esqu4.transform.rotation);
            linha4.transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 37);
            GameObject linha5 = Instantiate(linha, Esqu5.transform.position, Esqu5.transform.rotation);
            linha5.transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 22);

            GameObject linha6 = Instantiate(linha, Dir1.transform.position, Dir1.transform.rotation);
            linha6.transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 117);
            GameObject linha7 = Instantiate(linha, Dir2.transform.position, Quaternion.identity);
            linha7.transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 67);
            GameObject linha8 = Instantiate(linha, Dir3.transform.position, Quaternion.identity);
            linha8.transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 57);
            GameObject linha9 = Instantiate(linha, Dir4.transform.position, Quaternion.identity);
            linha9.transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 37);
            GameObject linha10 = Instantiate(linha, Dir5.transform.position, Quaternion.identity);
            linha10.transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 22);
            yield return new WaitForSeconds(1f);
            Destroy(linha1);
            Destroy(linha2);
            Destroy(linha3);
            Destroy(linha4);
            Destroy(linha5);
            Destroy(linha6);
            Destroy(linha7);
            Destroy(linha8);
            Destroy(linha9);
            Destroy(linha10);
            for (float i = pattern6Timer; i > 0; i--)
            {

                projetil2 tiro1 = Instantiate(bala, Esqu1.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro1.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro1.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 117);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro2 = Instantiate(bala, Esqu2.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro2.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro2.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 67);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro3 = Instantiate(bala, Esqu3.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro3.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro3.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 57);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro4 = Instantiate(bala, Esqu4.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro4.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro4.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 37);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro5 = Instantiate(bala, Esqu5.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro5.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro5.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoEsq.transform.eulerAngles.z + 22);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);

                projetil2 tiro6 = Instantiate(bala, Dir1.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro6.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro6.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 117);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro7 = Instantiate(bala, Dir2.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro7.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro7.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 67);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro8 = Instantiate(bala, Dir3.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro8.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro8.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 57);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro9 = Instantiate(bala, Dir4.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro9.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro9.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 37);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);
                projetil2 tiro10 = Instantiate(bala, Dir5.transform.position, firepoint.rotation).GetComponent<projetil2>();
                tiro10.GetComponent<projetil2>().speed = -pattern6Speed;
                tiro10.GetComponent<projetil2>().transform.eulerAngles = new Vector3(0, 0, maoDir.transform.eulerAngles.z - 22);
                AudioSource.PlayClipAtPoint(balaSFX, transform.position, 1f);

                yield return new WaitForSeconds(shootRate6);
            }


        }


        yield return new WaitForSeconds(1);
        maoDir.transform.eulerAngles = new Vector3(0f, 0f, -15.06f);
        maoEsq.transform.eulerAngles = new Vector3(0f, 0f, 15.06f);
        maoDir_Anim.SetTrigger("idle");
        maoEsqu_Anim.SetTrigger("idle");
        maoDir.transform.position = new Vector3(50.9f, 25.8f, 0);
        maoEsq.transform.position = new Vector3(-47.3f, 25.8f, 0);

        StartCoroutine(wait());
    }
//ATAQUE 7 --------------------------------------------------
    IEnumerator Pattern7()
    {
        maoDir.transform.position = new Vector3(250.9f, 25.8f, 0);
        maoEsq.transform.position = new Vector3(-247.3f, 25.8f, 0);
        yield return new WaitForSeconds(1);
        firepoint.position = new Vector3(-124.4f, 2.1f, 0f);
        Enemybase mao1 = Instantiate(maoAndano, firepoint.position, firepoint.rotation).GetComponent<Enemybase>();
        mao1.GetComponent<Enemybase>().speed = 150;

        yield return new WaitForSeconds(1);

        firepoint.position = new Vector3(124.4f, 2.1f, 0f);
        Enemybase mao2 = Instantiate(maoAndano, firepoint.position, firepoint.rotation).GetComponent<Enemybase>();
        mao2.GetComponent<Enemybase>().transform.eulerAngles = new Vector3(0, 180, 0);
        mao2.GetComponent<Enemybase>().speed = -150;
        firepoint.position = new Vector3(0.5f, 57.9625f, 0f);
        yield return new WaitForSeconds(3);
        maoDir.transform.position = new Vector3(50.9f, 25.8f, 0);
        maoEsq.transform.position = new Vector3(-47.3f, 25.8f, 0);


        StartCoroutine(wait());
    }

    public void attackControl(bool trigger)
    {
        podeAtacar = trigger;
    }
}
