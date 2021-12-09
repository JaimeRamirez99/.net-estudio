using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace RampUp
{
    class Program
    {
        static void Main(string[] args)
        {
            ifValidation validation = new ifValidation();
            Exceptions exceptionValidation = new Exceptions();
            regexValidation regexValidationMain = new regexValidation();

            cicles allCicles = new cicles();

            int iterations = 10000;

            Stopwatch time = new();

            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            cpuCounter.NextValue();
            ramCounter.NextValue();

            time.Restart();
            allCicles.ifCicle(iterations);
            time.Stop();
            PrintTime(cpuCounter.NextValue(), ramCounter.NextValue(), time.ElapsedMilliseconds, nameof(validation.ifValidationMethod));

            time.Restart();
            allCicles.exceptionCicle(iterations);
            time.Stop();
            PrintTime(cpuCounter.NextValue(), ramCounter.NextValue(), time.ElapsedMilliseconds, nameof(exceptionValidation.ExceptionValidationMethod));

            time.Restart();
            allCicles.regexValidation(iterations);
            time.Stop();
            PrintTime(cpuCounter.NextValue(), ramCounter.NextValue(), time.ElapsedMilliseconds, nameof(regexValidationMain.validationRegex));
            
            
           

            void PrintTime(float cpuValue, float ramValue, float elapsedTime, string methodName)
            {
                Console.WriteLine($"{methodName}:");
                Console.WriteLine($"Time: {elapsedTime} ms");
                Console.WriteLine($"CPU Value: {cpuValue}, Ram value: {ramValue} \n");
            }
       
            // List <string> errorListVoid = validation.ifValidationMethod("5eon152");    
            // foreach (var item in errorListVoid)
            // {
            //     System.Console.WriteLine(item);
            // }

            // List <string> errorListException = exceptionValidation.ExceptionValidationMethod("leon");  
            // foreach (var item in errorListException)
            // {
            //     System.Console.WriteLine(item);
            // }

            // List <string> errorListRx = regexValidationMain.validationRegex("leon15");
            // foreach (var item in errorListRx)
            // {
            //     System.Console.WriteLine(item);
            // }
        }
        
    }
    
    class cicles 
        {
           
            ifValidation validation = new ifValidation();
            Exceptions exceptionValidation = new Exceptions();
            regexValidation regexValidationMain = new regexValidation();
                       
            public void ifCicle (int cicleLength)
            {
                for (int i = 0; i < cicleLength; i++)
                {                        
                    this.validation.ifValidationMethod("Asdsdsdsd");
                    this.validation.ifValidationMethod("Asd");
                    this.validation.ifValidationMethod("Aasddsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsddfadasdsdssdsdsdsdsdsdsdsdsdsddssd");
                    this.validation.ifValidationMethod("asdsdsdsd");
                }              
            }
            public void exceptionCicle (int cicleLength)
            {
                for (int i = 0; i < cicleLength; i++)
                {                        
                    this.exceptionValidation.ExceptionValidationMethod("Asdsdsdsd");
                    this.exceptionValidation.ExceptionValidationMethod("Asd");
                    this.exceptionValidation.ExceptionValidationMethod("Aasddsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsddfadasdsdssdsdsdsdsdsdsdsdsdsddssd");
                    this.exceptionValidation.ExceptionValidationMethod("asdsdsdsd");
                }              
            }
            public void regexValidation (int cicleLength)
            {
                for (int i = 0; i < cicleLength; i++)
                {                        
                    this.regexValidationMain.validationRegex("Asdsdsdsd");
                    this.regexValidationMain.validationRegex("Asd");
                    this.regexValidationMain.validationRegex("Aasddsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsddfadasdsdssdsdsdsdsdsdsdsdsdsddssd");
                    this.regexValidationMain.validationRegex("asdsdsdsd");
                }              
            }
    }

    public class ifValidation
    {
    
        public List <string> ifValidationMethod(string inbound)
        {           
            List<string> errorListVoid = new List<string>();

            string ListErrorVoid = "";          

 
                if (!char.IsUpper(inbound[0])) ListErrorVoid = ListErrorVoid + " \n The first letter must be uppercase";                                

                if(inbound.Length < 5 && inbound.Length <= 32) ListErrorVoid =  ListErrorVoid + "\n It must have a minimum of 5 characters, a maximum of 32";

                if(!char.IsLetter(inbound[0])) ListErrorVoid = ListErrorVoid + "\n the first character must be a letter";

                if (ListErrorVoid != "") errorListVoid.Add(ListErrorVoid);

                ListErrorVoid = "";              
           

            return errorListVoid;

        }
    }

    public class Exceptions 
    {
        public List <string> ExceptionValidationMethod(string inbound)
        {          

            List<string> List = new List<string>();
                
            try
            {               
                    if (inbound.Length < 5 && inbound.Length >= 32)
                    {
                        throw new Exception("It must have a minimum of 5 characters, a maximum of 32");                                    
                    }
                    if (!char.IsLetter(inbound[0]))
                    {                        
                        throw new Exception("the first character must be a letter");                
                    }
                    if (inbound[0] < 65 || inbound[0] >= 90)
                    {                                              
                        throw new Exception("The first letter must be uppercase");                      
                    }     
                                   

                throw new Exception();       

            }  
            catch (Exception e)
            {            
                List.Add(e.Message);   
                return List;                
            }                            
        }
    }

    class regexValidation
    {
        public List <string> validationRegex(string inbound)

            {

                string rx = "^[A-Z][a-zA-Z0-9]{5,32}$";
               
                Regex regex = new Regex(rx);
         
                List<string> error = new List<string>(); 
               

                int cicle = 4;              
                
                for (int i = 0; i < cicle; i++)
                {
                        if (regex.IsMatch(inbound))
                    {
                        return error;                  
                    }else
                    {
                        error.Add("The string must have a minimum of 5 characters, a maximum of 32 and the first letter must be uppercase");
                    }                         
                }      

                return error;                                               
            }
    }
}