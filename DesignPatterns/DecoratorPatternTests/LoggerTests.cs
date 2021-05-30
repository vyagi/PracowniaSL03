using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern;
using FluentAssertions;
using Xunit;

namespace DecoratorPatternTests
{
    public class LoggerTests
    {
        [Fact]
        public void SimpleLogger_log_properly()
        {
            var logger = new SimpleLogger();
            var log = logger.Log("Marcin");
        
            log.Should().Be("Information: Marcin");
        }

        [Fact]
        public void TimeStampingLogger_log_properly()
        {
            var logger = new TimeStampingLogger(new SimpleLogger());
            var log = logger.Log("Marcin");

            log.Should().StartWith(DateTime.Now.Year.ToString());
            log.Should().EndWith("Information: Marcin");
        }

        [Fact]
        public void EncryptingLogger_log_properly()
        {
            var logger = new EncryptingLogger(new SimpleLogger());
            var log = logger.Log("Marcin");
        
            log.Should().NotContain("Marcin");
        }

        [Fact]
        public void TimeStampingEncryptingLogger_log_properly()
        {
            var logger = new TimeStampingLogger(new EncryptingLogger(new SimpleLogger()));
            var log = logger.Log("Marcin");

            log.Should().StartWith(DateTime.Now.Year.ToString());
            log.Should().NotContain("Marcin");
        }

        [Fact]
        public void EncryptingTimeStampingLogger_log_properly()
        {
            var logger = new EncryptingLogger(new TimeStampingLogger(new SimpleLogger()));
            var log = logger.Log("Marcin");

            log.Should().NotStartWith(DateTime.Now.Year.ToString());
            log.Should().NotContain("Marcin");
        }

        // [Fact]
        // public void Logger_log_properly()
        // {
        //     var logger = new Logger();
        //     var log = logger.Log("Marcin");
        //
        //     log.Should().Be("Information: Marcin");
        // }
        //
        // [Fact]
        // public void TimeStampingLogger_log_properly()
        // {
        //     var logger = new TimeStampingLogger();
        //     var log = logger.Log("Marcin");
        //
        //     log.Should().StartWith(DateTime.Now.Year.ToString());
        //     log.Should().EndWith("Information: Marcin");
        // }
        //
        // [Fact]
        // public void EncryptingLogger_log_properly()
        // {
        //     var logger = new EncryptingLogger();
        //     var log = logger.Log("Marcin");
        //
        //     log.Should().NotContain("Marcin");
        // }
    }
}
