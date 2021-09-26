using Solnet.Programs;
using Solnet.Raydium.Utilities;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Programs
{
    /// <summary>
    /// Contains methods to interact with the Raydium Stake Program.
    /// </summary>
    public class StakeProgram
    {

        /// <summary>
        /// The public key of the on-chain Raydium stake program.
        /// </summary>
        public static readonly PublicKey ProgramId = new(Consts.STAKE_PROGRAM_ID);

        /// <summary>
        /// Generate a transaction instruction that invokes the Deposit method of the Stake program.
        /// </summary>
        /// <returns></returns>
        public static TransactionInstruction Deposit(PublicKey poolId,
                                                     PublicKey poolAuthority,
                                                     PublicKey userInfoAccount,
                                                     PublicKey owner,
                                                     PublicKey userLpTokenAccount,
                                                     PublicKey poolLpTokenAccount,
                                                     PublicKey userRewardTokenAccount,
                                                     PublicKey poolRewardTokenAccount,
                                                     ulong depositAmountRaw)
        {

            var keys = new List<AccountMeta>();
            keys.Add(AccountMeta.Writable(poolId, false));                      // 01 Pool ID 
            keys.Add(AccountMeta.Writable(poolAuthority, false));               // 02 Pool Authority
            keys.Add(AccountMeta.Writable(userInfoAccount, false));             // 03 User Info Account 
            keys.Add(AccountMeta.Writable(owner, true));                        // 04 User Owner
            keys.Add(AccountMeta.Writable(userLpTokenAccount, false));          // 05 User LP Token Account
            keys.Add(AccountMeta.Writable(poolLpTokenAccount, false));          // 06 Pool LP Token Account
            keys.Add(AccountMeta.Writable(userRewardTokenAccount, false));      // 07 User Reward Token Account
            keys.Add(AccountMeta.Writable(poolRewardTokenAccount, false));      // 08 Pool Reward Token Account
            keys.Add(AccountMeta.Writable(Consts.SYSVAR_CLOCK_PUBKEY, false));  // 09 SYSVAR Clock 
            keys.Add(AccountMeta.Writable(TokenProgram.ProgramIdKey, false));   // 10 Token Program

            // var 
            var data = new BufferEncoder(9);
            data.WriteByte(1);
            data.WriteU64(depositAmountRaw);

            // build
            return TransactionInstructionFactory.Create(ProgramId, keys, data.GetBytes());

        }

    }
}
