
using System.Collections.Generic;
using System.Linq;
using Persistence;
using UnityEngine;

public static class BindableExtensions
{
    public static void Bind<T, TData>(this TData data) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new() {
        var entity = Object.FindObjectsByType<T>(FindObjectsSortMode.None).FirstOrDefault();
        if (entity != null) {
            if (data == null) {
                data = new TData { Id = entity.Id };
            }
            entity.Bind(data);
        }
    }

    public static void Bind<T, TData>(this List<TData> datas) where T: MonoBehaviour, IBind<TData> where TData : ISaveable, new() {
        var entities = Object.FindObjectsByType<T>(FindObjectsSortMode.None);

        foreach(var entity in entities) {
            var data = datas.FirstOrDefault(d=> d.Id == entity.Id);
            if (data == null) {
                data = new TData { Id = entity.Id };
                datas.Add(data); 
            }
            entity.Bind(data);
        }
    }
}