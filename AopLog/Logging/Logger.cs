using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace AopLog.Logging
{
    public class Logger : ILog
    {
        private static readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AopLogs");

        private static TextWriterTraceListener _traceListener;

        public static Logger Instance = new Logger();

        private DateTime _logDate = DateTime.Now;

        private Logger()
        {
            Trace.AutoFlush = true;
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            var logFile = Path.Combine(_path, string.Format($"Log_{_logDate.ToString("yyyy-MM-dd")}.txt"));
            _traceListener = new TextWriterTraceListener(logFile);
            Trace.Listeners.Clear();
            Trace.Listeners.Add(_traceListener);
        }

        public void Error(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetTextWriterTraceListener();
            Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Error: {msg}");
            Trace.WriteLine($"--[详细信息] 方法名: {memberName},代码路径:{sourceFilePath},行号:{sourceLineNumber}");
        }

        public void Error(string msg, Exception e,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetTextWriterTraceListener();
            Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Error: {msg}");
            Trace.WriteLine($"--[详细信息] 方法名: {memberName},代码路径:{sourceFilePath},行号:{sourceLineNumber}");
            Trace.WriteLine($"----[异常信息]{e.StackTrace}");
        }

        public void Info( string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetTextWriterTraceListener();
            Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Info: {msg}");
            Trace.WriteLine($"--[详细信息] 方法名: {memberName},代码路径:{sourceFilePath},行号:{sourceLineNumber}");
        }

        public void Info(string msg, Exception e,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetTextWriterTraceListener();
            Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Info: {msg}");
            Trace.WriteLine($"--[详细信息] 方法名: {memberName},代码路径:{sourceFilePath},行号:{sourceLineNumber}");
            Trace.WriteLine($"----[异常信息]{e.StackTrace}");
        }

        public void Warn(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetTextWriterTraceListener();
            Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Warn: {msg}");
            Trace.WriteLine($"--[详细信息] 方法名: {memberName},代码路径:{sourceFilePath},行号:{sourceLineNumber}");
        }

        public void Warn(string msg, Exception e,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            SetTextWriterTraceListener();
            Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Info: {msg}");
            Trace.WriteLine($"--[详细信息] 方法名: {memberName},代码路径:{sourceFilePath},行号:{sourceLineNumber}");
            Trace.WriteLine($"----[异常信息]{e.StackTrace}");
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
