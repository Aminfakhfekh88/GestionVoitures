# GestionVoitures

A car rental management web app built with **ASP.NET Core MVC** (C#). It's a guided practical (TP) from the ENET'Com *Programmation Web* course, Chapter 3. It covers a full CRUD cycle using an in-memory static list, with no database.

## Features

- List all cars in a catalogue table
- Add a new car
- Edit an existing car
- Delete a car (with a confirmation page)
- Availability badge (Disponible / Louée)

## Tech Stack

- C# / .NET (ASP.NET Core MVC)
- Razor views (`.cshtml`)
- Bootstrap 5
- Static `List<Voiture>` stored in RAM

## Project Structure

```
GestionVoitures/
├── Controllers/
│   ├── HomeController.cs
│   └── VoitureController.cs
├── Models/
│   ├── ErrorViewModel.cs
│   └── Voiture.cs
├── Views/
│   ├── Home/        (Index, Privacy)
│   ├── Voiture/     (Index, Create, Edit, Delete)
│   └── Shared/      (_Layout, Error, ...)
├── wwwroot/
├── appsettings.json
└── Program.cs
```

## Model

| Property        | Type      | Description            |
|-----------------|-----------|------------------------|
| `Id`            | `int`     | Unique identifier      |
| `Marque`        | `string`  | Brand                  |
| `Modele`        | `string`  | Model                  |
| `Annee`         | `int`     | Year of manufacture    |
| `PrixJour`      | `decimal` | Daily rate (DT)        |
| `EstDisponible` | `bool`    | Availability status    |

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (the version used by the project)
- Visual Studio 2022+ or any code editor

### Run the project

```bash
git clone https://github.com/Aminfakhfekh88/GestionVoitures.git
cd GestionVoitures
dotnet run
```

Then open the URL shown in the terminal, followed by `/Voiture`, for example:

```
http://localhost:5115/Voiture
```

## Routes

| URL                   | Action                       |
|-----------------------|------------------------------|
| `/Voiture`            | List all cars                |
| `/Voiture/Create`     | Add a car                    |
| `/Voiture/Edit/{id}`  | Edit a car                   |
| `/Voiture/Delete/{id}`| Delete a car (confirmation)  |

## Note

Data is stored in a static list in memory. Restarting the app resets the list to its initial state. The next step would be persistent storage with **Entity Framework Core** and a SQL database.

## Author

**Mohamed Amine Fakhfekh**, student at ENET'Com, Sfax.
