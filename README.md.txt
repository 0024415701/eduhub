# EduHub - Club and Event Management

## 1. Project Overview

EduHub is a C# Console Application developed for the IN4211 Object-Oriented Programming assignment. It demonstrates object-oriented design and basic club and event management.

## 2. Domain Design

The project contains five main domain classes:

- **Member:** Represents a member with personal information and active status.
- **Club:** Represents a club and manages its members.
- **Event:** Represents an event organized by a club and checks event capacity.
- **Registration:** Represents a member's event registration and manages its status.
- **CheckIn:** Records a member's check-in for an event.

The `RegistrationStatus` enum represents Pending, Confirmed, and Cancelled registration states. The `CheckInMethod` enum represents the check-in method.

## 3. Project Structure

- `EduHub.Console/`: Console application and demo program.
- `EduHub.Domain/`: Domain classes and business rules.
- `docs/user-stories.md`: User stories and business requirements.
- `docs/class-diagram.md`: Domain class diagram.

## 4. Requirements

- .NET Console Application
- Nullable reference types enabled
- Factory methods for object creation
- Input validation and domain behavior
- XML documentation for public APIs

## 5. How to Run

1. Open `EduHub.sln` in Visual Studio.
2. Set `EduHub.Console` as the startup project.
3. Build the solution.
4. Run the application using **Ctrl + F5** or the Run command in Visual Studio.
5. Review the console output for club creation, member registration, event confirmation, check-in, and the attendance report.

Alternatively, open a terminal in the directory containing `EduHub.Console.csproj` and run:

```bash
dotnet run
```

## 6. Demo Output
![EduHub console demo](demo-output.png)

## 7. Author

- Student ID: 0024415701