using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    internal static class Check
    {
        public static void IsNotNull(object value, string paramName) {
            if (value == null) {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void IsNotNullOrEmpty(string value, string paramName) {
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentException(paramName);
            }
        }
    }
}
