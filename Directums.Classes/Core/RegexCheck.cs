using System.Text.RegularExpressions;

namespace Directums.Classes.Core
{
    public static class RegexCheck
    {
        private static Regex regexLoginPass = new Regex(@"[^0-9a-zA-Z_@]");

        private static Regex digits = new Regex(@"[0-9]");
        private static Regex lowLetters = new Regex(@"[a-z]");
        private static Regex upLetters = new Regex(@"[A-Z]");

        private static Regex loginRegex = new Regex(@"^[a-z0-9_\.\-]{3,32}$", RegexOptions.IgnoreCase);
        private static Regex emailRegex = new Regex(@"^[a-z0-9_\.\-]{1,20}@[a-z0-9\.\-]{1,20}\.[a-z]{2,4}$", RegexOptions.IgnoreCase);

        private static Regex fileNameRegex = new Regex("^[^\\|/\":*?<>]{1,256}$");

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

        public static bool CheckLogin(string login)
        {
            return loginRegex.Match(login).Success;
        }

        public static bool CheckEmail(string email)
        {
            return emailRegex.Match(email).Success;
        }

        public static bool CheckFileName(string name)
        {
            return fileNameRegex.Match(name).Success;
        }
    }
}