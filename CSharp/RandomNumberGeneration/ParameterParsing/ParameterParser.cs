using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParameterParsing.Core;

namespace ParameterParsing {
    public class ParameterParser : IParameterParser {
        private enum ParserState {
            None, InKey, InValue
        }

        public IParameterProvider Parse(string input)
            => new DefaultParameterProvider(ParseImpl(input).ToDictionary(x => x.Key, x => x.Value));

        private IEnumerable<KeyValuePair<string, string>> ParseImpl(string input) {
            var state = ParserState.None;
            var keyBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();

            foreach(var c in input) {
                switch(c) {
                    case '=':
                        if(state == ParserState.InKey) {
                            state = ParserState.InValue;
                        } else {
                            throw new FormatException("Encountered an unexpected equals (=)");
                        }
                        break;
                    case ' ':
                        yield return MakeValue(state, keyBuilder, valueBuilder);

                        keyBuilder = new StringBuilder();
                        valueBuilder = new StringBuilder();
                        state = ParserState.None;
                        break;
                    default:
                        if(state == ParserState.None || state == ParserState.InKey) {
                            state = ParserState.InKey;
                            keyBuilder.Append(c);
                        } else if(state == ParserState.InValue) {
                            valueBuilder.Append(c);
                        }
                        break;
                }
            }

            yield return MakeValue(state, keyBuilder, valueBuilder);
        }

        private KeyValuePair<string, string> MakeValue(ParserState state, StringBuilder keyBuilder, StringBuilder valueBuilder)
            => new KeyValuePair<string, string>(
                key: keyBuilder.ToString(),
                value: state == ParserState.InValue
                    ? valueBuilder.ToString()
                    : "true");
    }
}
