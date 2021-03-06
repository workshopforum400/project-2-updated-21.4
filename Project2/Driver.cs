﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace WorkshopForum
{
    public class Driver
    {
        private static String input = "";
        private static StringReader sb = new StringReader(input);
        private static Boolean exit = false;

        public static void Main(String[] args)
        {
            startUp();
        }

        private static void startUp()
        {
            // login as a member includes all types of users: admins, moderators, super manager and plain users 
            String choice = "";
            
            while (!exit)
            {
                Console.WriteLine("Choose option : ");
                Console.WriteLine("1. login as registered member");
                Console.WriteLine("2. login as guest");
                Console.WriteLine("3. register as a new member");
                Console.WriteLine("4. exit");
                choice = Console.ReadLine();
                if (choice.Equals("1"))
                {
                    Console.WriteLine("Enter a user name");
                    String userStr = Console.ReadLine();
                    ForumMember user;
                    if ((user = UserHandler.getUser(userStr)) == null)
                    {
                        Console.WriteLine("Error : Wrong user name");
                        continue;
                    }
                    String pass = "";
                    Console.WriteLine("Please enter password");
                    pass = Console.ReadLine();
                    if (pass != user.getPassword())
                    {
                        Console.WriteLine("Error : Wrong password for user " + userStr);
                        continue;
                    }
                    //currentUser = user;
                    viewMenu(user);
                }
                else if (choice.Equals("2"))
                {
                    Guest guest = UserHandler.enterAsGuest();
                    viewMenu(guest);
                }
                else if (choice.Equals("3"))
                {
                    Console.WriteLine("Enter user name");
                    String userName = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    String pass = Console.ReadLine();
                    Console.WriteLine("Enter email");
                    String e_mail = Console.ReadLine(); 
              
                    Console.WriteLine("Confirm your e-mail");
                    String confMail = Console.ReadLine();
                    if (!e_mail.Equals(confMail))
                    {
                        Console.WriteLine("E-Mails dont match");
                        continue;
                    }
                    Boolean regSuccess = UserHandler.registerForumMember(userName, pass, e_mail);
                    if (regSuccess)
                        Console.WriteLine("User " + userName + " has been added to the system");
                }
                else if (choice.Equals("4"))
                {
                    exit = true;
                    Console.WriteLine("Exiting...bye");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        public  static void initSys()
        {
            addStatesToStateList();
        }

        private static void addStatesToStateList()
        {
            Storage.stateStorage.Add(new DataTypes.State("Gold",40,45,50,true,true));
            Storage.stateStorage.Add(new DataTypes.State("Silver", 20, 20, 20, true, false));
            Storage.stateStorage.Add(new DataTypes.State("Regular", 0, 0, 0, false, false));
        }

        public static void viewMenu(User user)
        {
            //Console.WriteLine("not implemented yet");
            // System.Threading.Thread.Sleep(4000);
            //Console.WriteLine();
            user.viewMenues();
        }

    }
}
