namespace AdventOfCode2017
{
    using System;
    using System.Collections.Generic;

    public static class Day03
    {
        private enum Direction
        {
            Up, Down, Left, Right
        }

        public static int Solution01(int input)
        {
            var grid = CreateGrid(input);
            var middle = new Point(grid.Count / 2, grid.Count / 2);

            // populate grid
            // pos stands for position.
            var pos = new Point(middle.X, middle.Y);
            Direction direction = Direction.Right;

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

        public static int Solution02(int input)
        {
            var grid = CreateGrid(input);
            var middle = new Point(grid.Count / 2, grid.Count / 2);
            var pos = new Point(middle.X, middle.Y);
            Direction direction = Direction.Right;
            int latestSetValue = 0;

            while (latestSetValue < input)
            {
                grid[pos.X][pos.Y] = GetSurroundingValues(grid, pos);
                latestSetValue = grid[pos.X][pos.Y];

                var step = Step(grid, pos, direction);
                pos = step.Item1;
                direction = step.Item2;
            }

            return latestSetValue;
        }

        private static List<List<int>> CreateGrid(int input)
        {
            // unsafe convert, will fail if there are extremely large numbers as input. e.g. '1e19'
            int arraySize = Convert.ToInt32(Math.Ceiling(Math.Sqrt(input)));

            // make sure the grid is uneven, that way we have a middle.
            if (arraySize % 2 == 0)
            {
                arraySize++;
            }

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

            return grid;
        }

        /// <summary>
        /// returns the total of all the values surrounding the given gridPoint.
        /// </summary>
        /// <remarks>
        /// Will return 1 when it would normally return 0.
        /// </remarks>
        /// <param name="grid">The grid.</param>
        /// <param name="gridPoint">The point of which the surrounding values should be retrieved from.</param>
        /// <returns>The total of values surrounding the gridPoint.</returns>
        private static int GetSurroundingValues(List<List<int>> grid, Point gridPoint)
        {
            int sum = 0;
            sum += grid[gridPoint.X + 1][gridPoint.Y + 1];  // top right
            sum += grid[gridPoint.X + 1][gridPoint.Y];      // right
            sum += grid[gridPoint.X + 1][gridPoint.Y - 1];  // bottom right
            sum += grid[gridPoint.X][gridPoint.Y + 1];      // top
            sum += grid[gridPoint.X][gridPoint.Y - 1];      // bottom
            sum += grid[gridPoint.X - 1][gridPoint.Y + 1];  // top left
            sum += grid[gridPoint.X - 1][gridPoint.Y];      // left
            sum += grid[gridPoint.X - 1][gridPoint.Y - 1];  // bottom left

            // For the first step there are no values yet.
            if (sum == 0)
            {
                sum++;
            }

            return sum;
        }

        /// <summary>
        /// The main logic to step through the grid.
        /// Based on the direction that is being 'walked' you keep checking a grid-point next to you.
        /// </summary>
        /// <example>
        /// When you are walking to the right. When the grid-point above you has the value 0 it means you should go up.
        /// Then you start checking the grid-points left of you, when this point is 0 again you turn. This way you will 'walk' in circles.
        /// </example>
        /// <param name="grid">The grid.</param>
        /// <param name="pos">The current position.</param>
        /// <param name="direction">The direction you had while 'walking' previously.</param>
        /// <returns>The new position and a direction.</returns>
        private static Tuple<Point, Direction> Step(List<List<int>> grid, Point pos, Direction direction)
        {
            if (direction == Direction.Up)
            {
                // if the grid-point left of the position has a value, we can continue up. otherwise we make a turn, and thus go left.
                if (grid[pos.X - 1][pos.Y] != 0)
                {
                    pos.Y++;
                }
                else
                {
                    direction = Direction.Left;
                    pos.X--;
                }
            }
            else if (direction == Direction.Down)
            {
                // if the grid-point right of the position has a value, we can continue down. otherwise we make a turn, and thus go right.
                if (grid[pos.X + 1][pos.Y] != 0)
                {
                    pos.Y--;
                }
                else
                {
                    pos.X++;
                    direction = Direction.Right;
                }
            }
            else if (direction == Direction.Left)
            {
                // if the grid-point below of the position has a value, we can continue left. otherwise we make a turn, and thus go down.
                if (grid[pos.X][pos.Y - 1] != 0)
                {
                    pos.X--;
                }
                else
                {
                    pos.Y--;
                    direction = Direction.Down;
                }
            }
            else
            {
                // direction == Direction.right
                // if the grid-point above of the position has a value, we can continue right. otherwise we make a turn, and thus go up.
                if (grid[pos.X][pos.Y + 1] != 0)
                {
                    pos.X++;
                }
                else
                {
                    pos.Y++;
                    direction = Direction.Up;
                }
            }

            return new Tuple<Point, Direction>(pos, direction);
        }

        private class Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }
        }
    }
}
