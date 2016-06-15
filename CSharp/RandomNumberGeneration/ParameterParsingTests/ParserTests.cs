using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParameterParsing;

namespace ParameterParsingTests {
    [TestClass]
    public class ParserTests {
        [TestMethod]
        public void ParseSingleInt() {
            var name = "num";
            var expected = 12;

            var input = $"{name}={expected}";
            var parser = new ParameterParser();
            var provider = parser.Parse(input);

            Assert.AreEqual(expected, provider.Get<int>(name));
        }

        [TestMethod]
        public void ParseSingleBool() {
            var name = "optimize";
            var expected = true;

            var input = $"{name}";
            var parser = new ParameterParser();
            var provider = parser.Parse(input);

            Assert.AreEqual(expected, provider.Get<bool>(name));
        }

        [TestMethod]
        public void ParseMultipleParameters() {
            var input = "w=640 h=480 optimize no-default";
            var parser = new ParameterParser();
            var provider = parser.Parse(input);

            Assert.AreEqual(640, provider.Get<int>("w"));
            Assert.AreEqual(480, provider.Get<int>("h"));
            Assert.AreEqual(true, provider.Get<bool>("optimize"));
            Assert.AreEqual(true, provider.Get<bool>("no-default"));
        }
    }
}
