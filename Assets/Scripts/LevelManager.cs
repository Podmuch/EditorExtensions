using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Space]
    [Space]
    [Space]
    [Header("Informacje o poziomach")]
    [SerializeField]
    private List<LevelData> levelData;
    [SerializeField]
    private List<LevelDataScriptable> levelDataScriptable;
}