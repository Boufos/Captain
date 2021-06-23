using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterScreen : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI text;
    

    public void Draw(Character character)
    {
        spriteRenderer.sprite = character.face;
        text.text = $"<size=24>{character.name}</size><br>{character.description}<br>Из: {character.from}";
    }
}
