# UML Diagram: Factory Method Pattern (factory method for every service)

## Class Diagram

```
┌──────────────────────────────────┐
│   <<interface>>                  │
│   IPaymentGateway                │
├──────────────────────────────────┤
│ + ProcessPayment(amount: double) │
└──────────────────────────────────┘
            △
            │ implements
            │
    ┌───────┴───────┬────────────────┐
    │               │                │
┌───┴────────┐  ┌───┴──────────┐  ┌─┴───────────────┐
│PaymobGateway│  │StripeGateway │  │CreditCardGateway│
├─────────────┤  ├──────────────┤  ├─────────────────┤
│+ProcessPayment│ │+ProcessPayment│ │+ProcessPayment  │
│(amount:double)│ │(amount:double)│ │(amount:double)  │
└─────────────┘  └──────────────┘  └─────────────────┘
     △                △                    △
     │                │                    │
     │ creates        │ creates            │ creates
     │                │                    │
┌────┴────────┐  ┌───┴──────────┐  ┌─────┴───────────┐
│PaymobFactory│  │StripeFactory │  │CreditCardFactory│
├─────────────┤  ├──────────────┤  ├─────────────────┤
│+CreateGateway│ │+CreateGateway│  │+CreateGateway   │
│():IPayment...│ │():IPayment...│  │():IPayment...   │
└─────────────┘  └──────────────┘  └─────────────────┘
     △                △                    △
     │                │                    │
     └────────────────┴────────────────────┘
                      │ implements
                      │
        ┌─────────────┴──────────────────────┐
        │  <<abstract>>                      │
        │  PaymentGatewayFactory             │
        ├────────────────────────────────────┤
        │ + CreateGateway(): IPaymentGateway │ (abstract)
        │ + ProcessTransaction(amount:double)│ (concrete)
        └────────────────────────────────────┘
```

## Sequence Diagram

```
Client          ConcreteFactory         AbstractFactory      ConcreteProduct
  │                    │                       │                    │
  │  new StripeFactory()                       │                    │
  ├───────────────────>│                       │                    │
  │                    │                       │                    │
  │  ProcessTransaction(100.0)                 │                    │
  ├───────────────────>│                       │                    │
  │                    │                       │                    │
  │                    │  CreateGateway()      │                    │
  │                    ├──────────────────────>│                    │
  │                    │                       │                    │
  │                    │  new StripeGateway()  │                    │
  │                    │                       ├───────────────────>│
  │                    │                       │                    │
  │                    │<──────────────────────┤                    │
  │                    │                       │                    │
  │                    │  ProcessPayment(100.0)                     │
  │                    ├────────────────────────────────────────────>│
  │                    │                       │                    │
```

## Key Characteristics

**Advantages:**
- ✓ Follows Open/Closed Principle (add new types without modifying existing code)
- ✓ Single Responsibility Principle (each factory handles one product)
- ✓ Loose coupling between client and concrete products
- ✓ Easy to extend with new payment gateways

**Disadvantages:**
- ✗ More classes to maintain
- ✗ Slightly more complex structure
- ✗ May be overkill for simple scenarios

**When to Use:**
- Product types frequently change or expand
- Need to delegate instantiation to subclasses
- Want to follow SOLID principles strictly
- System needs to be highly extensible

## Code Structure

```csharp
// Abstract Factory
public abstract class PaymentGatewayFactory
{
    // Factory Method - must be implemented by subclasses
    public abstract IPaymentGateway CreateGateway();
    
    // Template method using the factory method
    public void ProcessTransaction(double amount)
    {
        IPaymentGateway gateway = CreateGateway();
        gateway.ProcessPayment(amount);
    }
}

// Concrete Factories
public class StripeFactory : PaymentGatewayFactory
{
    public override IPaymentGateway CreateGateway()
    {
        return new StripeGateway();
    }
}

public class PaymobFactory : PaymentGatewayFactory
{
    public override IPaymentGateway CreateGateway()
    {
        return new PaymobGateway();
    }
}

public class CreditCardFactory : PaymentGatewayFactory
{
    public override IPaymentGateway CreateGateway()
    {
        return new CreditCardGateway();
    }
}

// Usage
PaymentGatewayFactory factory = new StripeFactory();
factory.ProcessTransaction(100.0);

// Or directly
IPaymentGateway gateway = new PaymobFactory().CreateGateway();
gateway.ProcessPayment(50.0);
```
