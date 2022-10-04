using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SUT22_ÖvningiGrupp
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] userList = new string[20, 5]; //Skapar en array med 20 användare, 5 spots

            welcome();
            //userList = CreateUser(userList);
            Console.WriteLine("Please Enter your User Name !");
            string username = Console.ReadLine();
            bool UserFound = false;

          bool res = Login(username);
            Console.WriteLine("Välkommen");


            if (res == true)
            {
                Console.WriteLine("Du är inloggad!");
                Navigation(userList);
            }


        }

        public static void welcome()
        {
            Random message = new Random();
            int Randommessage = message.Next(0, 5);
            string[] welcomemessage = { "Välkommen!", "Välkommen till kalaset", "Välkommen SUT22!", "Välkommen hit!", "Hej!" };
            string write = welcomemessage[Randommessage];
            Console.WriteLine(write);



            DateTime localDate = DateTime.Now;
            String time = "HH:mm ddd MMM yyyy";
            Console.WriteLine(localDate.ToString(time));



        }

        static void Navigation(string[,] userList)
        {


            bool loop = true;
            while (loop)
            {

                Console.WriteLine("Gör ditt val");
                Console.WriteLine(" - ID Check - 1)");
                Console.WriteLine(" - Check Email - 2)");
                Console.WriteLine(" - Create User  - 3)");
                Console.WriteLine(" - Print User info  - 4)");
                Console.WriteLine(" - Avsluta - 5)");



                try
                {
                    int userChoice = int.Parse(Console.ReadLine());



                    switch (userChoice)
                    {
                        case 1:
                            if (IDCheck(Console.ReadLine()))
                            {
                                Console.WriteLine("ID is Valid");
                            }
                            ;
                            Console.ReadLine();
                            break;
                        case 2:
                            if (EmailCheck(Console.ReadLine()))
                            {
                                Console.WriteLine("Email Is Valid");
                            }
                            break;
                        case 3:
                            CreateUser(userList);

                            break;
                            
                        case 4:
                            WriteUserInfo(userList);

                            break;
                        case 5:
                            Search(userList);

                            break;
                        case 6:
                            Console.WriteLine("val 4");
                            loop = false;
                            break;




                    }
                }
                catch
                {
                    Console.WriteLine("Error! Välj ett nummer mellan 1-4");
                    Console.ReadLine();
                }

            }



        }
        public static bool Login(string name)
        {
            List<string> allUsers = new List<string> { };
            allUsers.Add("Lars");
            allUsers.Add("Henry");
            allUsers.Add("Jennie");
            int x = 0;
            foreach (var item in allUsers)
            {
                if (item == name)
                {
                    x = 1;
                    break;
                }
                else
                {
                    x = 0;
                }
            }
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IDCheck(string ssn)
        {

            Regex rx = new Regex(@"^[0-9]{10,10}");

            return rx.IsMatch(ssn);

        }
        private static bool EmailCheck(string email)
        {
            Regex regex = new Regex(@"^([\S]+)@([\S]+)\.([\S]{2,3})$");



            return regex.IsMatch(email);
        }
        static void WriteUserInfo(string[,] users)
        {
            string[] type = new string[5];
            type[0] = "Namn: \t\t";
            type[1] = "Adress: \t";
            type[2] = "Personnummer: \t";
            type[3] = "Telefonnummer: \t";
            type[4] = "E-post: \t";
            for (int i = 0; i < users.GetLength(0); i++)
            {
                for (int j = 0; j < users.GetLength(1); j++)
                {
                    Console.WriteLine($"{type[j]} {users[i, j]}");
                }
                Console.WriteLine();
            }
        }
        public static string[,] CreateUser(string[,] UserList)
        {
            int counter = 0;
            int indexplace = 0;
            bool createUser = true;
            for (int i = 0; i < 21; i++)
            {
                if (UserList[i, 0] == null)
                {
                    indexplace = counter;
                    i = 21;
                }
                else
                {
                    if (i == 20)
                    {
                        Console.WriteLine("Listan är full, ta bort en användare för att" +
                            " lägga till en ny.");
                        createUser = false;
                    }
                    else
                        counter++;
                }
            }
            if (createUser)
            {
                Console.WriteLine("Skriv ditt namn:");
                UserList[indexplace, 0] = Console.ReadLine();
                Console.WriteLine("Skriv din adress:");
                UserList[indexplace, 1] = Console.ReadLine();
                Console.WriteLine("Skriv ditt personnummer (format yymmddxxxx:");
                bool personnummer = true;
                while (personnummer)
                {
                    string userInput = Console.ReadLine();
                    double userNum;
                    if (userInput.Length != 10 || !Double.TryParse(userInput, out userNum))
                    {
                        Console.WriteLine("Skriv enbart med siffror i format yymmddxxxx:");
                    }
                    else
                    {
                        UserList[indexplace, 2] = userInput;
                        personnummer = false;
                    }
                }



                Console.WriteLine("Skriv ditt telefonnummer (använd endast siffror):");
                bool phoneNum = true;
                while (phoneNum)
                {
                    string userInput = Console.ReadLine();
                    double userNum;
                    if (!Double.TryParse(userInput, out userNum))
                    {
                        Console.WriteLine("Skriv enbart med siffror:");
                    }
                    else
                    {
                        UserList[indexplace, 3] = userInput;
                        phoneNum = false;
                    }
                }
                Console.WriteLine("Skriv din email:");
                bool email = true;
                while (email)
                {
                    string userInput = Console.ReadLine();
                    if (!EmailCheck(userInput))
                    {
                        Console.WriteLine("Du har angivit en felaktig mailadress, försök igen!");
                    }
                    else
                    {
                        UserList[indexplace, 4] = userInput;
                        email = false;
                    }
                }
            }
            return UserList;
        }
        public static void Search(string[,] userInfo)

        {


            int index = 0;

            int counter = 0;

            Console.Write("Vad söker du efter?: ");

            string searchWord = Console.ReadLine().ToLower();

            foreach (string hit in userInfo)

            {

                if (index == 5)

                    break;

                else if (userInfo[index, 0].ToLower() == searchWord || userInfo[index, 1].ToLower() == searchWord)

                {

                    counter++;

                    //Console.WriteLine(searchWord);

                    Console.WriteLine(userInfo[index, 0] + ", " + userInfo[index, 1]);

                    Console.WriteLine();



                }


                index++;

            }

            if (counter > 0)

            {

                Console.WriteLine("{0} Träffar hittades", counter);

            }

            else

            {

                Console.WriteLine("Inga träffar hittades!");

            }



        }
    }
}
