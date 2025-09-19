using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyShooter : MonoBehaviour
{
    public bool respawn;
    [SerializeField] private float shootTimer;
    [SerializeField] private float shootRate;
    [SerializeField] private float projectileMaxHeight;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bala;
    [SerializeField] private AnimationCurve trajAnimCurv;
    [SerializeField] private AnimationCurve axisCorrectionAnimCurv;
    [SerializeField] private AnimationCurve projSpeedAnimCurv;
    [SerializeField] private float projectileMoveSpeed;
    [SerializeField] private float projectileMoveSpeedY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (respawn)
        {
            target = player.transform;
            projectileMoveSpeedY = projectileMoveSpeed;
        }
        else
        {
            projectileMoveSpeedY = projectileMoveSpeed;
        }

    }
    private void Update()
    {

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            if (target.position.x < transform.position.x)
            {
                shootTimer = shootRate;
                ProjectileAdvanced projectile = Instantiate(bala, transform.position, Quaternion.identity).GetComponent<ProjectileAdvanced>();
                projectile.InitializeProjectile(target, -projectileMoveSpeed, projectileMoveSpeedY, projectileMaxHeight);
                projectile.InitializeAnimationCurve(trajAnimCurv, axisCorrectionAnimCurv, projSpeedAnimCurv);
            }
            else
            {
                shootTimer = shootRate;
                ProjectileAdvanced projectile = Instantiate(bala, transform.position, Quaternion.identity).GetComponent<ProjectileAdvanced>();
                projectile.InitializeProjectile(target, projectileMoveSpeed, projectileMoveSpeedY, projectileMaxHeight);
                projectile.InitializeAnimationCurve(trajAnimCurv, axisCorrectionAnimCurv, projSpeedAnimCurv);
            }
        }
    }
    public void InitializeShooter(GameObject player)
    {
        this.player = player;
    }
}
