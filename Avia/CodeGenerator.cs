using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia
{
    static class CodeGenerator
    {
        static Random random = new Random();
        public static int generateFiveSymbCode()
        {
            return random.Next(10000, 99999);
        }
    }
}
