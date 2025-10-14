using UnityEngine;

public class muguerço : MonoBehaviour
{
    public muguerçoAttack ataque;
    public bool isAttacking = false;
    public GameObject target1;
    public GameObject target2;
    private bool IsFacingRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && !IsFacingRight)
        {
            ataque.enabled = true;
            ataque.InitializePulo(target1);
            isAttacking = true;

        }
        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && IsFacingRight)
        {
            ataque.enabled = true;
            ataque.InitializePulo(target2);
            isAttacking = true;

        }
    }
    
    public void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        IsFacingRight = !IsFacingRight;
    }
}
