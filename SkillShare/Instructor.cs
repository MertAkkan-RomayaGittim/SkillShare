using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingAppMobile
{
    public class Instructor
    {
        private int id;
        private string email;
        private string name;
        private string surname;
        private string profilePicture;
        private string description;
        private string bankId;
        private List<Events> favoriteEvents;
        private float balance;
        private List<string> certificates;
        private List<Events> courses;
        private List<Events> workshops;

        public List<Events> Courses
        {
            get { return courses; }
            private set { courses = value; }
        }

        public List<Events> Workshops
        {
            get { return workshops; }
            private set { workshops = value; }
        }
        public int ID
        {
            get { return id; }
            private set { id = value; }
        }

        public string Email
        {
            get { return email; }
            private set { email = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            private set { surname = value; }
        }

        public string ProfilePicture
        {
            get { return profilePicture; }
            private set { profilePicture = value; }
        }

        public string Description
        {
            get { return description; }
            private set { description = value; }
        }

        public string BankID
        {
            get { return bankId; }
            private set { bankId = value; }
        }

        public List<Events> FavoriteEvents
        {
            get { return favoriteEvents; }
            private set { favoriteEvents = value; }
        }
        public List<string> Certificates
        {
            get { return certificates; }
            private set { certificates = value; }
        }

        public float Balance
        {
            get { return balance; }
            private set { balance = value; }
        }




    }
}

