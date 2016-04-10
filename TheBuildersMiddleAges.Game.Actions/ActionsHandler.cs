using System;
using TheBuildersMiddleAges.Game.Actions.Actions;

namespace TheBuildersMiddleAges.Game.Actions
{
    public class ActionHandler
    {
        public ActionResponse HandleAction(ActionRequest request, CardAction action)
        {
            ActionResponse response;

            try
            {
                response = action.Do(request);
            }
            catch (Exception)
            {
                
                throw;
            }

            return response;
        }
    }
}
