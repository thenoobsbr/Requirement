# requirements

This project was born to simplify the requirements validations of software projects.

With the `TheNoobs.Requirements`, you can validate our system requirements reducing the code deep and the code complexity.

## How to use

Change that:

```csharp
public MyClass
{
    public MyClass(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }
    }
}

```

for:

```csharp
public MyClass
{
    public MyClass(string value)
    {
        Requirement.To().NotEmpty(uf, () => new ArgumentNullException(nameof(uf)));
    }
}

```

---
> ♥ Made with love!
