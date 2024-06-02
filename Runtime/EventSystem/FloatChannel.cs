using UnityEngine;

namespace UnityUtils.EventSystem
{
    [CreateAssetMenu(menuName = "Events/FloatChannel")]
    public class FloatChannel : EventChannel<float>
    {
        public override void Test(string value)
        {
            if (float.TryParse(value, out var floatValue))
            {
                Invoke(floatValue);
            }
        }
    }
}