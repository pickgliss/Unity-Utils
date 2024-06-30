public interface ISerializer {
    public static readonly ISerializer Json = new JsonSerializer();
    string Serialize<T>(T obj);
    T Deserialize<T>(string json);
}
