using TreningPefPln;

var op = new Class1();

op.ReadFile("input.txt");
File.WriteAllText("output.txt", " ");
//op.Northwest();
op.MinEl();
op.WriteFile("output.txt");