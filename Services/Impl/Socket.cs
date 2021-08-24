using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Services.Api;

namespace Services.Impl
{
    public class Socket : ISocket 
    {
        private string _totalMoney = "";
        private string _pythonPath = @$"C:\Users\{Environment.UserName}\AppData\Local\Programs\Python\Python39\python.exe";
        public double GetTotalMoney()
        {
            try
            {
                string filePath = @"-u  ..\..\..\..\BinanceSocket\GetTotalMoney.py";
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = _pythonPath,
                        Arguments = filePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    },
                    EnableRaisingEvents = true
                };
                process.ErrorDataReceived += Process_OutputDataReceived1;
                process.OutputDataReceived += Process_OutputDataReceived1;

                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.WaitForExit();
                return Convert.ToDouble(_totalMoney);
            }
            catch
            {
                return -1;
            }
        }

        public List<(string assetName, double assetAmount, double assetAmountUsdt)> GetAllAssets()
        {
            try
            {
                string filePath = @"-u  ..\..\..\..\BinanceSocket\GetAllAssets.py";
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = _pythonPath,
                        Arguments = filePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    },
                    EnableRaisingEvents = true
                };
                process.ErrorDataReceived += Process_OutputDataReceived2;
                process.OutputDataReceived += Process_OutputDataReceived2;

                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.WaitForExit();
                return null;
            }
            catch
            {
                return null;
            }
        }

        public void Process_OutputDataReceived1(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                _totalMoney = e.Data;
        }

        public void Process_OutputDataReceived2(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                _totalMoney = e.Data;
        }
    }
}
