namespace FirstWebDBApp.DTO
{
    public class CustomerUpdateDTO : BaseDTO
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int Age { get; set; }
        public string? Region { get; set; }
    }
}
