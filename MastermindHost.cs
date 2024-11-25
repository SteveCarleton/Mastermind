namespace Scc.Mastermind;

class MastermindHost
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

                validInput = MastermindLogic.ValidateInput(input, secret, minDigitValue, maxDigitValue);
                if (validInput)
                {
                    attempts++;
                }
            }

            string messageStr = MastermindLogic.ProcessInput(input, secret, successMessage, plusMarker, minusMarker);

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
}