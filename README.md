# 11. Object-Oriented Programming (OOP) - Introduction (DRAFT)

OOP stands for **ORIENTED OBJECT PROGRAMMING**

## 1. What is an object and a class? 

Before diving into the world of OOP in C# we need to clarify what is a `class` and an `object`. For example, an object could be a `car`, a `chair`, a `house` but it could also be a `client` even a `cat` (if you love cat). 

If we take for example the ´Car´ object (we always take this example ...). Let us describe it. 

A car has some caracteristics (called `Fields` or `Attributes`) and some functionalities like `Starting engine` ,... 

But bad news (or good news, depends on the your pov) we don't have one car on roads but thousands. 

If the factory wants to create them so fast, they need a pattern, something that can describe the `attributes (fields)` and the `functionalites`. 

So in OOP, we have `classes`.


## 2. Create our first Class

Good news, you already have created your first class in the previous exercices, but let's explore them to understand well. 

For this example, let us create a new `solution` including a `project` named `OOP`.

Create a new class `Car`.

```csharp
namespace Clients
{
    internal class Car
    {
    }
}
```

Oh wait, What is `internal` ? Previously we have seen `public`. Quick answer ...
- `Internal` classes are only available in the `project` itself.
- `Public` classes are available everywhere in the `solution`.

### A. Fields (attributes)

In our `car` class, we need to specify its color, its brand and so on ...

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

### B. Object 
From this class, create our first object `car`;

```csharp
namespace Clients
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Color = "red";
            Console.WriteLine(car.Color);
        }
    }
}
```

Well, this line is not correct ` car.Color = "red";`.  We can do this action because the `public` keyword is assign to the `field`. 
Please, always use a `getter` or a `setter` to get or set a field. So here is an example of what we called `Accessors`

```csharp
namespace Clients
{
    internal class Car
    {
        private string _Color;
        private string _Brand;

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

It is better but you remark that will be not a super cool code! Imagine you have 5 or 10 fields (20 methods) and also add the methods of the class. 

So, let us fix this with `Properties` ! 

### C. Properties

```csharp
namespace Clients
{
    internal class Car
    {
        public string Color { get; set; }
        public string Brand { get; set; }
    }
}
```

Cool, it seems better ! But we can go deeper. Imagine, you don't allow user to change de color of the car, which is not possible if you already have bought your car. So the field must be `readonly`.
let us just adjust our code and add a `private` keyword bedore the `set` method.

``public string Colour { get; private set; }`` 

So how can we now set the color of our car? We have two possiblities but it depends on what you want. 

- You want that every cars have the same color : ``public string Colour { get; private set; } = "Red";``
- Or we can use a `constructor` which is better in this case, so every object will have a different color. 

## 3. Constructors


