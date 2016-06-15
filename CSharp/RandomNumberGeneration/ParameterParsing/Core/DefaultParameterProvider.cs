using System;
using System.Collections.Generic;

namespace ParameterParsing.Core {
    class DefaultParameterProvider : IParameterProvider {
        private Dictionary<string, string> parameters;

        public T Get<T>(string key) {
            string result;
            if(parameters.TryGetValue(key, out result)) {
                return (T)Convert.ChangeType(result, typeof(T));
            } else {
                return default(T);
            }
        }

        public DefaultParameterProvider(Dictionary<string, string> values) {
            this.parameters = values;
        }
    }
}
