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
    [SerializeField] private char number;
    [SerializeField] private ButtonPanel buttonPanel;
    [SerializeField] private PlaySound playSound;
    public bool closed = false;

    public bool Closed
    {
        get => closed;
        set => closed = value;
    }
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
        tag = "Button";
    }

    private void OnActivate()
    {
        if (!closed)
        {
            playSound.PlayButtonSound();
            _spriteRenderer.sprite = pressedButton;
            if (Char.IsDigit(number))
                buttonPanel.AddCode(number);
            onClick?.Invoke();
        }
    }
    
    private void OnDeactivate()
    {
        _spriteRenderer.sprite = button;
    }
}
