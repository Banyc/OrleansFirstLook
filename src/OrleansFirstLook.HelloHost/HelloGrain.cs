using Orleans;
using Orleans.Runtime;
using OrleansFirstLook.Common;

namespace OrleansFirstLook.HelloHost
{
    public class GreetingState
    {
        public int Count { get; set; }
    }

    public class HelloGrain : Grain, IHelloGrain
    {
        private readonly IPersistentState<GreetingState> _state;
        public HelloGrain(
            [PersistentState("greetings", storageName: "helloState")]
            IPersistentState<GreetingState> state)
        {
            this._state = state;
        }

        public async Task<string> SayHello(string greeting)
        {
            this._state.State.Count++;
            await this._state.WriteStateAsync();
            return $"Hello, {greeting}! Count: {this._state.State.Count}";
        }
    }
}
