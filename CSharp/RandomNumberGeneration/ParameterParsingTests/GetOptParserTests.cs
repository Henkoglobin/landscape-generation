using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParameterParsing;

namespace ParameterParsingTests {
    [TestClass]
    public class GetOptParserTests {
        [TestMethod]
        public void TestShortSingleInt() {
            var name = "x";
            var expected = 12;
            var input = $"-{name} {expected}";

            var parser = new GetOptParser();
            var provider = parser.Parse(input);

            Assert.AreEqual(expected, provider.Get<int>(name));
        }

        [TestMethod]
        public void TestLongSingleInt() {
            var name = "num";
            var expected = 12;
            var input = $"--{name} {expected}";

            var parser = new GetOptParser();
            var provider = parser.Parse(input);

            Assert.AreEqual(expected, provider.Get<int>(name));
        }

        [TestMethod]
        public void TestMultipleParameters() {
            var input = "-x 640 -y 480 --num 100 -vdi --no-commit";
            var parser = new GetOptParser();
            var provider = parser.Parse(input);

            Assert.AreEqual(640, provider.Get<int>("x"));
            Assert.AreEqual(480, provider.Get<int>("y"));
            Assert.AreEqual(100, provider.Get<int>("num"));
            Assert.AreEqual(true, provider.Get<bool>("v"));
            Assert.AreEqual(true, provider.Get<bool>("d"));
            Assert.AreEqual(true, provider.Get<bool>("i"));
            Assert.AreEqual(true, provider.Get<bool>("no-commit"));
        }
    }
}
