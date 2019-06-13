using System.Collections.Generic;

namespace Stateless
{
    public partial class StateMachine<TState, TTrigger>
    {
        //internal static readonly TriggerBehaviourResult NULL_TriggerBehaviourResult = default(TriggerBehaviourResult);

        internal class TriggerBehaviourResult
        {
            private static Dictionary<int, TriggerBehaviourResult> CACHED_INSTANCES = new Dictionary<int, TriggerBehaviourResult>();

            internal static TriggerBehaviourResult Get(TriggerBehaviour handler, List<string> unmetGuardConditions)
            {
                var hashCode = GetHashCode(handler, unmetGuardConditions);
                if (CACHED_INSTANCES.TryGetValue(hashCode, out TriggerBehaviourResult result))
                {
                    return result;
                }
                var newInstance = new TriggerBehaviourResult(handler, new List<string>(unmetGuardConditions));
                CACHED_INSTANCES.Add(hashCode, newInstance);
                return newInstance;
            }

            private TriggerBehaviourResult(TriggerBehaviour handler, List<string> unmetGuardConditions)
            {
                this.handler = handler;
                this.unmetGuardConditions = unmetGuardConditions;

            }
            public readonly TriggerBehaviour handler;
            public readonly List<string> unmetGuardConditions;

            private static int GetHashCode(TriggerBehaviour handler, List<string> unmetGuardConditions)
            {
                // assuming that handler and unmetGuardConditions are immutable
                var hashCode = 690819454;
                hashCode = hashCode * -1521134295 + EqualityComparer<TriggerBehaviour>.Default.GetHashCode(handler);
                hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(unmetGuardConditions);
                return hashCode;
            }
        }
    }
}
