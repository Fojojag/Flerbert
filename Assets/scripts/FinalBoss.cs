using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBoss : MonoBehaviour
{
    public Animator headAnim;
    public Animator bodyAnim;
    public Animator tentAnim1;
    public Animator tentAnim2;
    public GameObject tentacu1;
    public GameObject tentacu2;
    public Transform firepoint;
    public Transform firepoint2Esqu;
    public Transform firepoint2Dir;
    public GameObject bala;
    public GameObject bala2;
    [SerializeField] private float timer;
    private bool startTimer = false;
    public float shootRate;
    private bool speen = false;
    [SerializeField] private bool speen2 = false;
    [SerializeField] private bool speen3 = false;
    public float pattern1Timer;
    public float pattern1Speed;
    public float pattern2Timer;
    public float pattern2Speed;
    public int PickedMove;
    int PickedMoveIndex;
    private bool ataque2 = false;

    [SerializeField] List<int> MovePicker;

    void Start()
    {
        makeList();
    }

    void Update()
    {
        if (speen)
        {
            firepoint.eulerAngles = new Vector3(0f, 0f, firepoint.eulerAngles.z + 1);
        }
        if (speen2)
        {
            firepoint2Esqu.eulerAngles = new Vector3(0f, 0f, firepoint2Esqu.eulerAngles.z + 0.4f);
            firepoint2Dir.eulerAngles = new Vector3(0f, 0f, firepoint2Dir.eulerAngles.z - 0.4f);


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
        for (int i = 1; i <= 3; ++i)
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
    Select();
    return;
    }
//SELEÇÃO DE ATAQUE -------------------------------------------------------
    void Select()
    {
        if (PickedMove == 1)
        {
            StartCoroutine(Pattern1());
            return;
        }
        else
        if (PickedMove == 2)
        {
            StartCoroutine(Pattern2());
            StartCoroutine(Pattern22());
            return;
        }
        if (PickedMove == 3)
        {
            StartCoroutine(Pattern3());
            return;
        }

    }
//ATAQUE 1 --------------------------------------------------
    IEnumerator Pattern1()
    {
        
        Debug.Log("1");
        firepoint.eulerAngles = new Vector3(0, 0, 45);
        speen = true;
        for (float i = pattern1Timer; i > 0; i--)
        {

            projetil2 tiro1 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
            tiro1.GetComponent<projetil2>().speed = -pattern1Speed;
            projetil2 tiro2 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
            tiro2.GetComponent<projetil2>().speed = pattern1Speed;
            projetil2 tiro3 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
            tiro3.GetComponent<projetil2>().speed = -pattern1Speed;
            tiro3.GetComponent<projetil2>().isHorizontal = true;
            projetil2 tiro4 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
            tiro4.GetComponent<projetil2>().speed = pattern1Speed;
            tiro4.GetComponent<projetil2>().isHorizontal = true;
            yield return new WaitForSeconds(shootRate);

        }
        firepoint.eulerAngles = new Vector3(0, 0, 45);
        speen = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(wait());
    }
    //ATAQUE 2 --------------------------------------------------
    IEnumerator Pattern2()
    {
        Debug.Log("2");
        ataque2 = true;

        for (float i = pattern2Timer; i > 0; i--)
        {
            if (i == 0 || i == 40) { speen2 = true; speen3 = false; }
            if (i == 20 || i == 60) { speen2 = false; speen3 = true; }
            projetilbounce tiro1 = Instantiate(bala2, firepoint2Esqu.position, firepoint2Esqu.rotation).GetComponent<projetilbounce>();
            tiro1.GetComponent<projetilbounce>().speed = -pattern1Speed;
            tiro1.GetComponent<projetilbounce>().isHorizontal = true;
            projetilbounce tiro2 = Instantiate(bala2, firepoint2Dir.position, firepoint2Dir.rotation).GetComponent<projetilbounce>();
            tiro2.GetComponent<projetilbounce>().speed = pattern1Speed;
            tiro2.GetComponent<projetilbounce>().isHorizontal = true;
            yield return new WaitForSeconds(shootRate);

        }
        firepoint2Esqu.eulerAngles = new Vector3(0, 0, 355);
        firepoint2Dir.eulerAngles = new Vector3(0, 0, 5);
        speen2 = false;
        speen3 = false;
        ataque2 = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(wait());
    }
    IEnumerator Pattern22()
    {
        Debug.Log("2");


        while (ataque2 == true)
        {
            projetil2 tiro1 = Instantiate(bala, firepoint.position, firepoint.rotation).GetComponent<projetil2>();
            tiro1.GetComponent<projetil2>().speed = -pattern1Speed;
            yield return new WaitForSeconds(3);
        }
        yield break;

    }
    //ATAQUE 3 --------------------------------------------------
    IEnumerator Pattern3()
    {
        tentAnim1.SetBool("surgir", true);
        yield return new WaitForSeconds(1);
        tentAnim2.SetBool("surgir", true);
        yield return new WaitForSeconds(1.5f);
        tentAnim1.SetBool("surgir", false);
        tentAnim1.SetBool("attack", true);
        yield return new WaitForSeconds(1.5f);
        tentAnim2.SetBool("attack", true);
        tentAnim1.SetBool("attack", false);
        
        tentAnim1.SetBool("surgir", false);
        tentAnim2.SetBool("surgir", false);
        yield return new WaitForSeconds(1.5f);
        tentAnim2.SetBool("attack", false);
        StartCoroutine(wait());

    }
}
