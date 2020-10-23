/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.validators
{
    /// <summary>
    /// [validators.mandatory] slot, for verifying that some input was given.
    /// </summary>
    [Slot(Name = "validators.mandatory")]
    public class ValidateMandatory : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to signal.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var value = input.GetEx<object>();
            var name = input.Value is Expression exp ? exp.Iterators.Last().Value : "";
            if (value == null)
                throw new ArgumentException($"Mandatory [{name}] argument was not given");
        }
    }
}
