using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] private Camera virtualCamera;
    [SerializeField] private SpriteRenderer buttonCap;
    [SerializeField] private Button redButton;
    [SerializeField] private Sprite openedCap;
    private Collider2D lastButtonCollider;
    private Collider2D collider2D;
    private string _code = "";
    

    public string Code
    {
        get => _code;
        set
        {
            _code = value;
            if (_code.Length > 4)
            {
                _code = "";
            }
        }
    }

    private bool isCollider2DExists => collider2D != null;
    private bool isLastButtonExists => lastButtonCollider != null;
    private bool isButtonNew => lastButtonCollider != collider2D;
    private bool isLastButtonNotInFocus => isLastButtonExists && isButtonNew && lastButtonCollider.CompareTag("Button");
    void Update() 
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = virtualCamera.ScreenToWorldPoint(mousePos);
        collider2D = Physics2D.OverlapPoint(worldPos);

        if (isLastButtonNotInFocus)
        {
            lastButtonCollider.GetComponent<Button>().Activated = false;
        }

        if (Input.GetMouseButtonDown(0)) // Нажимаем
        {
            if (isCollider2DExists && collider2D.CompareTag("Button"))
            {
                Button button = collider2D.GetComponent<Button>();
                button.Activated = true;
                if (isButtonNew)
                {
                    if (isLastButtonExists)
                    {
                        lastButtonCollider.GetComponent<Button>().Activated = false;
                    }

                    lastButtonCollider = collider2D;
                }
                
            }
        }
        else if (Input.GetMouseButtonUp(0)) // Отпускаем
        {
            if (isCollider2DExists && collider2D.CompareTag("Button"))
            {
                Button button = collider2D.GetComponent<Button>();
                button.Activated = false;
                if (isLastButtonExists)
                {
                    button = lastButtonCollider.GetComponent<Button>();
                    button.Activated = false;
                }
            }
        }
    }

    public void AddCode(char number)
    {
        Code += number;
        if (Code == "4331")
        {
            buttonCap.sprite = openedCap;
            buttonCap.sortingOrder = 1;
            redButton.closed = false;
        }
    }
}

