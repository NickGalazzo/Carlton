using Castle.DynamicProxy;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Carlton.Domain.Interceptors
{
    public abstract class CarltonBaseInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //Impliment Actual Interception Behavior
            InterceptBehavior(invocation);

            //Rework the return value if Tasks are involved
            HandleAsyncResponse(invocation);
        }
        
        public abstract void InterceptBehavior(IInvocation invocation);
        
        private void HandleAsyncResponse(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            var isAsync = method.GetCustomAttributes(typeof(AsyncStateMachineAttribute)) != null;
            if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                invocation.ReturnValue = InterceptAsync((dynamic) invocation.ReturnValue);
            }
        }

        private static async Task InterceptAsync(Task task)
        {
            await task.ConfigureAwait(false);
        }

        private static async Task<T> InterceptAsync<T>(Task<T> task)
        {
            T result = await task.ConfigureAwait(false);
            return result;
        }
    }
}
