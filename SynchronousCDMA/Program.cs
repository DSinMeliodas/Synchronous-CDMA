using System;

namespace SynchronousCDMA
{
    class Program
    {
        static void Main()
        {
            SCDMASignal signal1 = new sbyte[] { 0, 0, -2, 2, 0, -2, 0, 2 };
            SCDMASignal signal2 = new sbyte[] { 0, 2, 2, 2, 0, 4, -2, 2 };
            SCDMASignal signal3 = new sbyte[] { 2, 0, 2, -2, 0, 2, 0, 2 };

            SCDMASignal stationSignal1 = new sbyte[] { -1, -1, -1, 1, 1, -1, 1, 1 };
            SCDMASignal stationSignal2 = new sbyte[] { -1, -1, 1, -1, 1, 1, 1, -1 };
            SCDMASignal stationSignal3 = new sbyte[] { -1, 1, -1, 1, 1, 1, -1, -1 };

            SCDMACalculator calculator = new SCDMACalculator(signal1);
            Console.WriteLine(calculator.CurrentSignalAsString);

            calculator.Add(signal2);
            Console.WriteLine(calculator.CurrentSignalAsString);

            calculator.Add(signal3);
            Console.WriteLine(calculator.CurrentSignalAsString);

            SCDMAResult result1 = calculator.CalculateResult(stationSignal1);
            Console.Write("First result: ");
            calculator.Display(result1);

            SCDMAResult result2 = calculator.CalculateResult(stationSignal2);
            Console.Write("Second result: ");
            calculator.Display(result2);

            SCDMAResult result3 = calculator.CalculateResult(stationSignal3);
            Console.Write("Third result: ");
            calculator.Display(result3);
        }
    }
}
