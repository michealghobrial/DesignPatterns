namespace BuilderPattern2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example without director
            UserProfileBuilder concreteUserProfile = new ConcreteUserProfileBuilder();

            concreteUserProfile.SetBasicInfo("John", "Doe", "john.doe@example.com");
            concreteUserProfile.SetAddress("123 Main St", "Springfield", "IL", "12345");
            concreteUserProfile.SetPreferences(true, "Dark");

            UserProfile userProfile = concreteUserProfile.GetUserProfile();
            userProfile.DisplayProfile();

            Console.ReadKey();
        }
    }
}
