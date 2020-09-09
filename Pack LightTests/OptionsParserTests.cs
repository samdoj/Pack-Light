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
            String[] opts = { @"C:\test.php" };
            var parsed = OptionsParser.Parse(opts);
            String[] fnames = parsed.GetValueOrDefault("FileNames");
           CollectionAssert.Contains(fnames,opts[0]);
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
        [TestMethod()]
        public void TestParseFileNamesBeforeSwitch()
        {
            String[] args = { "cat.php", "-s" };
            Assert.AreEqual(Parse(args).GetValueOrDefault("FileNames")[0], "cat.php");
        }
        [TestMethod()]
        public void TestParseConfigFileNameAsOnlyParam()
        {
            String[] args = { "plcfg.json" };
            Assert.AreEqual(Parse(args).GetValueOrDefault("ConfigFileName")[0], args[0]);
        }
        [TestMethod()]
        public void TestParseConfigFileNameOnDriveAsOnlyParam()
        {
            String[] args = { @"C:\plcfg\plcfg.json" };
            Assert.AreEqual(Parse(args).GetValueOrDefault("ConfigFileName")[0], args[0]);
        }
        /*
         //To test, remove plcfg.json from directory or rename to altconfig.json
 [TestMethod()]
        public void TestParseAlternativeConfigFileName()
        {
            String[] args = { @"altconfig.json" };
            var pv = Parse(args);
            Assert.AreEqual(Parse(args).GetValueOrDefault("ConfigFileName")[0], args[0]);
        }
        */
    }

}