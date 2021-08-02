using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml;

namespace RomanNumbersLibrary.Implementations {
    public class Interpreter : IRomanArabicNumbersInterpreter {
        private readonly string one = "I";
        private readonly string five = "V";
        private readonly string ten = "X";
        private readonly string fifty = "L";
        private readonly string hundred = "C";
        private readonly string fiveHun = "D";
        private readonly string thousend = "M";

        public string ToRomanNumber(int number) {
            if (number < 0) throw new ArgumentOutOfRangeException("The number must be postitive!");
            var builder = new StringBuilder();
            var num = number % 10;
            var tens = number % 100 / 10;
            var hundreds = number % 1000 / 100;
            RomanBuilder(builder, hundreds, hundred, fiveHun, thousend);
            RomanBuilder(builder, tens, ten, fifty, hundred);
            RomanBuilder(builder, num, one, five, ten);

            return builder.ToString();
        }

        public int ToArabicNumber(string romanNumber) {
            if (!IsRomanNumber(romanNumber)) throw new ArgumentException("The string is not a roman number!");
            int result = 0;
            var numbers = new int[romanNumber.Length];
            for (int i = romanNumber.Length - 1; i >= 0; i--) {
                numbers[i] = Dismember(romanNumber[i]);
                if (i < romanNumber.Length - 1) {
                    if (numbers[i + 1] / numbers[i] == 10 || numbers[i + 1] / numbers[i] == 5) {
                        result -= numbers[i];
                    } else {
                        result += numbers[i];
                    }
                } else {
                    result += numbers[i];
                }
            }

            return result;
        }

        public bool IsRomanNumber(string romanNumber) {
            romanNumber.ToUpper().Trim();
            if (string.IsNullOrEmpty(romanNumber)) return false;
            if (romanNumber.Contains("IIII")) return false;
            if (romanNumber.Contains("VV")) return false;
            if (romanNumber.Contains("XXXX")) return false;
            if (romanNumber.Contains("LL")) return false;
            if (romanNumber.Contains("CCCC")) return false;
            if (romanNumber.Contains("DD")) return false;
            if (romanNumber.Contains("MMMM")) return false;
            if (romanNumber.Contains(" ")) return false;

            StringBuilder builder = new StringBuilder();
            var numbers = new int[romanNumber.Length];

            for (int i = romanNumber.Length - 1; i >= 0; i--) {
                try {
                    numbers[i] = Dismember(romanNumber[i]);
                    if (i < romanNumber.Length - 1) {
                        if (numbers[i + 1] / numbers[i] > 10) {
                            return false;
                        }

                        if (numbers[i + 1] / numbers[i] == 2) {
                            return false;
                        }

                        if (i < romanNumber.Length - 2 && numbers[i + 1] == numbers[i] && numbers[i + 2] > numbers[i]) {
                            return false;
                        }
                    }
                } catch {
                    return false;
                }
            }


            var line = builder.ToString();

            line
                .Replace(one, "")
                .Replace(five, "")
                .Replace(ten, "")
                .Replace(fifty, "")
                .Replace(hundred, "")
                .Replace(fiveHun, "")
                .Replace(thousend, "");
            if (line.Length > 0) return false;

            return true;
        }

        private static void RomanBuilder(StringBuilder builder, int num, string one, string five, string ten) {
            if (num <= 3) {
                for (int i = 0; i < num; i++) {
                    builder.Append(one);
                }
            } else if (num == 4) {
                builder.Append(one).Append(five);
            } else if (num == 5) {
                builder.Append(five);
            } else if (num > 5 && num <= 8) {
                builder.Append(five);
                for (int i = 0; i < num - 5; i++) {
                    builder.Append(one);
                }
            } else if (num == 9) {
                builder.Append(one).Append(ten);
            }
        }

        private int Dismember(char symbol) {
            switch (symbol.ToString().ToUpper()) {
                case "I": return 1;
                case "V": return 5;
                case "X": return 10;
                case "L": return 50;
                case "C": return 100;
                case "D": return 500;
                case "M": return 1000;
                default: throw new ArgumentException("Unrecognizable symbol");
            }
        }
    }
}
