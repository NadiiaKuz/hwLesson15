using System.Net.Mail;

namespace hwLesson15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Candidate[] candidates = new[]
            {
                new Candidate("Maria", 2006, 2),
                new Candidate("Paul", 2000, 3),
                new Candidate("Mark", 1997, 0),
                new Candidate("Sarah", 1999, 5)
            };

            foreach (var candidate in candidates)
            {
                try
                {
                    MailSender.Send(candidate);
                }
                catch (TooYoungExeption ex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ERROR: {ex.Message} Age {ex.Age}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}