﻿using System.Collections.Generic;

namespace ImageGenerator
{
    public static class PromptHelper
    {
        public static IReadOnlyList<string> Styles = new List<string>()
        {
            "Da Vinci",
            "Van Gogh",
            "Salvador Dali",
            "Pablo Picasso",
            "Digital Art",
            "Cartoon"
        };
    }
}