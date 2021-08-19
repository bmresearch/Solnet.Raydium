using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solnet.Raydium.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Test
{
    [TestClass]
    public class DecodingTests
    {

        [TestMethod]
        public void TestBufferDecoder()
        {
            // 0x01 + 0x00000000 00000000
            var buf = BufferDecoder.CreateFromBase58("jpXCZedGfVR");
            Assert.AreEqual(1, buf.ReadByte());
            Assert.AreEqual(0U, buf.ReadU64());
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void TestBufferByteExhausted()
        {
            var buf = BufferDecoder.CreateFromBase58("jpXCZedGfVR");
            Assert.AreEqual(1, buf.ReadByte());
            Assert.AreEqual(0U, buf.ReadU64());
            buf.ReadByte();
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void TestBufferU64Exhausted()
        {
            var buf = BufferDecoder.CreateFromBase58("jpXCZedGfVR");
            Assert.AreEqual(1, buf.ReadByte());
            Assert.AreEqual(0, buf.ReadByte());
            buf.ReadU64();
        }

    }
}
