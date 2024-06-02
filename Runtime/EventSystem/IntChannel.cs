using UnityEngine;

namespace UnityUtils.EventSystem
{
    [CreateAssetMenu(menuName = "Events/IntChannel")]
    public class IntChannel : EventChannel<int>
    {
        public override void Test(string value)
        {
            if (int.TryParse(value, out var intValue))
            {
                Invoke(intValue);
            }
        }
    }
}