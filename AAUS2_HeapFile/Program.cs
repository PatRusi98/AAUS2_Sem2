// See https://aka.ms/new-console-template for more information
using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.File;
using AAUS2_HeapFile.Tester;
using System.Diagnostics;
using static AAUS2_HeapFile.Helpers.Enums;

Console.WriteLine("Hello, World!");

Vehicle person1 = new Vehicle()
{
    Name = "Patrik",
    Surname = "Rusinak",
    ID = 51,
    LicencePlate = "ZA375ET"
};
Vehicle person2 = new Vehicle()
{
    Name = "Matej",
    Surname = "Rusinak",
    ID = 14,
    LicencePlate = "PR375ET"
};
Vehicle person3 = new Vehicle()
{
    Name = "Jozo",
    Surname = "Gec",
    ID = 1,
    LicencePlate = "RV375ET"
};
Vehicle person4 = new Vehicle()
{
    Name = "Jakub",
    Surname = "Dira",
    ID = 0,
    LicencePlate = "KKT12345"
};
Vehicle person5 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 44,
    LicencePlate = "SB375ET"
};
Vehicle person6 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 6,
    LicencePlate = "SB375ET"
};
Vehicle person7 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 7,
    LicencePlate = "SB375ET"
};
Vehicle person8 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 8,
    LicencePlate = "SB375ET"
};
Vehicle person9 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 9,
    LicencePlate = "SB375ET"
};
Vehicle person10 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 10,
    LicencePlate = "SB375ET"
};
Vehicle person11 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 11,
    LicencePlate = "SB375ET"
};
Vehicle person12 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 12,
    LicencePlate = "SB375ET"
};
Vehicle person13 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 13,
    LicencePlate = "SB375ET"
};
Vehicle person14 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 24,
    LicencePlate = "SB375ET"
};
Vehicle person15 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 15,
    LicencePlate = "SB375ET"
};
Vehicle person16 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 16,
    LicencePlate = "SB375ET"
};
Vehicle person17 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 17,
    LicencePlate = "SB375ET"
};
Vehicle person18 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 18,
    LicencePlate = "SB375ET"
};
Vehicle person19 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 19,
    LicencePlate = "SB375ET"
};
Vehicle person20 = new Vehicle()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 20,
    LicencePlate = "SB375ET"
};


//Dictionary<Vehicle, long> addresses = new();

//HeapFile<Vehicle> heapFile = new("data.bin", 3);
//var add = heapFile.Insert(person1);
//add = heapFile.Insert(person2);
//add = heapFile.Insert(person3);

//add = heapFile.Insert(person4);
//add = heapFile.Insert(person5);
//add = heapFile.Insert(person6);

//add = heapFile.Insert(person7);
//add = heapFile.Insert(person8);
//add = heapFile.Insert(person9);

//add = heapFile.Insert(person10);
//add = heapFile.Insert(person11);
//add = heapFile.Insert(person12);

//add = heapFile.Insert(person13);
//add = heapFile.Insert(person14);
//add = heapFile.Insert(person15);

//add = heapFile.Insert(person16);
//add = heapFile.Insert(person17);
//add = heapFile.Insert(person18);

//add = heapFile.Insert(person19);
//add = heapFile.Insert(person20);

//heapFile.Delete(0, person3);

//heapFile.Delete(334, person7);
//heapFile.Delete(334, person8);
//heapFile.Delete(334, person9);

//heapFile.Delete(668, person13);
//heapFile.Delete(668, person14);
//heapFile.Delete(668, person15);

//heapFile.Delete(1002, person19);
//heapFile.Delete(1002, person20);
//HeapFileTester tester = new("data.bin");

//for (int i = 0; i < 1000; i++)
//{
//    Debug.WriteLine("Epoch: " + i);
//    HeapFileTester tester = new($"data{i}.bin");
//    tester.CreateTestCase(100000, 100, 70, 0, 30);
//}

var heapFile = new HeapFile<Vehicle>("data.bin", 500);
var extHash = new ExtendibleHashing<VehicleIDToHashFile>("hash_id.bin", "data.bin", 500);

long add = 0;

add = heapFile.Insert(person1);

var p1 = new VehicleIDToHashFile() { ID = person1.ID, Address = add };
extHash.Insert(p1, HashProperty.ID);

add = heapFile.Insert(person2);

var p2 = new VehicleIDToHashFile() { ID = person2.ID, Address = add };
extHash.Insert(p2, HashProperty.ID);

var s1 = new VehicleIDToHashFile() { ID = person1.ID };
var searched = extHash.Search(s1, HashProperty.ID);

searched.Address = add;
//heapFile.Get(add, );

Console.WriteLine("tu brejkac");
