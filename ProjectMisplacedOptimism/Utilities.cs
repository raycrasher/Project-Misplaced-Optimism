using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectMisplacedOptimism
{
    public static class Utilities
    {
        public static Vector3 AsNormalized(this Vector3 vec)
        {
            vec.Normalize();
            return vec;
        }

        public static void SetFocus(this Game game)
        {
            var myForm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(game.Window.Handle);
            myForm.Activate();
        }
    }
}
