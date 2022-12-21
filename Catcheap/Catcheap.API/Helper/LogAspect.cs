using Castle.DynamicProxy;
using Newtonsoft.Json;
using Serilog;

namespace Catcheap.API.Helper;

public class LogAspect : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        try
        {
            invocation.Proceed();
            Log.Logger.Information("Method named " + invocation.Method.Name + " of interface " + invocation.GetType().Name.ToString().Split("_").First() + " was called with parameters " + JsonConvert.SerializeObject(invocation.Arguments) + ". It returned " + JsonConvert.SerializeObject(invocation.ReturnValue));
        }
        catch (Exception e)
        {
            Log.Logger.Error("Error detected in method named " + invocation.Method.Name + " of interface " + invocation.GetType().Name.ToString().Split("_").First() + ". The error is " + e);
            throw;
        }
    }
}
