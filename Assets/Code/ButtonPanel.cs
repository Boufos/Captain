using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] private Camera virtualCamera;
    private Collider2D lastButtonCollider;
    private Collider2D collider2D;
    
    private bool isCollider2DExists => collider2D != null;
    private bool isLastButtonExists => lastButtonCollider != null;
    private bool isButtonNew => lastButtonCollider != collider2D;
    private bool isLastButtonNotInFocus => isLastButtonExists && isButtonNew && lastButtonCollider.CompareTag("Button");
    void Update() //Если нажал и на кнопку мыши и объект равен кнопке
                  //- послать активацию и записать в последние активированные
                  //Если последний активированный собираемся заменить на новый
                  //то его деактивируем
                  //если над текущей кнопкой отпускаем кнопку мыши
                  //посылаем деактивацию
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
}
