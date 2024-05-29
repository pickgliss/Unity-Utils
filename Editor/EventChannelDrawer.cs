using UnityEditor;
using UnityEngine;
using UnityUtils.EventSystem;

namespace Editor
{
    [CustomPropertyDrawer(typeof(EventChannel<>),true)]
    public class EventChannelDrawer : PropertyDrawer
    {
        private readonly float _labelWidth = 80;
        private readonly float _objectFieldWidth = 120;
        private readonly float _buttonWidth = 60;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Calculate rects for UI elements
            var labelRect = new Rect(position.x, position.y, _labelWidth, position.height);
            var objectFieldRect = new Rect(position.x + _labelWidth, position.y, _objectFieldWidth, position.height);
            var buttonRect = new Rect(position.x + position.width - _buttonWidth, position.y, _buttonWidth, position.height);

            // Draw label
            EditorGUI.LabelField(labelRect, label);
            // Draw the ObjectField
            EditorGUI.ObjectField(objectFieldRect, property, GUIContent.none);

            if (property.objectReferenceValue == null)
            {
                if (GUI.Button(buttonRect,"Create"))
                {
                    var type = property.serializedObject.targetObject.GetType().GetField(property.propertyPath)?.FieldType;
                    if(type == null) throw new System.Exception("Property Type not found");
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