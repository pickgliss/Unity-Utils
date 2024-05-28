using Sirenix.OdinInspector;
using UnityEngine;
using UnityUtils.EventSystem;

public class EventChannelTest : MonoBehaviour
{
    // [Header("Channels")]
    // [SerializeField,HideLabel,InlineButton("TestEmptyChannel")] private EventChannel emptyChannel;
    // [SerializeField,HideLabel,InlineButton("TestFloatChannel")] private FloatChannel floatChannel;
    // [SerializeField,HideLabel,InlineButton("TestIntChannel")] private IntChannel intChannel;
    //
    
    [Button]
    public void TestEmptyChannel(EventChannel channel)
    {
        Debug.Log("Empty channel invoked");
        channel.Invoke();
    }
    [Button]
    public void TestFloatChannel(FloatChannel channel)
    {
        Debug.Log("Float channel invoked");
        channel.Invoke(1.0f);
    }
    [Button]
    public void TestIntChannel( IntChannel channel)
    {
        Debug.Log("Int channel invoked");
        channel.Invoke(2);
    }
    
    public void ReceiveEmpty()
    {
        Debug.Log("Empty channel received");
    }
    
    public void ReceiveFloat(float value)
    {
        Debug.Log($"Float channel received: {value}");
    }
    
    public void ReceiveInt(int value)
    {
        Debug.Log($"Int channel received: {value}");
    }
}
