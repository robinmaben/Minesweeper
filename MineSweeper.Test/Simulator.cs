using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MineSweeper.Test
{
    [TestClass]
    public class Simulator
    {
        [TestMethod]
        public void EmptyBoardGameNotOver()
        {
            var game = new Game
            {
                Grid = new Grid(3, Enumerable.Empty<Point>())
            };

            Assert.IsTrue(!game.IsLost);
        }

        [TestMethod]
        public void BoardWithMinesGameNotOver()
        {
            var game = new Game
            {
                Grid = new Grid(3, new[]
                {
                    new Point(0, 0),
                    new Point(1, 1)
                })
            };
            
            Assert.IsTrue(!game.IsLost);
        }

        [TestMethod]
        public void GameOverOnFirstMineOpened()
        {
            var game = new Game
            {
                Grid = new Grid(3, new[]
                {
                    new Point(0, 0),
                    new Point(1, 1)
                })
            };
            
            var gameResult = game.Move(new Point(0,0), SiteState.Open);

            Assert.IsTrue(gameResult == GameResult.Lost);

        }
    }
}
