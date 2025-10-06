using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Teste : MonoBehaviour
{
    public float timer = 3f;
    public int numero;
    public Transform tiro_spawn;
    public Transform bolha_spawn;
    public GameObject tiro;
    public GameObject bolha;
    public bool espinhoAtivo = false;
    public GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public bool isJumping;
    public puloBoss jumpScript;
    public bool IsFacingRight = false;
    public Espinhostart espinhos;
    public BossEspinho espinho5;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x >= player.transform.position.x && !isJumping && IsFacingRight)
        {
            flip();
        }
        if (transform.position.x <= player.transform.position.x && !isJumping && !IsFacingRight)
        {
            flip();
        }

        GameObject bolhaClone = GameObject.Find("bolha(Clone)");

        if (timer >= 0 || numero == 0)
        {
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            numero = Random.Range(0, 6);
        }

        //Tiro pra cima
        if (numero == 1 || numero == 2)
        {
            Instantiate(tiro, tiro_spawn.position, tiro_spawn.rotation);
            timer = 2f;
            numero = 0;

        }
        //Espinho
        if (numero == 3 && !espinhoAtivo)
        {
            espinhos.iniciar();
            espinhoAtivo = true;
            timer = 1f;
            numero = 0;
        }
        if (numero == 3 && espinhoAtivo)
        {
            timer = 1f;
            numero = 0;
        }
        //Bolha
        if (numero == 4 && bolhaClone == null || numero == 4 && bolhaClone == null  )
        {
            Instantiate(bolha, bolha_spawn.position, bolha_spawn.rotation);
            timer = 3.5f;
            numero = 0;
        }
        if (numero == 4 && bolhaClone == null || numero == 4 && bolhaClone != null  )
        {
            timer = 1f;
            numero = 0;
        }
        //Pulo
        if (numero == 5 && !espinhoAtivo)
        {
            isJumping = true;
            timer = 5.5f;
            numero = 0;
            jumpScript.enabled = true;
            jumpScript.InitializePulo(player);

        }
        if (numero == 5 && espinhoAtivo)
        {
            timer = 1f;
            numero = 0;

        }

        if (espinho5.isActive == false)
        {
            espinhoAtivo = false;
        }

        


    }
    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        IsFacingRight = !IsFacingRight;
    }
}
