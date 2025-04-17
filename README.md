# Station Offset Calculator

This is a C# WinForms application that calculates the **Station** and **Offset** between a given point and a polyline. It's a solution for the programming exercise proposed by **Fugro**.

---

## 📐 Problem Description

Given:
- A **Polyline** defined by a sequence of (Easting, Northing) coordinates.
- A **Point** input by the user.

The app computes:
- **Offset**: The shortest perpendicular distance from the point to the polyline.
- **Station**: The distance along the polyline from the start to the point of intersection with the perpendicular line.

---

## 💻 Features

- Load polyline from an ASCII `.csv` file.
- User input for coordinates (Easting and Northing).
- Displays computed Station, Offset, and closest point on the polyline.
- Robust geometry calculations using object-oriented design.
- Modular architecture (Core, UI, Tests).
- Unit tested with MSTest.

---

## 📁 Project Structure

```
StationOffsetCalculator/
├── Core/                   # Domain logic (models and services)
│   ├── Models/             # Point, LineSegment, Polyline
│   └── Services/           # PolylineReader, StationOffsetCalculator
│
├── WinForms/               # Windows Forms UI project
│   └── (UI forms and logic)
│
├── Tests/                  # MSTest unit tests
│   └── StationOffsetCalculatorTests.cs
│
└── README.md
```

---

## 📦 How to Run

### Requirements:
- .NET 9

### Run the application:
```bash
dotnet build
dotnet run --project StationOffsetCalculator.WinForms
```

### Run tests:
```bash
dotnet test
```

---

## 🧪 Sample Input File

The polyline file is a comma-separated `.csv` with no header:

```
0,0
10,0
10,10
```

---

## 📊 Example

Given point: `(5, 5)`  
Polyline: `[(0, 0), (10, 0), (10, 10)]`

Result:
- **Offset**: 5
- **Station**: 5
- **Nearest point**: (5, 0)

---

## ✅ Deliverables

- ✔️ Executable (WinForms app)
- ✔️ Source code (C#)
- ✔️ Unit tests
- ✔️ README documentation

---

## 📄 License

This project is for educational and demonstration purposes only. No official license is applied.

---

## 🙋‍♂️ Author

Developed by Hugo Stowasser as part of the Fugro Programming Exercise.
