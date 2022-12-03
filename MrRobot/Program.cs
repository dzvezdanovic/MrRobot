using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace MrRobot
{

    class CurrentOrientation
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            var facePosition = new List<CurrentOrientation>() {
                new CurrentOrientation(){ Id = 0, Value="E"},
                new CurrentOrientation(){ Id = 1, Value="N"},
                new CurrentOrientation(){ Id = 2, Value="W"},
                new CurrentOrientation(){ Id = 3, Value="S"}
            };

           
            String inputCoordinates = "1 1 N";
         
            string[] z = inputCoordinates.Split(" ");

            int x = Int32.Parse(z[0]);
            int y = Int32.Parse(z[1]);

            

            String path = "a";
          
            int currentNumberPosition = SSOrientation(z, facePosition);
           

            for (int i = 0; i < path.Length; i++)
            {
                if (path[i].ToString().ToUpper() == "R")
                {
                     currentNumberPosition = (currentNumberPosition + 3) % 4;

                     Console.WriteLine(currentNumberPosition);
                     //Console.WriteLine("Trenutni polozaj je: " + currentNumberPosition + "trenutni korak je " + i);
                }
                else if (path[i].ToString().ToUpper() == "L")
                {
                    currentNumberPosition = (currentNumberPosition + 1) % 4;
                    Console.WriteLine(currentNumberPosition);
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
                    else if(currentNumberPosition == 2)
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
            string sSveta = SSOrienatationLetter(facePosition, currentNumberPosition);

            Console.WriteLine(x + " " + y + " " + sSveta);
            
        }

        public static int SSOrientation(string[] z, List<CurrentOrientation> facePosition)
        {
            var StranaSveta = from ss in facePosition
                              where ss.Value == "E" || ss.Value == "W" || ss.Value == "N" || ss.Value == "S"
                              select ss;

            int ssss;
            foreach (var currentOrientation in StranaSveta)
            {
                if (z[2].ToString() == currentOrientation.Value)

                {
                    ssss = currentOrientation.Id;
                    return ssss;
                }
            }
            return -1;
        }

        public static string SSOrienatationLetter(List<CurrentOrientation> facePositions, int currentNumberPosition)
        {
            var StranaSveta = from ss in facePositions
                              where ss.Id == 0 || ss.Id == 1 || ss.Id == 2 || ss.Id == 3
                              select ss;
            string sSveta;
            foreach (var currentOrientation in StranaSveta)
            {
                if (currentNumberPosition == currentOrientation.Id)
                {
                    sSveta = currentOrientation.Value;
                    return sSveta;
                }
            }

            return null;
        }
    }
}
