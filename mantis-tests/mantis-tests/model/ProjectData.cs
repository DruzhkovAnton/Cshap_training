﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData(string name,  string description)
        {
            Name = name;
            Description = description;

        }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Active { get; set; }

        public string Visibility { get; set; }

        public string Description { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            if (Object.ReferenceEquals(this, other)) { return true; }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null)) { return 1; }
            return Name.CompareTo(other.Name);
        }
    }
}
