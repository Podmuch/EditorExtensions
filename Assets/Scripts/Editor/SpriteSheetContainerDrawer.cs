using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpriteSheetContainer))]
public class SpriteSheetContainerDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty propertySprites = property.FindPropertyRelative("Sprites");
        SerializedProperty propertyId = property.FindPropertyRelative("selectedFolderId");
        EditorGUI.BeginProperty(position, label, property);
        GUIStyle style = new GUIStyle();
        style.fontSize = 25;
        style.fontStyle = FontStyle.Bold;
        EditorGUI.LabelField(new Rect(position.x, position.y, position.width * 0.5f, 50), label, style);
        if (propertySprites.isArray)
        {
            propertySprites.ClearArray();
            DirectoryInfo resourcesDirectory = new DirectoryInfo(GetResourcesPath());
            if (resourcesDirectory != null)
            {
                DirectoryInfo[] directories = resourcesDirectory.GetDirectories();
                string[] names = new string[directories.Length];
                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = directories[i].Name;
                }
                EditorGUI.LabelField(new Rect(position.x, position.y + 50, position.width * 0.5f, 50), "Source Folder:");
                propertyId.intValue = EditorGUI.Popup(new Rect(position.x+ position.width * 0.5f, position.y + 50, position.width * 0.5f, 50), propertyId.intValue, names);
                if(directories.Length > propertyId.intValue)
                {
                    Sprite[] sprites = Resources.LoadAll<Sprite>(directories[propertyId.intValue].Name);
                    bool odd = true;
                    for (int i = 0; i < sprites.Length; i++)
                    {
                        propertySprites.InsertArrayElementAtIndex(0);
                        SerializedProperty prop = propertySprites.GetArrayElementAtIndex(0);
                        prop.objectReferenceValue = sprites[i];
                        if (odd)
                        {
                            EditorGUI.DrawPreviewTexture(new Rect(position.x+50, position.y + (2 + i) * 50, 50, 50), sprites[i].texture);
                        }
                        else
                        {
                            EditorGUI.DrawPreviewTexture(new Rect(position.x+ 150, position.y + (1 + i) * 50, 50, 50), sprites[i].texture);
                        }
                        odd = !odd;
                    }
                }
            }
        }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty propertySprites = property.FindPropertyRelative("Sprites");
        return base.GetPropertyHeight(property, label)*5 + propertySprites.arraySize*50;
    }

    private string GetResourcesPath()
    {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.GetFullPath(new Uri(Path.Combine(Path.GetDirectoryName(path), "../../Assets/Resources")).AbsolutePath);
    }
}