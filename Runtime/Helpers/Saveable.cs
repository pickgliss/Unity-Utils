using System.Collections.Generic;
using System.Linq;
using UnityEngine;
        
public interface ISaveable  {
    SerializableGuid Id { get; set; }
}

public interface IBind<TData> where TData : ISaveable, new()
{
    SerializableGuid Id { get; set; }
    void Bind(TData data);
    public static void To<T>(TData source) where T : MonoBehaviour, IBind<TData>{
        var entity = Object.FindObjectsByType<T>(FindObjectsSortMode.None).FirstOrDefault();
        if (entity != null) {
            if (source == null) {
                source = new TData { Id = entity.Id };
            }
            entity.Bind(source);
        }
    }
    
    public static void To<T>(List<TData> source) where T: MonoBehaviour, IBind<TData>{
        var entities = Object.FindObjectsByType<T>(FindObjectsSortMode.None);

        foreach(var entity in entities) {
            var data = source.FirstOrDefault(d=> d.Id == entity.Id);
            if (data == null) {
                data = new TData { Id = entity.Id };
                source.Add(data); 
            }
            entity.Bind(data);
        }
    }
}
