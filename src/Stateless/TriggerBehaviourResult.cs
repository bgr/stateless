using System.Collections.Generic;

namespace Stateless
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal class TriggerBehaviourResult
        {
            public TriggerBehaviourResult(TriggerBehaviour handler, List<string> unmetGuardConditions)
            {
                Handler = handler;
                UnmetGuardConditions = unmetGuardConditions;
            }
            public TriggerBehaviour Handler { get; }
            public List<string> UnmetGuardConditions { get; }
        }
    }
}
