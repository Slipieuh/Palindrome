using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPalindrome;

namespace BllPalindrome
{
    public class PalindromeManagement
    {
        /// <summary>
        /// bracketClean = Regex.Replace(bracketClean, @"\(.*\)", "");
        /// Regex.Replace cherche la parenthèse ouvrante et fermante puis clean  
        /// .Trim() enlève les espaces devant et derrière.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<string> GetListPalindromeFromFile(string pFileName)
        {
            FileTextReaderUtility myReader = new FileTextReaderUtility();
            List<string> readLines = myReader.ReadAllLines(pFileName);
            List<string> cleanLines = new List<string>();
            foreach (string line in readLines)
            {
                string bracketClean = line;

                for (int countLetterBetweenBrackets = 0; countLetterBetweenBrackets < bracketClean.Length; countLetterBetweenBrackets++)
                {
                    int firstBracket = bracketClean.IndexOf('(');
                    int lastBracket = bracketClean.LastIndexOf(')');
                    if (firstBracket >= 0 && lastBracket >= 0)
                    {
                        bracketClean = bracketClean.Substring(0, firstBracket) + bracketClean.Substring(lastBracket + 1);
                    }
                }
                string[] splitted = bracketClean.Split(',');
                cleanLines.Add(splitted[0].Trim()); 
            }
            return cleanLines;
        }
    }
}