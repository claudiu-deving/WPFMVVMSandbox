using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Bogus;
using System.Collections.ObjectModel;
using Bogus.DataSets;

namespace Library.Extensions.Tests
{
    [TestClass()]
    public class SortedObservableCollectionTests
    {
        [TestMethod()]
        public void SortedObservableCollectionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortTest()
        {
            var sut = new SortedObservableCollection<string>(
            [
                "A",
                "C",
                "B",
                "D",
                "E",
                "C",
                "F",
                "G",
                "H",
                "I",
                "B",
                "J",
                "K",
                "B",
                "L",
                "M",
                "C",
                "N",
                "O",
                "P"
            ]);
            Assert.AreEqual("A", sut[0]);
            Assert.AreEqual("B", sut[1]);
        }

        private class TestClass : IComparable<TestClass>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public int CompareTo(TestClass other)
            {
                return Name.CompareTo(other.Name);
            }


            public override string ToString()
            {
                return Name + "|" + Description + "|" + Id;
            }
        }

        [TestMethod()]
        public void SortTest1()
        {
            var sut = new SortedObservableCollection<TestClass>(
                           [
                new TestClass() { Id = 1, Name = "A", Description = "A" },
                               new TestClass() { Id = 2, Name = "C", Description = "C" },
                               new TestClass() { Id = 3, Name = "B", Description = "B" },
                               new TestClass() { Id = 4, Name = "D", Description = "D" },
                               new TestClass() { Id = 5, Name = "E", Description = "E" },
                               new TestClass() { Id = 6, Name = "C", Description = "C" },
                               new TestClass() { Id = 7, Name = "F", Description = "F" },
                               new TestClass() { Id = 8, Name = "G", Description = "G" },
                               new TestClass() { Id = 9, Name = "H", Description = "H" },
                               new TestClass() { Id = 10, Name = "I", Description = "I" },
                               new TestClass() { Id = 11, Name = "B", Description = "B" },
                               new TestClass() { Id = 12, Name = "J", Description = "J" },
                               new TestClass() { Id = 13, Name = "K", Description = "K" },
                               new TestClass() { Id = 14, Name = "B", Description = "B" },
                               new TestClass() { Id = 15, Name = "L", Description = "L" },
                               new TestClass() { Id = 16, Name = "M", Description = "M" },
                               new TestClass() { Id = 17, Name = "C", Description = "C" },
                               new TestClass() { Id = 18, Name = "N", Description = "N" },
                               new TestClass() { Id = 19, Name = "O", Description = "O" },
                               new TestClass() { Id = 20, Name = "P", Description = "P" }
            ]);
            Assert.AreEqual("A", sut[0].Name);
            Assert.AreEqual("B", sut[1].Name);
        }

        [TestMethod()]
        public void SortTest2()
        {
            var sut = new SortedObservableCollection<TestClass>(
                                          [
                new TestClass() { Id = 1, Name = "A", Description = "A" },
                                              new TestClass() { Id = 2, Name = "C", Description = "C" },
                                              new TestClass() { Id = 3, Name = "B", Description = "B" },
                                              new TestClass() { Id = 4, Name = "D", Description = "D" },
                                              new TestClass() { Id = 5, Name = "E", Description = "E" },
                                              new TestClass() { Id = 6, Name = "C", Description = "C" },
                                              new TestClass() { Id = 7, Name = "F", Description = "A" },
                                              new TestClass() { Id = 8, Name = "G", Description = "G" },
                                              new TestClass() { Id = 9, Name = "H", Description = "H" },
                                              new TestClass() { Id = 10, Name = "I", Description = "I" },
                                              new TestClass() { Id = 11, Name = "B", Description = "B" },
                                              new TestClass() { Id = 12, Name = "J", Description = "J" },
                                              new TestClass() { Id = 13, Name = "K", Description = "K" },
                                              new TestClass() { Id = 14, Name = "B", Description = "B" },
                                              new TestClass() { Id = 15, Name = "L", Description = "L" },
                                              new TestClass() { Id = 16, Name = "M", Description = "M" },
                                              new TestClass() { Id = 17, Name = "C", Description = "C" },
                                              new TestClass() { Id = 18, Name = "N", Description = "N" },
                                              new TestClass() { Id = 19, Name = "O", Description = "O" },
                                              new TestClass() { Id = 20, Name = "P", Description = "P" }
            ], o => o.Description);
            Assert.AreEqual("F", sut[0].Name);
            Assert.AreEqual("A", sut[1].Name);
        }

        [TestMethod()]
        public void SortTest3()
        {
            var sut = new SortedObservableCollection<TestClass>(
                                                         [
                new TestClass() { Id = 1, Name = "A", Description = "A" },
                                                             new TestClass() { Id = 2, Name = "C", Description = "C" },
                                                             new TestClass() { Id = 3, Name = "B", Description = "B" },
                                                             new TestClass() { Id = 4, Name = "D", Description = "D" },
                                                             new TestClass() { Id = 5, Name = "E", Description = "E" },
                                                             new TestClass() { Id = 6, Name = "C", Description = "C" },
                                                             new TestClass() { Id = 7, Name = "F", Description = "A" },
                                                             new TestClass() { Id = 8, Name = "G", Description = "G" },
                                                             new TestClass() { Id = 9, Name = "H", Description = "H" },
                                                             new TestClass() { Id = 10, Name = "I", Description = "I" },
                                                             new TestClass() { Id = 11, Name = "B", Description = "B" },
                                                             new TestClass() { Id = 12, Name = "J", Description = "J" },
                                                             new TestClass() { Id = 13, Name = "K", Description = "K" },
                                                             new TestClass() { Id = 14, Name = "B", Description = "B" },
                                                             new TestClass() { Id = 15, Name = "L", Description = "L" },
                                                             new TestClass() { Id = 0, Name = "M", Description = "M" },
                                                             new TestClass() { Id = 17, Name = "C", Description = "C" },
                                                             new TestClass() { Id = 18, Name = "N", Description = "N" },
                                                             new TestClass() { Id = 19, Name = "O", Description = "O" },
                                                             new TestClass() { Id = 20, Name = "P", Description = "P" }
            ], o => o.Id.ToString());
            Assert.AreEqual("M", sut[0].Name);
            Assert.AreEqual("A", sut[1].Name);
        }

        [TestMethod()]
        public void CompoundedPropertiesSortTest()
        {
            var sut = new SortedObservableCollection<TestClass>(
                                         [
                new TestClass() { Id = 1, Name = "X", Description = "A" },
                                             new TestClass() { Id = 2, Name = "D", Description = "C" },
                                             new TestClass() { Id = 3, Name = "B", Description = "B" },
                                             new TestClass() { Id = 4, Name = "D", Description = "D" },
                                             new TestClass() { Id = 5, Name = "E", Description = "A" },
                                             new TestClass() { Id = 6, Name = "C", Description = "C" },
                                             new TestClass() { Id = 7, Name = "A", Description = "A" },
                                             new TestClass() { Id = 8, Name = "G", Description = "G" },
                                             new TestClass() { Id = 9, Name = "H", Description = "H" },
                                             new TestClass() { Id = 10, Name = "I", Description = "I" },
                                             new TestClass() { Id = 11, Name = "B", Description = "B" },
                                             new TestClass() { Id = 12, Name = "X", Description = "G" },
                                             new TestClass() { Id = 13, Name = "K", Description = "K" },
                                             new TestClass() { Id = 14, Name = "B", Description = "B" },
                                             new TestClass() { Id = 15, Name = "L", Description = "L" },
                                             new TestClass() { Id = 16, Name = "M", Description = "M" },
                                             new TestClass() { Id = 17, Name = "W", Description = "C" },
                                             new TestClass() { Id = 18, Name = "N", Description = "N" },
                                             new TestClass() { Id = 19, Name = "O", Description = "O" },
                                             new TestClass() { Id = 20, Name = "P", Description = "P" }
           ], o => o.Description + o.Name);
            Assert.AreEqual("A", sut[0].Name);
            Assert.AreEqual("E", sut[1].Name);
            Assert.AreEqual("X", sut[2].Name);
        }

        [TestMethod()]
        public void CustomComparerSortTest()
        {
            var sut = new SortedObservableCollection<TestClass>(
                                                        [
                new TestClass() { Id = 1, Name = "X", Description = "A" },
                                                            new TestClass() { Id = 2, Name = "D", Description = "C" },
                                                            new TestClass() { Id = 3, Name = "B", Description = "B" },
                                                            new TestClass() { Id = 4, Name = "D", Description = "D" },
                                                            new TestClass() { Id = 5, Name = "E", Description = "A" },
                                                            new TestClass() { Id = 6, Name = "C", Description = "C" },
                                                            new TestClass() { Id = 7, Name = "A", Description = "A" },
                                                            new TestClass() { Id = 8, Name = "G", Description = "G" },
                                                            new TestClass() { Id = 9, Name = "H", Description = "H" },
                                                            new TestClass() { Id = 10, Name = "I", Description = "I" },
                                                            new TestClass() { Id = 11, Name = "B", Description = "B" },
                                                            new TestClass() { Id = 12, Name = "X", Description = "G" },
                                                            new TestClass() { Id = 13, Name = "K", Description = "K" },
                                                            new TestClass() { Id = 14, Name = "B", Description = "B" },
                                                            new TestClass() { Id = 15, Name = "L", Description = "L" },
                                                            new TestClass() { Id = 16, Name = "M", Description = "M" },
                                                            new TestClass() { Id = 17, Name = "W", Description = "C" },
                                                            new TestClass() { Id = 18, Name = "N", Description = "N" },
                                                            new TestClass() { Id = 19, Name = "O", Description = "O" },
                                                            new TestClass() { Id = 20, Name = "P", Description = "P" }
           ], Comparer<TestClass>.Create((x, y) => x.Description.CompareTo(y.Description)));
            Assert.AreEqual("A", sut[0].Name);
            Assert.AreEqual("E", sut[1].Name);
            Assert.AreEqual("X", sut[2].Name);
        }

        [TestMethod()]
        public void BenchmarkWithOneMillionEntries()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            Faker faker = new();
            var sut = new SortedObservableCollection<TestClass>(
                               Enumerable.Range(0, 10000).Select(i => new TestClass() { Id = i, Name = faker.Name.FirstName(), Description = faker.Name.LastName() }).ToList(),
                                              Comparer<TestClass>.Create((x, y) => x.Description.CompareTo(y.Description)));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            stopwatch.Restart();
            var normalObsCollection = new ObservableCollection<TestClass>(
             [
                 .. Enumerable.Range(0, 10000)
                 .Select(i => new TestClass()
                 {
                     Id = i,
                     Name = faker.Name.FirstName(),
                     Description = faker.Name.LastName()
                 }).OrderBy(x => x.Description),
             ]);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

        }

        [TestMethod()]
        public void BenchmarkOnAdding()
        {

            Faker faker = new();
            var sut = new SortedObservableCollection<TestClass>(
                               Enumerable.Range(0, 10000).Select(i => new TestClass() { Id = i, Name = faker.Name.FirstName(), Description = faker.Name.LastName() }).ToList(),
                                              Comparer<TestClass>.Create((x, y) => x.Description.CompareTo(y.Description)));

            var normalObsCollection = new ObservableCollection<TestClass>(
             [
                 .. Enumerable.Range(0, 10000)
                 .Select(i => new TestClass()
                 {
                     Id = i,
                     Name = faker.Name.FirstName(),
                     Description = faker.Name.LastName()
                 }).OrderBy(x => x.Description),
             ]);

            Stopwatch stopwatch = new();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                sut.Add(new TestClass() { Id = i, Name = faker.Name.FirstName(), Description = faker.Name.LastName() }, x => x.Description);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            stopwatch.Restart();

            for (int i = 0; i < 1000; i++)
            {
                normalObsCollection.Add(new TestClass() { Id = i, Name = faker.Name.FirstName(), Description = faker.Name.LastName() });
            }
            normalObsCollection = new ObservableCollection<TestClass>(normalObsCollection.OrderBy(x => x.Description));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}