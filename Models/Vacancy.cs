namespace StounXXI.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Department Department { get; set; }
        public bool IsClosed { get; set; }
        public DateTime HiringDate { get; set; }
    }
}
