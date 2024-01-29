using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Bogus;

namespace Library.Extensions.Tests
{
    [TestClass()]
    public class ObservableCollectionExtensionsTests
    {
        [TestMethod()]
        public void InsertInPlaceTest()
        {
            Faker faker = new Faker();

            var sut = new ObservableCollection<string>();
            for (int i = 0; i < 100; i++)
            {
                sut.Add(faker.Random.String2(10));
            }
            for (int i = 0; i < 20; i++)
            {
                sut.InsertInPlace(sut[i], s => s, StringComparer.Ordinal);
            }

        }
    }
}