using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest1.UnitTests.Fakes
{
    public class FakeOptionsSnapshot<TOptions>
        : IOptions<TOptions>, IOptionsSnapshot<TOptions>, IOptionsMonitor<TOptions>
        where TOptions : class
    {
        private readonly TOptions options;

        public FakeOptionsSnapshot(TOptions options)
        {
            this.options = options;
        }

        public TOptions Value => options;

        public TOptions CurrentValue => Value;

        public TOptions Get(string? name)
        {
            return Value;
        }

        public IDisposable? OnChange(Action<TOptions, string?> listener)
        {
            throw new NotImplementedException(
                "This fake does not implement OnChange yet.");
        }
    }
}
