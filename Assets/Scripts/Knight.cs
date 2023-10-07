using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : EnemyController
{
    AttributeComponent attributeComponent;
    public float walkSpeed = 5f;
    Rigidbody2D rb;

    protected bool canWalk = true;
        
    public bool CanWalk
    { 
        get { return canWalk; } 
        set { canWalk = value; }
    }
    public GameObject TargetPlayer;

    Vector3 walkDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attributeComponent = GetComponent<AttributeComponent>();
        
    }

    private void WhenGODie(bool isAlive)
    {
        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        attributeComponent.OnIsAliveChanged.AddListener(WhenGODie);
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
        //Debug.Log(canWalk);
        if (canWalk)
        {
            WalkDirection = TargetPlayer.transform.position - transform.position;
            //Debug.Log(WalkDirection.x + ' ' + WalkDirection.y);
            //Debug.Log(Vector3.Normalize(WalkDirection).x + ' ' + Vector3.Normalize(WalkDirection).y);
            rb.velocity = new Vector2(walkSpeed * Vector3.Normalize(WalkDirection).x, walkSpeed * Vector3.Normalize(WalkDirection).y);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        canWalk = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //if (collision.gameObject.name == "Player")
        //{
            
        //    AttributeComponent otherGOAttributeComponent = collision.gameObject.GetComponent<AttributeComponent>();
        //    if (otherGOAttributeComponent != null)
        //    {
        //        otherGOAttributeComponent.ApplyHealthChanged(this, otherGOAttributeComponent, 10);
        //    }
        //}
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        canWalk = true;
    }
}
