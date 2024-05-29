using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.EventSystem
{
    public abstract class EventListener<T> : MonoBehaviour {
        protected EventChannel<T> Channel;
        [SerializeField] UnityEvent<T> unityEvent;
        protected virtual void Awake() => Channel.Register(this);
        protected void OnDestroy() => Channel.Deregister(this);
        public void Raise(T value) => unityEvent?.Invoke(value);
    }
    public class EventListener : EventListener<Empty> { }
}