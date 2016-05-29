
using System.Collections.Generic;

using System;
using System.Linq;

namespace EFCoreWebAPI.Tools
{
    
public static class SeasonFixer{
    public static string MostFrequentWord(List<String> wordList){
           var wordPairs=Parse(wordList);
           return wordPairs.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
        
        
    }
private static  IDictionary<string, int> Parse(List<String> reactions)
        {
                IDictionary<string, int> words = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
       
            foreach (var reaction in reactions)
            {
                
           
            string[] tokens = reaction.Split(' ', '.', ',', '-', '?', '!','<','>','&','[',']','(',')');
             foreach (string word in tokens)
            {
                if (string.IsNullOrEmpty(word.Trim()))
                {
                    continue;
                }
                int count;
                if (!words.TryGetValue(word, out count))
                {
                    count = 0;
                }
                words[word] = count + 1;
            }
            }
            return words;
            
        }
}
    
     class CaseInsensitiveComparer : IComparer<string>
{
    public int Compare(String s1, string s2)
    {
        return string.Compare(s1,s2,true);
    }
}
}