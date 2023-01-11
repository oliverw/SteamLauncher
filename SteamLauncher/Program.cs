using System.Diagnostics;

if (args.Length != 2)
{
    Console.WriteLine("ERROR: Needs launch URL and Process (Executable) Name");
    return;
}

var epicUrl = args[0];
var processName = args[1];

// strip .exe extension if present
if (processName.ToLower().EndsWith(".exe"))
    processName = processName[..^4];

var ps = new ProcessStartInfo(epicUrl)
{
    UseShellExecute = true,
    Verb = "open"
};

Console.WriteLine($"Starting url: {epicUrl}");
Process.Start(ps);

Thread.Sleep(5000);

var processes = Process.GetProcessesByName(processName);

if (processes.Length != 1)
{
    Console.WriteLine($"Could not find a single process with name: {processName}");
    return;
}
    
Console.WriteLine($"Game is runnning. Waiting for process exit ...");

processes[0].WaitForExit();

Console.WriteLine($"Process exited.");
