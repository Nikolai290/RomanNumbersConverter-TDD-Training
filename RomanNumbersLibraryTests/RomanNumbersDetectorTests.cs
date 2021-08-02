using FluentAssertions;
using RomanNumbersLibrary;
using RomanNumbersLibrary.Implementations;
using System.Collections.Generic;
using Xunit;

namespace RomanNumbersLibraryTests {
    public class RomanNumbersDetectorTests {

        public static IEnumerable<object[]> IsRomanNumberTests_Data = new List<object[]>() {
            new object[] {"I", true},
            new object[] {"II", true},
            new object[] {"III", true},
            new object[] {"IV", true},
            new object[] {"V", true},
            new object[] {"VI", true},
            new object[] {"VII", true},
            new object[] {"VIII", true},
            new object[] {"IX", true},
            new object[] {"X", true},
            new object[] {"XXXIII", true},
            new object[] {"XLIV", true},
            new object[] {"LXXIX", true},
            new object[] {"XCIX", true},
            new object[] {"CXII", true},
            new object[] {"CCLVI", true},
            new object[] {"DXII", true},
            new object[] {"CMXCIX", true},
            new object[] {"DCCII", true},
            new object[] {"CDIX", true},
            new object[] {"MI", true},
            new object[] {"DV", true},
            new object[] {"CCCIV", true},

            //new object[] {"DIXIV", false},
            new object[] {"CDIIIIX", false},
            new object[] {"CDDDX", false},
            new object[] {"VX", false},
            new object[] {"VIIIIX", false},
            new object[] {"VVVV", false},
            new object[] {"XXXX", false},
            new object[] {"LLL", false},
            new object[] {"CCCC", false},
            new object[] {"CCD", false},
            new object[] {"CCM", false},
            new object[] {"de5rt", false},
            new object[] {"ADSD", false},
            new object[] {"VDSER#", false},
            new object[] {"HGKI&(*", false},
            new object[] {"   ", false},
            new object[] {"  ", false},
            new object[] {"awer3 ", false},
            new object[] {"fa3ra 3r", false},
            new object[] {"a raw3 ra", false},
            new object[] {" arfdw3r ra", false},
        };

        [Theory]
        [MemberData(nameof(IsRomanNumberTests_Data))]
        public void IsRomanNumber_Test(string value, bool expected) {
            IRomanNumberDetector detector = new Interpreter();
            // Act
            var actual = detector.IsRomanNumber(value);
            // Assert
            actual.Should().Be(expected);
        }
    }
}
