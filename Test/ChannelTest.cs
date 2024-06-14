using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityUtils.EventChannel;

public class ChannelTest : MonoBehaviour
{
    [FormerlySerializedAs("eventChannel")] public Channel channel;
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
