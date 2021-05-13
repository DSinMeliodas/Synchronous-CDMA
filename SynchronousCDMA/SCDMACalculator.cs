using System;
using System.Collections.Generic;

namespace SynchronousCDMA
{
    internal class SCDMACalculator
    {
        private static readonly Dictionary<SCDMAResult, string> ResultToString = new Dictionary<SCDMAResult, string>
        {
            {SCDMAResult.OneSent, "Sent One."}, {SCDMAResult.ZeroSent, "Sent Zero."}, {SCDMAResult.NothingSent, "Sent Nothing."}
        };

        private SCDMASignal m_CurrentSignal;

        public SCDMACalculator(SCDMASignal currentSignal)
        {
            m_CurrentSignal = currentSignal;
        }

        public string CurrentSignalAsString => m_CurrentSignal.ToString();

        public void Add(SCDMASignal toAdd)
        {
            m_CurrentSignal += toAdd;
        }

        public SCDMAResult CalculateResult(SCDMASignal stationSignal)
        {
            return m_CurrentSignal.Combine(stationSignal);
        }

        public void Display(SCDMAResult result)
        {
            Console.WriteLine(ResultToString[result]);
        }
    }
}