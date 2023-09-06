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

                        SendMessage(candidate.Name, salary);
                    }
                    else
                    {
                        SendMessage(candidate.Name, null);
                    }
                }
                catch (TooYoungExeption ex)
                {
                    LogErrorNotPublish($"ERROR: {ex.Message} Age {ex.Age}");
                }
                catch (DivideByZeroException ex)
                {
                    LogErrorNotPublish($"ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    LogErrorNotPublish($"ERROR: {ex.Message}");
                }
            }
        }

        private void SendMessage(string name, int? salary)
        {
            if(salary is not null)
                Console.WriteLine($"MESSAGE SENT: Congratulations {name}, you've been hired with salary: {salary}");
            else
                Console.WriteLine($"MESSAGE SENT: Sorry {name}, you did not get a job");
        }

        private void LogErrorNotPublish(string message)
        {
            Console.WriteLine(message);
        }
    }
}
