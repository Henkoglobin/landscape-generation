namespace ParameterParsing.Core {
    public interface IParameterProvider {
        T Get<T>(string key);
    }
}
