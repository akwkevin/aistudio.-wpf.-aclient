//using AIStudio.Wpf.Service;
using AIStudio.Core;
using Prism.Ioc;
using System;

namespace AIStudio.Wpf.Business
{
    public class Logger : ILogger
    {
        /// <summary>
        /// 配置Logger
        /// </summary>
        static Logger()
        {
            //从配置文件读取
            var logger = NLog.LogManager.LoadConfiguration("nlog.config");           
        }
        private IOperator _operator { get => ContainerLocator.Current.Resolve<IOperator>(); }


        public void Log(LogLevel logLevel, LogType logType, string msg, string data)
        {
            NLog.Logger _nLogger = NLog.LogManager.GetLogger(logType.ToString());

            NLog.LogEventInfo log = new NLog.LogEventInfo(NLog.LogLevel.FromString(logLevel.ToString()), logType.ToString(), msg);
            log.Properties[LoggerConfig.Data] = data;
            log.Properties[LoggerConfig.LogType] = logType.ToString();
            try
            {
                if (_operator != null && _operator.Property != null)
                {
                    log.Properties[LoggerConfig.CreatorName] = _operator?.UserName;
                    log.Properties[LoggerConfig.CreatorId] = _operator?.Property?.Id;
                }
            }
            catch
            {

            }

            _nLogger.Log(log);
        }

        public void Log(LogLevel logLevel, LogType logType, string msg)
        {
            Log(logLevel, logType, msg, null);
        }

        public void Debug(LogType logType, string msg)
        {
            Log(LogLevel.Debug, logType, msg);
        }

        public void Debug(LogType logType, string msg, string data)
        {
            Log(LogLevel.Debug, logType, msg, data);
        }

        public void Error(LogType logType, string msg)
        {
            Log(LogLevel.Error, logType, msg);
        }

        public void Error(LogType logType, string msg, string data)
        {
            Log(LogLevel.Error, logType, msg, data);
        }

        public void Error(Exception ex)
        {
            Log(LogLevel.Error, LogType.系统异常, ExceptionHelper.GetExceptionAllMsg(ex));
        }

        public void Fatal(LogType logType, string msg)
        {
            Log(LogLevel.Fatal, logType, msg);
        }

        public void Fatal(LogType logType, string msg, string data)
        {
            Log(LogLevel.Fatal, logType, msg, data);
        }

        public void Info(LogType logType, string msg)
        {
            Log(LogLevel.Info, logType, msg);
        }

        public void Info(LogType logType, string msg, string data)
        {
            Log(LogLevel.Info, logType, msg, data);
        }

        public void Trace(LogType logType, string msg)
        {
            Log(LogLevel.Trace, logType, msg);
        }

        public void Trace(LogType logType, string msg, string data)
        {
            Log(LogLevel.Trace, logType, msg, data);
        }

        public void Warn(LogType logType, string msg)
        {
            Log(LogLevel.Warn, logType, msg);
        }

        public void Warn(LogType logType, string msg, string data)
        {
            Log(LogLevel.Warn, logType, msg, data);
        }
    }
}
