using System.Linq;

namespace MineSweeper
{
    public class Game
    {
        public Grid Grid { get; set; }

        public bool IsLost
        {
            get { return Grid.AllSites.Any(site => site.HasMine && site.State == SiteState.Open); }
        }

        public bool IsWon
        {
            get { return Grid.AllSites.All(site => !site.HasMine && site.State == SiteState.Open); }
        }

        public GameResult Move(Point point, SiteState state)
        {
            var site = Grid.SiteAt(point);
            site.State = state;

            if (site.HasMine && state == SiteState.Open)
            {
                return GameResult.Lost;
            }

            return IsWon ? GameResult.Won : GameResult.Unknown;
        }
    }

    public enum GameResult
    {
        Unknown,
        Won,
        Lost
    }
}
