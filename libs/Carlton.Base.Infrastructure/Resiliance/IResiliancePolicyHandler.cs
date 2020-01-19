using Polly;
using Polly.Wrap;

namespace Carlton.Infrastructure.Resiliance
{
    public interface IResiliancePolicyHandler<T>
    {
        AsyncPolicyWrap<T> CreatePolicyWrap();
        void HandleResult(PolicyResult<T> result);
    }
}

