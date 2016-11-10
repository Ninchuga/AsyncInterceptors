using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;

namespace AsyncInterceptors
{
	public class LoggerClass : ILogger
	{
		public ILogger CreateChildLogger(string loggerName)
		{
			throw new NotImplementedException();
		}

		public void Debug(string message)
		{
			
		}

		public void Debug(Func<string> messageFactory)
		{
			throw new NotImplementedException();
		}

		public void Debug(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(Exception exception, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Error(string message)
		{
			
		}

		public void Error(Func<string> messageFactory)
		{
			throw new NotImplementedException();
		}

		public void Error(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(Exception exception, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Fatal(string message)
		{
			
		}

		public void Fatal(Func<string> messageFactory)
		{
			throw new NotImplementedException();
		}

		public void Fatal(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(Exception exception, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Info(string message)
		{
			
		}

		public void Info(Func<string> messageFactory)
		{
			throw new NotImplementedException();
		}

		public void Info(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(Exception exception, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Warn(string message)
		{
			
		}

		public void Warn(Func<string> messageFactory)
		{
			throw new NotImplementedException();
		}

		public void Warn(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(Exception exception, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public bool IsDebugEnabled { get; }
		public bool IsErrorEnabled { get; }
		public bool IsFatalEnabled { get; }
		public bool IsInfoEnabled { get; }
		public bool IsWarnEnabled { get; }
	}
}
