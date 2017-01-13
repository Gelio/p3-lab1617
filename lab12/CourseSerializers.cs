using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace lab13A
{
    class CourseSerializers
    {
        public static void SerializeBinary(Course course, string path)
        {
            FileStream fs = File.Open(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, course);

            fs.Close();
        }

        public static Course DeserializeBinary(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            Course course = bf.Deserialize(fs) as Course;
            fs.Close();
            return course;
        }

        public static void SerializeSOAP(Course course, string path)
        {
            FileStream fs = File.Open(path, FileMode.Create);
            SoapFormatter soapFormatter = new SoapFormatter();
            soapFormatter.Serialize(fs, course.Name);
            soapFormatter.Serialize(fs, course.Segments.Count);
            foreach (var segment in course.Segments)
            {
                soapFormatter.Serialize(fs, segment.Name);
                soapFormatter.Serialize(fs, segment.Phrases.Count);
                foreach (var phrase in segment.Phrases)
                {
                    soapFormatter.Serialize(fs, phrase.Key);
                    soapFormatter.Serialize(fs, phrase.Value);
                }
            }
            fs.Close();
        }

        public static Course DeserializeSOAP(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            SoapFormatter soapFormatter = new SoapFormatter();

            string name = soapFormatter.Deserialize(fs) as string;
            Course course = new Course(name);

            int? segments = soapFormatter.Deserialize(fs) as int?;
            for (int i=0; i < segments; i++)
            {
                string segmentName = soapFormatter.Deserialize(fs) as string;
                Segment segment = new Segment(segmentName);

                int? phrases = soapFormatter.Deserialize(fs) as int?;
                for (int j=0; j < phrases; j++)
                {
                    string key = soapFormatter.Deserialize(fs) as string,
                        value = soapFormatter.Deserialize(fs) as string;

                    segment.Phrases.Add(key, value);
                }

                course.Segments.Add(segment);
            }


            fs.Close();
            return course;
        }
    }
}
