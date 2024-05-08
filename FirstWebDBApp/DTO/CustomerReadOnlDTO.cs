namespace FirstWebDBApp.DTO
{
    public class CustomerReadOnlDTO : BaseDTO
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int Age { get; set; }
        public string? Region { get; set; }
    }
}
