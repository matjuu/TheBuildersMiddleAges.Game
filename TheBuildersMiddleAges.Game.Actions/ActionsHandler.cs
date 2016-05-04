using TheBuildersMiddleAges.Game.Actions.Actions;

namespace TheBuildersMiddleAges.Game.Actions
{
    public class ActionHandler
    {
        public TResponse HandleAction<TAction, TResponse>(ActionRequest request, TAction action)
            where TAction : ActionBase<TResponse> 
            where TResponse : ActionResponseBase
        {
            var response = action.Do(request);

            return response;
        }
    }
}
