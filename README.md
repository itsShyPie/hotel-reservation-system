# Hotel reservation system

A Windows desktop booking system for a hotel group, built in C# WinForms on a three-layer
architecture over a SQL Server database.

Systems Design & Development project (INF2011S), University of Cape Town, 2024. Group of 4.

## Features

- Create, change and cancel bookings, with checks on room capacity, dates and child rates
- Guest records, guest lists and new-guest registration
- Payments
- Occupancy and financial reports
- Seasonal room rates

## Architecture

| Layer | Folder | What it holds |
|---|---|---|
| Presentation | `Group71/Presentation/` | The WinForms screens: bookings, guests and reports |
| Business | `Group71/Business/` | Domain classes and controllers: guests, reservations, rooms, rates, payments |
| Data | `Group71/Data/` | Data access to a SQL Server LocalDB database (`HotelReservationsDB.mdf`) |

## Run

Needs Windows, Visual Studio with .NET Framework 4.7.2, and SQL Server Express LocalDB (installed
with Visual Studio's data storage workload).

1. Open `Group71.sln`.
2. Build and run (F5). The database is copied next to the app and attached automatically.
