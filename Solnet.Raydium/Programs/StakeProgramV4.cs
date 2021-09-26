using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Programs
{
    /// <summary>
    /// Defines the method to integrate with the V4 stake program
    /// </summary>
    public class StakeProgramV4
    {

        /// <summary>
        /// The public key of the on-chain Raydium stake program.
        /// </summary>
        public static readonly PublicKey ProgramId = new(Consts.STAKE_PROGRAM_ID_V4);

    }
}
