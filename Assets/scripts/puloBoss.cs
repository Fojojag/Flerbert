using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class puloBoss : MonoBehaviour
{
    [SerializeField] private GameObject alvo;
    private Transform target;
    [SerializeField] private Vector3 player;
    [SerializeField] private bool chegou = false;
    public bool podeCair;
    private float playercorrectY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedY;
    private float distanceToTargetToDestroyProjectile = 25f;
    [SerializeField] private AnimationCurve trajAnimCurv;
    [SerializeField] private AnimationCurve axisCorrectionAnimCurv;
    [SerializeField] private AnimationCurve projSpeedAnimCurv;


    private Vector3 startPoint;
    [SerializeField] private float trajMaxHeight;
    private float trajMaxRealtiveHeight;

    public void Awake()
    {


        startPoint = transform.position;
        target = alvo.transform;
        playercorrectY = target.position.y;

        player = target.position;

        float xDistanceToTarget = target.position.x - transform.position.x;
        trajMaxRealtiveHeight = trajMaxHeight = Mathf.Abs(xDistanceToTarget) * trajMaxHeight;

        if (target.position.x < transform.position.x)
        {
            moveSpeed = -moveSpeed;
        }
    }
    private void Update()
    {

        UpdateProjPos();

        if (Vector3.Distance(transform.position, player) <= distanceToTargetToDestroyProjectile)
        {
            chegou = true;
            

        }
        if (chegou && podeCair)
        {
            player = new Vector3(player.x, playercorrectY -= moveSpeedY * Time.deltaTime, -20);
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
private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && chegou)
        {
            this.enabled = false;

        }
    }


}
