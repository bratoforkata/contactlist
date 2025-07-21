using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface ISentenceScoreRepository
    {
        void Add(SentenceScore sentenceScore);

        SentenceScore[] GetScores();
    }
}
