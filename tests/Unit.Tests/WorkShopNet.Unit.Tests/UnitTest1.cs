using System;
using Xunit;

namespace WorkShopNet.Unit.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 10;
            int b = 20;
            int c = a +b;

            Assert.Equal(c, 30);
        }
    }
}
