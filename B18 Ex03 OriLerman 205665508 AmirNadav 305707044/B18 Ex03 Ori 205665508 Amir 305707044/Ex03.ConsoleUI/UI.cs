using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class UI
    {
        private enum eUserState { Quit, GoOn }
        public static void GarageLoop()
        {
            eUserState userState = eUserState.GoOn;

            while (userState == eUserState.GoOn)
            {
                try
                {
                    ///the actual garageLoop
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);   
                }
                catch(Ex03.GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception)
                {
                    Console.WriteLine("someThing Went Wrong mate -> but generally wrong");///needs better text
                }


            }






        }


    }
}
