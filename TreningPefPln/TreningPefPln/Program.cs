using TreningPefPln;

var op = new Class1();

op.ReadFile("input.txt");
File.WriteAllText("input.txt", " ");
op.Northwest();
op.WriteFile("output.txt");