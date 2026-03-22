public interface ISerializer
{
    string Serialize<T>(T obj); // receives object and serealizes it
    T Deserealize<T>(string json);
}
