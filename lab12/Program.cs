using System;

namespace lab13A
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = Course.ReadFromFolder("angielski");
            Console.Write(course.ToString());

            //CourseSerializers.SerializeBinary(course, "angielski.bin");
            //Course course2 = CourseSerializers.DeserializeBinary("angielski.bin");

            //if(course.ToString() == course2.ToString())
            //{
            //    Console.WriteLine("Serializacja binarna - OK");
            //}
            //else
            //{
            //    Console.WriteLine("Serializacja binarna - FAILED");
            //}

            //CourseSerializers.SerializeSOAP(course, "angielski.soap");
            //Course course3 = CourseSerializers.DeserializeSOAP("angielski.soap");
            //if (course.ToString() == course3.ToString())
            //{
            //    Console.WriteLine("Serializacja SOAP - OK");
            //}
            //else
            //{
            //    Console.WriteLine("Serializacja SOAP - FAILED");
            //}

            //course.WriteToFolder("newFolder");
            //Course course4 = Course.ReadFromFolder("newFolder/angielski");
            //if (course.ToString() == course4.ToString())
            //{
            //    Console.WriteLine("Reczny zapis do struktury folderow - OK");
            //}
            //else
            //{
            //    Console.WriteLine("Reczny zapis do struktury folderow - FAILED");
            //}
        }
    }
}