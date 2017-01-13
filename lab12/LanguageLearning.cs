using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace lab13A
{
    [Serializable] class Course
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
            Course course = new lab13A.Course(path);
            string[] segmentNames = Directory.GetDirectories(path);
            foreach (string segmentPath in segmentNames)
            {
                course.Segments.Add(Segment.ReadFromFolder(segmentPath));
            }
            return course;
        }

        public void WriteToFolder(string path)
        {
            // etap 4
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Course: {0}\n\n", name);
            foreach (var segment in segments)
                sb.AppendFormat("{0}\n\n", segment);

            return sb.ToString();
        }

    }

    [Serializable] class Segment
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
            string segmentName = Path.GetFileNameWithoutExtension(path);
            Segment segment = new Segment(segmentName);

            // wczytywanie fraz
            foreach (string filePath in Directory.GetFiles(path))
            {
                string[] phrase = File.ReadAllLines(filePath);
                segment.phrases.Add(phrase[0], phrase[1]);
            }
            return segment;
        }

        public void WriteToFolder(string path)
        {
            // etap 4
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Segment: {0}\n", name);

            foreach (var phrase in phrases)
                sb.AppendFormat("{0}\n{1}\n", phrase.Key, phrase.Value);

            return sb.ToString();
        }
    }
}
