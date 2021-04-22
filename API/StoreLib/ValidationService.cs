using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StoreDB.Models;

namespace StoreLib
{
    public class ValidationService
    {
        //TODO use this to throw exceptions and have the console output in the catch instead of writeline in this class
        // Exception InvalidInput = new Exception();
        // Exception InvalidUsername = new Exception();

        public static Boolean ValidName(string name) {
            if(Regex.IsMatch(name, "[\\d]", RegexOptions.IgnoreCase)) {
                Console.WriteLine("This is not a valid name.");
                Console.WriteLine("Your name should not have numbers.");
                return false;
            } else {
                return true;
            }
        }

        public static Boolean ValidEmail(string email) {
            if(Regex.IsMatch(email, @"^[a-z0-9.]+@[a-z0-9]+[\.][a-z]", RegexOptions.IgnoreCase)) {
                return true;
            } else {
                Console.WriteLine("This is not a valid email address.");
                return false;
            }
        }

        public static Boolean ValidUsername(string username, List<User> users) {
            foreach(User user in users) {
                if(user.username == username) {
                    Console.WriteLine("This username is already taken.");
                    return false;
                }                
            }
            return true;  
        }

        public static Boolean InvalidQuantity(int locQuantity, int userQuantity) {
            if(userQuantity > locQuantity) {
                Console.WriteLine("Your current shopping location does not have that many of this item.");
                Console.WriteLine($"Please select no more than {locQuantity}");
                return false;
            }

            return true;
        }

    }
}




