using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULSLogging
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var i = 0;
                var a = 2 / i;
            }
            catch (Exception ex)
            {
                LoggingService.LoggingTrace("Error", ex.Message);
            }
        }
    }
}
