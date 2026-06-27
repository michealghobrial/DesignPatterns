namespace BuilderPattern2
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public string ThemePreference { get; set; }
        public void DisplayProfile()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Address: {StreetAddress}, {City}, {State} {ZipCode}");
            Console.WriteLine($"Newsletter: {IsSubscribedToNewsletter}");
            Console.WriteLine($"Theme: {ThemePreference}");
        }
    }
}
