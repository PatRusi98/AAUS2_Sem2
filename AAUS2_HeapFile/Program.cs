using AAUS2_HeapFile.Tester;
using AAUS2_SemPraca;

// GUI
//ApplicationConfiguration.Initialize();
//Application.Run(new Form1());

for (int i = 0; i < 10; i++)
{
    SemTester tester = new();
    for (int j = 0; j < 20000; j++)
    {
        tester.TestInsert(1);
        tester.TestSearch();
    }
}

Console.WriteLine("tu brejkac");
