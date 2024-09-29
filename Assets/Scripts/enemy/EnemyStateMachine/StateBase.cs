namespace UnityHFSM
{ 


//namespace FSM
//{
    //va a ser la base de todos los estados

    public class StateBase<TStateId>
    {

        public bool needsExitTime;
        public TStateId name;

        public IStateMachine fsm;


            public StateBase (bool needsExitTime)
            {
                this.needsExitTime = needsExitTime;
            }
    }
}
   //} 