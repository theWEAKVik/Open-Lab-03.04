using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_03._04
{
    [TestFixture]
    public class Tests
    {

        private Numbers numbers;

        private const int RandMaxNum = 1000000;
        private const int RandSeed = 304304304;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init() => numbers = new Numbers();

        [TestCase(3, "odd")]
        [TestCase(19, "odd")]
        [TestCase(146, "even")]
        [TestCaseSource(nameof(GetRandom))]
        public void EvenOrOddTest(int number, string expectedOutput) =>
            Assert.That(numbers.EvenOrOdd(number), Is.EqualTo(expectedOutput));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var num = random.Next(RandMaxNum + 1);
                yield return new TestCaseData(num, num % 2 == 0 ? "even" : "odd");
            }
        }

    }
}
