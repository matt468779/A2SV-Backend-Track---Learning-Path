namespace Task
{
    class Task2
    {
        public Dictionary<string, int> GetFrequencyOfWords(string sentence)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var word in sentence.Split())
            {
                string lower_word = word.ToLower();
                if (result.ContainsKey(lower_word))
                {
                    result[lower_word]++;
                }
                else
                {
                    result[lower_word] = 1;
                }
            }

            return result;
        }

        public void DoTask(string sentence)
        {
            Dictionary<string, int> result = GetFrequencyOfWords(sentence);
            DisplayResult(sentence, result);
        }

        public void DisplayResult(string sentence, Dictionary<string, int> dict)
        {
            Console.WriteLine($"Input word: {sentence}");
            Console.WriteLine($"The fequency of each word in lowercase is: ");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} ==> {item.Value}");
            }
        }
    }
}