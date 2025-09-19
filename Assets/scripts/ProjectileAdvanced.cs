using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ProjectileAdvanced : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 player;
    private bool chegou = false;
    public bool podeCair;
    public float playercorrectY;
    private float moveSpeed;
    private float moveSpeedY;
    private float distanceToTargetToDestroyProjectile = 6f;
    private AnimationCurve trajAnimCurv;
    private AnimationCurve axisCorrectionAnimCurv;
    private AnimationCurve projSpeedAnimCurv;

    private Vector3 startPoint;
    [SerializeField] private float trajMaxRealtiveHeight;

    private void Start()
    {

        startPoint = transform.position;
        playercorrectY = target.position.y;
        player = target.position;

    }
    private void Update()
    {

        UpdateProjPos();

        if (Vector3.Distance(transform.position, player) < distanceToTargetToDestroyProjectile)
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

    public void InitializeProjectile(Transform target, float moveSpeed, float moveSpeedY, float trajMaxHeight)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;
        this.moveSpeedY = moveSpeedY;
        float xDistanceToTarget = target.position.x - transform.position.x;
        this.trajMaxRealtiveHeight = trajMaxHeight = Mathf.Abs(xDistanceToTarget) * trajMaxHeight;

    }
    public void InitializeAnimationCurve(AnimationCurve trajAnimCurv, AnimationCurve axisCorrectionAnimCurv, AnimationCurve projSpeedAnimCurv)
    {
        this.trajAnimCurv = trajAnimCurv;
        this.axisCorrectionAnimCurv = axisCorrectionAnimCurv;
        this.projSpeedAnimCurv = projSpeedAnimCurv;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);

        }
    }

}
