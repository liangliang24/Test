using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ActionComponent : MonoBehaviour
{
    public CharacterController Owner;
    public Rigidbody2D OwnerRb;
    [SerializeField] public List<Action> ActionList;
    [SerializeField] public List<Action> EffectList;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        foreach (Action action in ActionList)
        {
            action.Instigator = Owner;
            action.InstigatorRb = OwnerRb;
        }
        foreach (Action action in ActionList)
        {
            action.CurrentTime = action.LastTime = Time.time;
            action.StartAction(Owner);
        }
        foreach (Action action in EffectList)
        {
            action.Instigator = Owner;
            action.InstigatorRb = OwnerRb;
        }
        foreach (Action action in EffectList)
        {
            action.StartAction(Owner);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Action action in ActionList)
        {
            //Debug.Log(action.Cooldown);

            action.CurrentTime = Time.time;
            if (action.CurrentTime - action.LastTime >= action.Cooldown)
            {
                action.Fire();
                action.LastTime = action.CurrentTime;
            }
        }
    }

    public void AddAction(Action action)
    {
        switch(action.ActionType)
        {
            case 0:
                ActionList.Add(action);
                break;
            case 1:
                EffectList.Add(action);
                break;
        }
    }

}
