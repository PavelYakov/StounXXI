namespace StounXXI.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CandidateStatus Status { get; set; }
        public string Resume { get; set; }
        public string Email { get; set; }
        public bool TestIsOk { get; set; }
        public bool IsHired { get; set; }
        public DateTime HiringDate { get; set; }
    }
}
