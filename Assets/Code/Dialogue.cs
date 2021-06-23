using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Create dialogue")]
public class Dialogue : ScriptableObject
{
    public List<string> lines;
    public List<Character> characters;
    public List<Choice> choices;
    [NonSerialized] private int _currentLineIndex = 0;
    [NonSerialized] private Choice _recordedChoice;

    public string GetLineOrChoice(int buttonIndex, ScoreContainer scoreContainer, ChoicesBox choicesBox, CharacterScreen characterScreen)
    {
        Debug.Log(_currentLineIndex);
        choicesBox.labels.Clear();
        string _line = "";

        if (_currentLineIndex == lines.Count - 1)
        {
            foreach (Choice choice in choices)
            {
                choicesBox.labels.Add(choice.label);
            }
        }
        else
        {
            choicesBox.labels.Add("Продолжить");
        }

        if (_currentLineIndex == lines.Count)
        {
            _recordedChoice = choices[buttonIndex];
            _line = _recordedChoice.Perform(scoreContainer, characterScreen);
            _currentLineIndex++;
        }
        else if (_currentLineIndex > lines.Count)
        {
            _line = _recordedChoice.Perform(scoreContainer, characterScreen);
        }
        else
        {
            characterScreen.Draw(characters[_currentLineIndex]);
            _line = lines[_currentLineIndex];
            _currentLineIndex++;
        }
        return _line;
    }
}
