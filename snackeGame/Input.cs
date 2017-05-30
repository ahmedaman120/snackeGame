using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snackeGame
{
    class Input
    {
        private static Hashtable keytable = new Hashtable();
        public static bool keyPress(Keys key) {
            if (keytable[key] == null)
            {
                return false;
            }

                return (bool)keytable[key];

        }
        public static void ChangeState(Keys k, bool state) {
            keytable[k] = state;

        }
    }
}
