using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Utilities
{
    /// <summary>
    /// Represents an unsigned 128-bit integer (little endian)
    /// </summary>
    public class U128
    {

        /// <summary>
        /// The internal 
        /// </summary>
        public BigInteger Value { get; private set; }

        /// <summary>
        /// Constructs a U128 instance using the 16 byte buffer provided.
        /// </summary>
        /// <param name="buffer"></param>
        public U128(Span<byte> buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            if (buffer.Length != 16) throw new ArgumentException("Expected 16 bytes");
            Value = new BigInteger(buffer, true, false);
        }

    }
}
