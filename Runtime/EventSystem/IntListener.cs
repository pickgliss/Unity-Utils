namespace UnityUtils.EventSystem
{
    public class IntListener : EventListener<int>
    {
        public IntChannel channel;
        protected override void Awake()
        {
            Channel = channel;
            base.Awake();
        }
    }
}