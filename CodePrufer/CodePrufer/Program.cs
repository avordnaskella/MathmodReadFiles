using CodePrufer;


//string inputFile = "input.txt";
//string outputFile = "output.txt";

//Class1.ReadFromFile(inputFile);

//int[] code = Class1.Encode();

//Class1.WriteToFile(outputFile, code);

var cp = new Class1();

cp.ReadFromFile("input.txt");

int[] code = cp.Encode();

cp.WriteFile("output.txt", code);