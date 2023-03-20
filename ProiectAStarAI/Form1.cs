namespace ProiectAStarAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Coordonatele unei celule
        public class Coordinates : IEquatable<Coordinates>
        {
            public int row;
            public int col;

            public Coordinates() { this.row = -1; this.col = -1; }
            public Coordinates(int row, int col) { this.row = row; this.col = col; }

            public bool Equals(Coordinates c)
            {
                if (this.row == c.row && this.col == c.col)
                    return true;
                else
                    return false;
            }
        }

        public class Cell
        {
            public int cost;
            public int g;
            public int f;
            public Coordinates parent;
        }

        Cell[,] cells = new Cell[8, 8];
        List<Coordinates> path = new List<Coordinates>();
        List<Coordinates> opened = new List<Coordinates>();
        List<Coordinates> closed = new List<Coordinates>();
        Coordinates startCell;
        Coordinates finishCell;

        public void AStar()
        {
            try
            {
                var x = int.Parse(textX.Text);
                var y = int.Parse(textY.Text);
                var xF = int.Parse(textXF.Text);
                var yF = int.Parse(textYF.Text);

                startCell = new Coordinates(x, y);
                finishCell = new Coordinates(xF, yF);

                if (IsWall(x, y) || IsWall(xF, yF))
                {
                    MessageBox.Show("Nu exista solutii, alegeti alte coordonate.");
                    return;
                }

                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        cells[i, j] = new Cell();
                        cells[i, j].parent = new Coordinates();
                        if (IsWall(i, j))
                            cells[i, j].cost = 100;
                        else
                            cells[i, j].cost = 1;
                    }

                opened.Add(startCell);

                Boolean pathFound = false;

                do
                {
                    List<Coordinates> neighbors = new List<Coordinates>();
                    Coordinates currentCell = ShorterExpectedPath();
                    neighbors = neighborCells(currentCell);

                    foreach (Coordinates newCell in neighbors)
                    {
                        if (newCell.row == finishCell.row && newCell.col == finishCell.col)
                        {
                            cells[newCell.row, newCell.col].g = cells[currentCell.row, currentCell.col].g + cells[newCell.row, newCell.col].cost;
                            cells[newCell.row, newCell.col].parent.row = currentCell.row;
                            cells[newCell.row, newCell.col].parent.col = currentCell.col;
                            pathFound = true;
                            break;
                        }
                        else if (!opened.Contains(newCell) && !closed.Contains(newCell))
                        {
                            cells[newCell.row, newCell.col].g = cells[currentCell.row, currentCell.col].g + cells[newCell.row, newCell.col].cost;
                            cells[newCell.row, newCell.col].f = cells[newCell.row, newCell.col].g + Heuristic(newCell);
                            cells[newCell.row, newCell.col].parent.row = currentCell.row;
                            cells[newCell.row, newCell.col].parent.col = currentCell.col;
                            SetCell(newCell, opened);
                        }
                        else if (cells[newCell.row, newCell.col].g > cells[currentCell.row, currentCell.col].g + cells[newCell.row, newCell.col].cost)
                        {
                            cells[newCell.row, newCell.col].g = cells[currentCell.row, currentCell.col].g + cells[newCell.row, newCell.col].cost;
                            cells[newCell.row, newCell.col].f = cells[newCell.row, newCell.col].g + Heuristic(newCell);
                            cells[newCell.row, newCell.col].parent.row = currentCell.row;
                            cells[newCell.row, newCell.col].parent.col = currentCell.col;
                            SetCell(newCell, opened);
                            ResetCell(newCell, closed);
                        }
                    }

                    SetCell(currentCell, closed);
                    ResetCell(currentCell, opened);

                } while (opened.Count > 0 && pathFound == false);

                if (pathFound)
                {
                    path.Add(finishCell);
                    Coordinates currentCell = new Coordinates(finishCell.row, finishCell.col);
                    while (cells[currentCell.row, currentCell.col].parent.row >= 0)
                    {
                        path.Add(cells[currentCell.row, currentCell.col].parent);
                        int tmp_row = cells[currentCell.row, currentCell.col].parent.row;
                        currentCell.col = cells[currentCell.row, currentCell.col].parent.col;
                        currentCell.row = tmp_row;
                    }

                    //afisarea gridului
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A aparut o eroare! Asigura-te ca toate campurile sunt completate si incearca din nou!");
            }
        }

        public bool IsWall(int row, int col)
        {
            int[,] walls = new int[,] { { 1, 5 }, { 2, 2 }, { 4, 0 }, { 5, 5 }, { 6, 6 } };
            bool isWall = false;
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                if (walls[i, 0] == row && walls[i, 1] == col)
                    isWall = true;
            }
            return isWall;
        }

        public Coordinates ShorterExpectedPath()
        {
            int sep = 0;
            if (opened.Count > 1)
            {
                for (int i = 1; i < opened.Count; i++)
                {
                    if (cells[opened[i].row, opened[i].col].f < cells[opened[sep].row, opened[sep].col].f)
                    {
                        sep = i;
                    }
                }
            }
            return opened[sep];
        }

        public List<Coordinates> neighborCells(Coordinates c)
        {
            List<Coordinates> lc = new List<Coordinates>();

            for (int i = -1; i <= 1; i++)
            {
                if (c.row + i >= 0 && c.row + i < 8 && c.col + i >= 0 && c.col + i < 8 && (i != 0))
                {
                    lc.Add(new Coordinates(c.row + i, c.col));
                    lc.Add(new Coordinates(c.row, c.col + i));
                }

                if (c.row + i > 7 && c.col + i <= 7)
                {
                    lc.Add(new Coordinates(c.row, c.col + i));
                }

                if (c.col + i > 7 && c.row + i <= 7)
                {
                    lc.Add(new Coordinates(c.row + i, c.col));
                }
            }
            return lc;
        }

        public int Heuristic(Coordinates cell)
        {
            int dRow = Math.Abs(finishCell.row - cell.row);
            int dCol = Math.Abs(finishCell.col - cell.col);
            return Math.Max(dRow, dCol);
        }

        public void SetCell(Coordinates cell, List<Coordinates> coordinatesList)
        {
            if (coordinatesList.Contains(cell) == false)
            {
                coordinatesList.Add(cell);
            }
        }

        public void ResetCell(Coordinates cell, List<Coordinates> coordinatesList)
        {
            if (coordinatesList.Contains(cell))
            {
                coordinatesList.Remove(cell);
            }
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            AStar();
        }

        private void pictureGrid_Paint(object sender, PaintEventArgs e)
        {
            int squareSize = 20;
            Pen gridPen = Pens.Black;
            Pen wallPen = Pens.Red;

            // Draw horizontal lines
            for (int y = 0; y <= pictureGrid.Height; y += squareSize)
            {
                e.Graphics.DrawLine(gridPen, 0, y, pictureGrid.Width, y);
            }

            // Draw vertical lines
            for (int x = 0; x <= pictureGrid.Width; x += squareSize)
            {
                e.Graphics.DrawLine(gridPen, x, 0, x, pictureGrid.Height);
            }

            // Draw walls
            Point[] wallPositions = { new Point(1, 5), new Point(2, 2), new Point(4, 0), new Point(5, 5), new Point(6, 6) };
            foreach (Point wallPos in wallPositions)
            {
                int x = wallPos.X * squareSize;
                int y = wallPos.Y * squareSize;

                // Draw wall as a thick line
                e.Graphics.DrawLine(wallPen, x, y, x + squareSize, y + squareSize);
                e.Graphics.DrawLine(wallPen, x + squareSize, y, x, y + squareSize);
            }
        }
    }
}