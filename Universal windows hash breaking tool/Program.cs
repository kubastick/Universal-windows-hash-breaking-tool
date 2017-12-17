using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Universal_windows_hash_breaking_tool
{
    class Program
    {
        //If 0, hash break failed
        static int breaked = 0;

        static void Main(string[] args)
        {
            //View welcome strings
            Welcome();
            //Show hashing algo selection
            SelectAlgo();
            return;
        }

        static void Welcome()
        {
            //Welcome strings
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("================================================");
            Console.WriteLine("======Universal Windows Hash Breaking Tool======");
            Console.WriteLine("=========By Jakub Tomana Copyright 2017=========");
            Console.WriteLine("================================================");
            Console.WriteLine("==================Donations:====================");
            Console.WriteLine("=====BTC:3FMiVhp7V9VxSbj4wcwfdZ9jSPGKfJQdek=====");
            Console.WriteLine("=====LTC:LKGAvJagwQFWW63xeJ2aSztzHDgfnW2TTt=====");
            Console.WriteLine("=ETH:0x2ceab97090f749c704aeaba58eeca22529d12caa=");
            Console.WriteLine("================================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void SelectAlgo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Select hashing algorithm:");
            Console.WriteLine("[1] MD5");
            Console.WriteLine("[2] SHA1");
            Console.WriteLine("[3] SHA256");
            Console.WriteLine("[4] SHA384");
            Console.WriteLine("[5] SHA512");
            Console.ForegroundColor = ConsoleColor.White;
            //Wait for choice
            ConsoleKey button;
            button = Console.ReadKey().Key;
            if (button == ConsoleKey.D1)
            {
                Algo_MD5();
                return;
            }
            if (button == ConsoleKey.D2)
            {
                Algo_SHA1();
                return;
            }
            if (button == ConsoleKey.D3)
            {
                Algo_SHA256();
                return;
            }
            if (button == ConsoleKey.D4)
            {
                Algo_SHA384();
                return;
            }
            if (button == ConsoleKey.D5)
            {
                Algo_SHA512();
                return;
            }
            //No choice selected, show selectalgo again
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo algo selected");
            Console.ForegroundColor = ConsoleColor.White;
            SelectAlgo();
            return;
        }

        //Algos
        static void Algo_MD5()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMD5 hashing algorithm");
            Console.WriteLine("Select dictionary file (f.e.: passwords.txt or C://passwords.txt)");
            Console.WriteLine("(You can download one here: https://github.com/danielmiessler/SecLists/tree/master/Passwords)");
            Console.ForegroundColor = ConsoleColor.White;
            string filepath = Console.ReadLine();
            if(!File.Exists(filepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File do not exists, try again");
                Algo_MD5();
                return;
            }
            //File found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File found!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter hash here:");
            string hash = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Load dictionary into RAM? Y/N");
            ConsoleKey button;
            Console.ForegroundColor = ConsoleColor.White;
            button = Console.ReadKey().Key;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd after breaking at least one hash? Y/N");
            ConsoleKey gotoend;
            Console.ForegroundColor = ConsoleColor.White;
            gotoend = Console.ReadKey().Key;
            if (button == ConsoleKey.Y)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nLoading dictionary into RAM, this may take some time...");
                string[] dictionary = File.ReadAllLines(filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dictionary loaded!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    foreach (var key in dictionary)
                    {
                        if (hash != MD5Hash(key))
                        {
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + key);
                            breaked = 1;
                            using (StreamWriter file = new StreamWriter("result.txt", true))
                            {
                                file.WriteLine(key);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (button == ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    string line;
                    StreamReader file = new StreamReader(filepath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (hash != MD5Hash(line))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + line);
                            breaked = 1;
                            using (StreamWriter log = new StreamWriter("result.txt", true))
                            {
                                log.WriteLine(line);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Call the ending function
            End();
        }

        static void Algo_SHA1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMD5 hashing algorithm");
            Console.WriteLine("Select dictionary file (f.e.: passwords.txt or C://passwords.txt)");
            Console.WriteLine("(You can download one here: https://github.com/danielmiessler/SecLists/tree/master/Passwords)");
            Console.ForegroundColor = ConsoleColor.White;
            string filepath = Console.ReadLine();
            if (!File.Exists(filepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File do not exists, try again");
                Algo_SHA1();
                return;
            }
            //File found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File found!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter hash here:");
            string hash = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Load dictionary into RAM? Y/N");
            ConsoleKey button;
            Console.ForegroundColor = ConsoleColor.White;
            button = Console.ReadKey().Key;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd after breaking at least one hash? Y/N");
            ConsoleKey gotoend;
            Console.ForegroundColor = ConsoleColor.White;
            gotoend = Console.ReadKey().Key;
            if (button == ConsoleKey.Y)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nLoading dictionary into RAM, this may take some time...");
                string[] dictionary = File.ReadAllLines(filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dictionary loaded!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    foreach (var key in dictionary)
                    {
                        if (hash != SHA1Hash(key))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + key);
                            breaked = 1;
                            using (StreamWriter file = new StreamWriter("result.txt", true))
                            {
                                file.WriteLine(key);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (button == ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    string line;
                    StreamReader file = new StreamReader(filepath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (hash != SHA1Hash(line))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + line);
                            breaked = 1;
                            using (StreamWriter log = new StreamWriter("result.txt", true))
                            {
                                log.WriteLine(line);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Call the ending function
            End();
        }

        static void Algo_SHA256()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSHA256 hashing algorithm");
            Console.WriteLine("Select dictionary file (f.e.: passwords.txt or C://passwords.txt)");
            Console.WriteLine("(You can download one here: https://github.com/danielmiessler/SecLists/tree/master/Passwords)");
            Console.ForegroundColor = ConsoleColor.White;
            string filepath = Console.ReadLine();
            if (!File.Exists(filepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File do not exists, try again");
                Algo_MD5();
                return;
            }
            //File found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File found!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter hash here:");
            string hash = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Load dictionary into RAM? Y/N");
            ConsoleKey button;
            Console.ForegroundColor = ConsoleColor.White;
            button = Console.ReadKey().Key;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd after breaking at least one hash? Y/N");
            ConsoleKey gotoend;
            Console.ForegroundColor = ConsoleColor.White;
            gotoend = Console.ReadKey().Key;

            if (button == ConsoleKey.Y)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nLoading dictionary into RAM, this may take some time...");
                string[] dictionary = File.ReadAllLines(filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dictionary loaded!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    foreach (var key in dictionary)
                    {
                        if (hash != SHA256Hash(key))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + key);
                            breaked = 1;
                            using (StreamWriter file = new StreamWriter("result.txt", true))
                            {
                                file.WriteLine(key);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (button == ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    string line;
                    StreamReader file = new StreamReader(filepath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (hash != SHA256Hash(line))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + line);
                            breaked = 1;
                            using (StreamWriter log = new StreamWriter("result.txt", true))
                            {
                                log.WriteLine(line);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Call the ending function
            End();
        }

        static void Algo_SHA384()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSHA384 hashing algorithm");
            Console.WriteLine("Select dictionary file (f.e.: passwords.txt or C://passwords.txt)");
            Console.WriteLine("(You can download one here: https://github.com/danielmiessler/SecLists/tree/master/Passwords)");
            Console.ForegroundColor = ConsoleColor.White;
            string filepath = Console.ReadLine();
            if (!File.Exists(filepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File do not exists, try again");
                Algo_MD5();
                return;
            }
            //File found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File found!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter hash here:");
            string hash = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Load dictionary into RAM? Y/N");
            ConsoleKey button;
            Console.ForegroundColor = ConsoleColor.White;
            button = Console.ReadKey().Key;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd after breaking at least one hash? Y/N");
            ConsoleKey gotoend;
            Console.ForegroundColor = ConsoleColor.White;
            gotoend = Console.ReadKey().Key;

            if (button == ConsoleKey.Y)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nLoading dictionary into RAM, this may take some time...");
                string[] dictionary = File.ReadAllLines(filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dictionary loaded!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    foreach (var key in dictionary)
                    {
                        if (hash != SHA384Hash(key))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + key);
                            breaked = 1;
                            using (StreamWriter file = new StreamWriter("result.txt", true))
                            {
                                file.WriteLine(key);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (button == ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    string line;
                    StreamReader file = new StreamReader(filepath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (hash != SHA384Hash(line))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + line);
                            breaked = 1;
                            using (StreamWriter log = new StreamWriter("result.txt", true))
                            {
                                log.WriteLine(line);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Call the ending function
            End();
        }

        static void Algo_SHA512()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSHA256 hashing algorithm");
            Console.WriteLine("Select dictionary file (f.e.: passwords.txt or C://passwords.txt)");
            Console.WriteLine("(You can download one here: https://github.com/danielmiessler/SecLists/tree/master/Passwords)");
            Console.ForegroundColor = ConsoleColor.White;
            string filepath = Console.ReadLine();
            if (!File.Exists(filepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("File do not exists, try again");
                Algo_MD5();
                return;
            }
            //File found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File found!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter hash here:");
            string hash = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Load dictionary into RAM? Y/N");
            ConsoleKey button;
            Console.ForegroundColor = ConsoleColor.White;
            button = Console.ReadKey().Key;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd after breaking at least one hash? Y/N");
            ConsoleKey gotoend;
            Console.ForegroundColor = ConsoleColor.White;
            gotoend = Console.ReadKey().Key;

            if (button == ConsoleKey.Y)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nLoading dictionary into RAM, this may take some time...");
                string[] dictionary = File.ReadAllLines(filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dictionary loaded!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    foreach (var key in dictionary)
                    {
                        if (hash != SHA512Hash(key))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + key);
                            breaked = 1;
                            using (StreamWriter file = new StreamWriter("result.txt", true))
                            {
                                file.WriteLine(key);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (button == ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hash breaker started");
                try
                {
                    string line;
                    StreamReader file = new StreamReader(filepath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (hash != SHA512Hash(line))
                        {

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[Succes] Hash breaked! Value is:" + line);
                            breaked = 1;
                            using (StreamWriter log = new StreamWriter("result.txt", true))
                            {
                                log.WriteLine(line);
                            }
                            if (gotoend == ConsoleKey.Y)
                            {
                                End();
                                return;
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Call the ending function
            End();
        }

        //Ending summary
        static void End()
        {
            if(breaked == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hash break failed, try another dictionary");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thank you for using my hash breaking tool, consider making small donation :)");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to exit, result was saved in result.txt file");
            Console.ReadKey();
        }

        //Hashing algorithms
        static string MD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("x2"));

            }

            return sb.ToString();
        }

        static string SHA256Hash(string input)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static string SHA384Hash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA384.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 96, because 384 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(96);
                foreach (var b in hashedInputBytes)
                    //Make all letters lower-case
                    hashedInputStringBuilder.Append(b.ToString("x2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public static string SHA512Hash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public static string SHA1Hash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA1.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 96, because 160 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(40);
                foreach (var b in hashedInputBytes)
                    //Make all letters lower-case
                    hashedInputStringBuilder.Append(b.ToString("x2"));
                return hashedInputStringBuilder.ToString();
            }
        }

    }
}

