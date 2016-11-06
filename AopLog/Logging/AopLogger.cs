using System;
using System.Diagnostics;
using System.IO;

namespace AopLog.Logging
{
    internal class AopLogger : IAopLog
    {
        private static readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AopLogs");

        private static TextWriterTraceListener _traceListener;

        public static AopLogger Instance = new AopLogger();

        private DateTime _logDate = DateTime.Now;

        private AopLogger()
        {
            Trace.AutoFlush = true;
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            var logFile = Path.Combine(_path, string.Format($"Log_{_logDate.ToString("yyyy-MM-dd")}.txt"));
            _traceListener = new TextWriterTraceListener(logFile);
            Trace.Listeners.Clear();
            Trace.Listeners.Add(_traceListener);
        }

        public void Error(string msg)
        {
            Trace.TraceError($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
        }

        public void Error(string msg, string stackTrace)
        {
            Trace.TraceError($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
            Trace.WriteLine($"--[异常信息]{stackTrace}");
        }

        public void Error(string msg, Exception e)
        {
            Trace.TraceError($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
            Trace.WriteLine($"--[异常信息]{e.ToString()}");
        }

        public void Info(string msg)
        {
            Trace.TraceInformation($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
        }

        public void Info(string msg, Exception e)
        {
            Trace.TraceInformation($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
            Trace.WriteLine($"--[异常信息]{e.ToString()}");
        }

        public void Warn(string msg)
        {
            Trace.TraceWarning($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
        }

        public void Warn(string msg, Exception e)
        {
            Trace.TraceWarning($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} : {msg}");
            Trace.WriteLine($"--[异常信息]{e.ToString()}");
        }

        private void SetTextWriterTraceListener()
        {
            DateTime now = DateTime.Now;
            if (!now.ToString("yyyyMMdd").Equals(_logDate.ToString("yyyyMMdd")))
            {
                _logDate = now;
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);
                var logFile = Path.Combine(_path, string.Format($"Log_{_logDate.ToString("yyyy-MM-dd")}.txt"));
                _traceListener = new TextWriterTraceListener(logFile);
                Trace.Listeners.Clear();
                Trace.Listeners.Add(_traceListener);
            }
        }
    }
}
