# UML Diagram: Builder Pattern

## What is Builder Pattern?

**Builder** is a creational design pattern that lets you construct complex objects **step by step**. It allows you to produce different types and representations of an object using the same construction code.

### Key Concept:
Instead of using a constructor with many parameters (some optional), the Builder pattern lets you build objects step-by-step, setting only the properties you need.

### Real-World Analogy:
Think of building a house. You don't build it all at once. You build it step by step: foundation → walls → roof → windows → doors → interior. Different builders can create different types of houses (mansion, cabin, apartment) using the same construction process.

---

## Class Diagram

```
                           Director
                              │
                              │ uses
                              ↓
                    ┌─────────────────────┐
                    │ <<interface>>       │
                    │ IBuilder            │
                    ├─────────────────────┤
                    │ + Reset()           │
                    │ + BuildPartA()      │
                    │ + BuildPartB()      │
                    │ + BuildPartC()      │
                    └─────────────────────┘
                              △
                              │ implements
                    ┌─────────┴─────────┐
                    │                   │
          ┌─────────┴────────┐  ┌──────┴──────────┐
          │ ConcreteBuilder1 │  │ ConcreteBuilder2│
          ├──────────────────┤  ├─────────────────┤
          │ - product        │  │ - product       │
          ├──────────────────┤  ├─────────────────┤
          │ + Reset()        │  │ + Reset()       │
          │ + BuildPartA()   │  │ + BuildPartA()  │
          │ + BuildPartB()   │  │ + BuildPartB()  │
          │ + BuildPartC()   │  │ + BuildPartC()  │
          │ + GetResult()    │  │ + GetResult()   │
          └──────────────────┘  └─────────────────┘
                    │                   │
                    │ builds            │ builds
                    ↓                   ↓
              ┌──────────┐        ┌──────────┐
              │ Product1 │        │ Product2 │
              └──────────┘        └──────────┘
```

## Detailed Component Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                          CLIENT CODE                            │
├─────────────────────────────────────────────────────────────────┤
│  1. Creates builder                                             │
│  2. Passes builder to director OR                               │
│  3. Uses builder directly for custom construction               │
└─────────────────────────────────────────────────────────────────┘
                    │                          │
                    ↓                          ↓
         ┌──────────────────┐         ┌─────────────────┐
         │    DIRECTOR      │         │    BUILDER      │
         ├──────────────────┤         ├─────────────────┤
         │ - builder        │         │ + Reset()       │
         ├──────────────────┤         │ + BuildStep1()  │
         │ + Construct()    │────────>│ + BuildStep2()  │
         │ + MakeSportscar()│         │ + BuildStep3()  │
         │ + MakeSUV()      │         │ + GetResult()   │
         └──────────────────┘         └─────────────────┘
                                               │
                                               │ creates
                                               ↓
                                      ┌─────────────────┐
                                      │    PRODUCT      │
                                      ├─────────────────┤
                                      │ - partA         │
                                      │ - partB         │
                                      │ - partC         │
                                      └─────────────────┘
```

---

## Sequence Diagram

```
Client          Director        Builder              Product
  │                 │              │                    │
  │ new Builder()   │              │                    │
  ├─────────────────┴─────────────>│                    │
  │                 │              │                    │
  │ new Director(builder)          │                    │
  ├────────────────>│              │                    │
  │                 │              │                    │
  │ MakeSportsCar() │              │                    │
  ├────────────────>│              │                    │
  │                 │              │                    │
  │                 │  Reset()     │                    │
  │                 ├─────────────>│                    │
  │                 │              │ new Product()      │
  │                 │              ├───────────────────>│
  │                 │              │                    │
  │                 │ BuildEngine()│                    │
  │                 ├─────────────>│                    │
  │                 │              │ product.SetEngine()│
  │                 │              ├───────────────────>│
  │                 │              │                    │
  │                 │ BuildSeats() │                    │
  │                 ├─────────────>│                    │
  │                 │              │ product.SetSeats() │
  │                 │              ├───────────────────>│
  │                 │              │                    │
  │                 │ BuildGPS()   │                    │
  │                 ├─────────────>│                    │
  │                 │              │ product.SetGPS()   │
  │                 │              ├───────────────────>│
  │                 │              │                    │
  │  GetResult()    │              │                    │
  ├─────────────────┴─────────────>│                    │
  │                 │              │                    │
  │                 │       return Product              │
  │<────────────────┴──────────────┤                    │
  │                 │              │                    │
```

---

## Complete Code Example: Car Builder

```csharp
// ============================================
// PRODUCT - Complex object being built
// ============================================

public class Car
{
    public string Engine { get; set; }
    public int Seats { get; set; }
    public bool HasGPS { get; set; }
    public bool HasSunroof { get; set; }
    public string Transmission { get; set; }
    public string Color { get; set; }
    public List<string> Features { get; set; } = new List<string>();
    
    public void ShowSpecifications()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║         CAR SPECIFICATIONS           ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine($"Engine: {Engine}");
        Console.WriteLine($"Seats: {Seats}");
        Console.WriteLine($"GPS: {(HasGPS ? "Yes" : "No")}");
        Console.WriteLine($"Sunroof: {(HasSunroof ? "Yes" : "No")}");
        Console.WriteLine($"Transmission: {Transmission}");
        Console.WriteLine($"Color: {Color}");
        
        if (Features.Count > 0)
        {
            Console.WriteLine("Features:");
            foreach (var feature in Features)
            {
                Console.WriteLine($"  • {feature}");
            }
        }
    }
}

// ============================================
// BUILDER INTERFACE
// ============================================

public interface ICarBuilder
{
    void Reset();
    void SetEngine(string engine);
    void SetSeats(int seats);
    void SetGPS();
    void SetSunroof();
    void SetTransmission(string transmission);
    void SetColor(string color);
    void AddFeature(string feature);
    Car GetResult();
}

// ============================================
// CONCRETE BUILDER - Sports Car
// ============================================

public class SportsCarBuilder : ICarBuilder
{
    private Car car;
    
    public SportsCarBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        car = new Car();
    }
    
    public void SetEngine(string engine)
    {
        car.Engine = engine;
    }
    
    public void SetSeats(int seats)
    {
        car.Seats = seats;
    }
    
    public void SetGPS()
    {
        car.HasGPS = true;
    }
    
    public void SetSunroof()
    {
        car.HasSunroof = true;
    }
    
    public void SetTransmission(string transmission)
    {
        car.Transmission = transmission;
    }
    
    public void SetColor(string color)
    {
        car.Color = color;
    }
    
    public void AddFeature(string feature)
    {
        car.Features.Add(feature);
    }
    
    public Car GetResult()
    {
        Car result = car;
        Reset(); // Prepare for next build
        return result;
    }
}

// ============================================
// CONCRETE BUILDER - SUV
// ============================================

public class SUVBuilder : ICarBuilder
{
    private Car car;
    
    public SUVBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        car = new Car();
    }
    
    public void SetEngine(string engine)
    {
        car.Engine = engine;
    }
    
    public void SetSeats(int seats)
    {
        car.Seats = seats;
    }
    
    public void SetGPS()
    {
        car.HasGPS = true;
    }
    
    public void SetSunroof()
    {
        car.HasSunroof = true;
    }
    
    public void SetTransmission(string transmission)
    {
        car.Transmission = transmission;
    }
    
    public void SetColor(string color)
    {
        car.Color = color;
    }
    
    public void AddFeature(string feature)
    {
        car.Features.Add(feature);
    }
    
    public Car GetResult()
    {
        Car result = car;
        Reset();
        return result;
    }
}

// ============================================
// DIRECTOR - Defines construction steps
// ============================================

public class CarDirector
{
    private ICarBuilder builder;
    
    public void SetBuilder(ICarBuilder builder)
    {
        this.builder = builder;
    }
    
    // Predefined construction recipe for sports car
    public void ConstructSportsCar()
    {
        builder.Reset();
        builder.SetEngine("V8 4.0L Twin-Turbo");
        builder.SetSeats(2);
        builder.SetTransmission("7-Speed Automatic");
        builder.SetColor("Red");
        builder.SetGPS();
        builder.AddFeature("Carbon Fiber Body");
        builder.AddFeature("Sport Suspension");
        builder.AddFeature("Racing Seats");
        builder.AddFeature("Launch Control");
    }
    
    // Predefined construction recipe for family SUV
    public void ConstructFamilySUV()
    {
        builder.Reset();
        builder.SetEngine("V6 3.5L");
        builder.SetSeats(7);
        builder.SetTransmission("8-Speed Automatic");
        builder.SetColor("Silver");
        builder.SetGPS();
        builder.SetSunroof();
        builder.AddFeature("Third Row Seats");
        builder.AddFeature("Rear Entertainment System");
        builder.AddFeature("Safety Package");
        builder.AddFeature("Tow Package");
    }
    
    // Predefined construction recipe for luxury sedan
    public void ConstructLuxurySedan()
    {
        builder.Reset();
        builder.SetEngine("V6 3.0L Turbocharged");
        builder.SetSeats(5);
        builder.SetTransmission("9-Speed Automatic");
        builder.SetColor("Black");
        builder.SetGPS();
        builder.SetSunroof();
        builder.AddFeature("Leather Interior");
        builder.AddFeature("Heated/Cooled Seats");
        builder.AddFeature("Premium Sound System");
        builder.AddFeature("Adaptive Cruise Control");
    }
}

// ============================================
// CLIENT CODE - Usage Examples
// ============================================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║         BUILDER PATTERN DEMONSTRATION                  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.WriteLine();
        
        // Create director
        CarDirector director = new CarDirector();
        
        // ============================================
        // METHOD 1: Using Director with Builder
        // ============================================
        
        Console.WriteLine("METHOD 1: Using Director for Predefined Configurations");
        Console.WriteLine(new string('=', 56));
        Console.WriteLine();
        
        // Build a sports car
        ICarBuilder sportsBuilder = new SportsCarBuilder();
        director.SetBuilder(sportsBuilder);
        director.ConstructSportsCar();
        
        Car sportsCar = sportsBuilder.GetResult();
        sportsCar.ShowSpecifications();
        
        Console.WriteLine();
        
        // Build a family SUV
        ICarBuilder suvBuilder = new SUVBuilder();
        director.SetBuilder(suvBuilder);
        director.ConstructFamilySUV();
        
        Car familySUV = suvBuilder.GetResult();
        familySUV.ShowSpecifications();
        
        Console.WriteLine();
        
        // ============================================
        // METHOD 2: Using Builder Directly (Custom Build)
        // ============================================
        
        Console.WriteLine("METHOD 2: Using Builder Directly for Custom Build");
        Console.WriteLine(new string('=', 56));
        Console.WriteLine();
        
        // Build custom car without director
        ICarBuilder customBuilder = new SportsCarBuilder();
        customBuilder.Reset();
        customBuilder.SetEngine("Electric Motor 500HP");
        customBuilder.SetSeats(4);
        customBuilder.SetTransmission("Single-Speed Direct Drive");
        customBuilder.SetColor("Blue");
        customBuilder.SetGPS();
        customBuilder.SetSunroof();
        customBuilder.AddFeature("Autopilot");
        customBuilder.AddFeature("Glass Roof");
        customBuilder.AddFeature("Premium Audio");
        
        Car customCar = customBuilder.GetResult();
        customCar.ShowSpecifications();
        
        Console.WriteLine();
        
        // ============================================
        // METHOD 3: Fluent Interface Builder
        // ============================================
        
        Console.WriteLine("METHOD 3: Fluent Interface Pattern");
        Console.WriteLine(new string('=', 56));
        Console.WriteLine();
        
        Car fluentCar = new FluentCarBuilder()
            .SetEngine("Hybrid V6 3.5L")
            .SetSeats(5)
            .SetTransmission("CVT")
            .SetColor("White")
            .WithGPS()
            .WithSunroof()
            .AddFeature("Eco Mode")
            .AddFeature("Regenerative Braking")
            .Build();
        
        fluentCar.ShowSpecifications();
        
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

// ============================================
// BONUS: Fluent Builder Implementation
// ============================================

public class FluentCarBuilder
{
    private Car car = new Car();
    
    public FluentCarBuilder SetEngine(string engine)
    {
        car.Engine = engine;
        return this;
    }
    
    public FluentCarBuilder SetSeats(int seats)
    {
        car.Seats = seats;
        return this;
    }
    
    public FluentCarBuilder SetTransmission(string transmission)
    {
        car.Transmission = transmission;
        return this;
    }
    
    public FluentCarBuilder SetColor(string color)
    {
        car.Color = color;
        return this;
    }
    
    public FluentCarBuilder WithGPS()
    {
        car.HasGPS = true;
        return this;
    }
    
    public FluentCarBuilder WithSunroof()
    {
        car.HasSunroof = true;
        return this;
    }
    
    public FluentCarBuilder AddFeature(string feature)
    {
        car.Features.Add(feature);
        return this;
    }
    
    public Car Build()
    {
        return car;
    }
}
```

---

## Another Example: Pizza Builder

```csharp
// Product
public class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public List<string> Toppings { get; set; } = new List<string>();
    public string Size { get; set; }
    public bool ExtraCheese { get; set; }
    
    public void Display()
    {
        Console.WriteLine($"Pizza - Size: {Size}");
        Console.WriteLine($"Dough: {Dough}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine($"Extra Cheese: {(ExtraCheese ? "Yes" : "No")}");
        Console.WriteLine("Toppings: " + string.Join(", ", Toppings));
    }
}

// Builder Interface
public interface IPizzaBuilder
{
    void Reset();
    void SetDough(string dough);
    void SetSauce(string sauce);
    void AddTopping(string topping);
    void SetSize(string size);
    void AddExtraCheese();
    Pizza GetResult();
}

// Concrete Builder
public class PizzaBuilder : IPizzaBuilder
{
    private Pizza pizza;
    
    public PizzaBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        pizza = new Pizza();
    }
    
    public void SetDough(string dough)
    {
        pizza.Dough = dough;
    }
    
    public void SetSauce(string sauce)
    {
        pizza.Sauce = sauce;
    }
    
    public void AddTopping(string topping)
    {
        pizza.Toppings.Add(topping);
    }
    
    public void SetSize(string size)
    {
        pizza.Size = size;
    }
    
    public void AddExtraCheese()
    {
        pizza.ExtraCheese = true;
    }
    
    public Pizza GetResult()
    {
        Pizza result = pizza;
        Reset();
        return result;
    }
}

// Director
public class PizzaDirector
{
    public void MakeMargherita(IPizzaBuilder builder)
    {
        builder.Reset();
        builder.SetDough("Thin Crust");
        builder.SetSauce("Tomato");
        builder.SetSize("Medium");
        builder.AddTopping("Mozzarella");
        builder.AddTopping("Basil");
    }
    
    public void MakePepperoni(IPizzaBuilder builder)
    {
        builder.Reset();
        builder.SetDough("Regular");
        builder.SetSauce("Tomato");
        builder.SetSize("Large");
        builder.AddTopping("Mozzarella");
        builder.AddTopping("Pepperoni");
        builder.AddExtraCheese();
    }
}

// Usage
var director = new PizzaDirector();
var builder = new PizzaBuilder();

director.MakeMargherita(builder);
Pizza margherita = builder.GetResult();
margherita.Display();
```

---

## When to Use Builder Pattern

### ✅ Use When:

1. **Complex object with many parameters**
   - Too many constructor parameters
   - Many optional parameters

2. **Step-by-step construction**
   - Object must be built in specific order
   - Different construction processes needed

3. **Multiple representations**
   - Same construction process creates different products
   - HTML builder, JSON builder, XML builder

4. **Avoid "telescoping constructor"**
   ```csharp
   // Anti-pattern - Telescoping Constructor
   public Car(string engine) { }
   public Car(string engine, int seats) { }
   public Car(string engine, int seats, bool gps) { }
   public Car(string engine, int seats, bool gps, bool sunroof) { }
   // ... many more overloads
   ```

### ❌ Don't Use When:

1. **Simple objects**
   - Objects with few properties
   - No complex construction logic

2. **Immutable objects**
   - Consider using constructor or factory

---

## Advantages & Disadvantages

### ✅ Advantages:

1. **Single Responsibility Principle**
   - Construction logic separated from business logic

2. **Avoids telescoping constructors**
   - No need for many constructor overloads

3. **Step-by-step construction**
   - Control over construction process

4. **Code reusability**
   - Same builder for different products

5. **Better readability**
   - Clear what each parameter does

### ❌ Disadvantages:

1. **Increased complexity**
   - More classes to maintain

2. **Overhead for simple objects**
   - Overkill if object is simple

---

## Builder vs Other Patterns

### Builder vs Abstract Factory

| Aspect | Builder | Abstract Factory |
|--------|---------|------------------|
| **Focus** | How to construct | What to construct |
| **Construction** | Step-by-step | One-step |
| **Returns** | At the end | Immediately |
| **Products** | Related by construction | Related by family |

### Builder vs Factory Method

| Aspect | Builder | Factory Method |
|--------|---------|----------------|
| **Complexity** | Complex objects | Simple objects |
| **Steps** | Multiple steps | Single step |
| **Customization** | High | Low |

---

## Common Variations

### 1. Fluent Builder (Method Chaining)
```csharp
var car = new CarBuilder()
    .SetEngine("V8")
    .SetSeats(4)
    .SetColor("Red")
    .Build();
```

### 2. Builder with Director
```csharp
director.ConstructSportsCar();
Car car = builder.GetResult();
```

### 3. Builder without Director
```csharp
builder.SetEngine("V8");
builder.SetSeats(4);
Car car = builder.GetResult();
```

### 4. Nested Builder (Inner Class)
```csharp
public class Car
{
    public class Builder
    {
        private Car car = new Car();
        
        public Builder SetEngine(string engine)
        {
            car.Engine = engine;
            return this;
        }
        
        public Car Build() => car;
    }
}

// Usage
var car = new Car.Builder()
    .SetEngine("V8")
    .Build();
```

---

## Real-World Examples

### 1. **StringBuilder in C#**
```csharp
var sb = new StringBuilder()
    .Append("Hello")
    .Append(" ")
    .Append("World")
    .AppendLine("!")
    .ToString();
```

### 2. **HTTP Request Builder**
```csharp
var request = new HttpRequestBuilder()
    .SetUrl("https://api.example.com")
    .SetMethod("POST")
    .AddHeader("Content-Type", "application/json")
    .SetBody(jsonData)
    .Build();
```

### 3. **SQL Query Builder**
```csharp
var query = new SqlQueryBuilder()
    .Select("Name", "Age", "Email")
    .From("Users")
    .Where("Age > 18")
    .OrderBy("Name")
    .Build();
```

### 4. **Email Builder**
```csharp
var email = new EmailBuilder()
    .To("user@example.com")
    .Subject("Welcome!")
    .Body("Thank you for signing up")
    .AddAttachment("welcome.pdf")
    .Build();
```

---

## Summary

**Builder Pattern:**
- Constructs complex objects **step by step**
- Separates construction from representation
- Allows different **construction processes**
- Great for objects with **many optional parameters**

**When to Use:**
- ✓ Complex objects with many parameters
- ✓ Need step-by-step construction
- ✓ Want to avoid telescoping constructors
- ✓ Same construction process for different representations

**Key Components:**
1. **Product** - Complex object being built
2. **Builder** - Interface defining construction steps
3. **Concrete Builder** - Implements construction steps
4. **Director** (Optional) - Defines construction order
5. **Client** - Uses builder to create products
