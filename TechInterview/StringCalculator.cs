using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechInterview
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("numbers");

            var result = 0;
            var inputs = numbers.Split(',');

            foreach (var inp in inputs)
            {
                var trimmedInp = inp.Trim();

                if (trimmedInp == "")
                    continue;

                result += int.Parse(trimmedInp);
            }

            return result;
        }
    }
}
