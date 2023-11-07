using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEffect_Bleed : Action
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StartAction(CharacterController Instigator)
    {
        base.StartAction(Instigator);

        InvokeRepeating("Bleed", 0.2f, 0.2f);
        
    }

    public void Bleed()
    {
        AttributeComponent instigatorAttribute = Instigator.GetComponent<AttributeComponent>();

        if (instigatorAttribute != null)
        {
            //Debug.Log("Damage");
            instigatorAttribute.ApplyHealthChanged(Instigator, instigatorAttribute, 2);
        }
    }
}
