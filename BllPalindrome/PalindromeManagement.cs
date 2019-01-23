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
        public List<string> GetListPalindromeFromFile(string pFileName)
        {
            FileTextReaderUtility myReader = new FileTextReaderUtility();
            List<string> readLines = myReader.ReadAllLines(pFileName);
            List<string> cleanLines = new List<string>();
            foreach (string line in readLines)
            {
                string bracketClean = line;

                for (int count = 0; count < bracketClean.Length; count++)
                {
                    int start = bracketClean.IndexOf('(');
                    int end = bracketClean.LastIndexOf(')');
                    if (start >= 0 && end >= 0)
                    {
                        bracketClean = bracketClean.Substring(0, start) + bracketClean.Substring(end + 1);
                    }
                }
                // string bracketClean = line;
                // bracketClean = Regex.Replace(bracketClean, @"\(.*\)", "");
                // Regex.Replace cherche la parenthèse ouvrante et fermante puis clean         
                string[] splitted = bracketClean.Split(',');
                cleanLines.Add(splitted[0].Trim()); //.Trim() enlève les espaces devant et derrière.
            }
            return cleanLines;
        }
    }
}