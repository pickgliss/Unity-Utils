using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.AssetEvents
{
    [CreateAssetMenu(menuName = "UnityUtils/AssetEvent")]
    public class AssetEvent : ScriptableObject
    {
        [ContextMenuItem("Rise", "Rise")]
        public string rise = "rise";
        readonly List<Action> _listeners = new();
        public void Rise() => _listeners.ForEach(action => action.Invoke());
        public void Add(Action listener) => _listeners.Add(listener);
        public void Remove(Action listener) => _listeners.Remove(listener);
    }
    
    public class AssetEvent<T> : ScriptableObject
    {
        [ContextMenuItem("TestValue", "TestValue")]
        public T value;
        public void TestValue()=> Rise(value);
        readonly List<Action<T>> _listeners = new();
        public void Rise(T arg) => _listeners.ForEach(action => action.Invoke(arg));
        public void Add(Action<T> listener) => _listeners.Add(listener);
        public void Remove(Action<T> listener) => _listeners.Remove(listener);
    }
}