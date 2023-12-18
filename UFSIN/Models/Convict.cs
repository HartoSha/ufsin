namespace UFSIN.Models
{
    public class Convict
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string Photo { get; set; } = "user_picture.png";

        public string FullName { get; set; } = "";

        //31231
        //123123123
    }
}
