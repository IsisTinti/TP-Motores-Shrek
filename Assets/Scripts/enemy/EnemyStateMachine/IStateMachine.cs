namespace UnityHFSM
{

    public interface IStateMachine
    {
        //sirve para que si hay una transicion del estado pendiente,lo tiene que hacer
        void StateCanExit();
        bool HasPendingTransition { get; }

        IStateMachine ParentFsm { get; }
  
    }






}

