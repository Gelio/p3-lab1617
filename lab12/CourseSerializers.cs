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
            return bf.Deserialize(fs) as Course;
        }

        public static void SerializeSOAP(Course course, string path)
        {
            //etap 3
        }

        public static Course DeserializeSOAP(string path)
        {
            //etap 3
            return new Course(null);  //  zmienić
        }
    }
}
