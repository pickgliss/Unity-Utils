﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityUtils {
    public static class Helpers {
        static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDict = new(100, new FloatComparer());

        /// <summary>
        /// Returns a WaitForSeconds object for the specified duration. </summary>
        /// <param name="seconds">The duration in seconds to wait.</param>
        /// <returns>A WaitForSeconds object.</returns>
        public static WaitForSeconds GetWaitForSeconds(float seconds) {
            if (seconds < 1f / Application.targetFrameRate) return null;

            if (!WaitForSecondsDict.TryGetValue(seconds, out var forSeconds)) {
                forSeconds = new WaitForSeconds(seconds);
                WaitForSecondsDict[seconds] = forSeconds;
            }

            return forSeconds;
        }

        class FloatComparer : IEqualityComparer<float> {
            public bool Equals(float x, float y) => Mathf.Abs(x - y) <= Mathf.Epsilon;
            public int GetHashCode(float obj) => obj.GetHashCode();
        }
        
        public static Guid CreateGuidFromString(string input) {
            return new Guid(MD5.Create().ComputeHash(Encoding.Default.GetBytes(input)));
        }
    
        public static Vector2 ClampToScreen(VisualElement element, Vector2 targetPosition) {
            float x = Mathf.Clamp(targetPosition.x, 0, Screen.width - element.layout.width);
            float y = Mathf.Clamp(targetPosition.y, 0, Screen.height - element.layout.height);

            return new Vector2(x, y);
        }

        /// <summary>
        /// Clears the console log in the Unity Editor.
        /// </summary>
#if UNITY_EDITOR        
        public static void ClearConsole() {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method?.Invoke(new object(), null);
        }
#endif        
    }
}
