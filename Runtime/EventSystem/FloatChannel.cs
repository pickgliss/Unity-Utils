using UnityEngine;

namespace UnityUtils.EventSystem
{
    [CreateAssetMenu(menuName = "Events/FloatChannel")]
    public class FloatChannel : EventChannel<float>
    {
        public override float Cast(string value) => float.Parse(value);
    }
}