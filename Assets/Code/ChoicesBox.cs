using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoicesBox : MonoBehaviour
{
    [SerializeField] public List<string> labels;
    [SerializeField] private int selectedItemIndex;
    [SerializeField] private DialogueContainer dialogueContainer;
    [SerializeField] private RectTransform selectorPosition;
    [SerializeField] private RectTransform[] selectorPositions;
    private TextMeshProUGUI _text;

    public int SelectedItemIndex
    {
        get => selectedItemIndex;
        set
        {
            if (value > labels.Count-1)
                selectedItemIndex = 0;
            else if (value < 0)
                selectedItemIndex = labels.Count-1;
            else
                selectedItemIndex = value;
        }
    }

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Draw();
    }

    public void Draw()
    {
        selectorPosition.position = selectorPositions[SelectedItemIndex].position;
        _text.text = "";
        for (int i = 0; i < labels.Count; i++)
        {
            string label = labels[i] == null ? "---" : labels[i];
            
            if (selectedItemIndex == i)
            {
                _text.text += "<color=black>" + label + "</color>\n";
                continue;
            }
            _text.text += labels[i] + "\n";
        }
    }

    public void ArrowUp()
    {
        SelectedItemIndex--;
        Draw();
    }

    public void ArrowDown()
    {
        SelectedItemIndex++;
        Draw();
    }

    public void Select()
    {
        dialogueContainer.Call(SelectedItemIndex);
        Draw();
        SelectedItemIndex = 0;
    }
}

