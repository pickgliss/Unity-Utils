using System;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtils
{
    [Serializable]
    public class WebRequest
    {
        public string url;
        
        public async void Get(Action<string> callback)
        {
            var request = UnityWebRequest.Get(url);
            await request.SendWebRequest().AsTask();
            if (request.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError($"Request failed with error: {request.error}");
            }
        }
        public async void Post(string body, Action<string> callback)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            await request.SendWebRequest().AsTask();
            if (request.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError($"Request failed with error: {request.error}");
            }
        }
    }
}