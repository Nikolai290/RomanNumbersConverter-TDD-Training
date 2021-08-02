using RomanNumbersLibrary;
using RomanNumbersLibrary.Implementations;
using System;

namespace RomanNumbers {
    class Program {
        private static IRomanArabicNumbersInterpreter interpreter;

        public static void Main(string[] args) {
            interpreter = new Interpreter();
            Console.WriteLine("Plese input any arabic or roman number from 0 to 999 " +
                              "and the program interpreters it.");
            Console.WriteLine("Or send 'q' for quit.");
            while (true) {
                var input = Console.ReadLine().ToLower();

                switch (input) {
                    case "q": return;
                    default:
                        Console.WriteLine(TryConvert(input)); 
                        break;
                }
            }
        }

        private static string TryConvert(string value) {
            if (Int32.TryParse(value, out int number)) {
                return interpreter.ToRomanNumber(number);
            } else if (interpreter.IsRomanNumber(value)) {
                return interpreter.ToArabicNumber(value).ToString();
            }
            return "Could not recognize the input as Arabic or Roman number.";
        }
    }
}
