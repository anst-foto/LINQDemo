using LINQDemo;

var persons = new List<Person>()
{
    new(LastName: "Starinin",
        FirstName: "Andrey",
        Phones: new List<string>{"+79042144491", "+74732575755"}),
    new(LastName: "Anonimus",
        FirstName: "Anonim",
        Phones: Array.Empty<string>())
};
Console.WriteLine("Исходные данные");
foreach (var (first, last, phones) in persons)
{
    Console.WriteLine($"{last} {first}:");
    foreach (var phone in phones)
    {
        Console.Write($"{phone} ");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();

Console.WriteLine("фильтрация элементов (простая, classic)");

var filteredPersons = from person2 in persons
    where person2.LastName == "Anonimus"
    select person2;
foreach (var person in filteredPersons)
{
    Console.WriteLine($"{person.LastName} {person.FirstName}");
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();

Console.WriteLine("фильтрация элементов (простая, Fluent API)");

var filteredPersons1 = persons.Where(p => p.LastName == "Anonimus");
foreach (var person in filteredPersons1)
{
    Console.WriteLine($"{person.LastName} {person.FirstName}");
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();


Console.WriteLine("фильтрация элементов (с созданием анонимного класса, classic)");
var personsWithNotPhone = from person in persons
    where person.Phones.Count() == 0
    select new {FullName = $"{person.LastName} {person.FirstName}"};
foreach (var item in personsWithNotPhone)
{
    Console.WriteLine(item.FullName);
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();

Console.WriteLine("фильтрация элементов (с созданием анонимного класса, Fluent API)");
var personsWithNotPhone1 = persons
    .Where(p => p.Phones.Count() == 0)
    .Select(p => new {FullName = $"{p.LastName} {p.FirstName}"});
foreach (var item in personsWithNotPhone1)
{
    Console.WriteLine(item.FullName);
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();

Console.WriteLine("фильтрация элементов (с созданием кортежа и использования внутризапросовой переменной и двух источников данных, classic)");

var result = from person1 in persons
    from phone in person1.Phones
    let number = "904"
    where phone.Contains(number)
    select (person1.LastName, phone);
foreach (var (lastName, phone) in result)
{
    Console.WriteLine($"{lastName} -> {phone}");
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();

Console.WriteLine("фильтрация элементов (с созданием кортежа и использования внутризапросовой переменной и двух источников данных, Fluent API)");

var number1 = "904";
var result1 = persons
    .Where(p => p.Phones.Contains(number1))
    .Select(p => new
    {
        LastName = p.LastName, 
        Phone = p.Phones.First(ph => ph.Contains(number1))
    });
    
foreach (var item in result1)
{
    Console.WriteLine($"{item.LastName} -> {item.Phone}");
}

Console.WriteLine();
Console.WriteLine("////////////////////");
Console.WriteLine();

return;