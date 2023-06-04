namespace NumberProvinces
{
	internal class Program
	{
		public class NumberProvinces
		{
			private List<int>[] GetAdj(int[][] isConnected)
			{
				List<int>[] adj = new List<int>[isConnected.Length];
				for (int r = 0; r < isConnected.Length; ++r)
				{
					adj[r] = new List<int>();
					for (int c = 0; c < isConnected[r].Length; ++c)
					{
						if (isConnected[r][c] == 1 && r != c)
						{
							adj[r].Add(c);
						}
					}
				}
				return adj;
			}

			private void DFS(List<int>[] adj, bool[] visited, int node)
			{
				if (visited[node])
				{
					return;
				}
				visited[node] = true;
				foreach(int edge in adj[node])
				{
					DFS(adj, visited, edge);
				}
			}

			public int FindCircleNum(int[][] isConnected)
			{
				int n = isConnected.Length;
				int circleNum = 0;
				bool[] visited = new bool[n];
				List<int>[] adj = GetAdj(isConnected);
				for (int node = 0; node < n; ++node)
				{
					if (!visited[node])
					{
						DFS(adj, visited, node);
						++circleNum;
					}
				}
				return circleNum;
			}
		}

		static void Main(string[] args)
		{
			NumberProvinces numberProvinces = new();
            Console.WriteLine(numberProvinces.FindCircleNum(new int[][]
			{
				new int[] { 1, 1, 0 },
				new int[] { 1, 1, 0 },
				new int[] { 0, 0, 1 }
			}));
			Console.WriteLine(numberProvinces.FindCircleNum(new int[][]
			{
				new int[] { 1, 0, 0 },
				new int[] { 0, 1, 0 },
				new int[] { 0, 0, 1 }
			}));
		}
	}
}