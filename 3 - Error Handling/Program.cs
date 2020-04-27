using DemoLibrary;
using System;

namespace _3___Error_Handling
{
    class Program
    {
        static void Main()
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);

                    if (result != null)
                    {
                        Console.WriteLine(result.TransactionAmount);
                    }
                    else
                    {
                        throw new NullReferenceException($"Null value for item {i}");
                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Skipped invalid record  {(ex.InnerException != null ? ex.InnerException.Message : "")}");
                }
                catch (FormatException ex) when (i != 5)
                {
                    Console.WriteLine($"Formatting Issue {(ex.InnerException != null ? ex.InnerException.Message : "")}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Payment skipped for payment with { i } items  {(ex.InnerException != null ? ex.InnerException.Message : "")}");
                }
            }

            Console.ReadLine();
        }
    }
}
