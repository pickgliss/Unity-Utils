using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.EventSystem
{
    public abstract class EventChannel<T> : ScriptableObject{
        readonly HashSet<IEventListener<T>> _observers = new();
        public void Invoke(T value) => _observers.ForEach(listener => listener.Raise(value));
        public void Register(EventListener<T> observer) => _observers.Add(observer);
        public void Deregister(EventListener<T> observer) => _observers.Remove(observer);
        public abstract T Cast(string value);
        public void Invoke(string value) => Invoke(Cast(value));
    }

    public readonly struct Empty { }

    [CreateAssetMenu(menuName = "Events/EventChannel")]
    public class EventChannel : EventChannel<Empty>
    {
        public void Invoke() => base.Invoke("");
        public override Empty Cast(string value) => default;
    }
}