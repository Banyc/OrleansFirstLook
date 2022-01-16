using Orleans;

namespace OrleansFirstLook.Common
{
    public interface IHelloGrain : IGrainWithStringKey
    {
        Task<string> SayHello(string greeting);
    }
}
