﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System.Linq;
using System.Text.RegularExpressions;
using magic.node;
using magic.node.extensions;
using magic.lambda.exceptions;
using magic.signals.contracts;
using magic.lambda.validators.helpers;

namespace magic.lambda.validators
{
    /// <summary>
    /// [validators.regex] slot, for verifying that some input is matching some specified regular expression found in [regex].
    /// </summary>
    [Slot(Name = "validators.regex")]
    public class ValidateRegex : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to signal.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var pattern = input.Children.First(x => x.Name == "regex").GetEx<string>();
            Enumerator.Enumerate<string>(input, (value, name) =>
            {
                var isMatch = new Regex(pattern).IsMatch(value);
                if (!isMatch)
                    throw new HyperlambdaException(
                        $"'{value}' does not conform to regular expression of '{pattern}' for [{name}]",
                        true,
                        400,
                        name);
            });
        }
    }
}
