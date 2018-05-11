using System;
using System.IO;
using Dynamo.CommonLib.Classes.Utils;
using Psicle.XMLClasses;

namespace Decryption
{
    static class DecryptPSI
    {
        private static void Main()
        {

            Console.WriteLine("\nPlease enter the building block file name : ");
            var command = Console.ReadLine();

            switch (command)
            {
                case "*.psi": Console.WriteLine("*.psi is Recognised "); break;
                case "*.xml": Console.WriteLine("*.xml is Recognised "); break;
                default:
                     
                    var state = FileCheck(command);
                    if (state[1] == 1)
                    {
                        InvalidInput();
                    }
                    else
                    {
                        if (state[0] == 1)
                        {
                            if (command != null)
                            {
                                var input = command.Split(' ');
                                Encrypt(input[0]);
                            }
                        }
                        else
                        {
                            Decrypt(command);
                        }
                    }
                    
                   
                    break;

            }

            
           
         
           Console.Read();

        }

        private static void ConversionSuccessful(string Outformat)=>Console.WriteLine("\nConversion Successful you will find the required " + Outformat + " file in the current Directory");
        private static void InvalidInput() => Console.WriteLine("\nEither the file referenced does not exist or no file name was provided.");
        private static void Decrypt(string File)
        {
            // Importing Building Block
            var bb = XMLUtils.LoadXML<PsicleBuildingBlock>(File);
            // Printing of Building Block 
            XMLUtils.SaveXML(File + ".XML", bb);
            ConversionSuccessful("XML");
            
        }

        private static void Encrypt(string File)
        {
            // Importing Building Block
            var bb = XMLUtils.LoadXML<PsicleBuildingBlock>(File);
            // Printing of Building Block 
            XMLUtils.SaveXML(File + ".PSI", bb);

          ConversionSuccessful("PSI");

        }

        private static int[] FileCheck(string Input)
        {   
            // Encrypt command makes state[0] = 1 . Decrypt makes state [0] = 0
            var state = new int[2];
            var inputarr = Input.Split(' ');
            var results = Array.FindAll(inputarr, S => S.Equals("-E"));


            //foreach (var item in inputarr)
            //{
            //    Console.WriteLine(item);
            //}

            if (results.Length == 0)
            {
                state[0] = 0;
            }

            else
            {
                state[0] = 1;
            }

            if (state[0] != 1) return state;
            if (File.Exists(results[0] + ".psi"))
            {
                state[1] = 0;
            }
            else
            {
                state[1] = 1;
            }


            return state;

        }


    }
}
