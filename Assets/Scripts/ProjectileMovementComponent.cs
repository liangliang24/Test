using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementComponent : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D rb;
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
        rb.velocity = new Vector2(
            speed * rb.rotation * Time.fixedDeltaTime,
            speed * rb.rotation * Time.fixedDeltaTime);
    }
}
