using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern2
{
    public class ConcreteUserProfileBuilder : UserProfileBuilder
    {
        public override void SetBasicInfo(string firstName, string lastName, string email)
        {
            UserProfile.FirstName = firstName;
            UserProfile.LastName = lastName;
            UserProfile.Email = email;
        }
        public override void SetAddress(string street, string city, string state, string zip)
        {
            UserProfile.StreetAddress = street;
            UserProfile.City = city;
            UserProfile.State = state;
            UserProfile.ZipCode = zip;
        }
        public override void SetPreferences(bool newsletter, string theme)
        {
            UserProfile.IsSubscribedToNewsletter = newsletter;
            UserProfile.ThemePreference = theme;
        }
    }
}
