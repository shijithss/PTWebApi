namespace User.Microservice.Application.Models
{
    public class UserViewModel
    {
        public int id { get; private set; }
        public string? firstName { get; private set; }
        public string? lastName { get; private set; }
        public string? maidenName { get; private set; }
        public int age { get; private set; }
        public string? gender { get; private set; }
        public string? email { get; private set; }
        public string? phone { get; private set; }
        public string? username { get; private set; }
        public string? password { get; private set; }
        public string? birthDate { get; private set; }
        public string? image { get; private set; }
        public string? bloodGroup { get; private set; }
        public int height { get; private set; }
        public double weight { get; private set; }
        public string? eyeColor { get; private set; }
        public Hair hair { get; private set; }
        public string? domain { get; private set; }
        public string? ip { get; private set; }
        public Address address { get; private set; }
        public string? macAddress { get; private set; }
        public string? university { get; private set; }
        public Bank bank { get; private set; }
        public Company company { get; private set; }
        public string? ein { get; private set; }
        public string? ssn { get; private set; }
        public string? userAgent { get; private set; }
    }

}
