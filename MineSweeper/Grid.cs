
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public class Grid
    {
        private readonly int _size;
        private Site[][] _columns;

        public Grid(int size, IEnumerable<Point> mineCoordinates)
        {
            _size = size;
            PrepareEmptyGrid(mineCoordinates);
        }

        public Site[] AllSites
        {
            get { return _columns.SelectMany(column => column).ToArray(); }
        }
        
        private void PrepareEmptyGrid(IEnumerable<Point> minePoints)
        {
            _columns = new Site[_size][];
            var points = minePoints as Point[] ?? minePoints.ToArray();

            for (var i = 0; i < _size; i++)
            {
                _columns[i] = new Site[_size];
                for (var j = 0; j < _size; j++)
                {
                    _columns[i][j] = new Site(new Point(i,j), points.Any(point => point.X == i && point.Y == j));
                }
            }
        }

        public Site SiteAt(int x, int y)
        {
            if (x - 1 > _size)
            {
                throw new ArgumentOutOfRangeException("x", "X co-ordinate exceeds grid size");
            }

            if (y - 1 > _size)
            {
                throw new ArgumentOutOfRangeException("y", "Y co-ordinate exceeds grid size");
            }

            return _columns[x][y];
        }

        public Site SiteAt(Point point)
        {
           return _columns[point.X][point.Y];
        }

        //private void LayMines(IEnumerable<Point> mineCoordinates)
        //{
        //    foreach (var mineCoordinate in mineCoordinates)
        //    {
        //        SiteAt(mineCoordinate).LayMine();
        //    }
        //}

        public void Render()
        {
            foreach (var column in _columns)
            {
                foreach (var site in column)
                {
                    Console.WriteLine(site);
                }
            }
        }

        public void MinesSurroundingSite(Site site)
        {
            //var neighbors = null;
        }
    }
}