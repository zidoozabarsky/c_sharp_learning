﻿using MockProject;
using Moq;
using NUnit.Framework;

namespace TestProject2
{
    //https://habr.com/ru/post/150859/
    public class CheckMock
    {
        [Test, Category("Slow")]
        public void ShouldBe()
        {
            ILoggerDependency loggerDependency = Mock.Of<ILoggerDependency>(d => d.GetCurrentDirectory() == "D:\\Temp");
            Assert.That(loggerDependency.GetCurrentDirectory(), Is.EqualTo("D:\\Temp"));

            loggerDependency = Mock.Of<ILoggerDependency>(d => d.DefaultLogger == "default logger");
            Assert.That(loggerDependency.DefaultLogger, Is.EqualTo("default logger"));

            Mock<ILoggerDependency> stub = new Mock<ILoggerDependency>();
            stub.Setup(ld => ld.GetDirectoryByLoggerName(It.IsAny<string>()))
                .Returns<string>(name => "C:\\" + name);
            string loggerName = "SomeLogger";
            loggerDependency = stub.Object;
            string directory = loggerDependency.GetDirectoryByLoggerName(loggerName);
            Assert.That(directory, Is.EqualTo("C:\\SomeLogger"));        }
    }
}