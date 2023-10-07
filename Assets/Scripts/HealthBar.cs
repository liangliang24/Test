using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject owner;
    AttributeComponent ownerAttributeComponent;
    [SerializeField]
    Image image;
    private void Awake()
    {
        if (owner != null)
        {
            ownerAttributeComponent = owner.GetComponent<AttributeComponent>();
        }
        else
        {
            Debug.LogError(owner);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (ownerAttributeComponent != null)
        {
            ownerAttributeComponent.OnHealthChanged.AddListener(OwnerOnHealthChanged);
        }
    }

    private void OwnerOnHealthChanged(CharacterController instigator, AttributeComponent attributeComponent, int delta)
    {
        image.fillAmount = 1f*attributeComponent.Health/attributeComponent.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
