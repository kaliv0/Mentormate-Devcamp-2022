namespace EndpointTestApplication
{
    using System.Diagnostics;

    public static class EndpointTester
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string Port = "44321";
        private const string VictimEndpoint= $"https://localhost:{Port}/Homework/victim";
        private const string TortureEndpoint = $"https://localhost:{Port}/Homework/torture";

        /* 
           Using Parallelism will have value if both endpoints are asynchronous.
           Torture (the longer endpoint in this example) is synchronous and thus a blocking one.         
        */

        public static async Task<(string victim, string torture, TimeSpan elapsedTime)> SendRequestsAsync()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var victim = _client.GetStringAsync(VictimEndpoint);
            var torture = _client.GetStringAsync(TortureEndpoint);

            await Task.WhenAll(victim, torture);

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed;

            return (victim.Result, torture.Result, elapsedTime);
        }
    }
}
