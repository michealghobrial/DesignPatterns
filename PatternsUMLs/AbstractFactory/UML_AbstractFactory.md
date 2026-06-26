# UML Diagram: Abstract Factory Pattern

## What is Abstract Factory?

**Abstract Factory** is a creational design pattern that lets you produce **families of related objects** without specifying their concrete classes.

### Key Concept:
Think of it as a "factory of factories" - it creates groups of related objects that are designed to work together.

### Real-World Analogy:
Imagine a furniture store that sells different styles (Modern, Victorian, ArtDeco). Each style has a complete family of furniture: Chair, Sofa, Table. The Abstract Factory ensures you get all furniture pieces in the same style - you can't accidentally mix Modern chairs with Victorian sofas.

---

## Class Diagram

```
                                    Client
                                      │
                      ┌───────────────┴───────────────┐
                      │                               │
                      ↓                               ↓
        ┌─────────────────────────┐    ┌─────────────────────────┐
        │ <<interface>>           │    │ <<interface>>           │
        │ IButton                 │    │ ICheckbox               │
        ├─────────────────────────┤    ├─────────────────────────┤
        │ + Render(): void        │    │ + Render(): void        │
        │ + Click(): void         │    │ + Toggle(): void        │
        └─────────────────────────┘    └─────────────────────────┘
                  △                              △
                  │                               │
        ┌─────────┴─────────┐          ┌────────┴────────┐
        │                   │          │                 │
┌───────┴────────┐  ┌───────┴────────┐ ┌────────┴──────┐ ┌────────┴──────┐
│ WindowsButton  │  │  MacButton     │ │WindowsCheckbox│ │ MacCheckbox   │
├────────────────┤  ├────────────────┤ ├───────────────┤ ├───────────────┤
│ + Render()     │  │ + Render()     │ │ + Render()    │ │ + Render()    │
│ + Click()      │  │ + Click()      │ │ + Toggle()    │ │ + Toggle()    │
└────────────────┘  └────────────────┘ └───────────────┘ └───────────────┘
        △                   △                  △                 △
        │                   │                  │                 │
        │ creates           │ creates          │ creates         │ creates
        │                   │                  │                 │
┌───────┴────────┐  ┌───────┴────────┐        │                 │
│WindowsFactory  │  │   MacFactory   │        │                 │
├────────────────┤  ├────────────────┤        │                 │
│+CreateButton() │──│+CreateButton() ├────────┘                 │
│+CreateCheckbox()  │+CreateCheckbox()──────────────────────────┘
└────────────────┘  └────────────────┘
        △                   △
        │                   │
        └───────────────────┴──────────────────┐
                            │                  │
                  ┌─────────┴──────────────────┴─────┐
                  │ <<interface>>                    │
                  │ IGUIFactory                      │
                  ├──────────────────────────────────┤
                  │ + CreateButton(): IButton        │
                  │ + CreateCheckbox(): ICheckbox    │
                  └──────────────────────────────────┘
```

---

## Detailed Explanation

### Components:

1. **Abstract Products (IButton, ICheckbox)**
   - Interfaces for a family of related products
   - Define operations that all concrete products must implement

2. **Concrete Products (WindowsButton, MacButton, etc.)**
   - Specific implementations of abstract products
   - Products from the same family are designed to work together

3. **Abstract Factory (IGUIFactory)**
   - Declares methods for creating abstract products
   - Returns abstract product types (interfaces)

4. **Concrete Factories (WindowsFactory, MacFactory)**
   - Implement abstract factory methods
   - Create concrete products from a specific family
   - Each factory produces a complete family

5. **Client**
   - Works only with abstract interfaces
   - Doesn't know which concrete products it uses
   - Can switch families by changing the factory

---

## Sequence Diagram

```
Client          Application      IGUIFactory    ConcreteFactory    Products
  │                  │                │               │              │
  │  Determine OS    │                │               │              │
  ├─────────────────>│                │               │              │
  │                  │                │               │              │
  │                  │  new WindowsFactory()          │              │
  │                  ├────────────────┴──────────────>│              │
  │                  │                                │              │
  │  factory         │                                │              │
  │<─────────────────┤                                │              │
  │                  │                                │              │
  │  CreateButton()  │                                │              │
  ├──────────────────┴────────────────────────────────>│             │
  │                                                    │             │
  │                                     new WindowsButton()          │
  │                                                    ├────────────>│
  │                                                    │             │
  │  IButton                                           │             │
  │<───────────────────────────────────────────────────┤             │
  │                                                    │             │
  │  CreateCheckbox()                                  │             │
  ├────────────────────────────────────────────────────>│            │
  │                                                    │             │
  │                                   new WindowsCheckbox()          │
  │                                                    ├────────────>│
  │                                                    │             │
  │  ICheckbox                                         │             │
  │<───────────────────────────────────────────────────┤             │
  │                                                    │             │
  │  button.Render()                                                 │
  ├──────────────────────────────────────────────────────────────────>│
  │                                                                   │
  │  checkbox.Render()                                                │
  ├───────────────────────────────────────────────────────────────────>
  │                                                                   │
```

---

## Complete Code Example: Cross-Platform UI

```csharp
// ============================================
// ABSTRACT PRODUCTS
// ============================================

public interface IButton
{
    void Render();
    void Click();
}

public interface ICheckbox
{
    void Render();
    void Toggle();
}

// ============================================
// CONCRETE PRODUCTS - WINDOWS FAMILY
// ============================================

public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows-style button with sharp corners");
    }
    
    public void Click()
    {
        Console.WriteLine("Windows button clicked - playing system sound");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows-style checkbox [✓]");
    }
    
    public void Toggle()
    {
        Console.WriteLine("Windows checkbox toggled");
    }
}

// ============================================
// CONCRETE PRODUCTS - MAC FAMILY
// ============================================

public class MacButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac-style button with rounded corners");
    }
    
    public void Click()
    {
        Console.WriteLine("Mac button clicked - smooth animation");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac-style checkbox (◉)");
    }
    
    public void Toggle()
    {
        Console.WriteLine("Mac checkbox toggled with animation");
    }
}

// ============================================
// ABSTRACT FACTORY
// ============================================

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// ============================================
// CONCRETE FACTORIES
// ============================================

public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }
    
    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }
    
    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

// ============================================
// CLIENT CODE
// ============================================

public class Application
{
    private IButton button;
    private ICheckbox checkbox;
    
    public Application(IGUIFactory factory)
    {
        button = factory.CreateButton();
        checkbox = factory.CreateCheckbox();
    }
    
    public void Render()
    {
        button.Render();
        checkbox.Render();
    }
    
    public void Interact()
    {
        button.Click();
        checkbox.Toggle();
    }
}

// ============================================
// USAGE
// ============================================

class Program
{
    static void Main(string[] args)
    {
        // Determine which factory to use based on OS
        IGUIFactory factory;
        
        string os = Environment.OSVersion.Platform.ToString();
        
        if (os.Contains("Win"))
        {
            factory = new WindowsFactory();
            Console.WriteLine("Creating Windows UI...\n");
        }
        else
        {
            factory = new MacFactory();
            Console.WriteLine("Creating Mac UI...\n");
        }
        
        // Client code works with factories and products
        // only through abstract interfaces
        Application app = new Application(factory);
        app.Render();
        
        Console.WriteLine();
        
        app.Interact();
    }
}

/* OUTPUT (on Windows):
Creating Windows UI...

Rendering Windows-style button with sharp corners
Rendering Windows-style checkbox [✓]

Windows button clicked - playing system sound
Windows checkbox toggled
*/
```

---

## Another Example: Database Connections

```csharp
// Abstract Products
public interface IConnection
{
    void Connect();
    void ExecuteQuery(string query);
}

public interface ICommand
{
    void Execute();
}

// Concrete Products - SQL Server Family
public class SqlConnection : IConnection
{
    public void Connect()
    {
        Console.WriteLine("Connected to SQL Server");
    }
    
    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"SQL Server executing: {query}");
    }
}

public class SqlCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Executing SQL Server command with T-SQL syntax");
    }
}

// Concrete Products - MySQL Family
public class MySqlConnection : IConnection
{
    public void Connect()
    {
        Console.WriteLine("Connected to MySQL");
    }
    
    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"MySQL executing: {query}");
    }
}

public class MySqlCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Executing MySQL command with MySQL syntax");
    }
}

// Abstract Factory
public interface IDatabaseFactory
{
    IConnection CreateConnection();
    ICommand CreateCommand();
}

// Concrete Factories
public class SqlServerFactory : IDatabaseFactory
{
    public IConnection CreateConnection()
    {
        return new SqlConnection();
    }
    
    public ICommand CreateCommand()
    {
        return new SqlCommand();
    }
}

public class MySqlFactory : IDatabaseFactory
{
    public IConnection CreateConnection()
    {
        return new MySqlConnection();
    }
    
    public ICommand CreateCommand()
    {
        return new MySqlCommand();
    }
}

// Client
public class DataAccessLayer
{
    private IConnection connection;
    private ICommand command;
    
    public DataAccessLayer(IDatabaseFactory factory)
    {
        connection = factory.CreateConnection();
        command = factory.CreateCommand();
    }
    
    public void PerformDatabaseOperation()
    {
        connection.Connect();
        connection.ExecuteQuery("SELECT * FROM Users");
        command.Execute();
    }
}

// Usage
IDatabaseFactory factory = new SqlServerFactory();
// OR: IDatabaseFactory factory = new MySqlFactory();

DataAccessLayer dal = new DataAccessLayer(factory);
dal.PerformDatabaseOperation();
```

---

## Key Differences from Other Patterns

### Abstract Factory vs Factory Method

| Aspect | Abstract Factory | Factory Method |
|--------|------------------|----------------|
| **Purpose** | Create families of related objects | Create single product |
| **Products** | Multiple related products | One product |
| **Factories** | One factory per family | One factory per product |
| **Methods** | Multiple creation methods | Single creation method |
| **Focus** | Family consistency | Individual product creation |

```
Factory Method:           Abstract Factory:
  Factory                   Factory
     │                         │
     ↓                    ┌────┼────┐
  Product                 │    │    │
                       Prod1 Prod2 Prod3
                       (family)
```

### Abstract Factory vs Builder

| Aspect | Abstract Factory | Builder |
|--------|------------------|---------|
| **Focus** | What is created | How it's created |
| **Products** | Family of products | Single complex product |
| **Steps** | One-step creation | Multi-step construction |
| **Variance** | Different families | Different representations |

---

## When to Use Abstract Factory

### ✅ Use When:

1. **System should be independent of product creation**
   - You want to configure system with one of multiple families

2. **Products must be used together**
   - Products in a family are designed to work together
   - You want to enforce this constraint

3. **You want to provide a class library**
   - Reveal only interfaces, not implementations

4. **Multiple families exist**
   - Windows/Mac UI, SQL/MySQL/PostgreSQL, Light/Dark theme

### ❌ Don't Use When:

1. **Only one family exists**
   - Use Factory Method instead

2. **Products aren't related**
   - No benefit from grouping

3. **Too many product types**
   - Factory interface becomes too large

---

## Advantages & Disadvantages

### ✅ Advantages:

1. **Ensures product consistency**
   - All products from same family work together

2. **Isolates concrete classes**
   - Client uses interfaces, not concrete classes

3. **Easy to switch families**
   - Change one line (factory creation)

4. **Follows Open/Closed Principle**
   - Add new families without modifying client

5. **Single Responsibility Principle**
   - Product creation code in one place

### ❌ Disadvantages:

1. **Complexity increases**
   - Many classes and interfaces

2. **Hard to add new products**
   - Adding new product type requires changing all factories

3. **More code to maintain**
   - Each family needs complete implementation

---

## Real-World Use Cases

### 1. **UI Frameworks**
```
Families: Windows, Mac, Linux
Products: Button, Checkbox, TextBox, Menu
```

### 2. **Database Providers**
```
Families: SQL Server, MySQL, PostgreSQL, Oracle
Products: Connection, Command, DataReader, Transaction
```

### 3. **Document Generators**
```
Families: PDF, Word, HTML
Products: Page, Paragraph, Image, Table
```

### 4. **Theme Systems**
```
Families: Light Theme, Dark Theme, High Contrast
Products: Background, Foreground, Accent, BorderColor
```

### 5. **Game Environments**
```
Families: Desert, Forest, Arctic
Products: Terrain, Vegetation, Animals, Weather
```

---

## Common Mistakes to Avoid

### ❌ Mistake 1: Not Enforcing Family Consistency
```csharp
// Bad - can mix families
public class Application
{
    public void Setup()
    {
        IButton button = new WindowsFactory().CreateButton();
        ICheckbox checkbox = new MacFactory().CreateCheckbox(); // WRONG!
    }
}

// Good - single factory ensures consistency
public class Application
{
    private IGUIFactory factory;
    
    public Application(IGUIFactory factory)
    {
        this.factory = factory;
    }
    
    public void Setup()
    {
        IButton button = factory.CreateButton();
        ICheckbox checkbox = factory.CreateCheckbox(); // Same family ✓
    }
}
```

### ❌ Mistake 2: Client Depending on Concrete Classes
```csharp
// Bad - client knows concrete types
public class Application
{
    public void Setup()
    {
        var factory = new WindowsFactory(); // Concrete type
        WindowsButton button = factory.CreateButton(); // Concrete type
    }
}

// Good - client uses abstractions
public class Application
{
    public void Setup(IGUIFactory factory)
    {
        IButton button = factory.CreateButton(); // Abstract type
    }
}
```

### ❌ Mistake 3: Too Many Products in Factory
```csharp
// Bad - factory is too large
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
    ITextBox CreateTextBox();
    IRadioButton CreateRadioButton();
    IDropdown CreateDropdown();
    ISlider CreateSlider();
    IDatePicker CreateDatePicker();
    IColorPicker CreateColorPicker();
    // ... 20 more methods
}

// Good - split into multiple factories
public interface IInputControlFactory
{
    ITextBox CreateTextBox();
    ICheckbox CreateCheckbox();
}

public interface IButtonFactory
{
    IButton CreateButton();
    IRadioButton CreateRadioButton();
}
```

---

## Summary

**Abstract Factory Pattern:**
- Creates **families of related objects**
- Ensures **family consistency**
- Client works with **abstractions only**
- Easy to **switch entire families**

**Remember:**
- Use when you have **multiple families** of related products
- Each family should be **consistent and interchangeable**
- Products in a family should **work together**
- Great for **cross-platform** applications

**Quick Test:**
If you can answer YES to these questions, use Abstract Factory:
1. Do I have multiple families of related objects?
2. Should products from the same family work together?
3. Do I need to switch between families at runtime?
4. Should my code be independent of how products are created?
