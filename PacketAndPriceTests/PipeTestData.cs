using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPriceTests
{
    public class PipeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 2, 3, 1 };
            yield return new object[] { 3, 1, 2 };
        }

        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { 1, 2, 3 },
                new object[] { 1, 2, 3 }
            };
        }

        // IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
