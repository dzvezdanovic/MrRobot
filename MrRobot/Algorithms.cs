using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MrRobot
{
    public class Algorithms
    {
        /// <summary>
        /// 
        /// </summary>

        #region MrRobot

        public Dictionary<int, string> facePositionDict = new Dictionary<int, string>()
            {
                {0, "E" },
                {1, "N"},
                {2, "W" },
                {3, "S"},
            };

        public void RobotSteps()
        {
            Console.WriteLine("Unesi početni položaj:");
            var inputCoordinates = Console.ReadLine();

            string[] z = inputCoordinates.Split(" ");

            int x = Int32.Parse(z[0]);
            int y = Int32.Parse(z[1]);

            Console.WriteLine("Unesi putanju:");
            var path = Console.ReadLine();

            int currentNumberPosition = facePositionDict.FirstOrDefault(kv => kv.Value == z[2]).Key;

            for (int i = 0; i < path.Length; i++)
            {                
                if (path[i].ToString().ToUpper() == "R")
                {
                    currentNumberPosition = (currentNumberPosition + 3) % 4;
                }
                else if (path[i].ToString().ToUpper() == "L")
                {
                    currentNumberPosition = (currentNumberPosition + 1) % 4;
                }
                else if (path[i].ToString().ToUpper() == "F")
                {
                    if (currentNumberPosition == 0)
                    {
                        x += 1;
                    }
                    else if (currentNumberPosition == 1)
                    {
                        y += 1;
                    }
                    else if (currentNumberPosition == 2)
                    {
                        x -= 1;
                    }
                    else
                    {
                        y -= 1;
                    }
                }
                else
                {
                    Console.WriteLine("Unesite ispravnu putanju!");
                }
            }
            string sSveta = facePositionDict[currentNumberPosition];

            Console.WriteLine(x + " " + y + " " + sSveta);
        }

        #endregion


        #region Jebemliga

        #endregion

    }
}
