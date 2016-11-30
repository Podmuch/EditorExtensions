using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MagicProperty))]
public class MagicPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty propertyColor = property.FindPropertyRelative("propertyColor");
        SerializedProperty propertyToggle = property.FindPropertyRelative("toggleValue");

        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.DrawRect(new Rect(position.x, position.y, position.width, position.height * 0.5f), propertyColor.colorValue);
        EditorGUI.LabelField(new Rect(position.x, position.y, position.width*0.5f, position.height * 0.5f), "kolor tła:");
        propertyColor.colorValue = EditorGUI.ColorField(new Rect(position.x + position.width * 0.5f, position.y, position.width * 0.5f, position.height * 0.5f), propertyColor.colorValue);
        EditorGUI.LabelField(new Rect(position.x, position.y + position.height * 0.5f, position.width * 0.5f, position.height * 0.5f), "Toggle:");
        propertyToggle.boolValue = EditorGUI.Toggle(new Rect(position.x + position.width * 0.5f, position.y + position.height * 0.5f, position.width * 0.5f, position.height * 0.5f), propertyToggle.boolValue);
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }
}