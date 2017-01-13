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

        [NonSerialized]
        private List<Segment> segments;

        private Segment[] segmentArray;

        [OnSerializing]
        void saveSegments(StreamingContext context)
        {
            segmentArray = segments.ToArray();
        }

        [OnDeserialized]
        void loadSegments(StreamingContext context)
        {
            segments = new List<Segment>();
            for (int i = 0; i < segmentArray.Length; i++)
                segments.Add(segmentArray[i]);
        }

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
            segmentArray = new Segment[0];
        }

        public static Course ReadFromFolder(string path)
        {
            Course course = new Course(Path.GetFileNameWithoutExtension(path));
            string[] segmentNames = Directory.GetDirectories(path);
            foreach (string segmentPath in segmentNames)
            {
                course.Segments.Add(Segment.ReadFromFolder(segmentPath));
            }
            return course;
        }

        public void WriteToFolder(string path)
        {
            string coursePath = Path.Combine(path, name);
            if (!Directory.Exists(coursePath))
                Directory.CreateDirectory(coursePath);

            foreach (Segment segment in segments)
            {
                segment.WriteToFolder(coursePath);
            }
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

        [NonSerialized]
        private Dictionary<string, string> phrases;

        private string[,] phrasesArray;

        [OnSerializing]
        void savePhrases(StreamingContext context)
        {
            phrasesArray = new string[phrases.Count, 2];
            int i = 0;
            foreach (var phrase in phrases)
            {
                phrasesArray[i, 0] = phrase.Key;
                phrasesArray[i++, 1] = phrase.Value;
            }
        }

        [OnDeserialized]
        void loadPhrases(StreamingContext context)
        {
            phrases = new Dictionary<string, string>();
            for (int i=0; i < phrasesArray.GetLength(0); i++)
            {
                phrases.Add(phrasesArray[i, 0], phrasesArray[i, 1]);
            }
        }

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
            phrasesArray = new string[0, 0];
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
            string segmentPath = Path.Combine(path, name);
            if (!Directory.Exists(segmentPath))
                Directory.CreateDirectory(segmentPath);

            int i = 1;
            foreach (var phrase in phrases)
            {
                FileStream fs = File.Open(Path.Combine(segmentPath, i + ".txt"), FileMode.Create);
                string phraseToWrite = phrase.Key + Environment.NewLine + phrase.Value;
                byte[] bytesToWrite = UTF8Encoding.UTF8.GetBytes(phraseToWrite);

                fs.Write(bytesToWrite, 0, phraseToWrite.Length);
                fs.Close();
                i++;
            }
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
