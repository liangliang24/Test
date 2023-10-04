using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : MonoBehaviour
{

    public float walkSpeed = 5f;
    Rigidbody2D rb;

    [SerializeField]
    GameObject player;

    Vector3 walkDirection;
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
        
    }

    public Vector3 WalkDirection
    {
        get { return walkDirection; }
        set { walkDirection = value; }
    }

    private void FixedUpdate()
    {
        WalkDirection = player.transform.position - transform.position;
        //Debug.Log(direction.x + ' ' + direction.y);
        //Debug.Log(Vector3.Normalize(direction).x + ' ' + Vector3.Normalize(direction).y);
        rb.velocity = new Vector2(walkSpeed * Vector3.Normalize(WalkDirection).x,walkSpeed * Vector3.Normalize(WalkDirection).y);
    }
}
