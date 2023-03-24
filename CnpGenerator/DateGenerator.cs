namespace CnpGenerator
{
    public class DateGenerator
    {
        private Random gen = new Random();
        public DateTime GenerateDateTimeFromSex(int i)
        {
            DateGenerator gen = new DateGenerator();
            DateTime start = new DateTime(2005, 1, 1);
            DateTime end = new DateTime(1960, 1, 1);

            switch (i)
            {
                case 1:
                case 2:
                    start = new DateTime(1900, 1, 1);
                    end = new DateTime(1999, 12, 31);
                    break;
                case 3:
                case 4:
                    start = new DateTime(1800, 1, 1);
                    end = new DateTime(1899, 12, 31);
                    break;

                case 5:
                case 6:
                    start = new DateTime(2000, 1, 1);
                    end = new DateTime(2005, 12, 31);
                    break;
                case 7:
                case 8:
                case 9:
                    start = new DateTime(1960, 1, 1);
                    end = new DateTime(2005, 1, 1);
                    break;
            }

            DateTime date =  gen.GenerateDateTime(start, end);

            return date;
        }
        public DateTime GenerateDateTime(DateTime start, DateTime end)
        {
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
        public int GenerateNumber(int start, int end)
        {
            int nums = gen.Next(start, end);

            return nums;
        }
        public Dictionary<string, string> DistrictCode()
        {
            Dictionary<string, string> districtCode = new Dictionary<string, string>();
            districtCode.Add("01", "Alba");
            districtCode.Add("02", "Arad"); 
            districtCode.Add("03", "Arges"); 
            districtCode.Add("04", "Bacau"); 
            districtCode.Add("05", "Bihor"); 
            districtCode.Add("06", "Bistrita-Nasaud"); 
            districtCode.Add("07", "Botosani"); 
            districtCode.Add("08", "Brasov"); 
            districtCode.Add("09", "Braila"); 
            districtCode.Add("10", "Buzau"); 
            districtCode.Add("11", "Caras-Severin"); 
            districtCode.Add("12", "Cluj"); 
            districtCode.Add("13", "Constanta"); 
            districtCode.Add("14", "Covasna"); 
            districtCode.Add("15", "Dambovita"); 
            districtCode.Add("16", "Dolj"); 
            districtCode.Add("17", "Galati"); 
            districtCode.Add("18", "Gorj"); 
            districtCode.Add("19", "Harghita"); 
            districtCode.Add("20", "Hunedoara"); 
            districtCode.Add("21", "Ialomita"); 
            districtCode.Add("22", "Iasi"); 
            districtCode.Add("23", "Ilfov");
            districtCode.Add("24", "Maramures"); 
            districtCode.Add("25", "Mehedinti"); 
            districtCode.Add("26", "Mures"); 
            districtCode.Add("27", "Neamt"); 
            districtCode.Add("28", "Olt"); 
            districtCode.Add("29", "Prahova"); 
            districtCode.Add("30", "Satu Mare"); 
            districtCode.Add("31", "Salaj"); 
            districtCode.Add("32", "Sibiu"); 
            districtCode.Add("33", "Suceava"); 
            districtCode.Add("34", "Teleorman"); 
            districtCode.Add("35", "Timis"); 
            districtCode.Add("36", "Tulcea"); 
            districtCode.Add("37", "Vaslui"); 
            districtCode.Add("38", "Valcea"); 
            districtCode.Add("39", "Vrancea"); 
            districtCode.Add("40", "Bucuresti"); 
            districtCode.Add("41", "Bucuresti Sectorul 1"); 
            districtCode.Add("42", "Bucuresti Sectorul 2"); 
            districtCode.Add("43", "Bucuresti Sectorul 3"); 
            districtCode.Add("44", "Bucuresti Sectorul 4"); 
            districtCode.Add("45", "Bucuresti Sectorul 5"); 
            districtCode.Add("46", "Bucuresti Sectorul 6"); 
            districtCode.Add("51", "Calarasi");
            districtCode.Add("52", "Giurgiu");

            return districtCode;
        }
        public string GenerateDistrictCode()
        {
            DateGenerator dtGenerator = new DateGenerator();
            Dictionary<string, string> districtCode = dtGenerator.DistrictCode();
            string code = districtCode.ElementAt(gen.Next(0, districtCode.Count)).Key;
            return code;
        }
        public int controllNumber(string cnp)
        {
            int[] arrayNumber = cnp.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
            int[] checkNumbers = new int[12] { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };

            int sum = 0;
            for (int g = 0; g < arrayNumber.Length; g++)
            {
                sum = sum + (arrayNumber[g] * checkNumbers[g]);
            }

            int remainder, quotient = Math.DivRem(sum, 11, out remainder);

            if (remainder == 10)
            {
                remainder = 1;
            }
            return remainder;
        }
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public int GetYear(int gender, int year)
        {
            int fullYear = 0;
            switch (gender)
            {
                case 1:
                case 2:
                    fullYear = 1900 + year;
                    break;
                case 3:
                case 4:
                    fullYear = 1800 + year;
                    break;
                case 5:
                case 6:
                    fullYear = 2000 + year;
                    break;
                case 7:
                case 8:
                    if (year < DateTime.Now.Year - 2000)
                    {
                        fullYear = 2000 + year;
                    }
                    else if (year >= DateTime.Now.Year - 2000)
                    {
                        fullYear = 1900 + year;
                    }
                    break;
            }
            return fullYear;
        }
        public DateTime BirthDate(int gender, int year, int month, int day)
        {
            DateTime birthDate = new DateTime();
            switch (gender)
            {
                case 1:
                case 2:
                    birthDate = new DateTime(1900 + year, month, day);
                    break;
                case 3:
                case 4:
                    birthDate = new DateTime(1800 + year, month, day);
                    break;
                case 5:
                case 6:
                    birthDate = new DateTime(2000 + year, month, day);
                    break;
                case 7:
                case 8:
                    if (year < DateTime.Now.Year - 2000)
                    {
                        birthDate = new DateTime(2000 + year, month, day);
                    }
                    else if (year >= DateTime.Now.Year - 2000)
                    {
                        birthDate = new DateTime(1900 + year, month, day);
                    }
                    break;
            }
            return birthDate;
        }
        public bool ContainsKey(string district)
        {
            DateGenerator dateGenerator = new DateGenerator();
            Dictionary<string, string> districtCode = dateGenerator.DistrictCode();
            if (!districtCode.ContainsKey(district))
                return false;

            return true;
        }
    }
}
