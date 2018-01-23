using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BobbiDonuts.Helpers;

namespace BobbiDonuts
{
    public class LogicHolder
    {
        /// <summary>
        /// Method that holds the logic to solve the donut problem.
        /// </summary>
        /// <param name="filePath">Path of file that contains test data.</param>
        public static void SolveDonutProblem(string filePath)
        {
            try
            {
                //Check if file exists. If not, show error message.
                if (!File.Exists(filePath))
                {
                    DisplayError(ErrorMessage.FileNotFound);
                    return;
                }                  
                else
                {
                    var fileExtension = Path.GetExtension(filePath);

                    //Check if file has .txt as extension. If not, show error message.
                    if (!fileExtension.Equals(".txt"))
                    {
                        DisplayError(ErrorMessage.IncorrectExtension);
                        return;
                    }
                        

                    var lines = File.ReadLines(filePath);

                    //Checking to see if file has content. If not, show error message.
                    if (!lines.Any())
                    {
                        DisplayError(ErrorMessage.NoContent);
                        return;
                    }
                    else if (lines.Count() < 2) //Checking to see if file has minimum 1 test case. If not, show error message.
                    {
                        DisplayError(ErrorMessage.InsufficientData);
                        return;
                    }
                        


                    var testCasesStr = lines.First();
                    var testCases = 0;
                    int.TryParse(testCasesStr, out testCases);

                    /*If number of test cases mentioned in line 1 is more than actual test cases in the file, then it will throw an error.
                     *If number of test cases mentioned in line 1 is less than actual test cases, then code won't process the extra test cases. This is done 
                     *This is done as line 1 is to be used to determine total number of test cases, thereby ignoring the rest of the test cases.
                    */
                    if (testCases > (lines.Count() - 1))
                    {
                        DisplayError(ErrorMessage.TestCasesMismatch);
                        return;
                    }
                        

                    var donutProblems = new List<DonutProblem>();
                    for (int i = 1; i <= testCases; i++)
                    {
                        var problem = new DonutProblem();
                        var line = lines.ElementAt(i);

                        var problemArr = line.Split(' ');
                        if (problemArr.Length != 3)
                        {
                            problem.IncorrectFormat = true;
                            problem.CanCarry = false;
                        }
                        else
                        {
                            var numberOfFriends = 0;
                            var donutWeight = 0;
                            var capacity = 0;

                            int.TryParse(problemArr[0], out numberOfFriends);
                            int.TryParse(problemArr[1], out donutWeight);
                            int.TryParse(problemArr[2], out capacity);

                            problem.NumberOfFriend = numberOfFriends;
                            problem.DonutWeight = donutWeight;
                            problem.BobbiCapacity = capacity;
                            problem.IncorrectFormat = false;
                            problem.CanCarry = (numberOfFriends * donutWeight) <= capacity;
                        }

                        donutProblems.Add(problem);
                    }

                    donutProblems.ForEach(problem => Console.WriteLine("{0}", problem.CanCarry ? "Yes" : "No"));

                }

                Console.Write("Press any key to exit...");
                Console.Read();
            }
            catch (Exception ex)
            {
                DisplayError(ErrorMessage.Exception, ex);
                return;
            }
        }

        /// <summary>
        /// Method that displays error messages in the console.
        /// </summary>
        /// <param name="errorMessage">An enumerator to identify which error message is to be displayed.</param>
        /// <param name="exception">An optional parameter of type Exception. When ErrorMessage parameter is of value 'Exception', then 'Message' property of Exception object is used to display the error message.</param>
        public static void DisplayError(ErrorMessage errorMessage, Exception exception = null)
        {
            var messageToDisplay = "";
            switch (errorMessage)
            {
                case ErrorMessage.FileNotFound:
                    messageToDisplay = "Given data file not found. Please check command line arguements.";
                    break;
                case ErrorMessage.IncorrectExtension:
                    messageToDisplay = "Given file has incorrect extension. Expecting a txt file. Please check command line arguements.";
                    break;
                case ErrorMessage.InsufficientData:
                    messageToDisplay = "Insufficient data in the data file.";
                    break;
                case ErrorMessage.NoContent:
                    messageToDisplay = "Given data file has no content.";
                    break;
                case ErrorMessage.TestCasesMismatch:
                    messageToDisplay = "Number of test cases is incorrect.";
                    break;
                case ErrorMessage.Exception:
                    messageToDisplay = exception.Message;
                    break;
                case ErrorMessage.CommandLineArguement:
                    messageToDisplay = "Please provide Command Line arguement in order to proceed.";
                    break;
                default:
                    messageToDisplay = "An error occurred while processing the request.";
                    break;
            }

            Console.WriteLine("{0}", messageToDisplay);
            Console.WriteLine("Exiting program after 3 seconds.");

            Thread.Sleep(3000);

            return;
        }
    }
}
