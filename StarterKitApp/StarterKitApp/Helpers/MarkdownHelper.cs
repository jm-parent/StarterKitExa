using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarterKitApp.Helpers
{
    public static class MarkdownHelper
    {
        /// <summary>
        /// Gets all the paragraphs in a given markdown document.
        /// </summary>
        /// <param name="text">The input markdown document.</param>
        /// <returns>The raw paragraphs from <paramref name="text"/>.</returns>
        public static IReadOnlyDictionary<string, string> GetParagraphs(string text)
        {
            var ofType = Regex.Matches(text, @"(?<=\W)#+ ([^\n]+).+?(?=\W#|$)", RegexOptions.Singleline)
                .OfType<Match>();
            return
                ofType
                    .ToDictionary(
                        m => m.Groups[1].Value.Trim().Replace("&lt;", "<"),
                        m => m.Groups[0].Value.Trim().Replace("&lt;", "<").Replace("[!WARNING]", "**WARNING:**").Replace("[!NOTE]", "**NOTE:**"));
        }
    }
}
