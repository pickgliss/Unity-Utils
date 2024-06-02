using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.EventSystem
{
    public interface IEventListener<in T> {
        void Raise(T value);
    }
    public abstract class EventListener<T> : MonoBehaviour,IEventListener<T> {
        [SerializeField] protected EventChannel<T> channel;
        [SerializeField] UnityEvent<T> unityEvent;
        protected virtual void Awake() => channel.Register(this);
        protected void OnDestroy() => channel.Deregister(this);
        public void Raise(T value) => unityEvent?.Invoke(value);
    }
    public class EventListener : EventListener<Empty> { }
}