/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using magic.node;
using magic.node.extensions;

namespace magic.lambda.validators.helpers
{
    /*
     * Helper class to iterate validator expressions.
     */
    internal static class Enumerator
    {
        /*
         * Iterates the expression found in the given node,
         * and invokes function callback for each result.
         */
        public static void Enumerate<T>(Node node, Action<T, string> functor)
        {
            try
            {
                if (node.Value is Expression x)
                {
                    var value = x.Iterators.LastOrDefault()?.Value;
                    foreach (var idx in node.Evaluate())
                    {
                        var obj = idx.GetEx<T>();
                        if (obj != null)
                            functor(obj, value);
                    }
                }
                else
                {
                    var obj = node.GetEx<T>();
                    if (obj != null)
                        functor(obj, "value of node");
                }
            }
            finally
            {
                node.Value = null;
                node.Clear();
            }
        }
    }
}
