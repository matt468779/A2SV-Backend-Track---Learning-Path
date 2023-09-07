namespace Task
{
    class Task3
    {
        public void DoTask(string word)
        {
            bool result = IsPalindrome(word);
            string temp = result ? "" : "NOT ";
            Console.WriteLine($"{word} is {temp}a palindrome");
        }

        public bool IsPalindrome(string word)
        {
            string strippedWord = strip(word);
            int l = 0, r = strippedWord.Count() - 1;
            while (l < r)
            {
                if (strippedWord[l] != strippedWord[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }

        public string strip(string word)
        {
            List<char> result = new List<char>();
            foreach (char character in word)
            {
                if (char.IsLetter(character))
                {
                    result.Add(char.ToLower(character));
                }
                else if (char.IsDigit(character))
                {
                    result.Add(character);
                }
            }
            return new string(result.ToArray<char>());
        }
    }
}