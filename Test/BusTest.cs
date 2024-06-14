using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityUtils.EventBus;

namespace Test
{
    public class BusTest : MonoBehaviour
    {
        public void TestStringEvent()
        {
            EventBus<IntEvent>.Raise(new IntEvent {value = 3});
        }
        private EventBinding<IntEvent> _onStringEvent;
        private void Awake() => _onStringEvent = new EventBinding<IntEvent>(OnStringEvent);
        private void OnEnable() => EventBus<IntEvent>.Register(_onStringEvent);
        private void OnDisable() => EventBus<IntEvent>.Deregister(_onStringEvent);

        private void OnStringEvent(IntEvent obj)
        {
            Debug.Log($"String event received: {obj.value}");
        }

        public struct IntEvent : IEvent
        {
            public int value;
        }
    }
}