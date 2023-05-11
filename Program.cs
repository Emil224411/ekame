namespace eksame
{
    public static class write // didnt feel like writing console.something one million times this class just writes at a x and y with a color
    {
        private static int defaultX = 0;
        private static int defaultY = Console.BufferHeight;

        public static void At(int x, int y, string s, ConsoleColor c, bool isInput)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = c;
            Console.Write(s);
            if (!isInput) Console.SetCursorPosition(defaultX, defaultY);
            Console.ForegroundColor = ConsoleColor.Black;

        }
    }
    public class User
    {
        //all varibles for a user
        public int phoneNumber;
        public string firstName;
        public string lastName;
        public string email;
        public string address;
        public string city;
        public int zipCode;
        private static List<User> AllUsers = new(); // list of all the users
        public static List<User> allUsers { get { return AllUsers; } }
        public User(int phonenum, string fname, string lname, string address, int zipCode, string city, string email)
        {
            this.phoneNumber = phonenum;
            this.firstName = fname;
            this.lastName = lname;
            this.address = address;
            this.zipCode = zipCode;
            this.city = city;
            this.email = email;
            adduser(this);
        }
        private static void adduser(User user)
        {
            AllUsers.Add(user);
        }
        public static bool exists(int phoneNumber) // checks if a user exists using a phonenumber
        {
            for (int i = 0; i < AllUsers.Count(); i++)
            {
                if (AllUsers[i].phoneNumber == phoneNumber)
                {
                    return true;
                }
            }
            return false;
        }
        static public User findUser(string find) // funtion for finding a user using a phonenumber or name
        {
            int numberToFind = 0;
            if (!Int32.TryParse(find, out numberToFind))
            {
                for (int i = 0; i < AllUsers.Count(); i++)
                {
                    if (AllUsers[i].firstName == find) return AllUsers[i];
                }
            }
            else
            {
                for (int i = 0; i < AllUsers.Count(); i++)
                {
                    if (AllUsers[i].phoneNumber == numberToFind) return AllUsers[i];
                }
            }
            return null;
        }

    }
    public class Program
    {
        //array of the text in the main menu
        public static string[] text = {"Telefon nr : +45 ",
                                "Navn       :     ",
                                "Efter Navn :     ",
                                "Adresse    :     ",
                                "Postnr     :     ",
                                "By         :     ",
                                "Email      :     ",
                                "[O] opret  [F] Find  [V] Vis alle  [Q] Afslut : "};
        public static void Main()
        {
            //filler data
            User bruger1 = new(12345678, "navn1", "efterNavn1", "addrasse 12", 2650, "hvidovre", "mail1@mail.com");
            User bruger2 = new(22345678, "navn2", "efterNavn2", "addrasse 13", 2650, "hvidovre", "mail2@mail.com");
            User bruger3 = new(32345678, "navn3", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");
            User bruger4 = new(42345678, "navn4", "efterNavn1", "addrasse 12", 2650, "hvidovre", "mail1@mail.com");
            User bruger5 = new(52345679, "navn5", "efterNavn2", "addrasse 13", 2650, "hvidovre", "mail2@mail.com");
            User bruger6 = new(62345688, "navn6", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");
            User bruger7 = new(72345678, "navn7", "efterNavn1", "addrasse 12", 2650, "hvidovre", "mail1@mail.com");
            User bruger8 = new(82345679, "navn8", "efterNavn2", "addrasse 13", 2650, "hvidovre", "mail2@mail.com");
            User bruger9 = new(92345688, "navn9", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");
            User bruger10 = new(13345678, "navn10", "efterNavn1", "addrasse 12", 2650, "hvidovre", "mail1@mail.com");
            User bruger11 = new(14345679, "navn11", "efterNavn2", "addrasse 13", 2650, "hvidovre", "mail2@mail.com");
            User bruger12 = new(15345688, "navn12", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");
            User bruger13 = new(16345678, "navn13", "efterNavn1", "addrasse 12", 2650, "hvidovre", "mail1@mail.com");
            User bruger14 = new(17345679, "navn14", "efterNavn2", "addrasse 13", 2650, "hvidovre", "mail2@mail.com");
            User bruger15 = new(18345688, "navn15", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");
            User bruger16 = new(19345688, "navn16", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");
            User bruger17 = new(10345688, "navn17", "efterNavn3", "addrasse 14", 2650, "hvidovre", "mail3@mail.com");

            bool running = true;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            //main loop
            while (running)
            {
                drawMainMenu();
                Console.CursorVisible = false;

                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'o':
                        Console.Clear();
                        CreateUser();
                        break;
                    case 'f':
                        FindUser();
                        break;
                    case 'v':
                        ShowAllUsers();
                        break;
                    case 'q':
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void ShowAllUsers()
        {

            int startUser = 0; // first user that will be printed
            char userInput = '0';
            while (userInput != 'q')
            {
                Console.Clear();
                Console.SetCursorPosition(0, 3);
                for (int i = 0; i < 15; i++) // loops 15 times each time it prints a users info
                {
                    if (i + startUser < User.allUsers.Count) //check if i + the user that we start at is under the amount of users
                    {
                        Console.WriteLine($"    {User.allUsers[i + startUser].phoneNumber}, {User.allUsers[i + startUser].firstName}, {User.allUsers[i + startUser].lastName}, {User.allUsers[i + startUser].email}, {User.allUsers[i + startUser].address}, {User.allUsers[+startUser].zipCode}, {User.allUsers[+startUser].city}");
                    }
                    else // if i + startUser is bigger than the amount of users it just makes a new line
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("\n\tk for gå op, j for gå ned, q for at gå tilbage: ");
                userInput = Console.ReadKey(true).KeyChar;

                if (userInput == 'j' && startUser < User.allUsers.Count - 1)
                {
                    startUser += 1;
                }
                else if (userInput == 'k' && startUser > 0)
                {
                    startUser -= 1;
                }
            }
            Console.Clear();
        }

        public static void FindUser() // funtion that asks for a phone number and outputs a users data if a user has said number 
        {
            string userName;
            ConsoleKey userChoise;
            User foundUser;
            bool uservalid = true;
            do
            {
                Console.Clear();
                if (!uservalid)
                {
                    write.At(10, 5, "brugeren findes ikke", ConsoleColor.Red, false);
                }

                write.At(2, 4, "indtast Telefon nr : +45 ", ConsoleColor.Black, true);
                userName = Console.ReadLine();

                if (!Int32.TryParse(userName, out int r)) uservalid = false;
                else
                {
                    foundUser = User.findUser(userName);
                    if (foundUser == null) uservalid = false;
                    else
                    {
                        uservalid = true;
                        drawMainMenu();
                        Console.SetCursorPosition(10 + text[0].Length, 5);
                        Console.Write(foundUser.phoneNumber);
                        Console.SetCursorPosition(10 + text[0].Length, 6);
                        Console.Write(foundUser.firstName);
                        Console.SetCursorPosition(10 + text[0].Length, 7);
                        Console.Write(foundUser.lastName);
                        Console.SetCursorPosition(10 + text[0].Length, 8);
                        Console.Write(foundUser.address);
                        Console.SetCursorPosition(10 + text[0].Length, 9);
                        Console.Write(foundUser.zipCode);
                        Console.SetCursorPosition(10 + text[0].Length, 10);
                        Console.Write(foundUser.city);
                        Console.SetCursorPosition(10 + text[0].Length, 11);
                        Console.Write(foundUser.email);
                    }

                }
            } while (!uservalid);

        }
        public static void CreateUser() //funtion lets a user creates a new user
        {
            bool numNotVaild = true;
            bool inputValid = false;
            string[] userInput = new string[7];
            Console.CursorVisible = true;
            drawMainMenu();

            while (numNotVaild) // gets phone number
            {
                write.At(10, 5, text[0], ConsoleColor.Black, true);
                userInput[0] = Console.ReadLine();
                // if userinput[0] is and number and has a length of 8 numNotVaild will be false  
                numNotVaild = !Int32.TryParse(userInput[0], out int r) || userInput[0].Length != 8;
                if (numNotVaild)
                {
                    // deletes users input and writes a error if numNotVaild
                    deleteLine(5, 10 + text[0].Length);
                    write.At(70, 5, "not valid!", ConsoleColor.Red, false);
                }
                else if (User.exists(Convert.ToInt32(userInput[0])))
                {
                    // deletes users input and writes a error if a user with the same phone number exists
                    deleteLine(5, 10 + text[0].Length);
                    write.At(67, 5, "User existst", ConsoleColor.Red, false);
                    numNotVaild = true;
                }
                else deleteLine(5, 10 + text[0].Length + userInput[0].Length); // deletes error if input is valid
            }
            do // gets first name
            {
                write.At(10, 6, text[1], ConsoleColor.Black, true);
                userInput[1] = Console.ReadLine().ToLower();
                inputValid = userInput[1].All(char.IsLetter); // input will be valid if all characters in userinput[1] are letters
                if (!inputValid) // prints error if input is not valid
                {
                    deleteLine(6, 10 + text[1].Length);
                    write.At(70, 11, "not valid!", ConsoleColor.Red, false);
                }
                else deleteLine(6, 10 + text[1].Length + userInput[1].Length); // deletes error if input is valid
            } while (!inputValid);
            do // gets last name just the same as getting the first name
            {
                write.At(10, 7, text[2], ConsoleColor.Black, true);
                userInput[2] = Console.ReadLine().ToLower();
                inputValid = userInput[2].All(char.IsLetter);
                if (!inputValid)
                {
                    deleteLine(7, 10 + text[2].Length);
                    write.At(70, 11, "not valid!", ConsoleColor.Red, false);
                }
                else deleteLine(7, 10 + text[2].Length + userInput[2].Length);
            } while (!inputValid);
            do // gets the address i dont really know what classifieds as a valid address
            {
                write.At(10, 8, text[3], ConsoleColor.Black, true);
                userInput[3] = Console.ReadLine().ToLower();
                inputValid = userInput[3] != null;
                if (!inputValid)
                {
                    // if input is not valid it prints a error
                    deleteLine(8, 10 + text[3].Length);
                    write.At(70, 11, "not valid!", ConsoleColor.Red, false);
                }
                else deleteLine(8, 10 + text[3].Length + userInput[3].Length); // deletes error is input valid
            } while (!inputValid);
            do // gets zip code
            {
                write.At(10, 9, text[4], ConsoleColor.Black, true);
                userInput[4] = Console.ReadLine();
                inputValid = Int32.TryParse(userInput[4], out int r); // input will be valid if userInput[4] can be convertet to a int
                if (!inputValid)
                {
                    //prints error if input not valid
                    deleteLine(9, 10 + text[4].Length);
                    write.At(70, 9, "not valid!", ConsoleColor.Red, false);
                }
                else deleteLine(9, 10 + text[4].Length + userInput[4].Length); // deletes error if input is valid
            } while (!inputValid);
            do // gets city
            {
                write.At(10, 10, text[5], ConsoleColor.Black, true);
                userInput[5] = Console.ReadLine().ToLower();
                inputValid = userInput[5].All(char.IsLetter); // input will be valid if all characters in userInput[5] are letters
                if (!inputValid)
                {
                    // prints error if input is not valid
                    deleteLine(10, 10 + text[5].Length);
                    write.At(70, 10, "not valid!", ConsoleColor.Red, false);
                }
                else deleteLine(10, 10 + text[5].Length + userInput[5].Length); // deletes error if input is valid
            } while (!inputValid);
            do // gets email
            {
                write.At(10, 11, text[6], ConsoleColor.Black, true);
                userInput[6] = Console.ReadLine();
                inputValid = userInput[6].Contains('@') && userInput[6].Contains('.'); // input will be valid if userInput[6] contains a @ and .
                if (!inputValid)
                {
                    //print error if input is not valid
                    deleteLine(11, 10 + text[6].Length);
                    write.At(70, 11, "not valid!", ConsoleColor.Red, false);
                }
                else deleteLine(11, 10 + text[6].Length + userInput[6].Length); // deletes error if input is valid
            } while (!inputValid);

            // creates a new user using the all the input we just got
            User newUser = new(Convert.ToInt32(userInput[0]),
                                                userInput[1],
                                                userInput[2],
                                                userInput[3],
                                                Convert.ToInt32(userInput[4]),
                                                userInput[5],
                                                userInput[6]);
            write.At(10, 14, "burger oprettet.", ConsoleColor.Green, false);
        }

        public static void deleteLine(int lineY, int startX) // deletes a line of text where int lineY is the line where you want to delete and startX is where it should start deleteing from
        {
            for (int i = startX; i < Console.BufferWidth; i++)
            {
                write.At(i, lineY, " ", ConsoleColor.Black, false);
            }
        }
        public static void drawMainMenu() // draws the main menu
        {

            for (int i = 5; i < 12; i++)
            {
                write.At(10, i, text[i - 5], ConsoleColor.Black, true);
            }
            write.At(10, Console.BufferHeight - 6, text[7], ConsoleColor.Black, true);

        }

    }
}