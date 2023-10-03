// Задача:
// Написать программу, которая из имеющегося массива строк формирует новый массив из строк, 
// длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, 
// лучше обойтись исключительно массивами.

// Приверы: 
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []


string[] words = Prompt("Введите слова через пробел: ");
Print(words, moveToLine: false);

int[] shortWordIndexes = GetIndexesWithLength(words, 3);
string[] shortWords = GetWordsByIndexes(words, shortWordIndexes);

Console.Write(" -> ");
Print(shortWords);



string[] Prompt(string message)
{
    Console.Write(message);
    return Console.ReadLine()!.Split();
}

void Print(string[] list, bool moveToLine = true)
{
    string joinedList = string.Join(", ", list);
    Console.Write($"[{joinedList}]");

    if (moveToLine)
    {
        Console.WriteLine();
    }
}

int[] GetIndexesWithLength(string[] list, int maxLength)
{
    int[] indexes = new int[list.Length];
    int pos = 0;

    for (int i = 0; i < list.Length; i++)
    {
        if (list[i].Length <= maxLength)
        {
            indexes[pos] = i;
            pos++;
        }
    }

    int[] resultIndexes = new int[pos];
    Array.Copy(indexes, 0, resultIndexes, 0, pos);

    return resultIndexes;
}

string[] GetWordsByIndexes(string[] list, int[] indexes)
{
    string[] result = new string[indexes.Length];

    for (int i = 0; i < indexes.Length; i++)
    {
        int wordIndex = indexes[i];
        result[i] = list[wordIndex];
    }

    return result;
}



Console.WriteLine();
Console.WriteLine("===== Тесты  =====");

string[] input = { "Hello", "2", "world", ":-)" };
string[] expected = { "2", ":-)" };

Test(input, expected);


string[] input2 = { "1234", "1567", "-2", "computer science" };
string[] expected2 = { "-2" };

Test(input2, expected2);


string[] input3 = { "Russia", "Denmark", "Kazan" };
string[] expected3 = { };

Test(input3, expected3);


void Test(string[] list, string[] expected)
{
    int[] shortWordIndexes = GetIndexesWithLength(list, 3);
    string[] shortWords = GetWordsByIndexes(list, shortWordIndexes);

    if (!isEqual(shortWords, expected))
    {

        Print(list, moveToLine: false);
        Console.Write(" -> ");
        Print(shortWords, moveToLine: false);
        Console.Write(" - Провален. Ожидается: ");
        Print(expected);
    }
    else
    {

        Print(list, moveToLine: false);
        Console.Write(" -> ");
        Print(expected, moveToLine: false);
        Console.WriteLine(" - Успешно");
    }
}

bool isEqual(string[] list1, string[] list2)
{
    if (list1.Length != list2.Length) return false;

    for (int i = 0; i < list1.Length; i++)
    {
        if (list1[i] != list2[i]) return false;
    }

    return true;
}