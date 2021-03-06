﻿using NUnit.Framework;

namespace CreateAR.Commons.Unity.Logging.Test
{
    [Parallelizable(ParallelScope.None)]
    [TestFixture]
    public class Log_Tests
    {
        public class DummyLogTarget : ILogTarget
        {
            public bool Called = false;
            public LogLevel Level;
            public object Caller;
            public string Message;

            public void OnLog(LogLevel level, object caller, string message)
            {
                Called = true;

                Level = level;
                Caller = caller;
                Message = message;
            }
        }

        private DummyLogTarget _target;

        [SetUp]
        public void Setup()
        {
            _target = new DummyLogTarget();
        }

        [TearDown]
        public void Teardown()
        {
            foreach (var target in Log.Targets)
            {
                Log.RemoveLogTarget(target);
            }
        }

        [Test]
        public void AddRemoveTarget()
        {
            Log.AddLogTarget(_target);

            Assert.AreSame(_target, Log.Targets[0]);

            Log.RemoveLogTarget(_target);

            Assert.AreEqual(0, Log.Targets.Length);
        }

        [Test]
        public void Filter()
        {
            Log.AddLogTarget(_target);
            Log.Filter = LogLevel.Error;
            Log.Debug(this, "Test");

            Assert.IsFalse(_target.Called);
        }
    }
}