namespace UnityUtils.EventSystem
{
    public class FloatListener : EventListener<float>
    {
        public FloatChannel channel;
        protected override void Awake()
        {
            Channel = channel;
            base.Awake();
        }
    }
}