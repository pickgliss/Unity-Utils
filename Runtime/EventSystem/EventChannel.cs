using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.EventSystem
{
    public abstract class EventChannel<T> : ScriptableObject{
        readonly HashSet<EventListener<T>> _observers = new();
        public void Invoke(T value) => _observers.ForEach(listener => listener.Raise(value));
        public void Register(EventListener<T> observer) => _observers.Add(observer);
        public void Deregister(EventListener<T> observer) => _observers.Remove(observer);
        public abstract void Test(string value);
    }

    public readonly struct Empty { }

    [CreateAssetMenu(menuName = "Events/EventChannel")]
    public class EventChannel : EventChannel<Empty>
    {
        public void Invoke() => base.Invoke(default);
        public override void Test(string value) => Invoke();
    }
}