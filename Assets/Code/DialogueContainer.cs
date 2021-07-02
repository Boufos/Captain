using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueContainer : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues;
    [NonSerialized] private int currentDialogueIndex = 0;
    [SerializeField] private ScoreContainer scoreContainer;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ChoicesBox choicesBox;
    [SerializeField] private CharacterScreen characterScreen;
    [SerializeField] private GameObject firstEnd;
    [SerializeField] private GameObject secondEnd;
    [SerializeField] private Button nextDayButton;

    public int day = 0;
    private int[] eventsCountInDay = new[] {2,6, 10, 15};
    
    public bool first = true;
    
    private string _line;
    private bool drawing = false;
    
    private void Start()
    {
        Call(0);
    }

    public void Call(int buttonIndex)
    {
        if (drawing == true)
        {
            return;
        }

        if (currentDialogueIndex == dialogues.Count) // Концовка
        {
            if (first)
            {
                firstEnd.SetActive(true);
            }
            else
            {
                secondEnd.SetActive(true);
            }
        }

        if (currentDialogueIndex == eventsCountInDay[day])
        {
            nextDayButton.closed = false;
            choicesBox.avaibleToSelect = false;
            StartCoroutine(DrawText($"День {day+1} окончен.\nНажмите на кнопку \"Следующий день\""));
            currentDialogueIndex++;
            return;
        }

        _line = dialogues[currentDialogueIndex].GetLineOrChoice(buttonIndex, scoreContainer, choicesBox, characterScreen);

        if (_line == "+")
        {
            currentDialogueIndex++;
            _line = "";
        }

        drawing = true;
        StartCoroutine(DrawText(_line));
    }

    private IEnumerator DrawText(string line)
    {
        string[] words = line.Split(' ');
        string textToDraw = "";
        string tempText = "";
        int length = line.Length;
        int i = 0;

        foreach (string word in words)
        {
            foreach (char c in word)
            {
                yield return new WaitForSeconds(0.02f);
                tempText += c;
                text.text = textToDraw + tempText;
                i++;
            }

            tempText = "";
            textToDraw += word+" ";
            text.text = textToDraw;
        }

        drawing = false;
        choicesBox.Draw();
    }
}
