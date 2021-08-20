using Solnet.Wallet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Raydium.Utilities
{
    /// <summary>
    /// Utility class for encoding byte buffers.
    /// </summary>
    public class BufferEncoder
    {

        /// <summary>
        /// Length of the byte buffer.
        /// </summary>
        private int Length { get; }

        /// <summary>
        /// Current read position.
        /// </summary>
        public int Cursor { get; set; }

        /// <summary>
        /// The internal buffer.
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// Construct an instance of the BufferEncoder object initialized with a buffer specified by length.
        /// </summary>
        /// <param name="length">Length in bytes of the buffer to allocate.</param>
        public BufferEncoder(int length)
        {
            Length = length;
            Cursor = 0;
            _buffer = (byte[]) Array.CreateInstance(typeof(byte), length);
        }

        /// <summary>
        /// Constructs a buffer decode prepopulated with the given byte buffer.
        /// </summary>
        /// <param name="buffer"></param>
        public BufferEncoder(byte[] buffer)
        {
            _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            Cursor = 0;
            Length = buffer.Length;
        }

        /// <summary>
        /// Write a single byte to buffer at the cursor position.
        /// </summary>
        /// <param name="value"></param>
        public void WriteByte(byte value)
        {
            if (Cursor >= Length) throw new ApplicationException("Buffer exceeded");
            _buffer[Cursor] = value;
            Cursor += 1;
        }

        /// <summary>
        /// Write a single byte to buffer at the cursor position.
        /// </summary>
        /// <param name="value"></param>
        public void WriteU64(ulong value)
        {
            var bytes = BitConverter.GetBytes(value);
            if ((Cursor + bytes.Length) > Length) throw new ApplicationException("Buffer exceeded");
            Array.Copy(bytes, 0, _buffer, Cursor, bytes.Length);
            Cursor += bytes.Length;
        }

        /// <summary>
        /// Convert the buffer to Base64 string.
        /// </summary>
        /// <returns>The buffer encoded as a Base64 string.</returns>
        public string ToBase64()
        {
            return Convert.ToBase64String(_buffer);
        }

        /// <summary>
        /// Convert the buffer to a Base58 string.
        /// </summary>
        /// <returns>The buffer encoded as a Base58 string.</returns>
        public string ToBase58()
        {
            var enc = new Base58Encoder();
            return enc.EncodeData(_buffer);
        }

        /// <summary>
        /// Get the byte buffer.
        /// </summary>
        /// <returns>The underlying buffer.</returns>
        public byte[] GetBytes()
        {
            return _buffer;
        }

    }
}
