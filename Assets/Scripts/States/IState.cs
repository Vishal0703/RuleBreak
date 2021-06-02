public interface IState
{
    public void Tick();

    public void LateTick();
    
    public void FixedTick();

    public void OnStateEnter();

    public void OnStateExit();
}

