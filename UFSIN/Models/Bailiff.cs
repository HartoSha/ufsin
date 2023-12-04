namespace UFSIN.Models
{
    public class Bailiff
    {
        public string Password { get; set; } = "password123";

        public string FullName { get; set; } = "Петр Первый";

        public List<Convict> Convicts { get; set; }
    }
}
