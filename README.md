# Hotel API

A simple **ASP.NET Core** (C#) Web API that serves hotel data from a local JSON file.  
The API provides two endpoints:

- **GET** `/api/hotels` – Returns a list of all hotels.  
- **GET** `/api/hotels/{id}` – Returns details for a specific hotel by its `id`.  

## Table of Contents
1. [Features](#features)  
2. [Technology Stack](#technology-stack)  
3. [Folder Structure](#folder-structure)  
4. [Data Source (hotels.json)](#data-source-hotelsjson)  
5. [Setup and Running Locally](#setup-and-running-locally)  
6. [Testing the API](#testing-the-api)  
---

## Features
1. **Simple HTTP Endpoints** for retrieving hotels data.  
2. Uses **.NET 6/7 Minimal Hosting** for easy setup.  
3. Reads data from `hotels.json`—no database required.  
4. Returns **JSON** responses with appropriate HTTP status codes (200, 404, etc.).  
5. Demonstrates the **Repository Pattern** for clean separation of concerns.

---

## Technology Stack
- **C#** / **.NET 6 or 7**  
- **ASP.NET Core** for the Web API  
- **System.Text.Json** for JSON serialization/deserialization  
- **Dependency Injection** for the repository

---

## Folder Structure

HotelApi/
├── Controllers/
│    └── HotelsController.cs      // The API controller with endpoints
├── Data/
│    └── hotels.json             // JSON file containing hotel data
├── Models/
│    ├── Hotel.cs
│    └── Room.cs
├── Repositories/
│    ├── IHotelRepository.cs
│    └── HotelRepository.cs
├── Program.cs                    // Minimal hosting setup and app configuration
├── HotelApi.csproj              // Project file
└── README.md                    // This file



### Explanation
- **Controllers**: Contains the `HotelsController` class, which defines our **/api/hotels** endpoints.  
- **Data**: Holds the `hotels.json` file with hotel records.  
- **Models**: C# classes (`Hotel` and `Room`) that mirror the structure of the JSON data.  
- **Repositories**: Data-access logic. `HotelRepository` loads and serves data from `hotels.json` to the controller.  
- **Program.cs**: The **entry point** for the .NET Web API (minimal hosting style).

---

## Data Source (`hotels.json`)

A JSON file located at `Data/hotels.json` with an array of **10** hotel records. Each record has:
- **id**  
- **name**  
- **location**  
- **rating**  
- **imageUrl**  
- **datesOfTravel** (array of strings)  
- **boardBasis**  
- **rooms** (array of room objects, each with `roomType` and `amount`)

Example snippet:

```json
[
  {
    "id": 1,
    "name": "Seaside Paradise",
    "location": "Maldives",
    "rating": 4.9,
    "imageUrl": "https://example.com/images/seaside-paradise.jpg",
    "datesOfTravel": ["2024-01-01","2024-01-07"],
    "boardBasis": "All Inclusive",
    "rooms": [
      { "roomType": "Deluxe Suite", "amount": 5 },
      { "roomType": "Family Room", "amount": 3 }
    ]
  },
  ...
]


##Setup and Running Locally
1. Prerequisites
.NET 6 SDK or .NET 7 SDK installed.
An IDE or editor like Visual Studio or Visual Studio Code.
2. Clone or Download
Clone this repository
git clone https://github.com/your-username/HotelApi.git
cd HotelApi
Ensure the folder contains Program.cs, Controllers/HotelsController.cs, Data/hotels.json, etc.
3. Build & Run
In Visual Studio:  Open the .sln or .csproj file.
Select Build → Rebuild Solution (or press Ctrl+Shift+B).
Press F5 (or the “Start” button) to run in debug mode.

In Visual Studio Code: Open the folder containing HotelApi.csproj.
When prompted, “Add required assets for debugging?” choose Yes.
Press F5 to start debugging.

Alternatively, from a terminal:
>dotnet restore
>dotnet run
4. The Web Server
Once running, the console or debug window will show something like:

Now listening on: https://localhost:7047
Now listening on: http://localhost:5047
...
That means the API is up and listening at those URLs.


##Testing the API
Use a browser or tool like Postman or curl to send requests to the endpoints.

1.GET /api/hotels

URL example: https://localhost:7047/api/hotels
Should return a JSON array of hotels (10 records).

2.GET /api/hotels/{id}

Example: https://localhost:7047/api/hotels/3
Returns the hotel with id = 3, or a 404 message "Hotel 3 if not found".

Please Note: When we run the code by default it renders " GET /api/hotels" end point.



