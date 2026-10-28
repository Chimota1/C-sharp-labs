using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace lab10_2
{
    public partial class MainWindow : Window
    {
        List<string> vertices = new List<string>
        {
            "a","b","c","d","e","f","g","h"
        };

        List<(string, string)> edges = new List<(string, string)>
        {
            ("a","b"),
            ("a","c"),
            ("a","e"),
            ("c","e"),
            ("c","f"),
            ("f","e"),
            ("f","h"),
            ("e","h"),
            ("g","h"),
            ("g","e"),
            ("g","d"),
            ("d","e"),
            ("b","e"),
            ("b","d")
        };

        public MainWindow()
        {
            InitializeComponent();
            LoadMatrices();
        }

        // ===============================
        // МАТРИЦЯ СУМІЖНОСТІ
        // ===============================
        private DataTable CreateAdjacencyMatrix()
        {
            int n = vertices.Count;
            int[,] matrix = new int[n, n];

            foreach (var (u, v) in edges)
            {
                int i = vertices.IndexOf(u);
                int j = vertices.IndexOf(v);
                matrix[i, j] = 1;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(" ", typeof(string));

            foreach (string v in vertices)
                dt.Columns.Add(v, typeof(int));

            for (int i = 0; i < n; i++)
            {
                var row = dt.NewRow();
                row[0] = vertices[i];

                for (int j = 1; j <= n; j++)
                {
                    row[j] = matrix[i, j - 1];
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        private DataTable CreateIncidenceMatrix()
        {
            int n = vertices.Count;
            int m = edges.Count;
            int[,] matrix = new int[n, m];

            for (int e = 0; e < m; e++)
            {
                var (u, v) = edges[e];
                int i = vertices.IndexOf(u);
                int j = vertices.IndexOf(v);

                matrix[i, e] = -1; // вихід з вершини
                matrix[j, e] = 1;  // вхід у вершину
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Vertex", typeof(string));

            for (int e = 0; e < m; e++)
                dt.Columns.Add($"{edges[e].Item1}->{edges[e].Item2}", typeof(int));

            for (int i = 0; i < n; i++)
            {
                var row = dt.NewRow();
                row[0] = vertices[i];

                for (int e = 0; e < m; e++)
                    row[e + 1] = matrix[i, e];

                dt.Rows.Add(row);
            }

            return dt;
        }
        private void LoadMatrices()
        {
            AdjMatrixGrid.ItemsSource = CreateAdjacencyMatrix().DefaultView;
            IncMatrixGrid.ItemsSource = CreateIncidenceMatrix().DefaultView;
        }
    }
}
