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

            var sender = new MailSender(candidates);

            sender.Send();
        }
    }
}