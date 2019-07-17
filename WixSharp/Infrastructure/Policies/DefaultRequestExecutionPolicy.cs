using System.Threading.Tasks;
using WixSharp.Infrastructure;

namespace WixSharp
{
    public class DefaultRequestExecutionPolicy : IRequestExecutionPolicy
    {
        public async Task<T> Run<T>(CloneableRequestMessage request, ExecuteRequestAsync<T> executeRequestAsync)
        {
            var fullResult = await executeRequestAsync(request);

            return fullResult.Result;
        }
    }
}
