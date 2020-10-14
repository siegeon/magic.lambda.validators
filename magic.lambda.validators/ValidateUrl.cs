/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using magic.node;
using magic.signals.contracts;
using magic.lambda.validators.helpers;

namespace magic.lambda.validators
{
    /// <summary>
    /// [validators.url] slot, for verifying that some input is a valid URL.
    /// </summary>
    [Slot(Name = "validators.url")]
    public class ValidateUrl : ISlot
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
                bool result = Uri.TryCreate(value, UriKind.Absolute, out Uri res);
                if (!result || (res.Scheme != Uri.UriSchemeHttp && res.Scheme != Uri.UriSchemeHttps))
                    throw new ArgumentException($"'{value}' in [{name}] is not a valid URL, it needs to be prepended with http:// or https:// and also be a valid URL");
            });
        }
    }
}
