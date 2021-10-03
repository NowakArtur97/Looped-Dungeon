namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class FiniteStateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State startingState) => CurrentState = startingState;

        public void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;

            CurrentState.Enter();
        }
    }
}
