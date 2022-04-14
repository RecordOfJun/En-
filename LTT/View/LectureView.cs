using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class LectureView
    {
        public void ShowValue(object value)
        {
            if (value == null)
                Console.Write("");
            else
            {
                Console.Write(value);
            }
        }
    }
}
