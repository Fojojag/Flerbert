using System.Collections;
using UnityEngine;
using System.Collections.Generic;



public class boss2 : MonoBehaviour
{

    
    public Renderer rend;
    public Animator bossAnim;
    //Scripts para atirar no boss
    public BalaNele balaNele1;
    public BalaNele balaNele2;
    public BalaNele balaNele3;
    public BalaNele balaNele4;
    public BalaNele balaNele5;

    //Tiros que ele spawna
    [SerializeField] GameObject tiro;
    [SerializeField] GameObject tiro2;
    [SerializeField] GameObject tiro3;
    [SerializeField] GameObject tiro4;
    [SerializeField] GameObject tiro5;
    [SerializeField] GameObject spawner;

    //Posição dele
    public bool IsFacingRight = false;
    [SerializeField] public bool Left = false;
    [SerializeField] public bool Right = true;
    public static bool Mid = false;
    [SerializeField] Transform Esquerda;
    [SerializeField] Transform Direita;
    [SerializeField] Transform Meio;
    bool podeTrocar;
    private float TimerTrocaPosition = 0.5f;
    [SerializeField] Transform Baixo;

    //Tiros dele
    private float TimerTiros = 2f;
    bool podeAtirar;

    //Laser dele
    [SerializeField] GameObject flash;
    [SerializeField] Transform boss;
    [SerializeField] Transform LaserEscondido;
    [SerializeField] GameObject Laser;
    [SerializeField] private float anguloZ;
    [SerializeField] Transform player;
    [SerializeField] private float TimerSpawnLaser = 2f;
    [SerializeField] private float TimerVoltaLaser = 0.7f;
    private bool LiberaçãoLaser = false;
    public static float TiroAlvoAlvo;
    [SerializeField] Transform AlvoLaserEsquerda;
    [SerializeField] Transform AlvoLaserDireita;

    //Sombras Horizontal Direita
    [SerializeField] GameObject Sombra1;
    [SerializeField] Transform PositionSombra1;
    [SerializeField] GameObject Sombra2;
    [SerializeField] Transform PositionSombra2;
    [SerializeField] GameObject Sombra3;
    [SerializeField] Transform PositionSombra3;

    //Sombras Horizontal Esquerda
    [SerializeField] GameObject Sombra6;
    [SerializeField] Transform PositionSombra6;
    [SerializeField] GameObject Sombra5;
    [SerializeField] Transform PositionSombra5;
    [SerializeField] GameObject Sombra4;
    [SerializeField] Transform PositionSombra4;

    //Sombras do krl
    [SerializeField] GameObject SombraBaixo;
    [SerializeField] Transform PositionBaixo;
    [SerializeField] GameObject SombraCima;
    [SerializeField] Transform PositionCima;
    [SerializeField] GameObject SombraDoKrl;
        [SerializeField] GameObject SombraH;
    [SerializeField] Transform DiagDir;
    [SerializeField] Transform DiagEsq;

    //Config pros ataques auto
    [SerializeField] float TimerAtaques = 0;
    [SerializeField] int ataqueSelecionado;
    int PickedMoveIndex;
    [SerializeField] List<int> MovePicker;
    private bool podeUsarLaser;

public float filhadaputa;
    public bool speen;
    public bool speen2;
    void Start()
    {

        
        podeTrocar = false;
        podeAtirar = false;
        Mid = false;
        makeList();
    }
    //RESETAR A LISTA -------------------------------------------------------
    void makeList()
    {
        Debug.Log("make list");
        MovePicker = new List<int>();
        for (int i = 1; i <= 4; ++i)
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
        yield return new WaitForSeconds(2);
        randomMove();
    }
    //RANDOMIZAÇÃO -------------------------------------------------------
    void randomMove()
    {
        
        Debug.Log("randomMove");

        // Return a bad card if the list wasn't made yet
        if (MovePicker == null) ataqueSelecionado = 0;

        // Return a bad card if the list is already empty
        if (MovePicker.Count <= 0)
        {
            makeList();
            return;
        }
        // Return a random card that's left and remove it so we don't pick it again
        PickedMoveIndex = Random.Range(0, MovePicker.Count);
        ataqueSelecionado = MovePicker[PickedMoveIndex];
        MovePicker.RemoveAt(PickedMoveIndex);
        StartCoroutine(Select());
        return;
    }
    //SELEÇÃO DE ATAQUE -------------------------------------------------------
    IEnumerator Select()
    {

        if (ataqueSelecionado == 1)
        {

            yield return new WaitForSeconds(1);
            StartCoroutine(SombraHoriz());
            yield break;
        }
        else
        if (ataqueSelecionado == 2)
        {

            yield return new WaitForSeconds(1);
           Explosion();
            yield break;
        }
        if (ataqueSelecionado == 3)
        {
            StartCoroutine(AtaqueLaser());
            yield break;
        }
        if (ataqueSelecionado == 4)
        {

            yield return new WaitForSeconds(1);
            StartCoroutine(AtaqueFinal());
            yield break;
        }

    }

    void FixedUpdate()
    {
        
        filhadaputa = Laser.transform.localEulerAngles.z;
        if (speen && filhadaputa < 131 && podeUsarLaser)
        {
        Laser.transform.eulerAngles = new Vector3(0, 0, Laser.transform.eulerAngles.z -1.5f);
        flash.transform.eulerAngles = new Vector3(0, 0, flash.transform.eulerAngles.z +6f);
        }
        else
        if (speen && filhadaputa > 131)
        {
            speen = false;
            speen2 = true;
            Laser.SetActive(false);
            Laser.transform.eulerAngles = new Vector3(0, 0, 40);
        }
        if (speen2 && filhadaputa < 360 && filhadaputa > 3)
        {
            Laser.SetActive(true);
            flash.transform.eulerAngles = new Vector3(0, 0, flash.transform.eulerAngles.z -6f);
            Laser.transform.eulerAngles = new Vector3(0, 0, Laser.transform.eulerAngles.z +1.5f);
        }
        else
        if (speen2 && filhadaputa < 360 && filhadaputa < 3)
        {
            Laser.SetActive(false);
            speen2 = false;
            Laser.transform.eulerAngles = new Vector3(0, 0, -50);
            StartCoroutine(laserOff());
            podeUsarLaser = false;

        }

        if (transform.position.x >= player.transform.position.x && IsFacingRight && !Mid)
                {
                    //olhando pra esquerda
                    flip();
                }
                if (transform.position.x <= player.transform.position.x && !IsFacingRight && !Mid)
                {
                    //olhando pra direita
                    flip();
                }

        

        float DistanceLeft = Vector3.Distance(AlvoLaserEsquerda.position, player.transform.position);
        float DistanceRight = Vector3.Distance(AlvoLaserDireita.position, player.transform.position);
        //Angulo z do laser :)
        anguloZ = Laser.transform.rotation.z;


        if(TimerVoltaLaser <= 0)
        {
            TimerSpawnLaser = 2;
            Laser.transform.position = LaserEscondido.position;
        }
        
        if(TimerSpawnLaser <= 0)
            { 
            Laser.transform.position = boss.position;
            LiberaçãoLaser = false; 
            TimerVoltaLaser -= Time.deltaTime; 
            }











        //Timers
        if(TimerSpawnLaser >= 0 && LiberaçãoLaser == true)
        {
            TimerSpawnLaser -= Time.deltaTime;
        }
        if (TimerTiros >= 0 && podeAtirar == true)
        {
            TimerTiros -= Time.deltaTime;
        }
        if (TimerTrocaPosition >= 0 && podeTrocar == true)
        {
            TimerTrocaPosition -= Time.deltaTime;
        }
        if(TimerAtaques >= 0 || ataqueSelecionado == 0)
        {
            TimerAtaques -= Time.deltaTime;
        }



        if (TimerTrocaPosition <= 0)
        {
            podeTrocar = false;
            TimerTrocaPosition = 0.5f;
            if (Left == true)
            {
                podeAtirar = true;
                Right = true;
                Left = false;
                
                StartCoroutine(TiroRight());
            }
            else if (Right == true)
            {
                podeAtirar = true;
                Left = true;
                Right = false;
                
                StartCoroutine(TiroLeft());
            }
        }


        
    }
    //Sombra Horizontal
    IEnumerator SombraHoriz()
    {
        GameObject avisoR = GameObject.Find("AvisoR");
        GameObject linhaR = GameObject.Find("linhaR");
        GameObject avisoL = GameObject.Find("AvisoL");
        GameObject linhaL = GameObject.Find("linhaL");
        if (Right == true )
        {
            
            bossAnim.SetBool("idle", false);
            bossAnim.SetBool("entrar", true);
            yield return new WaitForSeconds(1);
            GameObject NovoAviso = Instantiate(linhaR, avisoR.transform.position,avisoR.transform.rotation);
            
            yield return new WaitForSeconds(0.15f);
            Instantiate(Sombra2, PositionSombra2.position, Sombra2.transform.rotation);
             yield return new WaitForSeconds(0.15f);
            Instantiate(Sombra2, PositionSombra2.position, Sombra2.transform.rotation);
             yield return new WaitForSeconds(0.3f);
             Destroy(NovoAviso);
            boss.transform.position = Baixo.position;
            StartCoroutine(subir());

        }
        else
        if (Left == true)
        {

            bossAnim.SetBool("idle", false);
            bossAnim.SetBool("entrar", true);
            yield return new WaitForSeconds(1);
            GameObject NovoAviso = Instantiate(linhaL, avisoL.transform.position,avisoL.transform.rotation);
            
            yield return new WaitForSeconds(0.15f);
            Instantiate(Sombra5, PositionSombra5.position, Sombra5.transform.rotation);
             yield return new WaitForSeconds(0.15f);
            Instantiate(Sombra5, PositionSombra5.position, Sombra5.transform.rotation);
             yield return new WaitForSeconds(0.3f);
             Destroy(NovoAviso);
            boss.transform.position = Baixo.position;
            StartCoroutine(subir());
        }
    }
        
    //ataque da explosão dos tiros
    void Explosion()
    {
            bossAnim.SetBool("separar", true);
            

        
    }

    IEnumerator AtaqueLaser()
    {
        Mid = true;
        bossAnim.SetBool("idle", false);
        bossAnim.SetBool("entrar", true);
        yield return new WaitForSeconds(2);
        boss.transform.position = Baixo.position;
         this.transform.eulerAngles = new Vector3(0, 0, -180);
        yield return new WaitForSeconds(0.5f);
        
        this.transform.position = Meio.position;
        bossAnim.SetBool("entrar", false);
        bossAnim.SetBool("laser", true);
        yield return new WaitForSeconds(1f);
        
        speen = true;  
    }
    IEnumerator laserOff()
    {
        bossAnim.SetBool("laser", false);
        bossAnim.SetBool("entrar", true);

        yield return new WaitForSeconds(2f);
        boss.transform.position = Baixo.position;
        if(IsFacingRight)
        this.transform.eulerAngles = new Vector3(0, 180, 0);
        else
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        Mid = false;
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("entrar", false);
        bossAnim.SetBool("idle", true);
        if (Right)
        {
            right();
        }
        if (Left)
        {
            left();
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(wait());

    }
        //Sombras horizontais, verticais e diagonais
        IEnumerator AtaqueFinal(){
        GameObject avisoAAA = GameObject.Find("AvisoAAA");
        GameObject linhaAAA = GameObject.Find("linhaAAA");
        GameObject avisoDR = GameObject.Find("AvisoDR");
        GameObject linhaDR = GameObject.Find("linhaDR");
        GameObject linhaDL = GameObject.Find("linhaDL");
        GameObject avisoDL = GameObject.Find("AvisoDL");
        GameObject avisoB = GameObject.Find("AvisoB");
        GameObject linhaB = GameObject.Find("linhaB");
        GameObject avisoC = GameObject.Find("AvisoC");
        GameObject linhaC = GameObject.Find("linhaC");

        
            bossAnim.SetBool("idle", false);
            bossAnim.SetBool("entrar", true);
            yield return new WaitForSeconds(1);
            GameObject NovoAviso = Instantiate(linhaDR, avisoDR.transform.position,avisoDR.transform.rotation);

            yield return new WaitForSeconds(1);
            GameObject shadow1 = Instantiate(SombraDoKrl, DiagDir.position, DiagDir.transform.rotation);
            GameObject NovoAviso2 = Instantiate(linhaB, avisoB.transform.position,avisoB.transform.rotation);

            yield return new WaitForSeconds(0.5F);
            Destroy(NovoAviso);
            yield return new WaitForSeconds(0.5F);
            GameObject shadow2 = Instantiate(SombraBaixo, PositionCima.position, SombraBaixo.transform.rotation);
            GameObject NovoAviso3 = Instantiate(linhaDL, avisoDL.transform.position,avisoDL.transform.rotation);

            yield return new WaitForSeconds(0.5F);
            Destroy(NovoAviso2);
            yield return new WaitForSeconds(0.5F);
            GameObject shadow3 = Instantiate(SombraDoKrl, DiagEsq.position, DiagEsq.transform.rotation);
            GameObject NovoAviso4 = Instantiate(linhaC, avisoC.transform.position,avisoC.transform.rotation);

            yield return new WaitForSeconds(0.5F);
            Destroy(NovoAviso3);
            yield return new WaitForSeconds(0.5F);
            GameObject shadow4 = Instantiate(SombraCima, PositionBaixo.position, SombraCima.transform.rotation);


            yield return new WaitForSeconds(0.5F);
            Destroy(NovoAviso4);
            yield return new WaitForSeconds(0.5F);
            GameObject NovoAviso5 = Instantiate(linhaAAA, avisoAAA.transform.position,avisoAAA.transform.rotation);
            GameObject shadow5 = Instantiate(SombraH, PositionSombra1.position, Sombra1.transform.rotation);
            yield return new WaitForSeconds(0.5F);
            Destroy(NovoAviso5);
            yield return new WaitForSeconds(0.5F);
            Destroy(shadow1);
            Destroy(shadow2);
            Destroy(shadow3);
            Destroy(shadow4);
            Destroy(shadow5);

            boss.transform.position = Baixo.position;
            StartCoroutine(subir());
        
        }
    void left()
    {
        this.transform.position = Esquerda.position;
    }
    void right()
    {
        this.transform.position = Direita.position;
    }
    void mid()
    {
        this.transform.position = Meio.position;
    }
    IEnumerator Atirar()
    {
            Physics2D.IgnoreLayerCollision(7, 11, true);
            Instantiate(tiro, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro2, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro3, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro4, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro5, spawner.transform.position, tiro.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            rend.enabled = false;
            podeTrocar = true;
            
    }
        
    IEnumerator TiroRight()
    {
        Debug.Log("Tiros");
        balaNele1.fuzilamento();
        balaNele2.fuzilamento();
        balaNele3.fuzilamento();
        balaNele4.fuzilamento();
        balaNele5.fuzilamento();    
        right();
        yield return new WaitForSeconds(1.5f);
        
        bossAnim.SetBool("separar", false);
        rend.enabled = true;
        Physics2D.IgnoreLayerCollision(7, 11, false);
        StartCoroutine(wait());
            
    }
    IEnumerator TiroLeft()
    {
        Debug.Log("Tiros");
        balaNele1.fuzilamento();
        balaNele2.fuzilamento();
        balaNele3.fuzilamento();
        balaNele4.fuzilamento();
        balaNele5.fuzilamento();
        left();
        yield return new WaitForSeconds(1.5f);
        
        bossAnim.SetBool("separar", false);
        rend.enabled = true;
        Physics2D.IgnoreLayerCollision(7, 11, false);
        StartCoroutine(wait());
        
    }



    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        IsFacingRight = !IsFacingRight;
    }

    IEnumerator subir()
    {
        yield return new WaitForSeconds(2f);
        if (Mid == false && Right == true)
        {

            boss.transform.position = Direita.position;
            bossAnim.SetBool("entrar", false);
            bossAnim.SetBool("idle", true);
            StartCoroutine(wait());
        }
        else if (Mid == false && Left == true)
        {
            boss.transform.position = Esquerda.position;
            bossAnim.SetBool("entrar", false);
            bossAnim.SetBool("idle", true);
            StartCoroutine(wait());
        }
        else if (Mid == true && Left == true || Mid == true && Right == true)
        {
            boss.transform.position = Meio.position;
        }

    }
    void podelaser()
    {
        Laser.SetActive(true);
        podeUsarLaser = true;
    }

    
    
}
