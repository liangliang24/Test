using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EOnHealthChanged : UnityEvent<CharacterController, AttributeComponent, int>
{

}

public class EOnIsAliveChanged : UnityEvent<bool>
{

}
public class AttributeComponent : MonoBehaviour
{
    Animator animator;

    public EOnHealthChanged OnHealthChanged;
    public EOnIsAliveChanged OnIsAliveChanged;
    [SerializeField]
    private int maxHealth = 100;
    public int MaxHealth
    {
        get {  return maxHealth; }
        set { maxHealth = value; }
    }

    [SerializeField]
    private int health = 100;
    public int Health
    {
        get { return health; }
        set 
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                IsAlive = false;
            }
            Debug.Log("health" + value);
        }
    }
    [SerializeField]
    private bool isAlive = true;
    [SerializeField]
    private bool isInvincible = false;
    public bool IsAlive
    {
        get { return  isAlive; }
        set 
        { 
            isAlive = value; 
            if (!isAlive)
            {
                if (animator != null)
                {
                    animator.SetBool(AnimationStrings.isAlive, false);
                }
                
            }
            Debug.Log("isAlive" + value);
            OnIsAliveChanged.Invoke(isAlive);
        }
    }

    private void Awake()
    {
        if (OnHealthChanged == null)
        {
            OnHealthChanged = new EOnHealthChanged();
        }
        if (OnIsAliveChanged == null)
        {
            OnIsAliveChanged = new EOnIsAliveChanged();
        }
        animator = GetComponent<Animator>();
    }

    float timeSinceHit = 0;
    [SerializeField]
    float invincibilityTimer = 0.25f;
    private void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTimer) 
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
        //Hit(10);
    }

    public bool ApplyHealthChanged(CharacterController instigator, AttributeComponent attributeComponent, int delta)
    {
        if (!isInvincible)
        {
            Health -= delta;
            isInvincible = true;
            OnHealthChanged.Invoke(instigator, attributeComponent, delta);
        }
        
        
        return true;
    }

}
