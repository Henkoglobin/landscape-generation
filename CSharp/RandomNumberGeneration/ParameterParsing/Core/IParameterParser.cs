namespace ParameterParsing.Core {
    interface IParameterParser {
        IParameterProvider Parse(string input);
    }
}
