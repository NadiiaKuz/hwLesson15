namespace hwLesson15
{
    static class EmployeeDepartment
    {
        public static bool ApproveApplication(string name)
        {
            return !name.Contains('P');
        }

        public static int GetSalary(int experience)
        {
            int result = 20000 + (200 / experience);

            return result;
        }
    }
}
