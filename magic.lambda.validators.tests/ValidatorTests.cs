/*
 * Magic, Copyright(c) Thomas Hansen 2019, thomas@gaiasoul.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using Xunit;
using magic.node;

namespace magic.lambda.validators.tests
{
    public class ValidatorTests
    {
        [Fact]
        public void VerifyEmail()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo@bar.com");
            signaler.Signal("validators.email", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyEmail_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo@@bar.com");
            signaler.Signal("validators.email", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyInteger()
        {
            var signaler = Common.Initialize();
            var args = new Node("", 5, new Node[] { new Node("min", 4), new Node("max", 7) });
            signaler.Signal("validators.integer", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyInteger_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", 8, new Node[] { new Node("min", 4), new Node("max", 7) });
            signaler.Signal("validators.integer", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyUrl()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "http://foo.com");
            signaler.Signal("validators.url", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyHttpsUrl()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "https://foo.com");
            signaler.Signal("validators.url", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyUrl_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo.com");
            signaler.Signal("validators.url", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyDate()
        {
            var signaler = Common.Initialize();
            var args = new Node("", DateTime.Now, new Node[] { new Node("min", DateTime.Now.AddSeconds(-5)), new Node("max", DateTime.Now.AddSeconds(5)) });
            signaler.Signal("validators.date", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyDate_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", DateTime.Now.AddSeconds(10), new Node[] { new Node("min", DateTime.Now.AddSeconds(-5)), new Node("max", DateTime.Now.AddSeconds(5)) });
            signaler.Signal("validators.date", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }
    }
}
