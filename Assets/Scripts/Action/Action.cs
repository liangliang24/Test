using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action : MonoBehaviour
{
    [SerializeField]
    public string ActionName;

    [SerializeField]
    public float Cooldown;

    public float LastTime;
    public float CurrentTime;
    public CharacterController Instigator;
    public Rigidbody2D InstigatorRb;
    /*
     * 0 for Weapon
     * 1 for Effect
     */
    public int ActionType;
    virtual public void StartAction(CharacterController instigator)
    {
        //Fire();
    }

    virtual public void StopAction()
    {

    }

    virtual public void Fire()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Cooldown = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
