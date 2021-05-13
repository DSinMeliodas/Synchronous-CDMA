using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SynchronousCDMA
{
    internal class SCDMASignal
    {
        private readonly sbyte[] m_Signal;

        public long Length => m_Signal.LongLength;

        private SCDMASignal(params sbyte[] signal)
        {
            m_Signal = signal;
        }

        public SCDMASignal Add(SCDMASignal other)
        {
            CheckForLength(other);
            sbyte[] result = new sbyte[Length];
            for (var i = 0; i < Length; i++)
            {
                result[i] = (sbyte) (m_Signal[i] + other.m_Signal[i]);
            }
            return result;
        }

        public SCDMAResult Combine(SCDMASignal other)
        {
            CheckForLength(other);
            long result = 0;
            for (var i = 0; i < Length; i++)
            {
                result += m_Signal[i] * other.m_Signal[i];
            }

            result /= Length;
            if (!Enum.TryParse(result.ToString(), out SCDMAResult scdmaResult))
            {
                throw new ArgumentException();
            }
            return scdmaResult;
        }

        private void CheckForLength(SCDMASignal other)
        {
            if (Length == other.Length)
            {
                return;
            }
            throw new ArgumentException();
        }

        public override string ToString()
        {
            if (Length == 0)
            {
                return "Empty Signal";
            }
            string value = "Signal: [ ";
            for (int i = 0; i < Length-1; i++)
            {
                value += $"{m_Signal[i]}, ";
            }
            value += $"{m_Signal.Last()} ]";
            return value;
        }

        public static implicit operator SCDMASignal(sbyte[] signal)
        {
            return new SCDMASignal(signal);
        }

        public static SCDMASignal operator +(SCDMASignal left, SCDMASignal right)
        {
            return left.Add(right);
        }
    }
}