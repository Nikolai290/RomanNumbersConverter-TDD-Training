using FluentAssertions;
using RomanNumbersLibrary;
using RomanNumbersLibrary.Implementations;
using System.Collections.Generic;
using Xunit;

namespace RomanNumbersLibraryTests {
    public class ToArabicNumberTests {
        public static IEnumerable<object[]> ToArabicNumbersTests_Data = new List<object[]>() {
            new object[] {1, "I"},
            new object[] {2, "II"},
            new object[] {3, "III"},
            new object[] {4, "IV"},
            new object[] {5, "V"},
            new object[] {6, "VI"},
            new object[] {7, "VII"},
            new object[] {8, "VIII"},
            new object[] {9, "IX"},
            new object[] {10, "X"},
            new object[] {11, "XI"},
            new object[] {12, "XII"},
            new object[] {13, "XIII"},
            new object[] {14, "XIV"},
            new object[] {15, "XV"},
            new object[] {16, "XVI"},
            new object[] {17, "XVII"},
            new object[] {18, "XVIII"},
            new object[] {19, "XIX"},
            new object[] {20, "XX"},
            new object[] {22, "XXII"},
            new object[] {30, "XXX"},
            new object[] {34, "XXXIV"},
            new object[] {40, "XL"},
            new object[] {46, "XLVI"},
            new object[] {50, "L"},
            new object[] {55, "LV"},
            new object[] {60, "LX"},
            new object[] {69, "LXIX"},
            new object[] {70, "LXX"},
            new object[] {73, "LXXIII"},
            new object[] {80, "LXXX"},
            new object[] {88, "LXXXVIII"},
            new object[] {90, "XC"},
            new object[] {91, "XCI"},
            new object[] {100, "C"},
            new object[] {276, "CCLXXVI"},
            new object[] {481, "CDLXXXI"},
            new object[] {649, "DCXLIX"},
            new object[] {734, "DCCXXXIV"},
            new object[] {976, "CMLXXVI"},
            new object[] {512, "DXII"},
        };

        [Theory]
        [MemberData(nameof(ToArabicNumbersTests_Data))]
        public void ToArabicNumber_Test(int expected, string romanNumber) {
            IToArabicNumber interpreter = new Interpreter();
            // Act
            var actual = interpreter.ToArabicNumber(romanNumber);
            // Assert
            actual.Should().Be(expected);
        }
    }
}
