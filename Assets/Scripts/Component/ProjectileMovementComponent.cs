using System.Collections;
using System.Collections.Generic;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = (transform.right * RotationX + transform.up * RotationY).normalized * speed * Time.fixedDeltaTime;
            //new Vector2(
            //speed * RotationX * Time.fixedDeltaTime,
            //speed * RotationY * Time.fixedDeltaTime);
        //rb.angularVelocity = RotationX / RotationY;
        
    }
}
