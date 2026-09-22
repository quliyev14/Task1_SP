using System.Diagnostics;

class Program
{
    static void Main()
    {
        Thread thread1 = new(ShowProcesses);
        Thread thread2 = new(Command);

        thread1.Start();
        thread2.Start();
    }

    static void ShowProcesses()
    {
        while (true)
        {
            var processes = Process.GetProcesses();
            Console.WriteLine("Son 20 Process:");

            for (int i = 0; i < 20 && i < processes.Length; i++)
            {
                Console.WriteLine(processes[i].ProcessName);
            }
            Thread.Sleep(500);
        }
    }

    static void Command()
    {
        while (true)
        {
            var command = Console.ReadLine();
            if (command.Contains("start"))
            {
                Process.Start("chrome.exe");
            }
            else if (command.Contains("kill"))
            {
                var processes = Process.GetProcessesByName("chrome");

                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}