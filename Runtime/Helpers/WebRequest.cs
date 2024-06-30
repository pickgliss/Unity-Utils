using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtils
{
    public static class WebRequest
    {
        public static UnityWebRequestAsyncOperation Get(string url)
        {
            var request = UnityWebRequest.Get(url);
            return request.SendWebRequest();
        }

        public static UnityWebRequestAsyncOperation Post(string url, string body)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            return request.SendWebRequest();
        }

        public static async void WithCallback(this UnityWebRequestAsyncOperation operation, Action<string> callback)
        {
            await operation.AsTask();
            if (operation.webRequest.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(operation.webRequest.downloadHandler.text);
            }
            else
            {
                var url = operation.webRequest.url;
                Debug.LogError($"{url}  error: {operation.webRequest.error}");
            }
        }

        public static async Task<T> WithSerializer<T>(this UnityWebRequestAsyncOperation operation,
            ISerializer serializer = null)
        {
            var s = serializer ?? ISerializer.Json;
            await operation.AsTask();
            if (operation.webRequest.result == UnityWebRequest.Result.Success)
            {
                return s.Deserialize<T>(operation.webRequest.downloadHandler.text);
            }
            var url = operation.webRequest.url;
            Debug.LogError($"{url}  error: {operation.webRequest.error}");
            return default;
        }
    }
}