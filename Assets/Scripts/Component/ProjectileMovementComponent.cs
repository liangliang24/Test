using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileMovementComponent : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D rb;

    public float RotationX;
    public float RotationY;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(0,0,Mathf.Atan(RotationY/RotationX) * Mathf.Rad2Deg + (RotationX > 0?0:180));

    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = (new Vector3(1,0,0) * RotationX + new Vector3(0,1,0) * RotationY).normalized * speed * Time.fixedDeltaTime;
        
        //new Vector2(
        //speed * RotationX * Time.fixedDeltaTime,
        //speed * RotationY * Time.fixedDeltaTime);
        //rb.angularVelocity = RotationX / RotationY;
    }
}
