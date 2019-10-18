/*
 * Magic, Copyright(c) Thomas Hansen 2019, thomas@gaiasoul.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System.Net.Mail;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.validators
{
    /// <summary>
    /// [validators.email] slot, for verifying that some input is a valid email address.
    /// </summary>
    [Slot(Name = "validators.email")]
    public class ValidateEmail : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to signal.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var email = input.GetEx<string>();
            try
            {
                var addr = new MailAddress(email);
                input.Value = null;
            }
            catch
            {
                input.Value = $"'{email}' is not a valid email address";
            }
        }
    }
}
