using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace lab13A
{
    class Course
    {
        private string name;
        private List<Segment> segments;

        public List<Segment> Segments
        {
            get { return segments; }
        }

        public string Name
        {
            get { return name; }
        }

        public Course(string name)
        {
            this.name = name;
            segments = new List<Segment>();
        }

        public static Course ReadFromFolder(string path)
        {
            // etap 1
            return new Course(null);  // zmienić
        }

        public void WriteToFolder(string path)
        {
            // etap 4
        }

// można dopisywać niezbędne metody

    }

    class Segment
    {
        private string name;
        private Dictionary<string, string> phrases;

        public Dictionary<string, string> Phrases
        {
            get { return phrases; }
        }

        public string Name
        {
            get { return name; }
        }

        public Segment(string name)
        {
            this.name = name;
            phrases = new Dictionary<string, string>();
        }

        public static Segment ReadFromFolder(string path)
        {
            // etap 1
            return new Segment(null);  // zmienić
        }

        public void WriteToFolder(string path)
        {
            // etap 4
        }

// można dopisywać niezbędne metody

    }
}
