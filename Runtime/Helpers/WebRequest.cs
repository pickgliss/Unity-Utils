using System;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtils
{
    [Serializable]
    public class WebRequest
    {
        public string url;
        public event Action<string> OnComplete;
        public async void Get()
        {
            var request = UnityWebRequest.Get(url);
            await request.SendWebRequest().AsTask();
            if (request.result == UnityWebRequest.Result.Success)
            {
                HandleResponse(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError($"Request failed with error: {request.error}");
            }
        }
        public async void Post(string body)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            await request.SendWebRequest().AsTask();
            if (request.result == UnityWebRequest.Result.Success)
            {
                HandleResponse(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError($"Request failed with error: {request.error}");
            }
        }
        protected virtual void HandleResponse(string response)
        {
            OnComplete?.Invoke(response);
        }
    }
}