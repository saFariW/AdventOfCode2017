using System;
using System.Collections.Generic;

namespace AdventOfCode2017
{
    public static class Day03
    {
        public static int Solution01(int input)
        {
            // unsafe convert, will fail if there are extremely large numbers as input. e.g. '1e19'
            int arraySize = Convert.ToInt32(Math.Ceiling(Math.Sqrt(input)));
            var middle = new Point(arraySize / 2, arraySize / 2);

            // make sure the grid is uneven, that way we have a middle.
            if (arraySize % 2 == 0)
                arraySize++;

            // create grid
            List<List<int>> grid = new List<List<int>>(arraySize);
            for (int i = 0; i < arraySize; i++)
            {
                grid.Add(new List<int>(arraySize));
                for (int j = 0; j < arraySize; j++)
                {
                    grid[i].Add(0);
                }
            }

            // populate grid
            // pos stands for position.
            var pos = new Point(middle.X, middle.Y);
            Direction direction = Direction.right;

            for (int i = 1; i < input; i++)
            {
                grid[pos.X][pos.Y] = i;
                var step = Step(grid, pos, direction);
                pos = step.Item1;
                direction = step.Item2;
            }

            // calculate Manhattan distance

            return Math.Abs(middle.X - pos.X) + Math.Abs(middle.Y - pos.Y);
        }

        /// <summary>
        /// The main logic to step through the grid. 
        /// Based on the direction that is being 'walked' you keep checking a grid-point next to you. 
        /// For Example: When you are walking to the right. When the grid-point above you has the value 0 it means you should go up. 
        /// Then you start checking the grid-points left of you, when this point is 0 again you turn. This way you will 'walk' in circles.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="pos">The current position.</param>
        /// <param name="direction">The direction you had while 'walking' previously.</param>
        /// <returns>The new position and a direction.</returns>
        private static Tuple<Point, Direction> Step(List<List<int>> grid, Point pos, Direction direction)
        {
            if (direction == Direction.up)
            {
                // if the grid-point left of the position has a value, we can continue up. otherwise we make a turn, and thus go left.
                if (grid[pos.X - 1][pos.Y] != 0)
                    pos.Y++;
                else
                {
                    direction = Direction.left;
                    pos.X--;
                }
            }
            else if (direction == Direction.down)
            {
                // if the grid-point right of the position has a value, we can continue down. otherwise we make a turn, and thus go right.
                if (grid[pos.X + 1][pos.Y] != 0)
                    pos.Y--;
                else
                {
                    pos.X++;
                    direction = Direction.right;
                }
            }
            else if (direction == Direction.left)
            {
                // if the grid-point below of the position has a value, we can continue left. otherwise we make a turn, and thus go down.
                if (grid[pos.X][pos.Y - 1] != 0)
                    pos.X--;
                else
                {
                    pos.Y--;
                    direction = Direction.down;
                }
            }
            else // direction == Direction.right
            {
                // if the grid-point above of the position has a value, we can continue right. otherwise we make a turn, and thus go up.
                if (grid[pos.X][pos.Y + 1] != 0)
                    pos.X++;
                else
                {
                    pos.Y++;
                    direction = Direction.up;
                }
                    
            }
            return new Tuple<Point, Direction>(pos, direction);
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public enum Direction
        {
            up, down, left, right
        }
    }
}
