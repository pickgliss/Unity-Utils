using System.Collections.Generic;
using UnityEngine;

namespace EventChannel
{
    public abstract class Channel<T> : ScriptableObject{
        readonly HashSet<IListener<T>> _observers = new();
        public void Invoke(T value) => _observers.ForEach(listener => listener.Raise(value));
        public void Register(Listener<T> observer) => _observers.Add(observer);
        public void Deregister(Listener<T> observer) => _observers.Remove(observer);
        public abstract T Cast(string value);
        public void Invoke(string value) => Invoke(Cast(value));
    }

    public readonly struct Empty { }

    [CreateAssetMenu(menuName = "Events/Channel")]
    public class Channel : Channel<Empty>
    {
        public void Invoke() => base.Invoke("");
        public override Empty Cast(string value) => default;
    }
}