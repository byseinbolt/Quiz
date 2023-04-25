using System.Collections.Generic;

namespace AIQuiz
{
    public static class PromptHelper
    {
        public static readonly IReadOnlyList<string> Styles = new List<string>
        {
            "Da Vinci",
            "Van Gogh",
            "Cartoon",
            "Digital Art",
            "Salvador Dali"
        };
    }
}