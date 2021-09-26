using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Utilities
{
    /// <summary>
    /// Represents a 7 byte filler
    /// </summary>
    public class Blob7
    {

        /// <summary>
        /// The internal BigInteger for the U128
        /// </summary>
        public BigInteger Value { get; private set; }

        /// <summary>
        /// Constructs a U128 instance using the 16 byte buffer provided.
        /// </summary>
        /// <param name="buffer">A span of 16 bytes.</param>
        public Blob7(Span<byte> buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            if (buffer.Length != 7) throw new ArgumentException("Expected 7 bytes");
            Value = new BigInteger(buffer, true, false);
        }

        /// <summary>
        /// Present the value as a string.
        /// </summary>
        /// <returns>String representation of the U128 value.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
