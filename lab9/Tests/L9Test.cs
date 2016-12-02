using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L9;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class L9Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void E1_GetKeyNullException()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Get(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void E1_KeyNullException()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put(null, 2);
        }

        [TestMethod]
        public void E1_TestAddValuesInt32Count()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 1);
            collection.Put("K5", 1);
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(5, collection.Count);
        }

        [TestMethod]
        public void E1_TestAddValuesInt32Key()
        {

            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 1);
            collection.Put("K5", 1);
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(1, collection.Get("K5"));
        }

        [TestMethod]
        public void E1_TestAddValuesString()
        {
            IL9<String, String> collection = new L9<String, String>();
            collection.Put("K1", "1");
            collection.Put("K2", "2");
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void E1_TestAddValuesStringKey()
        {

            IL9<String, String> collection = new L9<String, String>();
            collection.Put("K2", "a");
            collection.Put("K4", "b");
            collection.Put("K3", "c");
            collection.Put("K5", "d");
            collection.Put("K1", "e");
            collection.Put("K5", "f");
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual("d", collection.Get("K5"));
        }


        [TestMethod]
        public void E1_TestGetException()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K1", 1);
            collection.Put("K2", 2);
            Assert.AreEqual(0, collection.Get("K100"));
        }

        [TestMethod]
        public void E1_TestGetInt32Value()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 1);
            collection.Put("K5", 1);
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(2, collection.Get("K2"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void E1_TestIndexerException()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            Console.Out.WriteLine(collection.ToString());
            var _value = collection["K100"];
        }
        [TestMethod]
        public void E1_TestUpdateValuesInt32Value()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 8);
            collection.Put("K5", 1);
            collection["K5"] = 5;
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(5, collection.Get("K5"));
        }

        [TestMethod]
        public void E2_TestAddValuesInt32LimitedCount()
        {
            IL9<String, Int32> collection = new L9<String, Int32>(2);
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 1);
            collection.Put("K5", 1);
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void E2_TestAddValuesInt32LimitedKey()
        {
            IL9<String, Int32> collection = new L9<String, Int32>(2);
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 1);
            collection.Put("K5", 1);
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(1, collection.Get("K5"));
        }

        [TestMethod]
        public void E2_TestSetLimitInt32LimitedKey()
        {
            IL9<String, Int32> collection = new L9<String, Int32>(2);
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 1);
            collection.Put("K5", 1);
            collection.Limit = 2;
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void E3_TestLastInt32()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K2", 2);
            collection.Put("K4", 2);
            collection.Put("K3", 2);
            collection.Put("K5", 1);
            collection.Put("K1", 8);
            collection.Put("K5", 1);
            collection["K5"] = 5;
            Console.Out.WriteLine(collection.ToString());
            Assert.AreEqual(5, collection.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void E3_TestGetAtException()
        {
            IL9<String, Int32> collection = new L9<String, Int32>();
            collection.Put("K1", 1);
            collection.Put("K2", 2);
            collection.GetAt(20);
        }

        //[TestMethod]
        //public void E4_TestIEnumerableInitializeInt32Count()
        //{
        //    IL9<String, Int32> collection = new L9<String, Int32>() { { "K2", 1 }, { "K1", 1 } };
        //    Console.Out.WriteLine(collection.ToString());
        //    Assert.AreEqual(2, collection.Count);
        //}

        //[TestMethod]
        //public void E4_TestIEnumerableInitializeInt32Value()
        //{
        //    IL9<String, Int32> collection = new L9<String, Int32>() { { "K2", 1 }, { "K1", 1 } };
        //    Console.Out.WriteLine(collection.ToString());
        //    Assert.AreEqual(1, collection.GetAt(0).Value);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(KeyNotFoundException))]
        //public void E4_TestIndexerGetException()
        //{
        //    IL9<String, Int32> collection = new L9<String, Int32>() { { "K2", 1 }, { "K1", 1 } };
        //    var _value = collection["K100"];
        //}

        //[TestMethod]
        //[ExpectedException(typeof(KeyNotFoundException))]
        //public void E4_TestIndexerSetException()
        //{
        //    IL9<String, Int32> collection = new L9<String, Int32>() { { "K2", 1 }, { "K1", 1 } };
        //    collection["K100"] = 1;
        //}
    }
}
