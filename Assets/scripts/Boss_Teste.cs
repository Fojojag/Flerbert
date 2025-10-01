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
    public GameObject espinho;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private bool isJumping;
    
    //Isso é do pulo apenas:
    private Transform target;
    [SerializeField] private Vector3 player;
    private bool chegou = false;
    public bool podeCair;
    public float playercorrectY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedY;
    private float distanceToTargetToDestroyProjectile = 6f;
    [SerializeField] private AnimationCurve trajAnimCurv;
    [SerializeField] private AnimationCurve axisCorrectionAnimCurv;
    [SerializeField] private AnimationCurve projSpeedAnimCurv;

    private Vector3 startPoint;
    [SerializeField] private float trajMaxRealtiveHeight;
    void Start()
    {
        startPoint = transform.position;
        playercorrectY = target.position.y;
        player = target.position;
    }

    void Update()
    {
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
        if (numero == 3)
        {
            timer = 1f;
            numero = 0;
        }
        //Bolha
        if (numero == 4 && bolhaClone == null)
        {
            Instantiate(bolha, bolha_spawn.position, bolha_spawn.rotation);
            timer = 3.5f;
            numero = 0;
        }
        if (numero == 4 && bolhaClone != null)
        {
            timer = 1f;
            numero = 0;
        }
        //Pulo
        if (numero == 5)
        {
            isJumping = true;

            timer = 5.5f;
            numero = 0;
        }

        if (Vector3.Distance(transform.position, player) < distanceToTargetToDestroyProjectile)
        {
            //chegou
            isJumping = false;


        }
        if (isJumping)
        {
            UpdateProjPos();
        }
    }
    private void UpdateProjPos()
    {

        Vector3 trajectoryRange = player - startPoint;

        float nextPosX = transform.position.x + moveSpeed * Time.deltaTime;
        float nextPosXNormalized = (nextPosX - startPoint.x) / trajectoryRange.x;

        float nextPosYNormalized = trajAnimCurv.Evaluate(nextPosXNormalized);

        float nextPosYCorrectionNormalized = axisCorrectionAnimCurv.Evaluate(nextPosXNormalized);
        float nextPosYCorrectionAbsolute = nextPosYCorrectionNormalized * trajectoryRange.y;
        float nextPosY = startPoint.y + nextPosYNormalized * trajMaxRealtiveHeight + nextPosYCorrectionAbsolute;

        Vector3 newPosition = new Vector3(nextPosX, nextPosY, -20);
        transform.position = newPosition;


    
    }
}
