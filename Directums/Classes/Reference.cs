namespace Directums.Client.DirectumsService
{
    public partial class User
    {
        public string GetLoginWithName()
        {
            string result = Login;

            if (!string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Patronymic))
            {
                result += string.Format(" ({0} {1} {2})", Surname, Name, Patronymic);
            }

            return result;
        }
    }
}