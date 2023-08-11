using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingAppMobile
{
    public class Participant
    {
        public Participant(int id, string email, string name, string surname, string profilePicture, string description, string bankId, List<Events> favoriteEvents, float balance, List<Skills> skills)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.surname = surname;
            this.profilePicture = profilePicture;
            this.description = description;
            this.bankId = bankId;
            this.favoriteEvents = favoriteEvents;
            this.balance = balance;
            this.skills = skills;
        }

        private int id;
        private string email;
        private string name;
        private string surname;
        private string profilePicture;
        private string description;
        private string bankId;
        private List<Events> favoriteEvents;
        private float balance;
        private List<Skills> skills;


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

        public float Balance
        {
            get { return balance; }
            private set { balance = value; }
        }
        public List<Skills> Skills
        {
            get { return skills; }
            private set { skills = value; }
        }
    }
}
        
