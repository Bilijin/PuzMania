using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddles
{

    private readonly string[] riddles = new string[] {
    "What is the end of everything?",
    "What goes up but never comes down?",
    "What has hands but can't clap?",
    "Sam's mother has 4 children named North, East and West. What's the name of the 4th child?",
    "You are my brother but I am not your brother. Who am I?",
    "What has many keys but cannot open any lock",
    "Wash me and I'll be dirty. Don't wash me and I'll be clean. What am I?",
    "I go up when rain comes down. What am I?",
    "What is so fragile that even the slighest sound would break it?",
    "What occurs once in a minute, twice in a moment but never in an hour?",
    "What can't talk but will reply when spoken to?",
    "What gets bigger when more is taken away",
    "If you have me, you want to share me but if you share me, then you no longer have me. I'm a",
    "What goes up and down but never moves",
    "I am an odd number. Take away a letter and I become even, What number am I?",
    "Clive has 4 daughters and each daughter has a brother. How many children does he have?",
    "If there are three apples and you take away two, how many apples do you have?",
    "The more you take the more you leave behind. What are they?",
    "I can be hot, I can be cold, I can run, I can still, I can be hard, I can be soft. I am?",
    "What has six faces and 21 eyes but cannot see",
    };

    private readonly string[] answers = new string[] {
    "G",
    "age",
    "Clock",
    "Sam",
    "Sister",
    "Piano",
    "Water",
    "Umbrella",
    "Silence",
    "M",
    "Echo",
    "Hole",
    "Secret",
    "Staircase",
    "Seven",
    "Five",
    "Two",
    "Footsteps",
    "Water",
    "Die"
    };

    private readonly string[] hints = new string[]
    {
        "its a single letter",
        "a word for \"how old you are\"",
        "what tells the time?",
        "whose mother?",
        "mother - father. brother -",
        "a musical instrument",
        "I'm a common liquid",
        "Rihanna sang \"under my _\"",
        "As ____ as the grave",
        "Remember the first riddle?",
        "Hello - hello - hello...",
        "You dig it",
        "Shh, it's a ___",
        "a flight of ___",
        "63 divided by 7 equals?",
        "one of the most popular numbers",
        "You know this one",
        "Involves walking or running",
        "I was the answer to another riddle",
        "No hints this time",
    };

    public string GetRiddle(int level)
    {
        return riddles[level - 1];
    }

    public string GetAnswer(int level)
    {
        return answers[level - 1];
    }

    public string GetHint(int level)
    {
        return hints[level - 1];
    }
}
