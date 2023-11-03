using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Trigger!");
    //    AttributeComponent attributeComp = collision.gameObject.GetComponent<AttributeComponent>();
    //    if (attributeComp == null) 
    //    {
    //        return;
    //    }

    //    attributeComp.ApplyHealthChanged(null, attributeComp, 50);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        AttributeComponent attributeComp = collision.gameObject.GetComponent<AttributeComponent>();

        if (attributeComp != null)
        {
            attributeComp.ApplyHealthChanged(null, attributeComp, 5000);
        }

        DestroyImmediate(this.gameObject);
    }
}
