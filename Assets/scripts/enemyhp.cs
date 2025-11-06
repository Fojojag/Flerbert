using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class enemyhp : MonoBehaviour
{
    public GameObject spawn;
    SpriteRenderer rend;
    Color c;
    [SerializeField] SpriteRenderer spriteRenderer;
    public float ENhealth;
    public float ENmaxhealth;
    public Animator anima;
    public Enemybase corpo;
    public bool boss = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ENhealth = ENmaxhealth;
        rend = GetComponent<SpriteRenderer>();
        c = rend.color;
    }
    void Awake()
    {
        spawn = GameObject.Find("SpawnPlayer");
    }

    void Update()
    {
                if (ENhealth <= 0)
        {
            corpo.Invoke("ded", 0.1f);
                if (boss)
            {
                spawn.transform.position = new Vector3(211.6f, -1.4f, -23.5f);

                FadeFases.FadeIn();
            }
            Destroy(gameObject);

            
        }
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limao")
        {
            ENhealth -= 3;
            hit();
        }

        if (collision.gameObject.tag == "chargeshot")
        {
            ENhealth -= 10;
            hit();
        }

    }
    void hit()
    {
        IEnumerator hit_Cor()
        {
            spriteRenderer.material.SetInt("_hit", 1);
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.material.SetInt("_hit", 0);
           
        }
        StartCoroutine(hit_Cor());
    }


}