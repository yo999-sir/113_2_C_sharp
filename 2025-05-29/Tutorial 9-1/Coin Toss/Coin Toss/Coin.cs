using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    internal class Coin
    {
        private string sideUp;// The side of the coin that is facing up.
        Random rand = new Random();// Random number generator.

        public Coin()
        {
            sideUp = "正面"; // Default side is Heads.  
        }

        public void Toss()
        {
            // Generate a random number that is either 0 or 1.
            int num = rand.Next(2);
            // If num is 0, set sideUp to Heads; otherwise, set it to Tails.
            if (num == 0)
                sideUp = "正面";
            else
                sideUp = "反面";
        }

        internal object GetSideUp()
        {
          return sideUp; // Return the side that is facing up.
        }
    }
}
