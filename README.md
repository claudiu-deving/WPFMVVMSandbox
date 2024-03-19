A collection of ideas for WPF projects, especially since I am pinned to .NET Framework 4.8 in most projects.

Some of the features that I'm developing here:

### Validation using attributes for properties:

```csharp
 [IsNotEmpty]
    public string Description { get => GetProperty<string>(); set => SetProperty(value); }
```
By placing the attribute on the property we can define custom validations that are displayed on the UI using an ErrorManager.

### Message notification center

Centralizer message notification to the user in a service that can then build different types of messages (with the coressponding UI).
