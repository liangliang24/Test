using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Projectile : Action
{
    [SerializeField] private ProjectileMovementComponent projectile;

    private float LastRotationX = 1;
    private float LastRotationY = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StartAction(CharacterController instigator)
    {
        base.StartAction(instigator);

        InvokeRepeating("Fire", 1f, 0.1f);
    }

    void Fire()
    {
        //Debug.Log("GO");
        Quaternion quaternion = Quaternion.identity;
        //quaternion.x = attackRotation.x;
        //quaternion.y = attackRotation.y;

        ProjectileMovementComponent SpawnedProjectile = Instantiate(projectile, Instigator.transform.position, quaternion);
        SpawnedProjectile.RotationX = InstigatorInfo.velocity.x;
        SpawnedProjectile.RotationY = InstigatorInfo.velocity.y;
        if (SpawnedProjectile.RotationX == 0 && SpawnedProjectile.RotationY == 0)
        {
            SpawnedProjectile.RotationX = LastRotationX;
            SpawnedProjectile.RotationY = LastRotationY;
        }
        else
        {
            LastRotationX = SpawnedProjectile.RotationX;
            LastRotationY = SpawnedProjectile.RotationY;
        }
        Debug.Log("RotationX:" + SpawnedProjectile.RotationX
            + " RotationY:" + SpawnedProjectile.RotationY);
    }
}