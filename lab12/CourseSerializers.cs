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
            soapFormatter.Serialize(fs, course);
            fs.Close();
        }

        public static Course DeserializeSOAP(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            SoapFormatter soapFormatter = new SoapFormatter();

            Course course = soapFormatter.Deserialize(fs) as Course;

            fs.Close();
            return course;
        }
    }
}
