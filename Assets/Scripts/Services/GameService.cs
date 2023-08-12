using GameWorkstore.Patterns;

namespace RogueStore
{
    public enum MatchState
    {
        PLAYING = 0,
        PAUSED = 1,
        SHOPPING = 2,
    }

    public class GameService : IService
    {
        public MatchState MatchState { get; private set; }

        public override void Postprocess()
        {
        }

        public override void Preprocess()
        {
            MatchState = MatchState.PLAYING;
        }

        internal void OpenStore()
        {
            MatchState = MatchState == MatchState.PLAYING ? MatchState.SHOPPING : MatchState.PLAYING;
        }
    }
}
