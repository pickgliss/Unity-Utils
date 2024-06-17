using UnityEngine;

namespace EventChannel
{
    [CreateAssetMenu(menuName = "Events/IntChannel")]
    public class IntChannel : Channel<int>
    {
        public override int Cast(string value)=> int.Parse(value);
    }
}