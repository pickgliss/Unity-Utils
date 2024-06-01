using UnityEditor;
using UnityEngine;
using UnityUtils.EventSystem;

namespace Editor
{
    [CustomPropertyDrawer(typeof(EventChannel<>),true)]
    public class EventChannelDrawer : PropertyDrawer
    {
        private readonly float _buttonWidth = 50;
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);
            var fieldWidth = rect.width - _buttonWidth;
            var labelWidth = fieldWidth * 0.4f;
            var objectFieldWidth = fieldWidth * 0.6f;
            // Calculate rects for UI elements
            var labelRect = new Rect(rect.x, rect.y, labelWidth, rect.height);
            var objectFieldRect = new Rect(rect.x + labelWidth, rect.y, objectFieldWidth, rect.height);
            var buttonRect = new Rect(rect.x + rect.width - _buttonWidth, rect.y, _buttonWidth, rect.height);

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