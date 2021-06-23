using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent onClick;
    [SerializeField] public Sprite button;
    [SerializeField] public Sprite pressedButton;
    private bool activated = false;
    private SpriteRenderer _spriteRenderer;
    public bool Activated
    {
        get => activated;
        set
        {
            if (activated != value && value)
            {
                activated = value;
                OnActivate();
            }
            else if (activated != value && value == false)
            {
                activated = value;
                OnDeactivate();
            }
        }
    }
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnActivate()
    {
        Debug.Log(1);
        _spriteRenderer.sprite = pressedButton;
        onClick?.Invoke();
    }
    
    private void OnDeactivate()
    {
        _spriteRenderer.sprite = button;
    }
}
