using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Models.Layouts
{
    /// <summary>
    /// USER_STAKE_INFO_ACCOUNT_LAYOUT_V4 
    /// </summary>
    public class UserStakeInfoV4
    {

        public ulong State { get; set; }

        public PublicKey PoolId { get; set; }

        public PublicKey StakerOwner { get; set; }

        public ulong DepositBalance { get; set; }

        public ulong RewardDebt { get; set; }

        public ulong RewardDebtB { get; set; }

    }

}
