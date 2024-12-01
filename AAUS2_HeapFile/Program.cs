// See https://aka.ms/new-console-template for more information
using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.File;
using AAUS2_HeapFile.Tester;
using AAUS2_SemPraca;
using static AAUS2_HeapFile.Helpers.Enums;

//var heapFile = new HeapFile<Vehicle>("data.bin", 500);
//var extHash = new ExtendibleHashing<VehicleIDToHashFile>("hash_id.bin", "data.bin", 500);

//long add = 0;

//add = heapFile.Insert(person1);

//var p1 = new VehicleIDToHashFile() { ID = person1.ID, Address = add };
//extHash.Insert(p1, HashProperty.ID);

//add = heapFile.Insert(person2);

//var p2 = new VehicleIDToHashFile() { ID = person2.ID, Address = add };
//extHash.Insert(p2, HashProperty.ID);

//var s1 = new VehicleIDToHashFile() { ID = person1.ID };
//var searched = extHash.Search(s1, HashProperty.ID);

//searched.Address = add;
//heapFile.Get(add, );

// GUI
ApplicationConfiguration.Initialize();
Application.Run(new Form1());

SemTester tester = new();
tester.TestInsert(20000);

Console.WriteLine("tu brejkac");
