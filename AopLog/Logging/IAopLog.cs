using System;

namespace AopLog.Logging
{
    internal interface IAopLog
    {
        void Info(string msg, Exception e);

        void Info(string msg);

        void Warn(string msg, Exception e);

        void Warn(string msg);

        void Error(string msg, Exception e);

        void Error(string msg);

        void Error(string msg, string stackTrace);
    }
}
