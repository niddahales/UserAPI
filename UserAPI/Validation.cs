using System.Text.RegularExpressions;


namespace UserAPI
{
    public class Validation
    {
        // This function controls Age is true or not.
        public bool IsValidAge(int age, string birthday)
        {
            DateTime bday = DateTime.ParseExact(birthday, "dd/MM/yyyy", null);
            DateTime today = DateTime.Today;
            int age2 = today.Year - bday.Year;
            if (age == age2)
                return true;
            else return false;
        }
        // This function controls Birthday is true or not.
        public bool IsValidBirthday(string birthday)
        {
            string slash = "/";
            if (TypeCheckInt(birthday.Substring(0, 2)) && TypeCheckInt(birthday.Substring(3, 2)) && TypeCheckInt(birthday.Substring(6, 4)) && birthday[2].Equals(slash[0]) && birthday[5].Equals(slash[0]))
                return true;
            else return false;
        }
        public bool TypeCheckInt(string input)
        {
            return int.TryParse(input, out int num);
        }
        // This function checks email valid or not.
        public bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }
    }
}
