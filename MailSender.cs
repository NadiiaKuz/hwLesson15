namespace hwLesson15
{
    class MailSender
    {
        private Candidate[] candidates;

        public MailSender(params Candidate[] candidates)
        {
            this.candidates = candidates;
        }

        public void Send()
        {
            foreach (var candidate in candidates)
            {
                try
                {
                    bool isApproved = EmployeeDepartment.ApproveApplication(candidate.Name);

                    if (isApproved)
                    {
                        byte age = Convert.ToByte(DateTime.Now.Year - candidate.YearOfBirth);

                        if (age < 18)
                            throw new TooYoungExeption(age);

                        int salary = EmployeeDepartment.GetSalary(candidate.Experience);

                        Console.WriteLine($"MESSAGE SENT: Congratulations {candidate.Name}, you've been hired with salary: {salary}");
                    }
                    else
                    {
                        Console.WriteLine($"MESSAGE SENT: Sorry {candidate.Name}, you did not get a job");
                    }
                }
                catch (TooYoungExeption ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message} Age {ex.Age}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
