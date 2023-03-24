namespace CnpGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenerateRandomCnp gen = new GenerateRandomCnp();
            ValidateCnp val = new ValidateCnp();
            for (int i = 0; i < 25; i++)
            {
                string cnp = gen.Generate();
                bool isValid = val.Validate(cnp);

               Console.WriteLine($"{cnp} - {isValid}");
            }

            Console.WriteLine(val.Validate("1740907519809"));
            Console.WriteLine(val.Validate("1740907511329"));
            Console.WriteLine(val.Validate("5200907517437"));
            Console.WriteLine(val.Validate("5450907512415"));
        }
    }
}