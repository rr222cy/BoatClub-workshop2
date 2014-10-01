﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;

namespace BoatClub.view
{
    class UserView
    {
        // Fields

        // Properties

        // Methods

        private static void ContinueOnKeyPressed()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nTryck på en tangent för att fortsätta!\n");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }

        public void AddUser(User userModel)
        {
            string name;
            int socialSecurity;
            int memberID;

            Console.Clear();
            Console.WriteLine("Lägg till medlem.\n");
            Console.Write("Ange namn: ");
            name = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("\nAnge personnummer: ");
                    socialSecurity = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt personnummer!");
                    //
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("\nAnge önskat medlemsnummer (siffror endast): ");
                    memberID = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt medlemsnummer!");
                    //
                }
            }

            try
            {
                userModel.AddUser(name, socialSecurity, memberID);
                Console.WriteLine("\nTack! Medlemmen har nu lagts till i registret!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nOj! Något gick snett, försök igen.");
            }
            
            ContinueOnKeyPressed();
        }

        public void UpdateUser()
        {

        }

        public void RemoveUser(User userModel)
        {
            userModel.RemoveUser();
            ContinueOnKeyPressed();
        }

        public void ShowUser()
        {

        }

        public void ShowUsersSimple()
        {

        }

        public void ShowUsersFull()
        {

        }

        // Constructor
        public UserView()
        {
            // TOM!
        }
    }
}
