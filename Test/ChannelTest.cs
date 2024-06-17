using UnityEngine;
using EventChannel;

public class ChannelTest : MonoBehaviour
{
    public Channel channel;
    public FloatChannel floatChannel;
    public IntChannel intChannel;
    
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
