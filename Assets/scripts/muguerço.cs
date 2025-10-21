using UnityEngine;
using System.Collections;
public class muguerço : MonoBehaviour
{
    SpriteRenderer rend;
    Color c;
    [SerializeField] SpriteRenderer spriteRenderer;
    public float ENhealth;
    public float ENmaxhealth;
    public muguerçoAttack ataque;
    public bool isAttacking = false;
    public GameObject target1;
    public GameObject target2;
    public bool IsFacingRight;
    public bool canAttack = false;
    public GameObject trigger;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
               
        rend = GetComponent<SpriteRenderer>();
        c = rend.color;
        ENhealth = ENmaxhealth;  
    }

    // Update is called once per frame
    void Update()
    {
        if (ENhealth <= 0)
        {

            Destroy(trigger);

        }
        if (canAttack && !isAttacking && !IsFacingRight && timer <= 0)
        {
            ataque.enabled = true;
            ataque.InitializePulo(target1);
            isAttacking = true;
            timer = 2;

        }
        if (canAttack && !isAttacking && IsFacingRight && timer <= 0)
        {
            ataque.enabled = true;
            ataque.InitializePulo(target2);
            isAttacking = true;
            timer = 2;

        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
        void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "limao")          
        {
            ENhealth -= 3;
            hit();
        }
        
        if(collision.gameObject.tag == "chargeshot")          
        {
            ENhealth -= 10;
            hit();
        }
        
    }

    public void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        IsFacingRight = !IsFacingRight;
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
