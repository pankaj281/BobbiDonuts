using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbiDonuts.Helpers
{
    public class DonutProblem
    {
        /// <summary>
        /// Class Constructor
        /// </summary>
        public DonutProblem()
        {
            NumberOfFriend = 0;
            DonutWeight = 0;
            BobbiCapacity = 0;
            IncorrectFormat = false;
            CanCarry = false;
        }

        /// <summary>
        /// Total number of friends for test case.
        /// </summary>
        public int NumberOfFriend { get; set; }

        /// <summary>
        /// Weight of each donut.
        /// </summary>
        public int DonutWeight { get; set; }

        /// <summary>
        /// Total weight Bobbi can carry.
        /// </summary>
        public int BobbiCapacity { get; set; }

        public bool IncorrectFormat { get; set; }
        
        /// <summary>
        /// Result of test case. True if Bobbi can carry donuts, else false.
        /// </summary>
        public bool CanCarry { get; set; }
    }
}
