# 11. Object-Oriented Programming (OOP) - Introduction (DRAFT)

OOP stands for **ORIENTED OBJECT PROGRAMMING**

## Classes and Objects: Definition, instantiation, and usage.

- **Classes :** A class is a blueprint or template for creating objects, defining a type by encapsulating data (properties) and behavior (methods).
- **Objects :** An object is an instance of a class. It is a specific realization of the class, with its own set of values for the fields defined by the class.

To init a class, use the keyword **class** next to its name. I adive you to use the SnakeCase. Let see an example.

```csharp
class Car
{

}
```

And now, let us simple **instantiate** this class to create a new object.

| Type | object |     | keyword | class |
| ---- | ------ | --- | ------- | ----- |
| Car  | volvo  | =   | new     | Car() |

## Constructors and Destructors: Purpose and syntax.

A constructor is a special method in C# that initializes a new instance of a class. It has the same name as the class and is used to set default values, initialize properties, and perform any setup required when an object is created. Constructors do not have a return type.

```csharp
public class Car{

    // Attributes
    string model;

    // Constructor
    Car(string ModelName)
    {
        model = modelName;
    }

    // Destructor
    ~Car()
    {
        Console.WriteLine($"Destructor called for " {model});
    }
}

Car volvo = new Car("Volvo");
```

## Encapsulation: Access modifiers (public, private, protected).

Encapsulation is an object-oriented programming principle that restricts direct access to an object's data and methods to prevent unintended interference and misuse. This is achieved using access modifiers.

- public: Members are accessible from any other code.
- private: Members are accessible only within the same class.
- protected: Members are accessible within the same class and by derived class instances.

```csharp
public class Car{

    // Attributes
    public string model;
    public string color;
    public int year;

    // Constructor
    public Car(string modelName, string modelColor, int modelYear)
    {
        model = modelName;
        color = modelColor;
        year = modelYear;
    }

    // Destructor
    ~Car()
    {
        Console.WriteLine($"Destructor called for " {this.model});
    }

}

Car volvo = new Car("Volvo", "Black",2016);
Console.WriteLine($"{volvo.model} {volvo.color} {volvo.year}");
```

## Properties and Encapsulation

Before going further, you sould have a basic understanding of **Encapsulation**.

Encapsulation is an object-oriented programming concept where the internal state of an object is hidden from the outside world. Access to this state is restricted to certain methods and properties, which are controlled using access modifiers (such as public, private, and protected). This ensures that the object's data is protected from unintended interference and misuse, promoting modularity and maintainability.

- Declare attributes as **private**
- Provide **public get** and **public set** to access and update value of a private field.

```csharp
public class Car{

    // The Long One
    private string model;

    // Get and Set
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    // The Short one
    public string Color { get;set; }
    public int Year { get; set; }

    // Constructor
    public Car(string model, string color, int year)
    {
        this.Model = model;
        this.Color = color;
        this.Year = year;
    }
}

Car volvo = new Car("Volvo", "Black",2016);

volvo.Model = "Audi";
Console.WriteLine($"{volvo.Model} {volvo.Color} {volvo.Year}");
```

## Inheritance: Base and derived classes.

Inheritance is an object-oriented programming concept where a new class (derived class) inherits the properties and methods of an existing class (base class). This allows for code reusability and the creation of a hierarchical relationship between classes, where the derived class can extend or modify the behavior of the base class.

- Derived Class (child) : The class that inherits
- Base Class (parent) : The class being inherited from

```csharp
public class User
{
    public String Role { get; set; }

    public User(string Role)
    {
        this.Role = Role;
    }

    public string init()
    {
        return "This is called from the parent class.";
    }
}

public class Admin : User
{
    public string Username { get; set; }
    public string Email { get; set; }

    public Admin (string Username, string Email)
    {
        this.Username = Username;
        this.Email = Email;
    }
}

Admin admin = new Admin("Admin","Admin@admin.be");
Console.WriteLine($"{admin.init()}");
```

But if you don't want the class to be inherited by another, you can use the keyword **sealed**

```csharp
public sealed class Car
{
    // ...
}
```

## Polymorphism: Method overriding and overloading.

Polymorphisme means "many forms".

```csharp
public class Animal
{
    public virtual void animalSound()
    {
        Console.WriteLine("The animal makes a sound");
    }
}

public class Pig : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The pig says: wee wee");
    }
}

public class Dog : Animal
{
  public void override animalSound()
  {
    Console.WriteLine("The dog says: bow wow");
  }
}

Animal Aminal = new Animal();
Animal pig = new Pig();
Animal Dog = new Dog();

animal.animalSound();
pig.animalSound();
dog.animalSound();
```

## Interfaces and Abstract Classes: Definitions and use cases.

The two last points are interfaces and abstract classes.

- **Abstract class:** A class that cannot be instantiated and is designed to be inherited by other classes. It can include both abstract methods (without implementation) and non-abstract methods (with implementation).

```csharp
public abstract class Animal
{
    public abstract void animalSound();
}

public class Pig : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The pig says: wee wee");
    }
}

Animal myAnimal = new Animal(); // Will generate an error (Cannot create an instance of the abstract class or interface 'Animal')
```

- **Interface:** An interface is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies).

By default members of an interface are **abstract** and **public**

```csharp
interface IAnimal
{
    void animalSound();
}

public class Pig : IAnimal
{
    public void animalSound()
    {
        Console.WriteLine("The pig says: wee wee");
    }
}
```

## Exercices

### 1. LibrarySystem

```csharp
using LibrarySystem;

namespace fundamentals.Test
{
    public class BookTest
    {
        [Test]
        public void Book_CanBeCreate_WithValidData()
        {
            string title = "The Great Gatsby";
            string author = "F. Scott Fitzgerald";
            string isbn = "9780743273565";

            Book book = new(title, author, isbn);

            Assert.Multiple(() => {
                Assert.That(book.Title,Is.EqualTo(title));
                Assert.That(book.Author,Is.EqualTo(author));
                Assert.That(book.ISBN,Is.EqualTo(isbn));
            });
        }

        [Test]
        public void Book_Checkout_DisplayCorrectMessage()
        {
            Book book = new("1984","George Orwell", "9780451524935");

            Assert.That(() => book.Checkout(), Throws.Nothing);
        }

        [Test]
        public void Book_Return_DisplayCorrectMessage()
        {
            Book book = new("To Kill a Mockingbird", "Harper Lee", "9780061120084");

            Assert.That(() => book.Return(),Throws.Nothing);
        }
    }
}
```

```csharp
using LibrarySystem;

namespace fundamentals.Test.LibrarySystem
{
    public class TestLibraryMember : LibraryMember
    {
        public TestLibraryMember(string memberId, string name) : base(memberId, name) { }
    }
    public class LibraryMemberTest
    {
        [Test]
        public void LibraryMember_CanBeCreate_WithValidData()
        {
            string memberId = "M123";
            string name = "John";

            TestLibraryMember member = new(memberId, name);

            Assert.Multiple(() => {
                Assert.That(member.MemberId,Is.EqualTo(memberId));
                Assert.That(member.Name,Is.EqualTo(name));

            });
        }

        [Test]
        public void BorrowedBooks_IsInitiallyEmpty()
        {
            TestLibraryMember member = new("M123","John Doe");
            var borrowBooks = member.BorrowedBooks;
            Assert.That(borrowBooks, Is.Empty);
        }

        [Test]
        public void BorrowBook_AddsBookToBorrowedBooksList()
        {
            TestLibraryMember member = new("M123","John Doe");
            Book book = new("The Hobbit", "J.R.R. Tolkien", "9780261103283");

            member.BorrowBook(book);

            Assert.Multiple(() =>
            {
                Assert.That(member.BorrowedBooks, Contains.Item(book));
                Assert.That(member.BorrowedBooks.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ReturnBook_RemovesBookFromBorrowedBooksList()
        {
            TestLibraryMember member = new("M123","John Doe");
            Book book = new("The Hobbit", "J.R.R. Tolkien", "9780261103283");

            member.BorrowBook(book);
            member.ReturnBook(book);

           Assert.Multiple(() => {
                Assert.That(member.BorrowedBooks, Does.Not.Contain(book));
                Assert.That(member.BorrowedBooks, Is.Empty);
           });
        }
    }
}
```

```csharp
using LibrarySystem;

namespace fundamentals.Test.LibrarySystem
{
    public class TestStudentMember
    {
        [Test]
        public void StudentMember_CanBeCreate_WithValidData()
        {
            string memberId = "PM23";
            string name = "John Doe";

            StudentMember studentMember = new(memberId,name);

            Assert.Multiple(() => {
                Assert.That(studentMember.MemberId, Is.EqualTo(memberId));
                Assert.That(studentMember.Name, Is.EqualTo(name));
            });
        }

        [Test]
        public void StudentMember_Has_BorrowLimit()
        {
            StudentMember studentMember = new("PM23","John Doe");

            Book book1 = new("Title1","Author1","ISBN4");
            Book book2 = new("Title2","Author2","ISBN4");
            Book book3 = new("Title3","Author3","ISBN4");
            Book book4 = new("Title4","Author4","ISBN4");

            studentMember.BorrowBook(book1);
            studentMember.BorrowBook(book2);
            studentMember.BorrowBook(book3);
            studentMember.BorrowBook(book4);

            Assert.That(studentMember.BorrowedBooks.Count, Is.EqualTo(3));
        }
    }
}
```
