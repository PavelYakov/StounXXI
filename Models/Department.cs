namespace StounXXI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
