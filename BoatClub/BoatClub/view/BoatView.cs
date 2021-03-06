﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;

namespace BoatClub.view
{
    class BoatView
    {
        Boat boatModel = new Boat();

        private enum MenuChoice
        {
            ExitMenu = 0,
            AddBoat = 1,
            HandleBoat = 2,
            RemoveBoat = 3,
        }

        public void RemoveBoat(Boat boatModel)
        {
            int boatId;

            Console.Clear();
            Console.WriteLine("Ta bort båt\n");            

            while (true)
            {
                try
                {
                    Console.Write("\nAnge båtens id för att ta bort en båt: ");
                    boatId = Int32.Parse(Console.ReadLine());
                    boatModel.RemoveBoat(boatId);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett giligt båtid.");
                }
                Console.WriteLine("\nBåten har tagits bort.");
                ContinueOnKeyPressed();
                return;
            }
        }

        public void HandleBoat(Boat boatModel)
        {
            int boatId;
            int memberId;
            string boatType;
            int length;

            Console.Clear();
            Console.WriteLine("Hantera båt.\n");
            Console.WriteLine("\nSkriv in de nya uppgifterna för en båt genom att fylla i ett korrekt id");
            Console.WriteLine("Sen fyller du i de nya uppgifterna som gäller för båten.");

            while (true)
            {
                try
                {
                    Console.Write("\nAnge båtens id: ");
                    boatId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        Console.Write("\n\nAnge medlemmens id. Ange 0 eller blankt om det inte ska ändras: ");
                        memberId = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        memberId = 0;
                    }
                    Console.Write("\n\nAnge båtens typ. Lämna blankt om inget ska ändras: ");
                    boatType = Console.ReadLine();
                    try
                    {
                        Console.Write("\n\nAnge båtens längd i hela meter. Lämna blankt om inget ska ändras: ");
                        length = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        length = 0;
                    }
                    boatModel.UpdateBoat(memberId, boatId, boatType, length);
                    Console.WriteLine("\nBåten är uppdaterad!");
                }
                catch (Exception)
                {
                    Console.WriteLine("\nNågot gick fel. Kontrollera att du angett rätt båtid.");
                }
                
                ContinueOnKeyPressed();
                return;
            }
        }

        public void AddBoat(Boat boatModel)
        {
            int memberId;
            string boatType;
            int length;

            Console.Clear();
            Console.WriteLine("Lägg till ny båt.");

            while (true)
            {
                try
                {
                    Console.Write("\nAnge medlems id för ägaren till båten: ");
                    memberId = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett korrekt medlems id!");
                }
            }

            Console.Write("Ange båtens typ: ");
            boatType = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("\nAnge båtens längd i hela meter: ");
                    length = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange båtens längd i hela meter:");
                }
            }

            try
            {
                boatModel.AddBoat(memberId, boatType, length);
                Console.WriteLine("\nTack! Båten har nu lagts till i registret.");
            }
            catch (Exception)
            {
                Console.WriteLine("\nOj! Något gick snett, försök igen.");
            }
            ContinueOnKeyPressed();
        }

        public void BoatMenu()
        {
            while (true)
            {
                int menuChoice = ViewBoatMenu();

                switch (menuChoice)
                {
                    case (int)MenuChoice.ExitMenu:
                        return;
                    case (int)MenuChoice.AddBoat:
                        AddBoat(boatModel);
                        return;
                    case (int)MenuChoice.HandleBoat:
                        HandleBoat(boatModel);
                        return;
                    case (int)MenuChoice.RemoveBoat:
                        RemoveBoat(boatModel);
                        return;
                    default:
                        break;
                }
            }
        }
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

        public int ViewBoatMenu()
        {
            int menuIndex;

            do
            {
                Console.Clear();
                Console.WriteLine("Hantera båtar");
                Console.WriteLine("\n -------------------------------------------\n");
                Console.WriteLine(" 0: Återgå till huvudmeny");
                Console.WriteLine(" 1: Registrera ny båt");
                Console.WriteLine(" 2: Redigera båt");
                Console.WriteLine(" 3: Ta bort båt\n");
                Console.Write(" Ange menyval [0-3]: ");

                if (int.TryParse(Console.ReadLine(), out menuIndex) && menuIndex >= 0 && menuIndex <= 3)
                {
                    return menuIndex;
                }
                else
                {
                    Console.Write("\nVänligen ange ett nummer mellan 0 och 3.\n", ConsoleColor.Red);
                    ContinueOnKeyPressed();
                }
            } while (true);
        }
    }
}