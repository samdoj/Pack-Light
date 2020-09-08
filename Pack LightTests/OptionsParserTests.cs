using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Pack_Light.Tests
{
    using static OptionsParser;
    [TestClass()]
    public class OptionsParserTests
    {

        [TestMethod()]
        public void TestParseFileName()
        {
            String[] opts = { "C:\test.php" };
            var parsed = OptionsParser.Parse(opts);
            String[] fnames = parsed.GetValueOrDefault("FileNames");
            Assert.AreEqual(opts[0], fnames[0]);
        }
        [TestMethod()]
        public void TestParseMultipleFiles()
        {
            String[] args = { "test1.php", "test2.php", "test3.php" };
            String[] fnames = Parse(args).GetValueOrDefault("FileNames");
            Assert.AreEqual(args, fnames);
        }
        [TestMethod()]
        public void TestParseOneSwitch()
        {
            String[] args = { "-switch", "1", "2" };
            string[] arr = { "1", "2" };
            String[] switches = OptionsParser.Parse(args).GetValueOrDefault("-switch");
            CollectionAssert.AreEqual(switches, new String[] { "1", "2" });   
        }
        [TestMethod()]
        public void TestParseMultipleSwitches()
        {
            String[] args = {"-switch1","A","B","C","-switch2","1","2","3"};
            var parsed = Parse(args);
            CollectionAssert.AreEqual(parsed.GetValueOrDefault("-switch1"), new string[] { "A", "B", "C" });
            CollectionAssert.AreEqual(parsed.GetValueOrDefault("-switch2"), new string[] { "1", "2", "3" });
        }
    }

}