using System;
using UnityEngine;

[Serializable]
public class SpriteSheetContainer
{
    public Sprite[] Sprites;
    [SerializeField]
    private int selectedFolderId;
}