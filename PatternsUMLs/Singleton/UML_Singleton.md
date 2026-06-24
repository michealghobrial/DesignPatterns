# UML Diagram: Singleton Pattern

## Class Diagram

```
┌─────────────────────────────────────────┐
│          Singleton                      │
├─────────────────────────────────────────┤
│ - instance: Singleton (static)          │
│ - data: string                          │
├─────────────────────────────────────────┤
│ - Singleton()                           │  ← Private Constructor
│ + GetInstance(): Singleton (static)     │
│ + DoSomething(): void                   │
└─────────────────────────────────────────┘
       △
       │ has only one instance
       │
   [instance]
```

## Sequence Diagram

```
Client1              Singleton             Client2
  │                      │                    │
  │ GetInstance()        │                    │
  ├─────────────────────>│                    │
  │                      │                    │
  │  check if instance == null               │
  │                      │                    │
  │  create new instance │                    │
  │                      │                    │
  │  return instance     │                    │
  │<─────────────────────┤                    │
  │                      │                    │
  │                      │   GetInstance()    │
  │                      │<───────────────────┤
  │                      │                    │
  │                      │  return same instance
  │                      ├───────────────────>│
  │                      │                    │
  │  DoSomething()       │                    │
  ├─────────────────────>│                    │
  │                      │  DoSomething()     │
  │                      │<───────────────────┤
  │                      │                    │
         (Both clients use SAME instance)
```

## Key Characteristics

**Purpose:**

- Ensure a class has only ONE instance
- Provide a global point of access to that instance

**Advantages:**

- ✓ Controlled access to sole instance
- ✓ Reduced namespace pollution
- ✓ Permits refinement of operations and representation
- ✓ Lazy initialization (created when first needed)
- ✓ Better than global variables

**Disadvantages:**

- ✗ Difficult to unit test (global state)
- ✗ Violates Single Responsibility Principle
- ✗ Can mask bad design (when used as a global)
- ✗ Threading issues if not implemented carefully
- ✗ Issues in multi-threaded environments

**When to Use:**

- Need exactly one instance of a class
- Instance should be accessible from well-known access point
- Sole instance should be extensible by subclassing

## Implementation Variations

### 1. Lazy Initialization (NOT Thread-Safe)

```csharp
public class Singleton
{
    private static Singleton instance;
    private string data;

    // Private constructor prevents instantiation from outside
    private Singleton()
    {
        data = "Singleton Instance Data";
    }

    public static Singleton GetInstance()
    {
        if (instance == null)
            instance = new Singleton();

        return instance;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Singleton working with: {data}");
    }
}

// Usage
Singleton s1 = Singleton.GetInstance();
Singleton s2 = Singleton.GetInstance();
Console.WriteLine(s1 == s2); // True - same instance
```

**Pros:** Simple, lazy initialization  
**Cons:** ❌ NOT thread-safe

---

### 2. Thread-Safe with Double-Check Locking

```csharp
public sealed class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();
    private string data;

    private Singleton()
    {
        data = "Thread-Safe Singleton Data";
    }

    public static Singleton GetInstance()
    {
        if (instance == null) // First check (no lock)
        {
            lock (lockObject)
            {
                if (instance == null) // Second check (with lock)
                {
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Thread-safe singleton: {data}");
    }
}
```

**Pros:** Thread-safe, lazy initialization, good performance  
**Cons:** More complex

---

### 3. Eager Initialization (Thread-Safe)

```csharp
public sealed class Singleton
{
    // Instance created at class load time
    private static readonly Singleton instance = new Singleton();
    private string data;

    private Singleton()
    {
        data = "Eager Singleton Data";
    }

    public static Singleton GetInstance()
    {
        return instance;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Eager singleton: {data}");
    }
}
```

**Pros:** Simple, thread-safe by CLR  
**Cons:** Instance created even if never used

---

### 4. Lazy<T> (Recommended for C#)

```csharp
public sealed class Singleton
{
    // .NET 4+ Lazy<T> type handles thread-safety
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());

    private string data;

    private Singleton()
    {
        data = "Lazy<T> Singleton Data";
    }

    public static Singleton GetInstance()
    {
        return lazy.Value;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Lazy<T> singleton: {data}");
    }
}
```

**Pros:** ✅ Simple, thread-safe, lazy, best practice for C#  
**Cons:** Requires .NET 4+

---

### 5. Nested Class (Thread-Safe Lazy)

```csharp
public sealed class Singleton
{
    private string data;

    private Singleton()
    {
        data = "Nested Class Singleton Data";
    }

    // Nested class for lazy initialization
    private class SingletonHolder
    {
        // Instantiated on first reference to Instance
        internal static readonly Singleton instance = new Singleton();

        // Explicit static constructor
        static SingletonHolder()
        {
        }
    }

    public static Singleton GetInstance()
    {
        return SingletonHolder.instance;
    }

    public void DoSomething()
    {
        Console.WriteLine($"Nested singleton: {data}");
    }
}
```

**Pros:** Thread-safe, lazy, no locks needed  
**Cons:** Slightly more complex

---

## Comparison Table

| Implementation    | Thread-Safe | Lazy Init | Performance | Complexity | Recommended |
| ----------------- | ----------- | --------- | ----------- | ---------- | ----------- |
| Basic Lazy        | ❌          | ✅        | High        | Low        | ❌          |
| Double-Check Lock | ✅          | ✅        | High        | Medium     | ⚠️          |
| Eager             | ✅          | ❌        | High        | Low        | ⚠️          |
| **Lazy<T>**       | ✅          | ✅        | High        | Low        | ✅✅✅      |
| Nested Class      | ✅          | ✅        | High        | Medium     | ✅          |

## Real-World Examples

### Configuration Manager

```csharp
public sealed class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> lazy =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    private Dictionary<string, string> settings;

    private ConfigurationManager()
    {
        // Load configuration from file
        settings = new Dictionary<string, string>
        {
            { "DatabaseConnection", "Server=localhost;..." },
            { "ApiKey", "abc123..." }
        };
    }

    public static ConfigurationManager Instance => lazy.Value;

    public string GetSetting(string key)
    {
        return settings.ContainsKey(key) ? settings[key] : null;
    }
}

// Usage
string dbConn = ConfigurationManager.Instance.GetSetting("DatabaseConnection");
```

### Logger

```csharp
public sealed class Logger
{
    private static readonly Lazy<Logger> lazy =
        new Lazy<Logger>(() => new Logger());

    private StreamWriter logWriter;

    private Logger()
    {
        logWriter = new StreamWriter("app.log", append: true);
    }

    public static Logger Instance => lazy.Value;

    public void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        logWriter.WriteLine($"[{timestamp}] {message}");
        logWriter.Flush();
    }
}

// Usage
Logger.Instance.Log("Application started");
```

### Database Connection Pool

```csharp
public sealed class ConnectionPool
{
    private static readonly Lazy<ConnectionPool> lazy =
        new Lazy<ConnectionPool>(() => new ConnectionPool());

    private Queue<SqlConnection> availableConnections;
    private int maxConnections = 10;

    private ConnectionPool()
    {
        availableConnections = new Queue<SqlConnection>();
        InitializePool();
    }

    public static ConnectionPool Instance => lazy.Value;

    private void InitializePool()
    {
        for (int i = 0; i < maxConnections; i++)
        {
            availableConnections.Enqueue(CreateConnection());
        }
    }

    public SqlConnection GetConnection()
    {
        lock (availableConnections)
        {
            if (availableConnections.Count > 0)
                return availableConnections.Dequeue();
            else
                return CreateConnection(); // Create new if pool empty
        }
    }

    public void ReleaseConnection(SqlConnection conn)
    {
        lock (availableConnections)
        {
            availableConnections.Enqueue(conn);
        }
    }

    private SqlConnection CreateConnection()
    {
        return new SqlConnection("Server=localhost;...");
    }
}
```

## Anti-Patterns to Avoid

### ❌ DON'T: Use Singleton for Everything

```csharp
// Bad - these shouldn't be singletons
public class UserService { } // Should be scoped per request
public class ShoppingCart { } // Should be per user session
public class Calculator { }   // Should be stateless utility
```

### ❌ DON'T: Make Mutable Singleton

```csharp
// Bad - mutable singleton causes issues
public class GlobalState
{
    public static GlobalState Instance { get; } = new GlobalState();
    public int Counter { get; set; } // Dangerous in multi-threaded!
}
```

### ✅ DO: Use Dependency Injection Instead (Modern Approach)

```csharp
// Better approach in modern applications
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Let DI container manage singleton lifetime
        services.AddSingleton<IConfigurationManager, ConfigurationManager>();
        services.AddSingleton<ILogger, Logger>();
    }
}
```

## Singleton vs. Static Class

| Aspect                   | Singleton     | Static Class     |
| ------------------------ | ------------- | ---------------- |
| **Instance**             | One object    | No object        |
| **Interface**            | Can implement | Cannot implement |
| **Inheritance**          | Can inherit   | Cannot inherit   |
| **Lazy Loading**         | Yes           | No               |
| **Polymorphism**         | Yes           | No               |
| **Dependency Injection** | Yes           | No               |
| **Testability**          | Medium        | Low              |

**Use Singleton When:**

- Need interface implementation
- Need inheritance
- Need lazy initialization
- Need to pass as parameter

**Use Static Class When:**

- Pure utility functions
- No state needed
- No polymorphism needed

## Testing Singleton

```csharp
// Problem: Hard to test due to global state
public class PaymentProcessor
{
    public void Process(double amount)
    {
        // Tightly coupled to singleton
        Logger.Instance.Log($"Processing ${amount}");
    }
}

// Solution 1: Dependency Injection
public class PaymentProcessor
{
    private readonly ILogger logger;

    public PaymentProcessor(ILogger logger)
    {
        this.logger = logger; // Can inject mock for testing
    }

    public void Process(double amount)
    {
        logger.Log($"Processing ${amount}");
    }
}

// Solution 2: Abstract behind interface
public interface ILogger
{
    void Log(string message);
}

public class Logger : ILogger
{
    private static readonly Lazy<Logger> lazy = new Lazy<Logger>();
    public static Logger Instance => lazy.Value;

    public void Log(string message) { /* ... */ }
}
```

## Summary

**Best Practice for C#:**

```csharp
public sealed class Singleton
{
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());

    private Singleton() { }

    public static Singleton Instance => lazy.Value;
}
```

**Remember:**

- ✅ Use sparingly (often indicates design smell)
- ✅ Prefer Dependency Injection in modern apps
- ✅ Use `Lazy<T>` for thread-safe lazy initialization in C#
- ✅ Make class `sealed` to prevent inheritance
- ✅ Consider alternatives like DI containers
- ❌ Avoid for objects with per-request or per-user state
- ❌ Don't use as global variable replacement
