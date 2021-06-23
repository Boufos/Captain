using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create choice")]
public class Choice : ScriptableObject
{
    [SerializeField] public string label;
    [SerializeField] public List<string> lines;
    [SerializeField] public List<Character> characters;
    [SerializeField] private int toHealth;
    [SerializeField] private int toMorale;
    [SerializeField] private int toCondition;
    [SerializeField] private int toFuel;
    [NonSerialized] private int currentLineIndex = 0;
    
    public string Perform(ScoreContainer scoreContainer, CharacterScreen characterScreen) 
    { 
        if (lines.Count == currentLineIndex)
            return "+";
        string _line = lines[currentLineIndex];
        
        if (currentLineIndex == 0)
            PerformAddition(scoreContainer);

        if (currentLineIndex < lines.Count)
            characterScreen.Draw(characters[currentLineIndex]);
        currentLineIndex++;
        return _line;
    }

    private void PerformAddition(ScoreContainer scoreContainer)
    {
        scoreContainer.health += toHealth;
        scoreContainer.morale += toMorale;
        scoreContainer.condition += toCondition;
        scoreContainer.fuel += toFuel;
    }
}
