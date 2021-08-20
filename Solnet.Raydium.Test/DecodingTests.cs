using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solnet.Raydium.Models.Layouts;
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

        [TestMethod]
        public void TestDecodeStakeInfo()
        {
            var data = "AQAAAAAAAAD/AAAAAAAAAHVGOxPNp222DfzL4x7V/CEcMZ3a7PPcqhvSOyeluvlpn0MrR+YigqNY5gHNDbS0emUyAmyVMnqGUqdDfzD3JJffAl8MQ4lt+9LLGPp3nkGhaxCx802CIpEdi/Wrpm69I98CXwxDiW370ssY+neeQaFrELHzTYIikR2L9aumbr0j6AMAAAAAAAABAAAAAAAAAICeCXdfAQAAWTQqrxQAAAAAAAAAAAAAAC6lgwUAAAAAYOoAAAAAAAA=";
            var buf = BufferDecoder.CreateFromBase64(data);
            var obj = buf.DecodeAs<StakeInfo>();
            Assert.AreEqual(1U, obj.State);
            Assert.AreEqual(255U, obj.Nonce);
            Assert.AreEqual("8tnpAECxAT9nHBqR1Ba494Ar5dQMPGhL31MmPJz1zZvY", obj.PoolLpTokenAccount.Key);
            Assert.AreEqual("BihEG2r7hYax6EherbRmuLLrySBuSXx4PYGd9gAsktKY", obj.PoolRewardTokenAccount.Key);
            Assert.AreEqual("G1Y1oLPnHnndErCydT1GVGLiMuB51THQiRfrDVCH4Hsx", obj.Owner.Key);
            Assert.AreEqual("G1Y1oLPnHnndErCydT1GVGLiMuB51THQiRfrDVCH4Hsx", obj.FeeOwner.Key);
            Assert.AreEqual(1000U, obj.FeeY);
            Assert.AreEqual(1U, obj.FeeX);
            Assert.AreEqual(1509530640000U, obj.TotalReward);
            Assert.AreEqual("88838124633", obj.RewardPerShareNet.Value.ToString());
            Assert.AreEqual(92513582U, obj.LastBlock);
            Assert.AreEqual(60000U, obj.RewardPerBlock);

        }




    }
}
