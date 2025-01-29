using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketAndPrice.models;
using Pipe = PacketAndPrice.models.Pipe;

namespace PacketAndPriceTests.Fixtures
{
    public class PipeFixture : IDisposable
    {
        public Pipe pipe {  get; set; }
        public Pipe TooLightPipe {  get; set; }
        public PipeFixture() 
        {
            pipe = new Pipe(1, 2, 3);
            TooLightPipe = new Pipe(1, 1, 1);
        }

        public void Dispose() { }
    }
}
