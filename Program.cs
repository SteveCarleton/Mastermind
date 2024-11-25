class Messenger
{
    const int maxAttempts = 10;
    const string secret = "1234";
    const string prompt = ": Enter four digits, with each digit ranging from 1 to 6.";
    const string successMessage = "SUCCESS!";
    const string failureMessage = "FAILURE";
    const char plusMarker = '+';
    const char minusMarker = '-';
    const int minDigitValue = 1;
    const int maxDigitValue = 6;

    static bool validInput = false;
    static int attempts = 0;
    static bool match = false;
    static int plusses;
    static int minusses;
    static string? input = null;

    static void Main()
    {
        while (attempts < maxAttempts && !match)
        {
            while (!validInput)
            {
                Console.WriteLine($"{attempts + 1}{prompt}");
                input = Console.ReadLine();

                validInput = ValidateInput(input);
                if (validInput)
                {
                    attempts++;
                }
                //if (input?.Length == 4)
                //{
                //    int validDigits = 0;

                //    foreach (char c in input)
                //    {
                //        if (char.IsDigit(c))
                //        {
                //            int val = c - '0';
                //            if (val > 0 && val < 7)
                //            {
                //                validDigits++;
                //            }
                //        }
                //    }

                //    if (validDigits == secret.Length)
                //    {
                //        validInput = true;
                //        attempts++;
                //    }
                //}
            }

            plusses = 0;
            minusses = 0;

            for (int inputIndex = 0; inputIndex < secret.Length; inputIndex++)
            {
                if (input?[inputIndex] == secret[inputIndex])
                {
                    plusses++;
                }
                else
                {
                    for (int secretIndex = inputIndex; secretIndex < secret.Length; secretIndex++)
                    {
                        if (secretIndex != inputIndex)
                        {
                            if (input?[inputIndex] == secret[secretIndex])
                            {
                                minusses++;
                            }
                        }
                    }
                }
            }

            if (plusses == secret.Length)
            {
                Console.Write(successMessage);
                match = true;
            }
            else
            {
                for (int index = 0; index < plusses; index++)
                {
                    Console.Write(plusMarker);
                }

                for (int index = 0; index < minusses; index++)
                {
                    Console.Write(minusMarker);
                }

                Console.WriteLine();
                validInput = false;
            }

            if (attempts == maxAttempts)
            {
                Console.WriteLine(failureMessage);
                return;
            }
        }
    }

    public static bool ValidateInput(string? input)
    {
        if (input?.Length == secret.Length)
        {
            int validDigits = 0;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    int val = c - '0';

                    if (val >= minDigitValue && val <= maxDigitValue)
                    {
                        validDigits++;
                    }
                }
            }

            return validDigits == secret.Length;
        }

        return false;
    }
}