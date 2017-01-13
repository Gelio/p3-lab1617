using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace lab13A
{
    class CourseSerializers
    {
        public static void SerializeBinary(Course course, string path)
        {
            //etap 2
        }

        public static Course DeserializeBinary(string path)
        {
            //etap 2
            return new Course(null);  //  zmienić
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
