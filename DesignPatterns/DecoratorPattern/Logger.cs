using System;
using NETCore.Encrypt;
using NETCore.Encrypt.Internal;

namespace DecoratorPattern
{
    public interface ILogger
    {
        string Log(string message);
    }

    public class SimpleLogger : ILogger
    {
        public string Log(string message) => $"Information: {message}";
    }

    public class TimeStampingLogger : ILogger
    {
        private readonly ILogger _logger;

        public TimeStampingLogger(ILogger logger) => _logger = logger;

        public string Log(string message) => 
            $"{DateTime.Now:yyyyMMddTHH:mm:ss} {_logger.Log(message)}";
    }

    public class EncryptingLogger : ILogger
    {
        private readonly AESKey _aesKey = EncryptProvider.CreateAesKey();

        private readonly ILogger _logger;

        public EncryptingLogger(ILogger logger) => _logger = logger;

        public string Log(string message) => 
            EncryptProvider.AESEncrypt(_logger.Log(message), _aesKey.Key);
    }



    // public class Logger
    // {
    //     public virtual string Log(string message) => $"Information: {message}";
    // }
    //
    // public class TimeStampingLogger : Logger
    // {
    //     public override string Log(string message) => 
    //         $"{DateTime.Now:yyyyMMddTHH:mm:ss} {base.Log(message)}";
    // }
    //
    // public class EncryptingLogger : Logger
    // {
    //     private readonly AESKey _aesKey = EncryptProvider.CreateAesKey();
    //
    //     public override string Log(string message) => 
    //         EncryptProvider.AESEncrypt(base.Log(message), _aesKey.Key);
    // }
    //
    // public class EncryptingTimeStampingLogger : Logger
    // {
    //     public override string Log(string message)
    //     {
    //         return base.Log(message);//TODO
    //     }
    // }
    //
    // public class TimeStampingEncryptingLogger : Logger
    // {
    //     public override string Log(string message)
    //     {
    //         return base.Log(message);//TODO
    //     }
    // }
    //
    // public class CompressingLogger : Logger
    // {
    //     public override string Log(string message)
    //     {
    //         return base.Log(message);//TODO
    //     }
    // }
}
