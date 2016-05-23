using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeWorkerAction : ActionBase<TakeCardActionResponse>
    {
        public TakeWorkerAction(Core.Game game)
        {
            Game = game;
        }

        public override TakeCardActionResponse Do(ActionRequest request)
        {
            if (Game.GameClock.Tick())
            {
                Player player = TryGetPlayer(request.PlayerGuid);
                Worker worker = Game.TakeWorker(request.WorkerId);

                player.HireWorker(worker);
                int newCard = Game.DrawWorker();
                int topCard = Game.GameBoard.TopWorker.Id;

                TakeCardActionResponse response = new TakeCardActionResponse
                {
                    Success = true,
                    NewCard = newCard,
                    TopCard = topCard
                };

                return response;
            }
            else
            {
                Player player = TryGetPlayer(request.PlayerGuid);
                int newCard = Game.GameBoard.TopWorker.Id;
                int topCard = Game.GameBoard.TopWorker.Id;

                TakeCardActionResponse response = new TakeCardActionResponse
                {
                    Success = false,
                    NewCard = newCard,
                    TopCard = topCard
                };

                return response;
            }
        }
    }
}