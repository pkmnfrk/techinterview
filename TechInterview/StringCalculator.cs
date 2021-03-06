﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechInterview
{
    public class StringCalculator
    {
        /// <summary>
        /// Adds a series of numbers, and returns the result
        /// </summary>
        /// <param name="numbers"><para>The input string, with a delimiter header. Empty entries are ignored.</para><para>The expected format is: //[delimiter]\n[input][delimiter][input]....</para></param>
        /// <returns>The result.</returns>
        public int Add(string numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("numbers");

            var result = 0;
            var inputs = ParseInput(numbers);

            foreach (var inp in inputs)
            {
                var n = int.Parse(inp);

                if (n < 0)
                    throw new ArgumentException("Negatives not allowed", "numbers");

                if (n > 1000)
                    continue;

                result += n;
            }

            return result;
        }

        /// <summary>
        /// Parses the delimiter header in the number input.
        /// </summary>
        /// <param name="numbers">A string in the format //[delimiter]\n[input][delimiter][input][delimiter][input]...</param>
        /// <returns>a list of inputs, already trimmed and empty entries removed</returns>
        private string[] ParseInput(string numbers)
        {
            if (!numbers.StartsWith("//"))
                throw new ArgumentException("missing delimiter", "numbers");

            numbers = numbers.Substring(2);

            var parts = numbers.Split(new char[] { '\n' }, 2);

            if (parts.Length == 1)
                throw new ArgumentException("missing inputs", "numbers");

            var delimiterString = parts[0];
            var inputs = parts[1];

            var delimiters = delimiterString.Split('\r');

            // if they try and use \n as a delimiter, that... well, we could make it work. But we won't for now

            if (delimiters.Any(string.IsNullOrEmpty))
                throw new ArgumentException("delimiter is empty", "numbers");

            return inputs.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
