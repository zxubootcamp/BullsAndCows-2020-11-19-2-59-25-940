﻿using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret = string.Empty;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

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

            if (secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count == 4)
            {
                int numberOfA = secret.Where(secretChar => guess.IndexOf(secretChar) == secret.IndexOf(secretChar)).ToList().Count;
                int numberOfB = 4 - numberOfA;
                return $"{numberOfA}A{numberOfB}B";
            }

            return "0A0B";
        }
    }
}