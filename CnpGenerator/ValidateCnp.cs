namespace CnpGenerator
{
    public class ValidateCnp
    {
        public bool Validate(string cnp)
        {
            DateGenerator dateGenerator = new DateGenerator();
            if (cnp.Length != 13 || !dateGenerator.IsDigitsOnly(cnp) || cnp.Substring(0, 1) =="0" || cnp.Substring(0, 1) == "9")
                return false;
            
            int gender = int.Parse(cnp.Substring(0, 1));
            int year = int.Parse(cnp.Substring(1, 2));
            int month = int.Parse(cnp.Substring(3, 2));
            int day = int.Parse(cnp.Substring(5, 2));
            string district = cnp.Substring(7, 2);
            int sec = int.Parse(cnp.Substring(9, 3));
            int checkNr = int.Parse(cnp.Substring(12, 1));

            int fullYear = dateGenerator.GetYear(gender, year);
            if (fullYear > DateTime.Now.Year)
                return false;

            if (month > 12 || month == 0)
                return false;

            if (day > DateTime.DaysInMonth(fullYear, month) || day == 0)
                return false;

            if (!dateGenerator.ContainsKey(district))
                return false;

            if(sec == 0)
                return false;

            if(checkNr != dateGenerator.controllNumber(cnp.Substring(0, 12)))
                 return false;

            return true;
        }   
    }
}
