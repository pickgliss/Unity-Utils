using UnityEditor;
using UnityEngine;
using UnityUtils.EventSystem;

namespace Editor
{
    [CustomPropertyDrawer(typeof(EventChannel<>),true)]
    public class EventChannelDrawer : PropertyDrawer
    {
        // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        // {
        //     EditorGUI.PropertyField(position,property,label);
        // }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Calculate rects for UI elements
            Rect labelRect = new Rect(position.x, position.y, 80, position.height);
            Rect objectFieldRect = new Rect(position.x + 80, position.y, 120, position.height);
            Rect buttonRect = new Rect(position.x + position.width - 60, position.y, 60, position.height);

            // Draw label
            EditorGUI.LabelField(labelRect, label);
            // Draw the ObjectField
            EditorGUI.ObjectField(objectFieldRect, property, GUIContent.none);

            if (property.objectReferenceValue == null)
            {
                if (GUI.Button(buttonRect,"Create"))
                {
                    var type = property.serializedObject.targetObject.GetType().GetField(property.propertyPath)?.FieldType;
                    // var type = fieldInfo.FieldType;
                    var channel = ScriptableObject.CreateInstance(type);
                    channel.name = type.Name;
                    AssetDatabase.CreateAsset(channel, AssetDatabase.GenerateUniqueAssetPath("Assets/" + type.Name + ".asset"));
                    property.objectReferenceValue = channel;
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    property.serializedObject.ApplyModifiedProperties();
                }
            }else if (GUI.Button(buttonRect,"Test"))
            {
                property.objectReferenceValue.GetType().GetMethod("Test")?.Invoke(property.objectReferenceValue, null);
            }
            EditorGUI.EndProperty();
        }
    }
}