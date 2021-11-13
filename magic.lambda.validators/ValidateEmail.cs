﻿/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Net.Mail;
using magic.node;
using magic.signals.contracts;
using magic.lambda.exceptions;
using magic.lambda.validators.helpers;

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
            Enumerator.Enumerate<string>(input, (value, name) =>
            {
                try
                {
                    var addr = new MailAddress(value);
                    if (addr.Address != value)
                    {
                        // Verifying there are not funny configurations, creating name as first part
                        throw new HyperlambdaException(
                            $"'{value}' is not a valid email address for [{name}]",
                            true,
                            400,
                            name);
                    }
                }
                catch
                {
                    // Verifying there are not funny configurations, creating name as first part
                    throw new HyperlambdaException(
                        $"'{value}' is not a valid email address",
                        true,
                        400,
                        name);
                }
            });
        }
    }
}
