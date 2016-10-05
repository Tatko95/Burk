﻿using System;

namespace Burk.Core.Abstract.Log
{
    /// <summary>
    /// The ILog interface is use by application to log messages into
    /// the log4net framework.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use the log4net.LogManager to obtain logger instances
    /// that implement this interface. The LogManager.GetLogger(Assembly,Type)
    /// static method is used to get logger instances.
    /// </para>
    /// <para>
    /// This class contains methods for logging at different levels and also
    /// has properties for determining if those logging levels are
    /// enabled in the current configuration.
    /// </para>
    /// <para>
    /// This interface can be implemented in different ways. This documentation
    /// specifies reasonable behavior that a caller can expect from the actual
    /// implementation, however different implementations reserve the right to
    /// do things differently.
    /// </para>
    /// </remarks>
    /// <example>Simple example of logging messages
    /// <code lang="C#">
    /// ILog log = LogManager.GetLogger("application-log");
    ///
    /// log.Info("Application Start");
    /// log.Debug("This is a debug message");
    ///
    /// if (log.IsDebugEnabled)
    /// {
    /// 	log.Debug("This is another debug message");
    /// }
    /// </code>
    /// </example>
    public interface ILog
    {
        #region PROPERTIES
        /// <summary>
        /// Checks if this logger is enabled for the log4net.Core.Level.Debug level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for log4net.Core.Level.Debug events, <c>false</c> otherwise.
        /// </value>
        /// <remarks>
        /// <para>
        /// This function is intended to lessen the computational cost of
        /// disabled log debug statements.
        /// </para>
        /// <para> For some ILog interface <c>log</c>, when you write:</para>
        /// <code lang="C#">
        /// log.Debug("This is entry number: " + i );
        /// </code>
        /// <para>
        /// You incur the cost constructing the message, string construction and concatenation in
        /// this case, regardless of whether the message is logged or not.
        /// </para>
        /// <para>
        /// If you are worried about speed (who isn't), then you should write:
        /// </para>
        /// <code lang="C#">
        /// if (log.IsDebugEnabled)
        /// { 
        ///     log.Debug("This is entry number: " + i );
        /// }
        /// </code>
        /// <para>
        /// This way you will not incur the cost of parameter
        /// construction if debugging is disabled for <c>log</c>. On
        /// the other hand, if the <c>log</c> is debug enabled, you
        /// will incur the cost of evaluating whether the logger is debug
        /// enabled twice. Once in log4net.ILog.IsDebugEnabled and once in
        /// the Debug(object).  This is an insignificant overhead
        /// since evaluating a logger takes about 1% of the time it
        /// takes to actually log. This is the preferred style of logging.
        /// </para>
        /// <para>Alternatively if your logger is available statically then the is debug
        /// enabled state can be stored in a static variable like this:
        /// </para>
        /// <code lang="C#">
        /// private static readonly bool isDebugEnabled = log.IsDebugEnabled;
        /// </code>
        /// <para>
        /// Then when you come to log you can write:
        /// </para>
        /// <code lang="C#">
        /// if (isDebugEnabled)
        /// { 
        ///     log.Debug("This is entry number: " + i );
        /// }
        /// </code>
        /// <para>
        /// This way the debug enabled state is only queried once
        /// when the class is loaded. Using a <c>private static readonly</c>
        /// variable is the most efficient because it is a run time constant
        /// and can be heavily optimized by the JIT compiler.
        /// </para>
        /// <para>
        /// Of course if you use a static readonly variable to
        /// hold the enabled state of the logger then you cannot
        /// change the enabled state at runtime to vary the logging
        /// that is produced. You have to decide if you need absolute
        /// speed or runtime flexibility.
        /// </para>
        /// </remarks>
        bool IsDebugEnabled
        {
            get;
        }

        /// <summary>
        /// Checks if this logger is enabled for the log4net.Core.Level.Info level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for log4net.Core.Level.Info events, <c>false</c> otherwise.
        /// </value>
        /// <remarks>
        /// For more information see log4net.ILog.IsDebugEnabled.
        /// </remarks>
        bool IsInfoEnabled
        {
            get;
        }

        /// <summary>
        /// Checks if this logger is enabled for the log4net.Core.Level.Warn level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for log4net.Core.Level.Warn events, <c>false</c> otherwise.
        /// </value>
        /// <remarks>
        /// For more information see log4net.ILog.IsDebugEnabled.
        /// </remarks>
        bool IsWarnEnabled
        {
            get;
        }

        /// <summary>
        /// Checks if this logger is enabled for the log4net.Core.Level.Error level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for log4net.Core.Level.Error events, <c>false</c> otherwise.
        /// </value>
        /// <remarks>
        /// For more information see log4net.ILog.IsDebugEnabled.
        /// </remarks>
        bool IsErrorEnabled
        {
            get;
        }

        /// <summary>
        /// Checks if this logger is enabled for the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for log4net.Core.Level.Fatal events, <c>false</c> otherwise.
        /// </value>
        /// <remarks>
        /// For more information see log4net.ILog.IsDebugEnabled.
        /// </remarks>
        bool IsFatalEnabled
        {
            get;
        }
        #endregion

        #region METHODS
        /// <overloads>Log a message object with the log4net.Core.Level.Debug level.</overloads>
        /// <summary>
        /// Log a message object with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <remarks>
        /// <para>
        /// This method first checks if this logger is <c>DEBUG</c>
        /// enabled by comparing the level of this logger with the 
        /// log4net.Core.Level.Debug level. If this logger is
        /// <c>DEBUG</c> enabled, then it converts the message object
        /// (passed as parameter) to a string by invoking the appropriate
        /// log4net.ObjectRenderer.IObjectRenderer. It then 
        /// proceeds to call all the registered appenders in this logger 
        /// and also higher in the hierarchy depending on the value of 
        /// the additivity flag.
        /// </para>
        /// <para><b>WARNING</b> Note that passing an System.Exception 
        /// to this method will print the name of the System.Exception 
        /// but no stack trace. To print a stack trace use the 
        /// Debug(object,Exception) form instead.
        /// </para>
        /// </remarks>
        void Debug(object message);

        /// <summary>
        /// Log a message object with the log4net.Core.Level.Debug level including
        /// the stack trace of the System.Exception passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        /// <para>
        /// See the Debug(object) form for more detailed information.
        /// </para>
        /// </remarks>
        void Debug(object message, Exception exception);

        /// <overloads>Log a formatted string with the log4net.Core.Level.Debug level.</overloads>
        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Debug(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Debug(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void DebugFormat(string format, object arg0);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Debug(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void DebugFormat(string format, object arg0, object arg1);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <param name="arg2">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Debug(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void DebugFormat(string format, object arg0, object arg1, object arg2);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific formatting information</param>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Debug(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void DebugFormat(IFormatProvider provider, string format, params object[] args);

        /// <overloads>Log a message object with the log4net.Core.Level.Info level.</overloads>
        /// <summary>
        /// Logs a message object with the log4net.Core.Level.Info level.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method first checks if this logger is <c>INFO</c>
        /// enabled by comparing the level of this logger with the 
        /// log4net.Core.Level.Info level. If this logger is
        /// <c>INFO</c> enabled, then it converts the message object
        /// (passed as parameter) to a string by invoking the appropriate
        /// log4net.ObjectRenderer.IObjectRenderer. It then 
        /// proceeds to call all the registered appenders in this logger 
        /// and also higher in the hierarchy depending on the value of the 
        /// additivity flag.
        /// </para>
        /// <para><b>WARNING</b> Note that passing an System.Exception 
        /// to this method will print the name of the System.Exception
        /// but no stack trace. To print a stack trace use the 
        /// Info(object,Exception) form instead.
        /// </para>
        /// </remarks>
        /// <param name="message">The message object to log.</param>
        void Info(object message);

        /// <summary>
        /// Logs a message object with the <c>INFO</c> level including
        /// the stack trace of the System.Exception passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        /// <para>
        /// See the Info(object) form for more detailed information.
        /// </para>
        /// </remarks>
        void Info(object message, Exception exception);

        /// <overloads>Log a formatted message string with the log4net.Core.Level.Info level.</overloads>
        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Info level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Info(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Info level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Info(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void InfoFormat(string format, object arg0);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Info level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Info(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void InfoFormat(string format, object arg0, object arg1);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Info level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <param name="arg2">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Info(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void InfoFormat(string format, object arg0, object arg1, object arg2);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Info level.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific formatting information</param>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Info(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void InfoFormat(IFormatProvider provider, string format, params object[] args);

        /// <overloads>Log a message object with the log4net.Core.Level.Warn level.</overloads>
        /// <summary>
        /// Log a message object with the log4net.Core.Level.Warn level.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method first checks if this logger is <c>WARN</c>
        /// enabled by comparing the level of this logger with the 
        /// log4net.Core.Level.Warn level. If this logger is
        /// <c>WARN</c> enabled, then it converts the message object
        /// (passed as parameter) to a string by invoking the appropriate
        /// log4net.ObjectRenderer.IObjectRenderer. It then 
        /// proceeds to call all the registered appenders in this logger 
        /// and also higher in the hierarchy depending on the value of the 
        /// additivity flag.
        /// </para>
        /// <para><b>WARNING</b> Note that passing an System.Exception 
        /// to this method will print the name of the System.Exception
        /// but no stack trace. To print a stack trace use the 
        /// Warn(object,Exception) form instead.
        /// </para>
        /// </remarks>
        /// <param name="message">The message object to log.</param>
        void Warn(object message);

        /// <summary>
        /// Log a message object with the log4net.Core.Level.Warn level including
        /// the stack trace of the System.Exception passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        /// <para>
        /// See the Warn(object) form for more detailed information.
        /// </para>
        /// </remarks>
        void Warn(object message, Exception exception);

        /// <overloads>Log a formatted message string with the log4net.Core.Level.Warn level.</overloads>
        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Warn level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Warn(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void WarnFormat(string format, params object[] args);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Warn level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Warn(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void WarnFormat(string format, object arg0);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Warn level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Warn(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void WarnFormat(string format, object arg0, object arg1);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Warn level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <param name="arg2">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Warn(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void WarnFormat(string format, object arg0, object arg1, object arg2);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Warn level.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific formatting information</param>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Warn(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void WarnFormat(IFormatProvider provider, string format, params object[] args);

        /// <overloads>Log a message object with the log4net.Core.Level.Error level.</overloads>
        /// <summary>
        /// Logs a message object with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <remarks>
        /// <para>
        /// This method first checks if this logger is <c>ERROR</c>
        /// enabled by comparing the level of this logger with the 
        /// log4net.Core.Level.Error level. If this logger is
        /// <c>ERROR</c> enabled, then it converts the message object
        /// (passed as parameter) to a string by invoking the appropriate
        /// log4net.ObjectRenderer.IObjectRenderer. It then 
        /// proceeds to call all the registered appenders in this logger 
        /// and also higher in the hierarchy depending on the value of the 
        /// additivity flag.
        /// </para>
        /// <para><b>WARNING</b> Note that passing an System.Exception
        /// to this method will print the name of the System.Exception
        /// but no stack trace. To print a stack trace use the 
        /// Error(object,Exception) form instead.
        /// </para>
        /// </remarks>
        void Error(object message);

        /// <summary>
        /// Log a message object with the log4net.Core.Level.Error level including
        /// the stack trace of the System.Exception passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        /// <para>
        /// See the Error(object) form for more detailed information.
        /// </para>
        /// </remarks>
        void Error(object message, Exception exception);

        /// <overloads>Log a formatted message string with the log4net.Core.Level.Error level.</overloads>
        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Error(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Error(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void ErrorFormat(string format, object arg0);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Error(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void ErrorFormat(string format, object arg0, object arg1);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <param name="arg2">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Error(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void ErrorFormat(string format, object arg0, object arg1, object arg2);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific formatting information</param>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Error(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void ErrorFormat(IFormatProvider provider, string format, params object[] args);

        /// <overloads>Log a message object with the log4net.Core.Level.Fatal level.</overloads>
        /// <summary>
        /// Log a message object with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method first checks if this logger is <c>FATAL</c>
        /// enabled by comparing the level of this logger with the 
        /// log4net.Core.Level.Fatal level. If this logger is
        /// <c>FATAL</c> enabled, then it converts the message object
        /// (passed as parameter) to a string by invoking the appropriate
        /// log4net.ObjectRenderer.IObjectRenderer. It then 
        /// proceeds to call all the registered appenders in this logger 
        /// and also higher in the hierarchy depending on the value of the 
        /// additivity flag.
        /// </para>
        /// <para><b>WARNING</b> Note that passing an System.Exception 
        /// to this method will print the name of the System.Exception
        /// but no stack trace. To print a stack trace use the 
        /// Fatal(object,Exception) form instead.
        /// </para>
        /// </remarks>
        /// <param name="message">The message object to log.</param>
        void Fatal(object message);

        /// <summary>
        /// Log a message object with the log4net.Core.Level.Fatal level including
        /// the stack trace of the System.Exception passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        /// <para>
        /// See the Fatal(object) form for more detailed information.
        /// </para>
        /// </remarks>
        void Fatal(object message, Exception exception);

        /// <overloads>Log a formatted message string with the log4net.Core.Level.Fatal level.</overloads>
        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Fatal(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Fatal(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void FatalFormat(string format, object arg0);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Fatal(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void FatalFormat(string format, object arg0, object arg1);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="arg0">An Object to format</param>
        /// <param name="arg1">An Object to format</param>
        /// <param name="arg2">An Object to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Fatal(object,Exception)
        /// methods instead.
        /// </para>
        /// </remarks>
        void FatalFormat(string format, object arg0, object arg1, object arg2);

        /// <summary>
        /// Logs a formatted message string with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific formatting information</param>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        /// <para>
        /// The message is formatted using the <c>String.Format</c> method. See
        /// String.Format(string, object[]) for details of the syntax of the format string and the behavior
        /// of the formatting.
        /// </para>
        /// <para>
        /// This method does not take an System.Exception object to include in the
        /// log event. To pass an System.Exception use one of the Fatal(object)
        /// methods instead.
        /// </para>
        /// </remarks>
        void FatalFormat(IFormatProvider provider, string format, params object[] args);
        #endregion
    }
}
