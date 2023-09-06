namespace hwLesson15
{
    static class MailSender
    {
        public static void Send(Candidate candidate)
        {
            {
                bool isApproved = EmployeeDepartment.ApproveApplication(candidate.Name);

                if (isApproved)
                {
                    byte age = Convert.ToByte(DateTime.Now.Year - candidate.YearOfBirth);

                    if (age < 18)
                        throw new TooYoungExeption(age);

                    int salary = EmployeeDepartment.GetSalary(candidate.Experience);

                    SendMessage(candidate.Name, salary);
                }
                else
                {
                    SendMessage(candidate.Name, null);
                }
            }
        }

        private static void SendMessage(string name, int? salary)
        {
            if(salary is not null)
                Console.WriteLine($"MESSAGE SENT: Congratulations {name}, you've been hired with salary: {salary}");
            else
                Console.WriteLine($"MESSAGE SENT: Sorry {name}, you did not get a job");
        }
    }
}
