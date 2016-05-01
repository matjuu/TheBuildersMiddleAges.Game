using System;
using Microsoft.AspNet.Mvc.ModelBinding;
using TheBuildersMiddleAges.Game.Actions.Actions;

namespace TheBuildersMiddleAges.Game.Actions
{
    public class ActionHandler
    {
        public TResponse HandleAction<TAction, TResponse>(ActionRequest request, TAction action)
            where TAction : ActionBase<TResponse> 
            where TResponse : BasicActionResponse
        {
            TResponse response;

            try
            {
                response = action.Do(request);
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return response;
        }
    }
}
