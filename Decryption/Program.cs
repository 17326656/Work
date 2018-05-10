using System;
using System.IO;
using Dynamo.CommonLib.Classes.Utils;
using Psicle.XMLClasses;

namespace Decryption
{
    class DecryptPSI
    {
        private static void Main()
        {
            Console.WriteLine("\nPlease enter the building block file name : ");
            var filename = Console.ReadLine();
            
            if (File.Exists(filename + ".psi"))
                { 
                // Importing Building Block
                var bb = XMLUtils.LoadXML<PsicleBuildingBlock>(filename);
                // Printing of Building Block 
                XMLUtils.SaveXML(filename + ".XML", bb);
                Console.WriteLine("\nConversion Successful you will find the required XML file in the current Directory");
                }
             else
                {
                    if (filename == "*psi") 
                    {
                        foreach (var fil in COLLECTION)
                        {
                            
                        }
                        
                    }

                Console.WriteLine("\nEither the file referenced does not exist or no file name was provided.");
           
                }

         
           Console.Read();

        }
    }
}
