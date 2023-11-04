using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ActionComponent : MonoBehaviour
{
    public CharacterController Owner;
    public Rigidbody2D OwnerInfo;
    [SerializeField] public List<Action> ActionList;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        foreach (Action action in ActionList)
        {
            action.Instigator = Owner;
            action.InstigatorInfo = OwnerInfo;
        }
        foreach (Action action in ActionList)
        {
            action.StartAction(Owner);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
