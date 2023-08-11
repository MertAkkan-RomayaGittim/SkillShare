using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingAppMobile
{
    public class Events
    {
        public Events(int participantNumber, DateTime date, string type, string description, string status, float rating, string location, string name, int skillId, string eventPhoto)
        {
            this.participantNumber = participantNumber;
            this.date = date;
            this.type = type;
            this.description = description;
            this.status = status;
            this.rating = rating;
            this.location = location;
            this.name = name;
            this.skillId = skillId;
            this.eventPhoto = eventPhoto;
        }
        private int participantNumber;
        private DateTime date;
        private string type;
        private string description;
        private string status;
        private float rating;
        private string location;
        private string name;
        private int skillId;
        private string eventPhoto;

        public int ParticipantNumber
        {
            get { return participantNumber; }
            private set { participantNumber = value; }
        }

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        public string Type
        {
            get { return type; }
            private set { type = value; }
        }

        public string Description
        {
            get { return description; }
            private set { description = value; }
        }

        public string Status
        {
            get { return status; }
            private set { status = value; }
        }

        public float Rating
        {
            get { return rating; }
            private set { rating = value; }
        }

        public string Location
        {
            get { return location; }
            private set { location = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int SkillId
        {
            get { return skillId; }
            private set { skillId = value; }
        }

        public string EventPhoto
        {
            get { return eventPhoto; }
            private set { eventPhoto = value; }
        }
    }
}
