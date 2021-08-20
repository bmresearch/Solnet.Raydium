using Solnet.Raydium.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Models.Layouts
{
    /// <summary>
    /// STAKE_INFO_LAYOUT
    /// </summary>
    public class StakeInfo
    {

        public ulong State { get; set; }

        public ulong Nonce { get; set; }

        public PublicKey PoolLpTokenAccount { get; set; }

        public PublicKey PoolRewardTokenAccount { get; set; }

        public PublicKey Owner { get; set; }

        public PublicKey FeeOwner { get; set; }

        public ulong FeeY { get; set; }

        public ulong FeeX { get; set; }

        public ulong TotalReward { get; set; }

        public U128 RewardPerShareNet { get; set; }

        public ulong LastBlock { get; set; }

        public ulong RewardPerBlock { get; set; }

    }
}
