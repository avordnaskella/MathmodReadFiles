using Dijkstra;

var dj = new Class1();

dj.ReadFile("input.txt");
int [] result = dj.FindShortPath();
dj.WriteFile("output.txt", result);

