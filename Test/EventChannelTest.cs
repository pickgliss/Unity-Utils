using Sirenix.OdinInspector;
using UnityEngine;
using UnityUtils.EventSystem;

public class EventChannelTest : MonoBehaviour
{
    public EventChannel eventChannel;
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
