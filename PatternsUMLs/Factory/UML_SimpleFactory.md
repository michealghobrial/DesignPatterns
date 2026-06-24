# UML Diagram: Simple Factory Pattern (with if-else/switch)

## Class Diagram

```
┌─────────────────────────────────────┐
│   <<interface>>                     │
│   IPaymentGateway                   │
├─────────────────────────────────────┤
│ + ProcessPayment(amount: double)    │
└─────────────────────────────────────┘
            △
            │ implements
            │
    ┌───────┴───────┬────────────────┐
    │               │                │
┌───┴────────┐  ┌───┴──────────┐  ┌─┴───────────────┐
│ PaymobGateway│  │StripeGateway │  │CreditCardGateway│
├──────────────┤  ├──────────────┤  ├─────────────────┤
│+ProcessPayment│  │+ProcessPayment│  │+ProcessPayment  │
│(amount:double)│  │(amount:double)│  │(amount:double)  │
└──────────────┘  └──────────────┘  └─────────────────┘
       △               △                    △
       │               │                    │
       └───────────────┴────────────────────┘
                       │ creates
                       │
           ┌───────────┴──────────────────────┐
           │  <<static>>                      │
           │  PaymentGatewayFactory           │
           ├──────────────────────────────────┤
           │ + CreatePaymentGateway(          │
           │     gatewayName: string)         │
           │   : IPaymentGateway              │
           └──────────────────────────────────┘
```

## Sequence Diagram

```
Client                PaymentGatewayFactory           ConcreteGateway
  │                            │                            │
  │ CreatePaymentGateway("stripe")                         │
  ├───────────────────────────>│                            │
  │                            │                            │
  │                            │  if/switch on gatewayName  │
  │                            │                            │
  │                            │  new StripeGateway()       │
  │                            ├───────────────────────────>│
  │                            │                            │
  │    return IPaymentGateway  │                            │
  │<───────────────────────────┤                            │
  │                            │                            │
  │  ProcessPayment(100.0)                                  │
  ├────────────────────────────────────────────────────────>│
  │                            │                            │
```

## Key Characteristics

**Advantages:**
- ✓ Simple and straightforward implementation
- ✓ Centralized object creation logic
- ✓ Easy to understand and use

**Disadvantages:**
- ✗ Violates Open/Closed Principle (must modify factory to add new types)
- ✗ Factory has too many responsibilities
- ✗ Tight coupling between factory and concrete classes

**When to Use:**
- Small number of product types
- Product types rarely change
- Simple creation logic

## Code Structure

```csharp
// Current Implementation
public static class PaymentGatewayFactory
{
    public static IPaymentGateway CreatePaymentGateway(string gatewayName)
    {
        switch (gatewayName.ToLower())
        {
            case "paymob":
                return new PaymobGateway();
            case "stripe":
                return new StripeGateway();
            case "creditcard":
                return new CreditCardGateway();
            default:
                throw new ArgumentException("Invalid payment gateway");
        }
    }
}
```
