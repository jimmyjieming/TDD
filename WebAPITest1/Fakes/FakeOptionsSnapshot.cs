using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest1.UnitTests.Fakes
{
    public class FakeOptionsSnapshot<TOptions> : IOptionsSnapshot<TOptions> where TOptions : class
    {
        private readonly TOptions options;

        public FakeOptionsSnapshot(TOptions options)
        {
            this.options = options;
        }

        public TOptions Value => options;

        public TOptions Get(string? name)
        {
            return Value;
        }
    }
}
