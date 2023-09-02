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

var personsWithNotPhone = from person in persons
    where person.Phones.Count() == 0
    select new {FullName = $"{person.LastName} {person.FirstName}"};
foreach (var item in personsWithNotPhone)
{
    Console.WriteLine(item.FullName);
}

var result = from person1 in persons
    from phone in person1.Phones
    let number = "904"
    where phone.Contains(number)
    select (person1.LastName, phone);
foreach (var (lastName, phone) in result)
{
    Console.WriteLine($"{lastName} -> {phone}");
}

return;