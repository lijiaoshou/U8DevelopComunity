using System.Diagnostics;

namespace UFIDA.Framework.Diagnostics
{
    /// <summary>
    /// 进程处理
    /// </summary>
    public static class UFIDAProcess
    {
        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="command">命令</param>
        public static void ExecuteCommand(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.WriteLine("exit");

                    while (!process.HasExited)
                    {
                        process.WaitForExit(1000);
                    }
                }
            }
        }
    }
}
