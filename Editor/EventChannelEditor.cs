using UnityEditor;
using UnityEngine;
using UnityUtils.EventChannel;

namespace Editor
{
    [CustomEditor(typeof(Channel<>),true)]
    public class EventChannelEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            OnInspectorGUI( (dynamic) target );
        }
        private string _testValue;
        private void OnInspectorGUI<T>(Channel<T> typedTarget) {
            EditorUtility.SetDirty(typedTarget);
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Value For Testing");  
            _testValue = GUILayout.TextField(_testValue);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Test"))
            {
                typedTarget.Invoke(_testValue);
            }
        }
    }
}