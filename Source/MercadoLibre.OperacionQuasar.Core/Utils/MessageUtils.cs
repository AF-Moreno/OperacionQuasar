using System.Collections.Generic;
using System.Linq;

namespace MercadoLibre.OperacionQuasar.Core.Utils
{
    public class MessageUtils
    {
        public static string GetMessage(IEnumerable<string[]> messages)
        {
            var message = new List<string>();

            if (messages.Select(x => x.Length).GroupBy(x => x).Count() == 1)
            {
                var length = messages.FirstOrDefault().Length;

                for (int i = 0; i < length; i++)
                {
                    var wordsGroup = messages
                                        .Select(x => x[i].Trim().ToLower())
                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                        .GroupBy(x => x)
                                        .Select(x => x.Key);

                    if (wordsGroup.Any())
                    {
                        if (wordsGroup.Count() == 1)
                        {
                            var word = wordsGroup.FirstOrDefault();

                            message.Add(word);
                        }
                        else
                        {
                            string errorMessage = $"There are different words:[{string.Join(",", wordsGroup)}] in the index[{i}]";
                            throw new System.Exception(errorMessage);
                        }
                    }
                }
            }
            else
            {
                throw new System.Exception("The number of words must be the same in all messages");
            }

            return string.Join(" ", message);
        }
    }
}
