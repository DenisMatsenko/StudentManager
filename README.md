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
I used a dictionary to store students because the most important program feature of adding marks to specific students required fast access to those students.
- A Dictionary is better for finding an element because it has a time complexity of O(1), meaning it takes a constant amount of time, while a List has a time complexity of O(n), meaning it takes longer as the List grows. Therefore, a Dictionary is a faster and more efficient option for searching elements in a data structure.

I used a List to store students because the most important program feature of adding marks to students required fast adding new elemet to collection.
- A List is a good choice for adding new elements because it is designed as a dynamic array, allowing for efficient adding new elements to the end with a time complexity of O(1) or O(n) if the capacity of the list needs to be increased.





