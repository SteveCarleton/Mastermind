class Messenger
{
    const int maxAttempts = 10;
    const string secret = "1234";
    const string banner = "An input must be valid to count as an attempt";
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
    static string? input = null;

    static void Main()
    {
        Console.WriteLine($"{banner}");

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
            }

            string messageStr = ProcessInput(input);
            if (messageStr != null)
            {
                Console.WriteLine(messageStr);
            }

            if (messageStr == successMessage)
            {
                match = true;
            }
            else
            {
                validInput = false;
            }

            if (attempts == maxAttempts)
            {
                Console.WriteLine(failureMessage);
                return;
            }
        }
    }

    /// <summary>
    /// Check that the required number of digits have been entered, in the given range of values.
    /// </summary>
    /// <param name="input">Input string for validation</param>
    /// <returns>Validity flag</returns>
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

    /// <summary>
    /// Check if the input matches the secret. If not determine apply logic such that a plus sign should be output 
    /// for every digit that is both correct and in the correct position.  Output all plus signs first, all minus 
    /// signs second, and nothing for incorrect digits.
    /// </summary>
    /// <param name="input">Input string for processing</param>
    /// <returns>Processing result</returns>
    public static string ProcessInput(string? input)
    {
        int plusses = 0;
        int minusses = 0;

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
            return successMessage;
        }
        else
        {
            string matchStr = default!;

            for (int index = 0; index < plusses; index++)
            {
                matchStr += plusMarker;
            }

            for (int index = 0; index < minusses; index++)
            {
                matchStr += minusMarker;
            }

            return matchStr;
        }
    }
}