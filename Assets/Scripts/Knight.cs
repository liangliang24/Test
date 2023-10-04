using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : MonoBehaviour
{

    public float walkSpeed = 5f;
    Rigidbody2D rb;

    protected bool canWalk = true;
        
    public bool CanWalk
    { 
        get { return canWalk; } 
        set { canWalk = value; }
    }
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

    public float WalkSpeed
    { 
        get { return walkSpeed; } 
        set {  walkSpeed = value; } 
    }
    private void FixedUpdate()
    {
        if (canWalk)
        {
            WalkDirection = player.transform.position - transform.position;
            //Debug.Log(direction.x + ' ' + direction.y);
            //Debug.Log(Vector3.Normalize(direction).x + ' ' + Vector3.Normalize(direction).y);
            rb.velocity = new Vector2(walkSpeed * Vector3.Normalize(WalkDirection).x, walkSpeed * Vector3.Normalize(WalkDirection).y);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Debug.Log(collision.gameObject.name);
        //if (collision.gameObject.name == "Player")
        canWalk = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        canWalk = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "Player")
        canWalk = true;
    }
}
