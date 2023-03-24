using System.Text;

namespace CnpGenerator
{
    public class GenerateRandomCnp
    {
        public string Generate()
        {
            DateGenerator dtGenerator = new DateGenerator();
            StringBuilder sb = new StringBuilder();

            int randomInt = dtGenerator.GenerateNumber(1, 9);
            sb.Append(randomInt.ToString());

            DateTime randomDateTime = dtGenerator.GenerateDateTimeFromSex(randomInt);
            sb.Append((randomDateTime.Year.ToString()).Substring(2, 2));
            sb.Append(randomDateTime.Month.ToString("D2"));
            sb.Append(randomDateTime.Day.ToString("D2"));

            string code = dtGenerator.GenerateDistrictCode();
            sb.Append(code);

            int randomBirthNumber = dtGenerator.GenerateNumber(1, 999);
            sb.Append(randomBirthNumber.ToString("D3"));

            int controllNumber = dtGenerator.controllNumber(sb.ToString());

            sb.Append(controllNumber.ToString());
            return sb.ToString();   
        }  
    }
}
