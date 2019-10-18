/*
 * Magic, Copyright(c) Thomas Hansen 2019, thomas@gaiasoul.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

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
    }
}
