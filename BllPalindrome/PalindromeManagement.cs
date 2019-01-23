using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                string text = line;
                text = Regex.Replace(text, @"\(.*\)", "");
                text = Regex.Replace(text, @"\s+", " ");               
                string[] splitted = text.Split(',');
                cleanLines.Add(splitted[0].Trim()); //.Trim() enlève les espaces devant et derrière.
            }
            return cleanLines;
        }
    }
}