using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.EventChannel
{
    public interface IListener<in T> {
        void Raise(T value);
    }
    public abstract class Listener<T> : MonoBehaviour,IListener<T> {
        [SerializeField] protected Channel<T> channel;
        [SerializeField] UnityEvent<T> unityEvent;
        protected virtual void Awake() => channel.Register(this);
        protected void OnDestroy() => channel.Deregister(this);
        public void Raise(T value) => unityEvent?.Invoke(value);
    }
    public class Listener : Listener<Empty> { }
}