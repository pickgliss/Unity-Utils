using UnityEngine.Networking;

namespace UnityUtils
{
    public static class WebRequest
    {
        public static UnityWebRequest Get(string url)
        {
            return UnityWebRequest.Get(url);
        }
        public static UnityWebRequest Post(string url, string body)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            return request;
        }
    }
}