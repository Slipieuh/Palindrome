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
        /// METHODE POUR SUPPRIMER LES PARENTHESES AVEC REGEX
        /// bracketClean = Regex.Replace(bracketClean, @"\(.*\)", "");
        /// Regex.Replace cherche la parenthèse ouvrante et fermante puis clean  
        /// 
        /// DEF METHODE .TRIM
        /// .Trim() enlève les espaces devant et derrière.
        /// 
        /// ENLEVE TOUT LES TITRES DU FICHIER
        /// titleClean = line.Replace("Noms propres","");
        /// titleClean = line.Replace("Prénoms", "");
        /// titleClean = line.Replace("Villes et localités", "");
        /// titleClean = line.Replace("Rivières", "");
        /// titleClean = line.Replace("Divers", "");
        /// 
        /// CLEAN LES ESPACES DANS LA LISTE
        /// cleanLines = cleanLines.Where(val => !string.IsNullOrEmpty(val)).ToList();
        /// ou la valeur est différente de 0 on met dans la liste
        /// 
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
                cleanLines = cleanLines.Where(valeur => !string.IsNullOrEmpty(valeur)).ToList();
                cleanLines.Add(splitted[0].Trim());
            }
            return cleanLines;
        }
    }
}