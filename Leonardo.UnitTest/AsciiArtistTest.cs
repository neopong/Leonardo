using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Leonardo.UnitTest
{
    [TestClass]
    public class AsciiArtistTest 
    {
        [TestMethod]
        public void _mapColorToAsciiTest()
        {
            AsciiArtist a = new AsciiArtist();

            char spc = (char)a.GetType().GetMethod("_mapColorToAscii",
    BindingFlags.NonPublic | BindingFlags.Instance).Invoke(a, new object[] { (byte)255 });
            char at = (char)a.GetType().GetMethod("_mapColorToAscii",
    BindingFlags.NonPublic | BindingFlags.Instance).Invoke(a, new object[] { (byte)0 });
            char amp = (char)a.GetType().GetMethod("_mapColorToAscii",
    BindingFlags.NonPublic | BindingFlags.Instance).Invoke(a, new object[] { (byte)33 });

            Assert.AreEqual(' ', spc);
            Assert.AreEqual('@', at);
            Assert.AreEqual('&', amp);

        }


    }
}
