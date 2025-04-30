namespace JsonExample
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    public class Admin : User
    {
        public string Role { get; set; } = "Admin";
    }

    public class RegularUser : User
    {
        public string Role { get; set; } = "User";
    }

    public class UserWithRole : User
    {
        public string Role { get; set; }
    }
}
