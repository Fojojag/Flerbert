using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class boss2 : MonoBehaviour
{
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
    private float TimerTrocaPosition = 3f;
    [SerializeField] Transform Baixo;

    //Tiros dele
    private float TimerTiros = 2f;
    bool podeAtirar;

    //Laser dele
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

    //Config pros ataques auto
    [SerializeField] float TimerAtaques = 0;
    [SerializeField] float ataqueSelecionado = 5;

    void Start()
    {
        podeTrocar = false;
        podeAtirar = false;
        Mid = false;
    }

    void Update()
    {
        //Seleção de ataques
        //O máximo no range nunca será selecionado
        if (TimerAtaques <= 0)
        {
            ataqueSelecionado = UnityEngine.Random.Range(0, 7);
        }
        

        float DistanceLeft = Vector3.Distance(AlvoLaserEsquerda.position, player.transform.position);
        float DistanceRight = Vector3.Distance(AlvoLaserDireita.position, player.transform.position);
        //Angulo z do laser :)
        anguloZ = Laser.transform.rotation.z;


        //Sombra Horizontal
        if (ataqueSelecionado == 1 && Right == true || ataqueSelecionado == 2 && Right == true)
        {
            ataqueSelecionado = 0;
            TimerAtaques = 5f;
            Instantiate(Sombra1, PositionSombra1.position, Sombra1.transform.rotation);
            Instantiate(Sombra2, PositionSombra2.position, Sombra2.transform.rotation);
            Instantiate(Sombra3, PositionSombra3.position, Sombra3.transform.rotation);
            boss.transform.position = Baixo.position;
            StartCoroutine(subir());

        }
        if (ataqueSelecionado == 1 && Left == true || ataqueSelecionado == 2 && Left == true)
        {
            ataqueSelecionado = 0;
            TimerAtaques = 5f;
            Instantiate(Sombra6, PositionSombra6.position, Sombra6.transform.rotation);
            Instantiate(Sombra5, PositionSombra5.position, Sombra5.transform.rotation);
            Instantiate(Sombra4, PositionSombra4.position, Sombra4.transform.rotation);
            boss.transform.position = Baixo.position;
            StartCoroutine(subir());
        }

        //Sombras horizontais, verticais e diagonais
        if (ataqueSelecionado == 5)
        {
            ataqueSelecionado = 0;
            TimerAtaques = 6f;
            Instantiate(SombraBaixo, PositionBaixo.position, SombraBaixo.transform.rotation);
            Instantiate(Sombra1, PositionSombra1.position, Sombra1.transform.rotation);
            Instantiate(SombraCima, PositionCima.position, SombraCima.transform.rotation);
            boss.transform.position = Baixo.position;
            StartCoroutine(subir());
        }

        //ataque dos lasers
        if (ataqueSelecionado == 6)
        {
            if (Mid == false)
            {
                ataqueSelecionado = 0;
                TimerAtaques = 7f;
                Mid = true;
                mid();
                LiberaçãoLaser = true;
                StartCoroutine(VoltarDoLaser());
                if (transform.position.x >= player.transform.position.x && IsFacingRight)
                {
                    //olhando pra esquerda
                    flip();
                }
                if (transform.position.x <= player.transform.position.x && !IsFacingRight)
                {
                    //olhando pra direita
                    flip();
                }

                if (DistanceLeft < DistanceRight)
                {
                    TiroAlvoAlvo = 1;
                }
                else if (DistanceRight < DistanceLeft)
                {
                    TiroAlvoAlvo = 2;
                }
            }
            
        }

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


        //ataque da explosão dos tiros
        if (ataqueSelecionado == 3 || ataqueSelecionado == 4)
        {
            ataqueSelecionado = 0;
            TimerAtaques = 5.5f;
            Instantiate(tiro, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro2, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro3, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro4, spawner.transform.position, tiro.transform.rotation);
            Instantiate(tiro5, spawner.transform.position, tiro.transform.rotation);
            podeTrocar = true;
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
            TimerTrocaPosition = 3f;
            if (Left == true)
            {
                podeAtirar = true;
                Right = true;
                Left = false;
                right();
                TiroRight();
            }
            else if (Right == true)
            {
                podeAtirar = true;
                Left = true;
                Right = false;
                left();
                TiroLeft();
            }
        }


        
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
        
    void TiroRight()
    {
        Debug.Log("Tiros");
        balaNele1.fuzilamento();
        balaNele2.fuzilamento();
        balaNele3.fuzilamento();
        balaNele4.fuzilamento();
        balaNele5.fuzilamento();        
    }
    void TiroLeft()
    {
        Debug.Log("Tiros");
        balaNele1.fuzilamento();
        balaNele2.fuzilamento();
        balaNele3.fuzilamento();
        balaNele4.fuzilamento();
        balaNele5.fuzilamento();
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
        }
        else if (Mid == false && Left == true)
        {
            boss.transform.position = Esquerda.position;
        }
        else if (Mid == true && Left == true || Mid == true && Right == true)
        {
            boss.transform.position = Meio.position;
        }

    }
    

    IEnumerator VoltarDoLaser()
    {
        yield return new WaitForSeconds(6f);
        ataqueSelecionado = 0;
        TimerAtaques = 0.5f;
        Mid = false;
        if (Left == true)
        {
            TimerSpawnLaser = 2f;
            TiroAlvoAlvo = 0;
            TimerVoltaLaser = 0.7f;
            left();
        }
        else if (Right == true)
        {
            TimerSpawnLaser = 2f;
            TiroAlvoAlvo = 0;
            TimerVoltaLaser = 0.7f;
            right();
        }
    }
    
    
}
