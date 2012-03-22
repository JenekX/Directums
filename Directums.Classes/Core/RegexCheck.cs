using System.Text.RegularExpressions;

namespace Directums.Classes.Core
{
    public static class RegexCheck
    {
        private static Regex regexLoginPass = new Regex(@"[^0-9a-zA-Z_@]");

        private static Regex digits = new Regex(@"[0-9]");
        private static Regex lowLetters = new Regex(@"[a-z]");
        private static Regex upLetters = new Regex(@"[A-Z]");

        public static bool CheckDigits(string checkingString)
        {
            return digits.Match(checkingString).Success;
        }

        public static bool CheckLoginPass(string checkingString)
        {
            return regexLoginPass.Match(checkingString).Success;
        }

        public static bool CheckLowLetter(string checkingString)
        {
            return lowLetters.Match(checkingString).Success;
        }

        public static bool CheckUpLetters(string checkingString)
        {
            return upLetters.Match(checkingString).Success;
        }
    }
}