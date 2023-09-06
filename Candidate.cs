namespace hwLesson15
{
    struct Candidate
    {
        public string Name { get; } 
        public ushort YearOfBirth { get; }
        public byte Experience { get; }

        public Candidate(string name, ushort yearOfBirth, byte experience)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
            Experience = experience;
        }
    }
}
