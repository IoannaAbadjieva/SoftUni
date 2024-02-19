using System;
using System.Collections.Generic;


namespace Exam.PackageManagerLite
{
    public class Package //:IComparable<Package>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }

        public Package(string id, string name, DateTime releaseDate, string version)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Version = version;
        }

        //public int CompareTo(Package other)
        //{
        //    if (other == null) return 1;

        //    if (this.ReleaseDate.CompareTo(other.ReleaseDate) != 0)
        //    {
        //        return other.ReleaseDate.CompareTo(this.ReleaseDate);
        //    }

        //    if (this.Version.CompareTo(other.Version) != 0)
        //    {
        //        return this.Version.CompareTo(other.Version);
        //    }

        //    return 0;

        //}

        //public override int GetHashCode()
        //{
        //    return this.Name.GetHashCode() * this.Version.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Package;

        //    return  other.ReleaseDate == this.ReleaseDate;
        //}

        //public override string ToString()
        //{
        //    return this.ReleaseDate.ToString() + " " + this.Version + " " + this.Name;
        //}
    }
}
