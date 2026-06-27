using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern2
{
    public abstract class UserProfileBuilder
    {
        protected UserProfile UserProfile = new UserProfile();
        public abstract void SetBasicInfo(string firstName, string lastName, string email);
        public abstract void SetAddress(string street, string city, string state, string zip);
        public abstract void SetPreferences(bool newsletter, string theme);
        public UserProfile GetUserProfile() => UserProfile;
    }
}
