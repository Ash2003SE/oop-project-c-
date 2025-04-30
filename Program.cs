using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using JsonExample;

class Program
{
    static void Main(string[] args)
    {
        string userFile = "users.json";
        string typedUserFile = "typed_users.json";

        // Step 1: Read and display users from users.json
        Console.WriteLine("Users from users.json:");
        var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(userFile));
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.Name}, Age: {user.Age}, City: {user.City}");
        }

        // Step 2: Add a new user and save back to file
        users.Add(new User { Name = "Charlie", Age = 40, City = "Klaipėda" });
        File.WriteAllText(userFile, JsonConvert.SerializeObject(users, Formatting.Indented));
        Console.WriteLine("\nAdded new user to users.json");

        // Step 3: Create specialized users and save to typed_users.json
        var typedUsers = new List<UserWithRole>
        {
            new UserWithRole { Name = "AdminUser", Age = 45, City = "Vilnius", Role = "Admin" },
            new UserWithRole { Name = "RegularJoe", Age = 25, City = "Kaunas", Role = "User" }
        };
        File.WriteAllText(typedUserFile, JsonConvert.SerializeObject(typedUsers, Formatting.Indented));

        // Step 4: Deserialize and display typed users
        Console.WriteLine("\nUsers from typed_users.json:");
        var loadedTypedUsers = JsonConvert.DeserializeObject<List<UserWithRole>>(File.ReadAllText(typedUserFile));
        foreach (var user in loadedTypedUsers)
        {
            Console.WriteLine($"{user.Role}: {user.Name}, Age {user.Age}, City {user.City}");
        }
    }
}
