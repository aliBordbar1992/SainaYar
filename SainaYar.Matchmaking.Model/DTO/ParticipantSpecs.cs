using System;
using System.Collections.Generic;
using System.Text;
using SainaYar.Matchmaking.Core.Interfaces;
using SainaYar.Matchmaking.Core.Model;
using SainaYar.Matchmaking.Core.Services;

namespace SainaYar.Matchmaking.Core.DTO
{
    public class ParticipantSpecs<T>
    {
        public T Participant { get; set; }
        public int RoundsWon { get; set; }
        public double PreviousScore { get; set; }

        public ParticipantSpecs(T participant, int roundsWon, double previousScore)
        {
            Participant = participant;
            RoundsWon = roundsWon;
            PreviousScore = previousScore;
        }
    }
}
