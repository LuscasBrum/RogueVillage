using GameWorkstore.Patterns;

namespace RogueStore
{
    public enum MatchState
    {
        PLAYING = 0,
        PAUSED = 1
    }

    public class GameService : IService
    {
        public MatchState MatchState { get; private set; }

        public override void Postprocess()
        {
        }

        public override void Preprocess()
        {
        }
    }
}
