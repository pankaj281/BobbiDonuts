using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using BobbiDonuts.Helpers;

namespace BobbiDonuts
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Holds the command line arguements. 
        /// The command line arguements can be added/modified by right clicking the project in solution explorer and then selecting Properties -> Debug tab.</param>
        /// <returns>Positive integer</returns>
        static int Main(string[] args)
        {
            if (args.Length <= 0)//if no command line arguement is given, then display error message.
                LogicHolder.DisplayError(ErrorMessage.CommandLineArguement);            
            else
                LogicHolder.SolveDonutProblem(args[0]);               
            
            return 1;
        }
    }
}
