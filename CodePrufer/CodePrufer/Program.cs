using CodePrufer;

//var cp = new Class1();

//cp.ReadFromFile("input.txt");

//int[] code = cp.Encode();

//cp.WriteFile("output.txt", code);


Class1 cp = new Class1();

cp.ReadFile("input.txt");
int[] code = cp.Encode();

cp.WriteFile("otput.txt", code);