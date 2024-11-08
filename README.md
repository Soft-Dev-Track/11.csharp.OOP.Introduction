# 11. Object-Oriented Programming (OOP) - Introduction (DRAFT)

OOP stands for **ORIENTED OBJECT PROGRAMMING**

## 1. What is an object and a class? 

Before diving into the world of OOP in C#, let's clarify what a `class` and an `object` are. An object can represent anything in the real world or a concept in software, such as a `car`, a `chair`, a `house`, or even a `client` or a `cat` (for all the cat lovers out there).

Let’s use the example of a `Car` object (a classic example in programming!).

A car has various characteristics (known as `fields` or `attributes`) and `functionalities` like Starting engine.

However, we don’t just have one car on the road but thousands.

If a factory wants to produce cars quickly, they need a blueprint that describes both the attributes (like color, make, model) and functionalities (like starting the engine or honking the horn) of each car.

In OOP, this "blueprint" is called a class.

## 2. Create our first Class

Good news: you have already created your first class in previous exercises! Now, let’s build upon that understanding.

To get started, create a new `solution` and add a `project` named `OOP`.

Inside, create a new class called `Car`:

```csharp
namespace Clients
{
    internal class Car
    {
    }
}
```

Oh, wait! What does `internal` mean? And what about public? Quick explanation:

- An `internal` class is accessible only within the `project` where it’s defined.
- A `public` class is accessible across the entire `solution`.


### A. Fields (attributes)

In our `Car` class, we need to specify properties like its color, brand, and more. These characteristics are represented by fields (or attributes) in OOP. Fields hold the values that define an object’s state.

Here’s an example of fields in our `Car` class:

```csharp
namespace Clients
{
    internal class Car
    {
        public string Color;
        public string Brand;
    }
}
```

These fields are currently accessible from anywhere in the code because they’re marked as `public`.

***Quick Tips on Access Modifiers:***:
- **private** (default if no modifier is specified): The member can only be accessed within the same class.
- **protected**: The member is accessible within its own class and in any derived classes.
- **internal**: The member is accessible anywhere within the current assembly (or project).
- **public**: No access restrictions; the member is accessible from any part of the code.

### B. Object 
Now that we have our `Car` class, let’s create our first object, `car`:

```csharp
namespace Clients
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Car car = new Car();
            car.Color = "red"; // Set the color to "red"
            Console.WriteLine(car.Color); // Display the color
        }
    }
}
```

While this code works, there’s a better approach for setting and retrieving field values. We can currently access `Color` directly because of the `public` modifier on the field. However, a best practice in OOP is to control access to fields by using getters and setters, also known as accessors.

Here’s an improved example using accessors:

```csharp
namespace Clients
{
    internal class Car
    {
        private string _color;
        private string _brand;

        public string GetColor ()
        {
            return _Color;
        }

        public void SetColor (string color) 
        {
            _Color = color;
        }
    }
}
```

### C. Properties

In C#, properties allow us to control access to fields in a more concise way than using separate `get` and `set` methods.

Here’s an example of properties in our `Car` class:

```csharp
namespace Clients
{
    internal class Car
    {
        public string Color { get; set; } // Simple property with get and set
        private string _brand;
        public string brand {
            get {
                return brand;
            }
            set{
                _brand = brand;
            }
        }
    }
}
```

This is cleaner, but we can refine it further.

Imagine we want to prevent users from changing the car’s color after it’s been set, as you typically wouldn’t change a car's color after purchasing it. To make a property that is only settable internally within the class, we can add the `private` keyword before `set`, making it a read-only property from the outside:

```public string Color { get; private set; }```

#### 1. Setting Read-Only Fields

So how can we set the car's color initially? There are two options:

- **Default Value**: If all cars should have the same color by default, we can assign it directly within the property:

```public string Color { get; private set; } = "Red";```

- **Constructor**: If each car should have a unique color, we should use a constructor to set the color at the time of object creation:

```csharp
internal class Car
{
    public string Color { get; private set; }

    public Car(string color)
    {
        Color = color; // Set color at creation
    }

    public ChanginColor(string color)
    {
        Color = color; // this is authorize
    }
}
```

#### 2. Using readonly for Fields

In addition to using `private set`, we can also make fields `readonly` to prevent them from being modified after initialization. A `readonly` field can only be assigned once, either at the point of declaration or within the constructor.

```csharp
internal class Car
{
    public readonly string Model;

    public Car(string model)
    {
        Model = model; // Set only in the constructor
    }

      public ChanginColor(string color)
    {
        Color = color; // this is NOT authorize
    }
}
```

| Summary of Differences       | `public readonly string Text`                         | `public string Text { get; private set; }`               |
|------------------------------|------------------------------------------------------|----------------------------------------------------------|
| **Modifiable**               | Once only (at declaration or in the constructor)     | Internally modifiable multiple times                     |
| **External Modification**    | Not allowed                                          | Not allowed                                              |
| **Typical Usage**            | Immutable values after initialization                | Access control with internal flexibility                 |

## 3. Constructors

In C#, a constructor is a special method that initializes a new object’s properties when it is created. Constructors allow us to set required values directly at the time of object creation.

Here’s an example of a constructor in the `Car` class:

```csharp
namespace Clients
{
    internal class Car
    {
        public string Color { get; private set; }
        public string Brand { get; private set; }

        public Car(string color, string Brand)
        {
            Color = color;
            this.Brand = Brand; // Using `this` to distinguish between the parameter and the field
        }
    }
}
```

**Note**: In the constructor parameters, we use lowercase (`color` and `brand`). For the second parameter, `brand`, the name matches the class field name `Brand`. To distinguish them, we use `this.Brand`, where this refers to the current instance of the class.

