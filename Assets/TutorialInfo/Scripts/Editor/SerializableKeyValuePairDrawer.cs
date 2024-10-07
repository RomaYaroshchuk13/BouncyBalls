using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SerializableKeyValuePair<,>))]  
public class SerializableKeyValuePairDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var keyProperty = property.FindPropertyRelative("Key");
        var valueProperty = property.FindPropertyRelative("Value");

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var halfWidth = position.width / 2;
        var keyRect = new Rect(position.x, position.y, halfWidth, position.height);
        var valueRect = new Rect(position.x + halfWidth, position.y, halfWidth, position.height);

        EditorGUI.PropertyField(keyRect, keyProperty, GUIContent.none);
        EditorGUI.PropertyField(valueRect, valueProperty, GUIContent.none);

        EditorGUI.EndProperty();
    }
}
