# Lavaver LogConsole： 轻量级 C# 日志库

Lavaver LogConsole 是一个轻量级 C# 日志库，旨在为开发人员提供简短、紧凑、高效的可移植日志记录解决方案。

## 功能特点

- 轻量级，易于集成。
- 支持多种日志级别（信息、警告、错误等）。
- 设计简洁高效。

## 入门指南

### 导入程序库

1. **下载程序库**：
    - 从 [Releases page](https://github.com/lavaver/LogConsole/releases) 下载最新版本的 LogConsole。

2. **将库添加到项目中**：
    - 在 Visual Studio 中打开解决方案。
    - 右键单击解决方案资源管理器中的 "依赖项"。
    - 选择 "添加项目引用 "并单击 "浏览 (B)..."。
    - 双击下载的库文件（通常是 .dll）。

3. **包含命名空间**：
    - 在代码文件中添加以下 using 指令：
      ```csharp
        using LogConsole；
      ```

### 基本用法

下面介绍如何开始记录日志：

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

### 自定义使用

如果对库中内置的这些日志级别不满意，可以自定义自己的日志：

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

可用参数列表如下：

| 参数 | 类型 | 是否必选 | 提示 |
| --- | --- | --- | --- |
| logLevel | string | 是 | 日志级别 |
| log | string | 是 | 日志信息 |
| color | ConsoleColor（枚举） | 是 | 前景色 |
| isError | bool | 否 | 是否记录错误。默认为否（false）|
| logToFile | bool | 否 | 是否写入日志文件。默认为是（true）|

# ENJOY!