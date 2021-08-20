using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solnet.Raydium.Programs;
using Solnet.Raydium.Utilities;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Test
{
    [TestClass]
    public class ProgramTests
    {

        private const string MnemonicWords =
              "route clerk disease box emerge airport loud waste attitude film army tray" +
              " forward deal onion eight catalog surface unit card window walnut wealth medal";

        private const string Blockhash = "5cZja93sopRB9Bkhckj5WzCxCaVyriv2Uh5fFDPDFFfj";

        [TestMethod]
        public void TestBufferDecoder()
        {
            // get owner
            var ownerWallet = new Wallet.Wallet(MnemonicWords);
            var signer = ownerWallet.GetAccount(1);
            var pubkey = signer.PublicKey;
            Assert.AreEqual("9we6kjtbcZ2vy3GSLLsZTEhbAqXPTRvEyoxa8wxSqKp5", pubkey.Key);
            
            // build a transaction that invokes the StakeProgram's deposit instruction
            // it would be nonsense to pass the same public key into the deposit command like this 
            // in real life, but this is sufficient mockery for testing
            var builder = new TransactionBuilder();
            builder.SetFeePayer(signer)
                   .SetRecentBlockHash(Blockhash)
                   .AddInstruction(StakeProgram.Deposit(pubkey, pubkey, pubkey, pubkey, pubkey, pubkey, pubkey, pubkey, 0U))
                   .AddInstruction(StakeProgram.Deposit(pubkey, pubkey, pubkey, pubkey, pubkey, pubkey, pubkey, pubkey, 123456U));

            // sign the transaction
            var tx = builder.Build(signer);

            // give it a decode for a full round trip
            var decodedTx = Transaction.Deserialize(tx);
            Assert.IsNotNull(decodedTx);
            Assert.AreEqual(2, decodedTx.Instructions.Count);
            Assert.AreEqual("9we6kjtbcZ2vy3GSLLsZTEhbAqXPTRvEyoxa8wxSqKp5", decodedTx.FeePayer.Key);
            Assert.AreEqual("jpXCZedGfVR", (new BufferEncoder(decodedTx.Instructions[0].Data).ToBase58()));
            Assert.AreEqual("vfxzYtddBom", (new BufferEncoder(decodedTx.Instructions[1].Data).ToBase58()));
        }

    }
}
