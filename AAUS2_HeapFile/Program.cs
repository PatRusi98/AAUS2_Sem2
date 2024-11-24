// See https://aka.ms/new-console-template for more information
using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.File;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

Person person1 = new Person()
{
    Name = "Patrik",
    Surname = "Rusinak",
    ID = 51,
    LicencePlate = "ZA375ET"
};
Person person2 = new Person()
{
    Name = "Matej",
    Surname = "Rusinak",
    ID = 14,
    LicencePlate = "PR375ET"
};
Person person3 = new Person()
{
    Name = "Jozo",
    Surname = "Gec",
    ID = 1,
    LicencePlate = "RV375ET"
};
Person person4 = new Person()
{
    Name = "Jakub",
    Surname = "Dira",
    ID = 0,
    LicencePlate = "KKT12345"
};
Person person5 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 44,
    LicencePlate = "SB375ET"
};
Person person6 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 6,
    LicencePlate = "SB375ET"
};
Person person7 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 7,
    LicencePlate = "SB375ET"
};
Person person8 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 8,
    LicencePlate = "SB375ET"
};
Person person9 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 9,
    LicencePlate = "SB375ET"
};
Person person10 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 10,
    LicencePlate = "SB375ET"
};
Person person11 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 11,
    LicencePlate = "SB375ET"
};
Person person12 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 12,
    LicencePlate = "SB375ET"
};
Person person13 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 13,
    LicencePlate = "SB375ET"
};
Person person14 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 24,
    LicencePlate = "SB375ET"
};
Person person15 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 15,
    LicencePlate = "SB375ET"
};
Person person16 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 16,
    LicencePlate = "SB375ET"
};
Person person17 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 17,
    LicencePlate = "SB375ET"
};
Person person18 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 18,
    LicencePlate = "SB375ET"
};
Person person19 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 19,
    LicencePlate = "SB375ET"
};
Person person20 = new Person()
{
    Name = "Laura",
    Surname = "Simcikova",
    ID = 20,
    LicencePlate = "SB375ET"
};


Dictionary<Person, long> addresses = new();

HeapFile<Person> heapFile = new("data.bin", 3);
var add = heapFile.Insert(person1);
add = heapFile.Insert(person2);
add = heapFile.Insert(person3);

add = heapFile.Insert(person4);
add = heapFile.Insert(person5);
add = heapFile.Insert(person6);

add = heapFile.Insert(person7);
add = heapFile.Insert(person8);
add = heapFile.Insert(person9);

add = heapFile.Insert(person10);
add = heapFile.Insert(person11);
add = heapFile.Insert(person12);

add = heapFile.Insert(person13);
add = heapFile.Insert(person14);
add = heapFile.Insert(person15);
    
add = heapFile.Insert(person16);
add = heapFile.Insert(person17);
add = heapFile.Insert(person18);

add = heapFile.Insert(person19);
add = heapFile.Insert(person20);

//var result5 = heapFile.Get(1, person5);
//var value = addresses.Where(x => x.Key == person1).First();
//var result1 = heapFile.Get(value.Value, value.Key);
//var result2 = heapFile.Get(0, person2);
//var result3 = heapFile.Get(0, person5);
//var result4 = heapFile.Get(0, person4);

heapFile.Delete(0, person3);

heapFile.Delete(334, person7);
heapFile.Delete(334, person8);
heapFile.Delete(334, person9);

heapFile.Delete(668, person13);
heapFile.Delete(668, person14);
heapFile.Delete(668, person15);

heapFile.Delete(1002, person19);
heapFile.Delete(1002, person20);

heapFile.Dispose();


Console.WriteLine("gec");
