using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingAppMobile
{
    public class Skills
    {
        public Skills(string name, int id, string category, string description)
        {
            this.name = name;
            this.id = id;
            this.category = category;
            this.description = description;
        }

        private string name;
        private int id;
        private string category;
        private string description;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int ID
        {
            get { return id; }
            private set { id = value; }
        }

        public string Category
        {
            get { return category; }
            private set { category = value; }
        }

        public string Description
        {
            get { return description; }
            private set { description = value; }
        }
    }
}
