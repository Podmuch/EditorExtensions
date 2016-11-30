﻿using UnityEngine;

[CreateAssetMenu(fileName ="aaaa",menuName = "LevelData3")]
public class LevelDataScriptable : ScriptableObject
{
    public int LevelNumber = 1;
    public string LevelName = "name";
    public Difficulty LevelOfDifficulty = Difficulty.MEDIUM;
    public int NumberOfEnemies = 20;
    [Tooltip("Wygrana jaką gracz otrzyma za przejście poziomu")]
    public int Prize;
    [Range(0.0f, 1.0f)]
    public float ProbabilityOfBonus;
    [HideInInspector]
    public string HiddenData;
}