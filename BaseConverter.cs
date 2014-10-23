using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO: Take numbers in base other than ten.
//TODO: Be able to convert from decimal to > Base-10
//TODO:  Be able to convert from any base to any base.

namespace BaseConverter
{
    class Program
    {
        //FIELDS
        public static uint input;
        public static int bit;
        public static double exponent;
        public static uint quotient;
        public static uint remainder;
        public static char [] map = {'0', '1', '2', '3', '4', '5', 
                             '6', '7', '8', '9', 
                             'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                             'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                             'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                             'Y', 'Z',
                             'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                             'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                             'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                             'y', 'z'};

        //MAIN
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to: \"Base Converter\"!\n");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            string userSelection = "";
            bool incorrectInput = false;
            bool survived = false;

            do
            {
                Console.Clear();

                if (incorrectInput == true)
                {
                    Console.WriteLine("Unknown option: " + userSelection);
                    Console.WriteLine();
                }

                if (survived == true)
                {
                    Console.WriteLine("Congratulations on surviving... This time.");
                    Console.WriteLine();
                }

                //Recorrecting bool values
                incorrectInput = false;
                survived = false;

                ShowMainMenu();
                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        {
                            YoMomma();
                            incorrectInput = false;
                            survived = true;
                            break;
                        }
                    case "2":
                        {
                            Binary();
                            incorrectInput = false;
                            break;
                        }
                    case "3":
                        {
                            Three();
                            incorrectInput = false;
                            break;
                        }
                    case "4":
                        {
                            Four();
                            incorrectInput = false;
                            break;
                        }
                    case "5":
                        {
                            Five();
                            incorrectInput = false;
                            break;
                        }
                    case "6":
                        {
                            Six();
                            incorrectInput = false;
                            break;
                        }
                    case "7":
                        {
                            Seven();
                            incorrectInput = false;
                            break;
                        }
                    case "8":
                        {
                            Octa();
                            incorrectInput = false;
                            break;
                        }
                    case "9":
                        {
                            Nine();
                            incorrectInput = false;
                            break;
                        }
                    case "10":
                        {
                            incorrectInput = false;
                            ExitSequence();
                            break;
                        }
                    default:
                        {
                            incorrectInput = true;
                            break;
                        }
                }

            } while (true);
        }

        //Math Methods
        static void Binary()
        {
            Console.Clear();
            
            bool incorrectForm;
            
            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to binary: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0) 
		    {
			    string zero = "0";
                Console.Write("Binary encoding of 0 is: " + zero);
		    }
		    else 
		    {
			    //This saves me column space.
			    exponent = Convert.ToDouble(input);
			
			    //The next if/else finds how many bits the 
			    //encoded number will be. (ex. input=14 --> bit=4).
			    if ((Math.Log(exponent,2)-Math.Log(exponent,2)) == 0)
				    bit = Convert.ToInt32(Math.Floor(1+Math.Log(exponent,2)));
			    else
				    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 2)));	
		
		
			    //Preparing the landing place for the encoded number.
			    Console.Write("Binary encoding of " + input + " is: ");
			
			    //Working backwards to find the quotient,
			    //using it to find the remainders at each division. 
			    //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
			    {
				    quotient = Convert.ToUInt32(Math.Floor(input/ Math.Pow(2,j)));
				    remainder = Convert.ToUInt32(quotient % 2);
					
				    Console.Write(remainder);
			    }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
        }

        static void Three()
		{
			Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-3: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                string zero = "0";
                Console.Write("Base-3 encoding of 0 is: " + zero);
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the 
                //encoded number will be.
                if ((Math.Log(exponent, 3) - Math.Log(exponent, 3)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 3)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 3)));


                //Preparing the landing place for the encoded number.
                Console.Write("Base-3 encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(3, j)));
                    remainder = Convert.ToUInt32(quotient % 3);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
		}

        static void Four()
        {
            Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-4: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                string zero = "0";
                Console.Write("Base-4 encoding of 0 is: " + zero);
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the 
                //encoded number will be. (ex. input=14 --> bit=4).
                if ((Math.Log(exponent, 4) - Math.Log(exponent, 4)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 4)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 4)));


                //Preparing the landing place for the encoded number.
                Console.Write("Base-4 encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(4, j)));
                    remainder = Convert.ToUInt32(quotient % 4);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
        }

        static void Five()
		{
			Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-5: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                string zero = "0";
                Console.Write("Base-5 encoding of 0 is: " + zero);
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the 
                //encoded number will be.
                if ((Math.Log(exponent, 5) - Math.Log(exponent, 5)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 5)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 5)));


                //Preparing the landing place for the encoded number.
                Console.Write("Base-5 encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(5, j)));
                    remainder = Convert.ToUInt32(quotient % 5);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
		}

        static void Six()
		{
			Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-6: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                string zero = "0";
                Console.Write("Base-6 encoding of 0 is: " + zero);
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the 
                //encoded number will be.
                if ((Math.Log(exponent, 6) - Math.Log(exponent, 6)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 6)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 6)));


                //Preparing the landing place for the encoded number.
                Console.Write("Base-6 encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(6, j)));
                    remainder = Convert.ToUInt32(quotient % 6);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
		}

        static void Seven()
		{
			Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-7: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                string zero = "0";
                Console.Write("Base-7 encoding of 0 is: " + zero);
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the 
                //encoded number will be.
                if ((Math.Log(exponent, 7) - Math.Log(exponent, 7)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 7)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 7)));


                //Preparing the landing place for the encoded number
                Console.Write("Base-7 encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(7, j)));
                    remainder = Convert.ToUInt32(quotient % 7);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
		}

        static void Octa()
        {
            Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-8: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                string zero = "0";
                Console.Write("Octal encoding of 0 is: " + zero);
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the encoded number will be. 
                if ((Math.Log(exponent, 8) - Math.Log(exponent, 8)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 8)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 8)));


                //Preparing the landing place for the encoded number.
                Console.Write("Octal encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(8, j)));
                    remainder = Convert.ToUInt32(quotient % 8);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
        }

        static void Nine()
		{
			Console.Clear();

            bool incorrectForm;

            //Ensuring real and positive input within bounds. 
            do
            {
                Console.Write("Select a number to encode to base-9: ");
                string inputString = Console.ReadLine();

                if (UInt32.TryParse(inputString, out input) == false)
                {
                    Console.WriteLine("\nYou must enter a positive integer that is"
                         + " within the interval [0,4294967295]. \nShucks.\n");
                    incorrectForm = true;
                }
                else
                {
                    input = UInt32.Parse(inputString);
                    incorrectForm = false;
                }
            } while (incorrectForm);


            if (input == 0)
            {
                Console.Write("Base-9 encoding of 0 is: ");
            }
            else
            {
                //This saves me column space.
                exponent = Convert.ToDouble(input);

                //The next if/else finds how many bits the 
                //encoded number will be.
                if ((Math.Log(exponent, 9) - Math.Log(exponent, 9)) == 0)
                    bit = Convert.ToInt32(Math.Floor(1 + Math.Log(exponent, 6)));
                else
                    bit = Convert.ToInt32(Math.Floor(Math.Log(exponent, 9)));


                //Preparing the landing place for the encoded number.
                Console.Write("Base-9 encoding of " + input + " is: ");

                //Working backwards to find the quotient,
                //using it to find the remainders at each division. 
                //Then outputting the results, final quotient first. 
                for (int j = bit - 1; j >= 0; j--)
                {
                    quotient = Convert.ToUInt32(Math.Floor(input / Math.Pow(9, j)));
                    remainder = Convert.ToUInt32(quotient % 9);

                    Console.Write(remainder);
                }
            }

            Console.WriteLine("\n\nPress a key to continue, yo.");
            Console.ReadKey();
		}
            
        //static void Ten()

        //static void Eleven()


        
		//Program methods
        static void ShowMainMenu()
        {
            Console.WriteLine("Starting from decimal, choose a base to convert to:");
            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
                "\n1) Pick Me", "\n2) Base-2", "\n3) Base-3", "\n4) Base-4",
                "\n5) Base-5", "\n6) Base-6", "\n7) Base-7", "\n8) Base-8",
                "\n9) Base-9", "\n", "\n10) Exit\n\n");
            Console.Write("Selection: ");
        }

        static void YoMomma()
        {
            Console.Clear();

            Console.WriteLine("This program has effectively executed order #3452: TrojanID02 has been planted.");
            Console.Write("\nCode to corrupt following sequence: ");
            string order = Console.ReadLine();
            Console.WriteLine();

            switch(order)
            {
                case "stop":
                {    
                    ShowMainMenu();
                    break;
                }
                default:
                {
                    Random num = new Random();
            
                    for (int x = 0; x < 1000; x += 2 )
                        {
                            Console.Write(num.Next(0,10));
                            System.Threading.Thread.Sleep(5);
                        }

                    Console.WriteLine("\n");
                    System.Threading.Thread.Sleep(70);

                    char[] message = {'H','a','v','e',' ', 'a', ' ', 
                                     'g', 'o', 'o', 'd', ' ', 'l','i',
                                     'f','e','.'};

                    foreach (char a in message)
                    {
                        Console.Write(a);
                        System.Threading.Thread.Sleep(50);
                    }

                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                }
            }

            
        } //Presently known as "Pick Me"

        static void ExitSequence()
        {
            Console.Clear();
			Console.WriteLine("Are you sure you want to exit?\n\n");
			Console.Write("(Y|N): ");
            string opt = Console.ReadLine();
			bool optRight = true;
			
			do
			{
				switch (opt)
				{
					case "Y":
					case "y":
					{
						Environment.Exit(0);
						break;
					}
				
					case "N":
					case "n":
					{
						Console.Clear();
						ShowMainMenu();
						break;
					}
					default:
					{
						optRight = false;
						break;
					}
				}
			} while (!optRight);
            //N - ShowMainMenu()
        }
    }
}
