# StudentManager
This text has been structured, grouped, formatted and corrected (grammatically) by artificial intelligence.

---

### Interfaces
An interface provides a way to achieve abstraction in C#.

An interface enable multiple inheritance in C#, by allowing a class, a struct or another interface to implement more than one interface.

An interface can only contain declarations of members, not their implementations. (In C# 8.0+ appeared a very controversial feature as default implementations which can be overridden by the inheriting types)
```
interface ILogger
{
    void Log(string message);
    
    // default implementation
    void LogError(string message) => Log($"Error: {message}");
}
```

An interface cannot contain fields, constructors.

---

### Work with files
Files allow to store and retrieve data in a persistent and structured way. Files can be used to save user preferences, application settings, logs, reports, etc. You can also read and write data from various sources and formats, such as text, binary, CSV, JSON, XML, etc.

To create, copy, delete, move, or open a single file, you can use the static methods of the File class. 
- For example, `File.Create(path)` creates a file at the specified path and returns a FileStream object that can be used to read or write to the file.

To read or write text from or to a file, you can use the StreamReader and StreamWriter classes. 
 - For example, `StreamReader sr = new StreamReader(path)` creates a StreamReader object that can read text from the file at the specified path. Similarly, `StreamWriter sw = new StreamWriter(path)` creates a StreamWriter object that can write text to the file at the specified path.

To parse data in files, such as CSV or JSON files, you can use various libraries depending on the format and structure of the data. 
 - For example, to parse CSV data, you can use the TextFieldParser class from the Microsoft.VisualBasic.FileIO namespace. To parse JSON data, you can use the JsonSerializer class from the System.Text.Json namespace.
 
---

### Collections
I used a Dictionary to store students and a List to store marks. I chose a Dictionary because the program will assign many marks to students and using a key is better than iterating through all students.(A dictionary is better than a list when you want to look up a value using a key. A dictionary uses a hash function to find the value in one step. A list requires iterating through the elements until you find the match. This can take many steps.) I chose a List to store marks because it is easy to use in development.





