﻿using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret = string.Empty;
        private int guessTimes = 1;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue
        {
            get
            {
                if (guessTimes <= 6)
                {
                    guessTimes += 1;
                    return true;
                }

                return false;
            }
        }

        public void InvalidRun()
        {
            guessTimes -= 1;
        }

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        public string Compare(string secret, string guess)
        {
            if (secret == guess)
            {
                return "4A0B";
            }

            int numberOfA = secret.Where(secretChar => guess.IndexOf(secretChar) == secret.IndexOf(secretChar)).ToList().Count;
            int numberOfB = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count - numberOfA;
            return $"{numberOfA}A{numberOfB}B";
        }
    }
}