using System;

namespace UnityHFSM
{

    public class State<TStateId, TEvent> : ActionState<TStateId, TEvent>
    {
        private Action<State<TStateId, TEvent>> onEnter;
        //cuando entra en el estado

        private Action<State<TStateId, TEvent>> onLogic;
        //cuando se activa por una funcion logica de la state machine activa

        private Action<State<TStateId, TEvent>> onExit;
        // cuando sale del estado

        private Func<State<TStateId, TEvent>, bool> canExit;
        //solamente por si necesita tiempo de salida 

        public ITimer timer;



        public State(

            Action<State<TStateId, TEvent>> onEnter = null,
            Action<State<TStateId, TEvent>> onLogic = null,
            Action<State<TStateId, TEvent>> onExit = null,
            Func<State<TStateId, TEvent>, bool> canExit = null,
            bool needsExitTime = false) : base(needsExitTime)
        {
            this.onEnter = onEnter;
            this.onLogic = onLogic;
            this.onExit = onExit;
            this.canExit = canExit;

            this.timer = new Timer();

        }

        public override void OnEnter()
        {
            timer.Reset();
            onEnter?.Invoke(this);
        }

        public override void OnLogic()
        {
            onLogic?.Invoke(this);

            if (needsExitTime && canExit != null && UnityHFSM.HasPendingTransition && canExit(this))
            {
                fsm.StateCanExit();
            }
        }

        public override void OnExitRequest()
        {
            if (canExit != null && canExit(this))
            {
                fsm.StateCanExit();
            }
        }
    }
    public class State<TStateId> : State<TStateId, string>
    {

        public State(
            Action<State<TStateId, string>> onEnter = null,
            Action<State<TStateId, string>> onLogic = null,
            Action<State<TStateId, string>> onExit = null,
            Func<State<TStateId, string>, bool> canExit = null,
            bool needsExitTime = false)
            : base(
               onEnter,
                onLogic,
                onExit,
                canExit,
                needsExitTime: needsExitTime)
        { }

    }

	public class State : State<string, string>
    {
       
        public State(
            Action<State<string, string>> onEnter = null,
            Action<State<string, string>> onLogic = null,
            Action<State<string, string>> onExit = null,
            Func<State<string, string>, bool> canExit = null,
            bool needsExitTime = false)
            : base(
                onEnter,
                onLogic,
                onExit,
                canExit,
                needsExitTime: needsExitTime
             )
        {
        }
    }
}
