using UnityEngine;

namespace EventChannel
{
    [CreateAssetMenu(menuName = "Events/FloatChannel")]
    public class FloatChannel : Channel<float>
    {
        public override float Cast(string value) => float.Parse(value);
    }
}