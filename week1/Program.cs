var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => " week1! : preparation, week plan and homework");

//week1 preparation
app.MapGet("/info", () => Environment.Version);
app.MapGet("/if-else", (int number) => number >= 0 ? "Positive number" : "Negative number");
app.MapGet("/greeting", (string name) =>
{
  string greeting;
  switch (name)
  {
    case "Kiran":
      greeting = "Hey, Kiran!";
      break;
    case "Zahra":
      greeting = "Hi, Zahra!";
      break;
    case "Divya":
      greeting = "Ola, Divya!";
      break;
    default:
      greeting = $"Hello, {name}!";
      break;
  }
  return greeting;
});

app.MapGet("/temperature", (int degrees) =>
{
  string description = "";
  switch (degrees)
  {
    case < 0:
      description = "freezing";
      break;
    case > 0 and < 10: // this is done just to show possibility < 10 is enough in this case but
      description = "cold";
      break;
    case < 25:
      description = "mild";
      break;
    default:
      description = "hot";
      break;
  };
  return $"The temperature of {degrees} degrees Celsius is considered {description}.";
});
app.MapGet("/for", (int number) =>
{
  int sum = 0;

  for (int i = 0; i <= number; i++)
  {
    sum += i;
  }

  return sum;
});
app.MapGet("/do-while", (int number) =>
{
  int sum = 0;
  int i = 0;

  do
  {
    sum += i;
    i++;
  } while (i <= number);

  return sum;
});
app.MapGet("/while", (int number) =>
{
  int sum = 0;
  int i = 0;

  while (i <= number)
  {
    sum += i;
    i++;
  }

  return sum;
});
app.MapGet("/for-each", (string anytext) =>
{
  string myString = anytext;
  string result = "";

  foreach (char c in myString)
  {
    result += c + " ";
  }

  return result;
});

//week1 lesson plan
app.MapGet("/ab", (int a, int b) => a + b);
app.MapGet("/str", (string str) => new { content = $"{str}" });
app.MapGet("/s", (string str) => int.TryParse(str, out int value) ? $" the value: '{str}' was int" : $"The value '{str}' in input is not a valid number");

//week1 homework
app.MapGet("/stringreverse", (string input) =>
{
  string reversed = ReverseString(input); //TODO: Implement ReverseString
  Console.WriteLine($"Reversed input value: {reversed}");
  return reversed;
});

app.MapGet("/stringreverse2", (string input) =>
{
  string reversed = ReverseString2(input); //TODO: Implement ReverseString
  Console.WriteLine($"Reversed input value: {reversed}");
  return reversed;
});

app.MapGet("/vowelcount", () =>
{
  string input = "Intellectualization";
  int vowelCount = GetVowelCount(input.ToLower()); //TODO: Implement GetVowelCount
  Console.WriteLine($"Number of vowels: {vowelCount}");
  return vowelCount;
});
app.MapGet("/vowelcount2", (string input) =>
{
  int vowelCount = GetVowelCount2(input.ToLower()); //TODO: Implement GetVowelCount
  Console.WriteLine($"Number of vowels: {vowelCount}");
  return vowelCount;
});

app.MapGet("/gettwoarrays", () =>
{
  int[] arr = new[] { 271, -3, 1, 14, -100, 13, 2, 1, -8, -59, -1852, 41, 5 };
  int[] result = GetResult(arr); //TODO: Implement GetResult
  return ($"Sum of negative numbers: {result[0]}. Multiplication of positive numbers: {result[1]}");
});

app.MapGet("/gettwoarrays2", () =>
{
  int[] arr = new[] { 271, -3, 1, 14, -100, 13, 2, 1, -8, -59, -1852 };
  int[] result = GetResult2(arr); //TODO: Implement GetResult
  return ($"Sum of negative numbers: {result[0]}. Multiplication of positive numbers: {result[1]}");
});

app.MapGet("/fibonacci", () =>
{
  int input = 7;
  int result = Fibonacci(input);
  return $"Nth fibonacci number is {result}";
});

app.MapGet("/fibonacci2", (string n) =>
{
  int result = Fibonacci2(n);
  return result;
});

app.MapGet("/dividearray", () =>
{
  int[] input = new[] { 1, 2, 5, 7, 2, 3 };
  int[] result = GetOneArray(input);
  return result;
});

app.MapGet("/dividearray2", () =>
{
  Object res;
  int[] input = new[] { 1, 2, 5, 7, 2, 9, 9, 9, 8, 8 };
  if (input.Length % 2 != 0) { res = ($" The array {System.Text.Json.JsonSerializer.Serialize(input)} has {input.Length} items. it must have even length"); }
  else
  {
    int[] result = GetOneArray2(input);
    res = result;
    // return result;
  }
  return res;
});

app.Run();

string ReverseString(string stringtoreverse)
{
  char[] charArray = stringtoreverse.ToCharArray();
  Array.Reverse(charArray);
  return new String(charArray);
}

string ReverseString2(string stringtoreverse)
{
  char[] chars = new char[stringtoreverse.Length];
  for (int i = 0; i < stringtoreverse.Length; i++)
  {
    chars[i] = stringtoreverse[(stringtoreverse.Length - 1) - i];
  }
  // var chars = input.ToCharArray().Reverse();
  return string.Join("", chars);
}

int GetVowelCount(string word)
{
  int count = 0;
  foreach (char c in word)
  {
    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
    {
      count += 1;
    }
  }
  return count;
}
int GetVowelCount2(string word)
{
  var vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
  int count = 0;
  foreach (char c in word)
  {
    if (vowels.Contains(c)) count++;
  }
  return count;
}

int[] GetResult(int[] arr)
{
  int countN = 0;
  int countP = 1;
  foreach (int item in arr)
  {
    if (item < 0) countN += item;
    if (item > 0) countP *= item;
  }
  return new[] { countN, countP };
}




int[] GetResult2(int[] arr)
{
  var mathArray = new int[2];
  int neg = 0;
  int pos = 1;
  foreach (var item in arr)
  {
    if (item < 0) neg += item;
    if (item > 0) pos *= item;
  }
  mathArray[0] = neg;
  mathArray[1] = pos;
  return mathArray;
}

int[] GetOneArray(int[] input)
{
  int mid = input.Length / 2;
  int[] first = input.Take(mid).ToArray();
  int[] second = input.Skip(mid).ToArray();
  // var first = input.Take(mid).ToArray();
  // var second = input.Skip(mid).ToArray();

  var sumArr = new int[mid];

  if (input.Length % 2 != 0)
  {
    Console.WriteLine($"{input} array must have even length");
  }
  else
  {
    for (var i = 0; i < first.Length; i++)
    {
      var sum = 0;
      sum = first[i] + second[i];
      sumArr[i] = sum;
    }
  }

  Console.WriteLine($"{sumArr}");
  return sumArr;
}
int[] GetOneArray2(int[] input)
{
  int mid = input.Length / 2;
  var first = input[..mid];
  var second = input[mid..];
  var sumArr = new int[mid];

  for (var i = 0; i < first.Length; i++)
  {
    var sum = 0;
    sum = first[i] + second[i];
    sumArr[i] = sum;
  }
  return sumArr;
}

int Fibonacci(int number)
{
  int firstNum = 0, secondNum = 1, nextNum = 0;
  for (int i = 2; i <= number; i++)
  {
    nextNum = firstNum + secondNum;
    firstNum = secondNum;
    secondNum = nextNum;
  }
  Console.WriteLine($"Nth fibonacci number is {secondNum}");
  return secondNum;
}

int Fibonacci2(string n)
{
  var fibList = new List<int>() { 1, 1 };
  if (int.TryParse(n, out int number))
  {
    if (number <= 2) return 1;
    for (var i = 2; i < number; i++)
    {
      fibList.Add(fibList[fibList.Count - 1] + fibList[fibList.Count - 2]);
    }
    System.Console.WriteLine($"unable to parse '{n}'!");
  }
  return fibList[fibList.Count - 1];
}