# Lavaver LogConsole: A Lightweight C# Logging Library

Lavaver LogConsole is a lightweight C# logging library designed to provide developers with a portable logging solution that is short, compact, and efficient.

> 若需要中文版，请[查看此处](README_zh-CN.md)

## Features

- Lightweight and easy to integrate.
- Supports multiple logging levels (Info, Warn, Error, etc.).
- Designed for simplicity and efficiency.

## Getting Started

### Importing the Library

1. **Download the Library**:
    - Download the latest version of LogConsole from the [Releases page](https://github.com/lavaver/LogConsole/releases).

2. **Add the Library to Your Project**:
    - Open your solution in Visual Studio.
    - Right-click on "Dependencies" in the Solution Explorer.
    - Select "Add Item Reference" and click "Browse (B)...".
    - Double-click on the downloaded library file (usually a .dll).

3. **Include the Namespace**:
    - In your code file, add the following using directive:
      ```csharp
      using LogConsole;
      ```

### Basic Usage

Here's how to get started with logging:

```csharp
using LogConsole;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Builtin.Info("This is an info message");
            Builtin.Warn("This is a warning message");
            Builtin.Err("This is an error message");
            Builtin.Init("Initialization message");
            Builtin.Debug("Debugging message");
            Builtin.R5("Software special operation message");
        }
    }
}
```

### Customize Usage

If you are not satisfied with these log levels built into the library, you can customize your own logs:

```csharp
using LogConsole;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Customize("Log Level", "Message(s)", <foreground color>, [isError], [logToFile]);
        }
    }
}
```

The following is a list of available parameters:

| parameter | type | compulsory | hint |
| --- | --- | --- | --- |
| logLevel | string | Necessarily | Logging Level(s) |
| log | string | Necessarily | Log Message(s) |
| color | ConsoleColor (enum) | Necessarily | Foreground color |
| isError | bool | Optional | Whether or not to log errors. Default is no (false) |
| logToFile | bool | Optional | Whether to write to the log file. Default is yes (true) |

# ENJOY!