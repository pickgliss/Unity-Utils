namespace Persistence {
    public interface ISerializer {
        public static ISerializer Json = new JsonSerializer();
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}