# UML Diagram: Fluent Interface Pattern

## What is Fluent Interface?

**Fluent Interface** is an object-oriented API design pattern that relies on **method chaining** to create more readable and expressive code. Each method returns the object itself (or another object in the chain), allowing multiple method calls to be chained together.

### Key Concept:
Instead of calling methods one by one, you chain them together in a single expression that reads like natural language.

### Real-World Analogy:
Think of giving directions: "Go straight, then turn left, then turn right, then stop" - each instruction flows naturally into the next, creating a complete journey.

---

## Class Diagram

```
┌─────────────────────────────────────────────┐
│          FluentObject                       │
├─────────────────────────────────────────────┤
│ - property1: string                         │
│ - property2: int                            │
│ - property3: bool                           │
├─────────────────────────────────────────────┤
│ + SetProperty1(value): FluentObject        │ ◄─┐
│ + SetProperty2(value): FluentObject        │ ◄─┤
│ + SetProperty3(value): FluentObject        │ ◄─┤  Returns 'this'
│ + WithOption(): FluentObject               │ ◄─┤  to enable
│ + Configure(): FluentObject                │ ◄─┤  chaining
│ + Build(): Result                          │ ◄─┘
└─────────────────────────────────────────────┘
```

## Method Chaining Flow

```
         Client
           │
           │ new FluentObject()
           ↓
    ┌──────────────┐
    │FluentObject  │
    └──────────────┘
           │
           │ SetProperty1("value")
           ↓
    ┌──────────────┐
    │    return    │
    │     this     │ ──────┐
    └──────────────┘       │
           ↑               │
           └───────────────┘
           │
           │ SetProperty2(42)
           ↓
    ┌──────────────┐
    │    return    │
    │     this     │ ──────┐
    └──────────────┘       │
           ↑               │
           └───────────────┘
           │
           │ WithOption()
           ↓
    ┌──────────────┐
    │    return    │
    │     this     │ ──────┐
    └──────────────┘       │
           ↑               │
           └───────────────┘
           │
           │ Build()
           ↓
    ┌──────────────┐
    │    Result    │
    └──────────────┘
```

## Sequence Diagram

```
Client                FluentBuilder                     Product
  │                         │                             │
  │ new FluentBuilder()     │                             │
  ├────────────────────────>│                             │
  │                         │                             │
  │ SetName("Product")      │                             │
  ├────────────────────────>│                             │
  │         return this     │                             │
  │<────────────────────────┤                             │
  │                         │                             │
  │ SetPrice(99.99)         │                             │
  ├────────────────────────>│                             │
  │         return this     │                             │
  │<────────────────────────┤                             │
  │                         │                             │
  │ WithDiscount()          │                             │
  ├────────────────────────>│                             │
  │         return this     │                             │
  │<────────────────────────┤                             │
  │                         │                             │
  │ Build()                 │                             │
  ├────────────────────────>│                             │
  │                         │  create Product             │
  │                         ├────────────────────────────>│
  │                         │                             │
  │         return Product                                │
  │<────────────────────────┤                             │
  │                         │                             │
```

---

## Complete Code Example 1: Query Builder

```csharp
// ============================================
// FLUENT SQL QUERY BUILDER
// ============================================

public class SqlQueryBuilder
{
    private List<string> selectColumns = new List<string>();
    private string tableName;
    private List<string> whereConditions = new List<string>();
    private List<string> orderByColumns = new List<string>();
    private int? limitValue;
    private List<string> joins = new List<string>();
    
    // SELECT clause
    public SqlQueryBuilder Select(params string[] columns)
    {
        selectColumns.AddRange(columns);
        return this; // Return 'this' for chaining
    }
    
    // FROM clause
    public SqlQueryBuilder From(string table)
    {
        tableName = table;
        return this;
    }
    
    // WHERE clause
    public SqlQueryBuilder Where(string condition)
    {
        whereConditions.Add(condition);
        return this;
    }
    
    // AND condition
    public SqlQueryBuilder And(string condition)
    {
        if (whereConditions.Count > 0)
        {
            whereConditions.Add($"AND {condition}");
        }
        else
        {
            whereConditions.Add(condition);
        }
        return this;
    }
    
    // OR condition
    public SqlQueryBuilder Or(string condition)
    {
        if (whereConditions.Count > 0)
        {
            whereConditions.Add($"OR {condition}");
        }
        else
        {
            whereConditions.Add(condition);
        }
        return this;
    }
    
    // JOIN clause
    public SqlQueryBuilder Join(string table, string condition)
    {
        joins.Add($"JOIN {table} ON {condition}");
        return this;
    }
    
    // LEFT JOIN clause
    public SqlQueryBuilder LeftJoin(string table, string condition)
    {
        joins.Add($"LEFT JOIN {table} ON {condition}");
        return this;
    }
    
    // ORDER BY clause
    public SqlQueryBuilder OrderBy(params string[] columns)
    {
        orderByColumns.AddRange(columns);
        return this;
    }
    
    // LIMIT clause
    public SqlQueryBuilder Limit(int limit)
    {
        limitValue = limit;
        return this;
    }
    
    // Build final query
    public string Build()
    {
        var query = new System.Text.StringBuilder();
        
        // SELECT
        query.Append("SELECT ");
        if (selectColumns.Count > 0)
        {
            query.Append(string.Join(", ", selectColumns));
        }
        else
        {
            query.Append("*");
        }
        
        // FROM
        query.Append($"\nFROM {tableName}");
        
        // JOINS
        if (joins.Count > 0)
        {
            query.Append($"\n{string.Join("\n", joins)}");
        }
        
        // WHERE
        if (whereConditions.Count > 0)
        {
            query.Append($"\nWHERE {string.Join(" ", whereConditions)}");
        }
        
        // ORDER BY
        if (orderByColumns.Count > 0)
        {
            query.Append($"\nORDER BY {string.Join(", ", orderByColumns)}");
        }
        
        // LIMIT
        if (limitValue.HasValue)
        {
            query.Append($"\nLIMIT {limitValue.Value}");
        }
        
        return query.ToString();
    }
    
    // Execute query (simulation)
    public void Execute()
    {
        string query = Build();
        Console.WriteLine("Executing Query:");
        Console.WriteLine(query);
        Console.WriteLine();
    }
}

// ============================================
// USAGE EXAMPLES
// ============================================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║       FLUENT INTERFACE PATTERN DEMONSTRATION           ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.WriteLine();
        
        // Example 1: Simple Query
        Console.WriteLine("EXAMPLE 1: Simple SELECT");
        Console.WriteLine(new string('=', 56));
        
        var query1 = new SqlQueryBuilder()
            .Select("Id", "Name", "Email")
            .From("Users")
            .Build();
        
        Console.WriteLine(query1);
        Console.WriteLine();
        
        // Example 2: Query with WHERE
        Console.WriteLine("EXAMPLE 2: Query with WHERE clause");
        Console.WriteLine(new string('=', 56));
        
        var query2 = new SqlQueryBuilder()
            .Select("Name", "Age", "City")
            .From("Customers")
            .Where("Age > 25")
            .And("City = 'New York'")
            .Build();
        
        Console.WriteLine(query2);
        Console.WriteLine();
        
        // Example 3: Complex Query with JOIN
        Console.WriteLine("EXAMPLE 3: Complex Query with JOIN");
        Console.WriteLine(new string('=', 56));
        
        var query3 = new SqlQueryBuilder()
            .Select("Orders.Id", "Orders.OrderDate", "Customers.Name", "Products.ProductName")
            .From("Orders")
            .Join("Customers", "Orders.CustomerId = Customers.Id")
            .Join("Products", "Orders.ProductId = Products.Id")
            .Where("Orders.OrderDate > '2024-01-01'")
            .And("Orders.Status = 'Completed'")
            .OrderBy("Orders.OrderDate DESC")
            .Limit(10)
            .Build();
        
        Console.WriteLine(query3);
        Console.WriteLine();
        
        // Example 4: Execute method
        Console.WriteLine("EXAMPLE 4: Using Execute method");
        Console.WriteLine(new string('=', 56));
        
        new SqlQueryBuilder()
            .Select("*")
            .From("Products")
            .Where("Price < 100")
            .Or("Category = 'Sale'")
            .OrderBy("Price ASC")
            .Execute();
        
        Console.ReadKey();
    }
}
```

---

## Complete Code Example 2: Email Builder

```csharp
// ============================================
// FLUENT EMAIL BUILDER
// ============================================

public class Email
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> CC { get; set; } = new List<string>();
    public List<string> BCC { get; set; } = new List<string>();
    public List<string> Attachments { get; set; } = new List<string>();
    public bool IsHtml { get; set; }
    public EmailPriority Priority { get; set; }
    
    public void Display()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║            EMAIL MESSAGE             ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine($"From: {From}");
        Console.WriteLine($"To: {To}");
        
        if (CC.Count > 0)
            Console.WriteLine($"CC: {string.Join(", ", CC)}");
        
        if (BCC.Count > 0)
            Console.WriteLine($"BCC: {string.Join(", ", BCC)}");
        
        Console.WriteLine($"Subject: {Subject}");
        Console.WriteLine($"Priority: {Priority}");
        Console.WriteLine($"Format: {(IsHtml ? "HTML" : "Plain Text")}");
        
        if (Attachments.Count > 0)
            Console.WriteLine($"Attachments: {string.Join(", ", Attachments)}");
        
        Console.WriteLine("\nBody:");
        Console.WriteLine(Body);
        Console.WriteLine();
    }
    
    public void Send()
    {
        Console.WriteLine("✓ Email sent successfully!");
        Console.WriteLine();
    }
}

public enum EmailPriority
{
    Low,
    Normal,
    High,
    Urgent
}

public class EmailBuilder
{
    private Email email = new Email();
    
    public EmailBuilder From(string from)
    {
        email.From = from;
        return this;
    }
    
    public EmailBuilder To(string to)
    {
        email.To = to;
        return this;
    }
    
    public EmailBuilder Subject(string subject)
    {
        email.Subject = subject;
        return this;
    }
    
    public EmailBuilder Body(string body)
    {
        email.Body = body;
        return this;
    }
    
    public EmailBuilder CC(params string[] ccList)
    {
        email.CC.AddRange(ccList);
        return this;
    }
    
    public EmailBuilder BCC(params string[] bccList)
    {
        email.BCC.AddRange(bccList);
        return this;
    }
    
    public EmailBuilder Attach(params string[] files)
    {
        email.Attachments.AddRange(files);
        return this;
    }
    
    public EmailBuilder AsHtml()
    {
        email.IsHtml = true;
        return this;
    }
    
    public EmailBuilder WithPriority(EmailPriority priority)
    {
        email.Priority = priority;
        return this;
    }
    
    public EmailBuilder AsUrgent()
    {
        email.Priority = EmailPriority.Urgent;
        return this;
    }
    
    public Email Build()
    {
        return email;
    }
    
    public void Send()
    {
        email.Display();
        email.Send();
    }
}

// ============================================
// USAGE
// ============================================

// Simple email
var email1 = new EmailBuilder()
    .From("sender@example.com")
    .To("recipient@example.com")
    .Subject("Hello!")
    .Body("This is a test email.")
    .Build();

email1.Display();

// Complex email with all features
new EmailBuilder()
    .From("manager@company.com")
    .To("team@company.com")
    .CC("hr@company.com", "admin@company.com")
    .Subject("Urgent: Project Update")
    .Body("<h1>Project Status</h1><p>Please review attached documents.</p>")
    .AsHtml()
    .AsUrgent()
    .Attach("report.pdf", "budget.xlsx")
    .Send();
```

---

## Complete Code Example 3: HTTP Request Builder

```csharp
// ============================================
// FLUENT HTTP REQUEST BUILDER
// ============================================

public class HttpRequest
{
    public string Url { get; set; }
    public string Method { get; set; }
    public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    public Dictionary<string, string> QueryParams { get; set; } = new Dictionary<string, string>();
    public string Body { get; set; }
    public int Timeout { get; set; } = 30000;
    
    public void Execute()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║         HTTP REQUEST                 ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine($"Method: {Method}");
        
        string fullUrl = Url;
        if (QueryParams.Count > 0)
        {
            var queryString = string.Join("&", 
                QueryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            fullUrl += "?" + queryString;
        }
        Console.WriteLine($"URL: {fullUrl}");
        
        Console.WriteLine("\nHeaders:");
        foreach (var header in Headers)
        {
            Console.WriteLine($"  {header.Key}: {header.Value}");
        }
        
        if (!string.IsNullOrEmpty(Body))
        {
            Console.WriteLine("\nBody:");
            Console.WriteLine(Body);
        }
        
        Console.WriteLine($"\nTimeout: {Timeout}ms");
        Console.WriteLine("\n✓ Request executed successfully!");
        Console.WriteLine();
    }
}

public class HttpRequestBuilder
{
    private HttpRequest request = new HttpRequest();
    
    public HttpRequestBuilder Get(string url)
    {
        request.Url = url;
        request.Method = "GET";
        return this;
    }
    
    public HttpRequestBuilder Post(string url)
    {
        request.Url = url;
        request.Method = "POST";
        return this;
    }
    
    public HttpRequestBuilder Put(string url)
    {
        request.Url = url;
        request.Method = "PUT";
        return this;
    }
    
    public HttpRequestBuilder Delete(string url)
    {
        request.Url = url;
        request.Method = "DELETE";
        return this;
    }
    
    public HttpRequestBuilder WithHeader(string key, string value)
    {
        request.Headers[key] = value;
        return this;
    }
    
    public HttpRequestBuilder WithBearerToken(string token)
    {
        request.Headers["Authorization"] = $"Bearer {token}";
        return this;
    }
    
    public HttpRequestBuilder WithJsonContent()
    {
        request.Headers["Content-Type"] = "application/json";
        return this;
    }
    
    public HttpRequestBuilder WithQuery(string key, string value)
    {
        request.QueryParams[key] = value;
        return this;
    }
    
    public HttpRequestBuilder WithBody(string body)
    {
        request.Body = body;
        return this;
    }
    
    public HttpRequestBuilder WithJsonBody(object obj)
    {
        request.Body = System.Text.Json.JsonSerializer.Serialize(obj);
        request.Headers["Content-Type"] = "application/json";
        return this;
    }
    
    public HttpRequestBuilder WithTimeout(int milliseconds)
    {
        request.Timeout = milliseconds;
        return this;
    }
    
    public HttpRequest Build()
    {
        return request;
    }
    
    public void Execute()
    {
        request.Execute();
    }
}

// ============================================
// USAGE
// ============================================

// GET request with query parameters
new HttpRequestBuilder()
    .Get("https://api.example.com/users")
    .WithQuery("page", "1")
    .WithQuery("limit", "10")
    .WithBearerToken("abc123token")
    .Execute();

// POST request with JSON body
new HttpRequestBuilder()
    .Post("https://api.example.com/users")
    .WithJsonContent()
    .WithBearerToken("abc123token")
    .WithBody("{\"name\":\"John\",\"email\":\"john@example.com\"}")
    .WithTimeout(5000)
    .Execute();
```

---

## Complete Code Example 4: Report Builder

```csharp
// ============================================
// FLUENT REPORT BUILDER
// ============================================

public class Report
{
    public string Title { get; set; }
    public DateTime GeneratedDate { get; set; }
    public List<string> Sections { get; set; } = new List<string>();
    public string Footer { get; set; }
    public string Format { get; set; }
    public bool IncludePageNumbers { get; set; }
    public bool IncludeTableOfContents { get; set; }
    
    public void Generate()
    {
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  {Title.PadRight(50)} ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.WriteLine($"Generated: {GeneratedDate:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Format: {Format}");
        Console.WriteLine();
        
        if (IncludeTableOfContents)
        {
            Console.WriteLine("TABLE OF CONTENTS");
            Console.WriteLine(new string('-', 56));
            for (int i = 0; i < Sections.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Sections[i]}");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("REPORT CONTENT");
        Console.WriteLine(new string('-', 56));
        foreach (var section in Sections)
        {
            Console.WriteLine($"\n{section}");
            Console.WriteLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        }
        
        Console.WriteLine();
        if (IncludePageNumbers)
        {
            Console.WriteLine("Page 1 of 1");
        }
        
        if (!string.IsNullOrEmpty(Footer))
        {
            Console.WriteLine(Footer);
        }
        
        Console.WriteLine("\n✓ Report generated successfully!");
        Console.WriteLine();
    }
}

public class ReportBuilder
{
    private Report report = new Report();
    
    public ReportBuilder()
    {
        report.GeneratedDate = DateTime.Now;
        report.Format = "PDF";
    }
    
    public ReportBuilder WithTitle(string title)
    {
        report.Title = title;
        return this;
    }
    
    public ReportBuilder AddSection(string section)
    {
        report.Sections.Add(section);
        return this;
    }
    
    public ReportBuilder WithFooter(string footer)
    {
        report.Footer = footer;
        return this;
    }
    
    public ReportBuilder AsPdf()
    {
        report.Format = "PDF";
        return this;
    }
    
    public ReportBuilder AsWord()
    {
        report.Format = "DOCX";
        return this;
    }
    
    public ReportBuilder AsExcel()
    {
        report.Format = "XLSX";
        return this;
    }
    
    public ReportBuilder WithPageNumbers()
    {
        report.IncludePageNumbers = true;
        return this;
    }
    
    public ReportBuilder WithTableOfContents()
    {
        report.IncludeTableOfContents = true;
        return this;
    }
    
    public Report Build()
    {
        return report;
    }
    
    public void Generate()
    {
        report.Generate();
    }
}

// ============================================
// USAGE
// ============================================

new ReportBuilder()
    .WithTitle("Annual Sales Report 2024")
    .AddSection("Executive Summary")
    .AddSection("Revenue Analysis")
    .AddSection("Market Trends")
    .AddSection("Recommendations")
    .WithTableOfContents()
    .WithPageNumbers()
    .WithFooter("© 2024 Company Inc. - Confidential")
    .AsPdf()
    .Generate();
```

---

## Advantages & Disadvantages

### ✅ Advantages:

1. **Improved Readability**
   - Code reads like natural language
   - Clear intent

2. **Less Verbose**
   - No repeated variable names
   - More concise code

3. **Discoverable API**
   - IDE auto-completion guides usage
   - Self-documenting

4. **Flexible Configuration**
   - Optional parameters easy to handle
   - Order doesn't always matter

5. **Immutability Support**
   - Can create new instances in chain
   - Thread-safe if implemented correctly

### ❌ Disadvantages:

1. **Debugging Difficulty**
   - Hard to set breakpoints in chain
   - Stack traces less clear

2. **Return Type Consistency**
   - Must return correct type for chaining
   - Can be confusing with multiple builders

3. **Error Handling**
   - Exceptions break the chain
   - Validation timing unclear

4. **Method Naming**
   - Need descriptive names
   - Can lead to verbose method names

---

## Implementation Patterns

### Pattern 1: Return 'this'
```csharp
public class Builder
{
    private string value;
    
    public Builder SetValue(string val)
    {
        value = val;
        return this; // Enable chaining
    }
}
```

### Pattern 2: Immutable Chaining
```csharp
public class ImmutableBuilder
{
    private readonly string value;
    
    public ImmutableBuilder(string value = "")
    {
        this.value = value;
    }
    
    public ImmutableBuilder SetValue(string val)
    {
        return new ImmutableBuilder(val); // New instance
    }
}
```

### Pattern 3: Different Return Types
```csharp
public interface IStep1
{
    IStep2 ConfigureStep1(string value);
}

public interface IStep2
{
    IStep3 ConfigureStep2(int value);
}

public interface IStep3
{
    Result Build();
}
```

---

## Best Practices

### ✅ DO:

1. **Use descriptive method names**
   ```csharp
   builder.WithTimeout(5000)      // Good
   builder.Timeout(5000)          // Also good
   builder.T(5000)                // Bad
   ```

2. **Return the builder instance**
   ```csharp
   public Builder SetName(string name)
   {
       this.name = name;
       return this;  // Enable chaining
   }
   ```

3. **Group related methods**
   ```csharp
   builder
       .SetName("Product")
       .SetPrice(99.99)
       .WithDiscount(10)
       .Build();
   ```

4. **Provide sensible defaults**
   ```csharp
   public Builder()
   {
       timeout = 30000;  // Default 30 seconds
       format = "JSON";  // Default format
   }
   ```

### ❌ DON'T:

1. **Break the chain**
   ```csharp
   // Bad - returns void
   public void SetName(string name)
   {
       this.name = name;
   }
   ```

2. **Make chains too long**
   ```csharp
   // Bad - too long, hard to read
   builder.A().B().C().D().E().F().G().H().I().J().K().L();
   
   // Good - break into logical groups
   builder
       .A().B().C()
       .D().E().F()
       .Build();
   ```

3. **Ignore validation**
   ```csharp
   // Bad - no validation
   public Builder SetAge(int age)
   {
       this.age = age;
       return this;
   }
   
   // Good - validate input
   public Builder SetAge(int age)
   {
       if (age < 0 || age > 150)
           throw new ArgumentException("Invalid age");
       
       this.age = age;
       return this;
   }
   ```

---

## Real-World Examples

### 1. **LINQ in C#**
```csharp
var result = collection
    .Where(x => x.Age > 18)
    .OrderBy(x => x.Name)
    .Select(x => x.Email)
    .ToList();
```

### 2. **StringBuilder**
```csharp
var html = new StringBuilder()
    .Append("<html>")
    .Append("<body>")
    .Append("<h1>Title</h1>")
    .Append("</body>")
    .Append("</html>")
    .ToString();
```

### 3. **Entity Framework**
```csharp
var users = dbContext.Users
    .Where(u => u.IsActive)
    .Include(u => u.Orders)
    .OrderByDescending(u => u.CreatedDate)
    .Take(10)
    .ToList();
```

### 4. **ASP.NET Core Configuration**
```csharp
services
    .AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
```

---

## When to Use Fluent Interface

### ✅ Use When:

1. **Building complex objects**
   - Many optional parameters
   - Configuration scenarios

2. **DSL (Domain Specific Language)**
   - Query builders
   - Test assertions
   - Configuration APIs

3. **Sequential operations**
   - Data transformations
   - Pipeline processing

4. **Improving readability**
   - Code should read like prose
   - Clear intent

### ❌ Don't Use When:

1. **Simple objects**
   - Few parameters
   - No configuration needed

2. **Operations with side effects**
   - Database operations
   - File I/O
   - Network calls

3. **Error-prone scenarios**
   - Need explicit error handling
   - Validation at each step critical

---

## Summary

**Fluent Interface Pattern:**
- Uses **method chaining** for readable code
- Each method returns an object (usually `this`)
- Creates a **DSL-like API**
- Makes code more **expressive and maintainable**

**Key Principles:**
1. Return `this` (or another builder) from methods
2. Use descriptive method names
3. Support optional configuration
4. Provide sensible defaults
5. End chain with Build() or Execute()

**Common Uses:**
- Query builders (SQL, LINQ)
- Object configuration (Builders)
- HTTP requests
- Test assertions
- Logging frameworks
