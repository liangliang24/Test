using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEffect_Bleed : Action
{
    // Start is called before the first frame update
    void Start()
    {
        ActionType = 1;
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
    
    public override void StopAction()
    {
        base.StopAction();
        //Debug.Log("StopAction");
        //CancelInvoke();
        //Destroy(gameObject);
    }

    public void Bleed()
    {
        AttributeComponent instigatorAttribute = Instigator.GetComponent<AttributeComponent>();

        if (instigatorAttribute != null)
        {
            //Debug.Log("Damage");
            instigatorAttribute.ApplyHealthChanged(Instigator, instigatorAttribute, 3);
        }
    }
}
