using System.Diagnostics;

namespace MineSweeper
{
    [DebuggerDisplay("{State}, {HasMine}")]
    public class Site
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly Point _coOrds;
        
        public SiteState State { get; set; }

        public Site(Point point, bool hasMine)
        {
            _coOrds = point;
            HasMine = hasMine;
            State = SiteState.Closed;
        }

        public bool HasMine { get; private set; }

        public void LayMine()
        {
            HasMine = true;
        }

        public override string ToString()
        {
            switch (State)
            {
                case SiteState.Open:
                    return "O";
                case SiteState.Closed:
                    return "X";
                case SiteState.Flagged:
                    return "F";
                default:
                    return "X";
            }
        }
    }

    public enum SiteState   
    {
        Closed,
        Open,
        Flagged
    }
}