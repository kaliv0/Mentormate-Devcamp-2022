using System.Diagnostics;
using EndpointTestApplication;

var stopWatch = new Stopwatch();
stopWatch.Start();

while (true)
{
    (string victim, string torture, TimeSpan elapsedTime) = await EndpointTester.SendRequestsAsync();

    Console.WriteLine(
        $"Victim name: {victim}, Torture: {torture}, Time elapsed: {elapsedTime}");

    if (victim == "Kaloyan Ivanov" && torture == ".NET")
    {
        break;
    }
}

stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
