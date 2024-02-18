string alpha = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž" + "aąbcčdeęėfghiįyjklmnoprsštuųūvzž".ToUpper();
int modn = alpha.Length;

repeat:

Console.Write("Select operation\n[0] Encrypt\n[1] Decrypt\nYour selection: ");
int selection = int.Parse(Console.ReadLine());

Console.Write("Select the character set to use\n[0] Lithuanian\n[1] ASCII\nYour selection:");
int langSelect = int.Parse(Console.ReadLine());

Console.Write("Enter shift (int): ");
int shift = int.Parse(Console.ReadLine());

Console.Write("Enter the text to " + (selection == 0 ? "en" : "de") + "crypt: ");
string text = Console.ReadLine();

string output = "";

switch (selection)
{
	case 0: // Encryption
		switch (langSelect)
		{
			case 0:
				foreach (char letter in text)
				{
					int m = alpha.IndexOf(letter);

					output += alpha[(shift + m) % modn];
				}
				break;

			case 1:
				foreach (char letter in text)
				{
					int res = letter + shift;

					res = res < 33 ? 126 + res - 33 : (res > 126 ? (res % 126) + 33 : res);

					output += (char)res;
				}
				
				break;
		}
		break;

	case 1: // Decryption
		switch (langSelect)
		{
			case 0:
				foreach (char letter in text)
				{
					int m = alpha.IndexOf(letter);

					output += alpha[(m - shift + modn) % modn];
				}
				break;

			case 1:
				foreach (char letter in text)
				{
					int res = letter - shift;

					res = res < 33 ? 126 + res - 33 : (res > 126 ? (res % 126) + 33 : res);

					output += (char)res;
				}

				break;
		}

		break;
}

Console.WriteLine((selection == 0 ? "En" : "De") + "crypted text: " + output);

Console.Write("Do you wish to continue?\n[0] Quit\n[1] Continue\nYour selection: ");

if (int.Parse(Console.ReadLine()) == 1)
	goto repeat;