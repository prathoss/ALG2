using System;
using Hrab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSorting
{
    [TestClass]
    public class UnitTest1
    {
        PermutationGenerator generator;
        int[] correct = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        [TestInitialize]
        public void Initialize()
        {
            generator = new PermutationGenerator((int[])correct.Clone());
        }

        [TestMethod]
        public void KType1()
        {
            while (generator.Next() != null)
            {
                int[] arr = (int[])generator.Array.Clone();
                arr.Hrabisort(1);
                CollectionAssert.AreEqual(arr, correct);
            }
        }

        [TestMethod]
        public void KType2()
        {
            while (generator.Next() != null)
            {
                int[] arr = (int[])generator.Array.Clone();
                arr.Hrabisort(2);
                CollectionAssert.AreEqual(arr, correct);
            }
        }

        [TestMethod]
        public void KType3()
        {
            while (generator.Next() != null)
            {
                int[] arr = (int[])generator.Array.Clone();
                arr.Hrabisort(3);
                CollectionAssert.AreEqual(arr, correct);
            }
        }


    }
}
