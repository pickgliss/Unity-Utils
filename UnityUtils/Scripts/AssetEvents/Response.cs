using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.AssetEvents
{
    public class Response : MonoBehaviour
    {
        public AssetEvent @event;
        public UnityEvent response;
        private void OnEnable() => @event.Add(response.Invoke);
        private void OnDisable() => @event.Remove(response.Invoke);
    }
    
    public class Response<T> : MonoBehaviour
    {
        public AssetEvent<T> @event;
        public UnityEvent<T> response;
        private void OnEnable() => @event.Add(response.Invoke);
        private void OnDisable() => @event.Remove(response.Invoke);
    }
}