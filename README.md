# Entity Framework Inheritance Types
1. Table per Hierarchy
2. Table per Type
3. Table per Conrete Type

## Table-per-Hierarchy
Table per Hierarchy inheritance uses one database table to maintain data for all entity types in an inheritance hierarchy. A new `Discriminator` column is added to the table which is used to distingush between persisted classes.
### Sample
```csharp
public class BillingDetail
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string Number { get; set; }
}

public class BankAccount : BillingDetail
{
    public string BankName { get; set; }
    public string Swift { get; set; }
}

public class CreditCard : BillingDetail
{
    public int CardType { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
}
```
### Generated SQL Query
```sql
CREATE TABLE "BankDetails" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_BankDetails" PRIMARY KEY AUTOINCREMENT,
    "Owner" TEXT NULL,
    "Number" TEXT NULL,
    "Discriminator" TEXT NOT NULL,
    "BankName" TEXT NULL,
    "Swift" TEXT NULL,
    "CardType" INTEGER NULL,
    "ExpiryMonth" TEXT NULL,
    "ExpiryYear" TEXT NULL
);
```

## Table-per-Type
Table-per-type inheritance uses a separate table in the database to maintain data for non-inherited properties for each type in the inheritance hierarchy.

### Sample
```csharp
[Table("Person")]
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

[Table("Client")]
public class Client : Person
{
    public string Email { get; set; }
}

[Table("User")]
public class User : Person
{
    public string UserName { get; set; }
}
```

### Generated SQL Query
```sql
CREATE TABLE "Person" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Person" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL
);
CREATE TABLE "Client" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Client" PRIMARY KEY AUTOINCREMENT,
    "Email" TEXT NULL,
    CONSTRAINT "FK_Client_Person_Id" FOREIGN KEY ("Id") REFERENCES "Person" ("Id") ON DELETE CASCADE
);
CREATE TABLE "User" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_User" PRIMARY KEY AUTOINCREMENT,
    "UserName" TEXT NULL,
    CONSTRAINT "FK_User_Person_Id" FOREIGN KEY ("Id") REFERENCES "Person" ("Id") ON DELETE CASCADE
);
```

## Table-per-ConreteType
Table per Concrete type uses one table for each (nonabstract) class and all the properties (including inherited properties) can be mapped to columns of the table.

### Sample
```csharp
public class BasEntity<T> {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
}

public class Student : BasEntity<int>
{
    public DateTime EnrollmentDate { get; set; }
}

public class Teacher : BasEntity<String>
{
    public DateTime HiredDate { get; set; }
}
```

### Generated SQL Query
```sql
CREATE TABLE "Students" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Students" PRIMARY KEY AUTOINCREMENT,
    "EnrollmentDate" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL,
    "Name" TEXT NULL
);

CREATE TABLE "Teachers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Teachers" PRIMARY KEY,
    "HiredDate" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL,
    "Name" TEXT NULL
);
```