using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create character")]
public class Character : ScriptableObject
{
    [SerializeField] public Sprite face;
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public string from;
}
