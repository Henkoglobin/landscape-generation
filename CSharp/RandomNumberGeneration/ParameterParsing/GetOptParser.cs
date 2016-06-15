using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParameterParsing.Core;

namespace ParameterParsing {
    public class GetOptParser : IParameterParser {
        private enum ParserState {
            None, InShortParam, InLongParam, InArgument
        }

        public IParameterProvider Parse(string input) {
            return new DefaultParameterProvider(ParseImpl(input).ToDictionary(x => x.Key, x => x.Value));
        }

        private IEnumerable<KeyValuePair<string, string>> ParseImpl(string input) {
            var state = ParserState.None;
            var paramBuilder = new StringBuilder();
            var argumentBuilder = new StringBuilder();

            foreach(var c in input) {
                switch(c) {
                    case '-':
                        if(state == ParserState.None) {
                            state = ParserState.InShortParam;
                        } else if(state == ParserState.InShortParam) {
                            state = ParserState.InLongParam;
                        } else if(state == ParserState.InLongParam) {
                            paramBuilder.Append(c);
                        } else if(state == ParserState.InArgument && argumentBuilder.Length == 0) {
                            yield return MakeReturnValue(paramBuilder.ToString(), "true");
                            paramBuilder = new StringBuilder();
                            state = ParserState.InShortParam;
                        } else {
                            argumentBuilder.Append(c);
                        }
                        break;
                    case ' ':
                        if(state == ParserState.InShortParam || state == ParserState.InLongParam) {
                            state = ParserState.InArgument;
                        } else {
                            yield return MakeReturnValue(paramBuilder.ToString(), argumentBuilder.ToString());
                            paramBuilder = new StringBuilder();
                            argumentBuilder = new StringBuilder();
                            state = ParserState.None;
                        }
                        break;
                    default:
                        if(state == ParserState.InArgument) {
                            argumentBuilder.Append(c);
                        } else if(state == ParserState.InShortParam) {
                            if(paramBuilder.Length > 0) {
                                yield return MakeReturnValue(paramBuilder.ToString(), "true");
                                paramBuilder = new StringBuilder();
                            }
                            paramBuilder.Append(c);
                        } else if(state == ParserState.InLongParam) {
                            paramBuilder.Append(c);
                        }
                        break;
                }
            }

            yield return MakeReturnValue(paramBuilder.ToString(), argumentBuilder.Length > 0 ? argumentBuilder.ToString() : "true");
        }

        private KeyValuePair<string, string> MakeReturnValue(string param, string arg) {
            return new KeyValuePair<string, string>(param, arg);
        }
    }
}
