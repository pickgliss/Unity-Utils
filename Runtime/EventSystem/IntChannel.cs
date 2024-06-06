using UnityEngine;

namespace UnityUtils.EventSystem
{
    [CreateAssetMenu(menuName = "Events/IntChannel")]
    public class IntChannel : EventChannel<int>
    {
        public override int Cast(string value)=> int.Parse(value);
    }
}