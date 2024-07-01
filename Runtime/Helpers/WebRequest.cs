using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtils
{
    public static class WebRequest
    {
        public static UnityWebRequest Get(string url)
        {
            var request = UnityWebRequest.Get(url);
            return request;
        }

        public static UnityWebRequest Post(string url, string body)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            return request;
        }

        public static async Task<string> Run(this UnityWebRequest request)
        {
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                return request.downloadHandler.text;
            }
            Debug.LogError($"{request.url}  error: {request.error}");
            return null;
        }

        public static async Task<T> Run<T>(this UnityWebRequest request,
            ISerializer serializer = null)
        {
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                var s = serializer ?? ISerializer.Json;
                return s.Deserialize<T>(request.downloadHandler.text);
            }
            var url = request.url;
            Debug.LogError($"{url}  error: {request.error}");
            return default;
        }
    }
}