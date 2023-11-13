using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action : MonoBehaviour
{
    [SerializeField]
    public string ActionName;

    public CharacterController Instigator;
    public Rigidbody2D InstigatorRb;
    /*
     * 0 for Weapon
     * 1 for Effect
     */
    public int ActionType;
    virtual public void StartAction(CharacterController instigator)
    {

    }

    virtual public void StopAction()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
