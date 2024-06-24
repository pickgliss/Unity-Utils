using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtils
{
    public static class WebRequestExtensions
    {
        public static async Task<string> Request(this UnityWebRequest request)
        {
            await request.SendWebRequest().AsTask();
            var content = request.downloadHandler.text;
            request.Dispose();
            if (request.result == UnityWebRequest.Result.Success)
            {
                return content;
            }
            else
            {
                Debug.LogError($"Request failed with error: {request.error}");
                return default;
            }
        }
    }
}