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
    /// STAKE_INFO_LAYOUT_V4
    /// </summary>
    public class StakeInfoV4
    {

        public ulong State { get; set; }

        public ulong Nonce { get; set; }

        public PublicKey PoolLpTokenAccount { get; set; }

        public PublicKey PoolRewardTokenAccount { get; set; }

        public ulong TotalReward { get; set; }

        public U128 PerShare { get; set; }

        public ulong PerBlock { get; set; }

        public ulong Option { get; set; }

        public PublicKey PoolRewardTokenAccountB { get; set; }

        public Blob7 Blob7 { get; set; }

        public ulong TotalRewardB { get; set; }

        public U128 PerShareB { get; set; }

        public ulong PerBlockB { get; set; }

        public ulong LastBlock { get; set; }

        public PublicKey Owner { get; set; }

    }
}
