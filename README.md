# Measurement Studio ScatterGraph Interactive Editor

This repository contains a C# .NET Framework sample application demonstrating **interactive data editing** using **NI Measurement Studio 2019** ScatterGraph controls.  
The program loads 3‑axis acceleration data from a CSV file, displays it in three toggleable plots (X/Y/Z), and allows users to **select and vertically drag points** to modify data values in real time.  
Edited data can then be exported while preserving the original input file headers and metadata.

---

## 📌 Features

- Load 3‑axis acceleration data from CSV  
- Toggle visibility of X, Y, and Z ScatterPlots  
- Click to select a data point  
- Drag vertically to edit values in real time  
- Annotation showing the currently edited point  
- Smooth updates using `ReplacePlotData` (zoom‑safe)  
- Export modified data while keeping:
  - original headers  
  - metadata  
  - CSV structure  

---

## 📁 Sample Data

A sample input CSV file is included in this repository so you can test:

- loading  
- point editing  
- exporting  

The application will reproduce the file format exactly, including all metadata lines.

---

## 🛠 Requirements

- **Windows**
- **.NET Framework 4.7.2** (or compatible)
- **NI Measurement Studio 2019**  
  - Windows Forms Graph control (`ScatterGraph`)
- Visual Studio 2019 or newer

---

## 🚀 How to Run

1. Clone the repository  
2. Open the solution in Visual Studio  
3. Make sure NI Measurement Studio components are installed  
4. Build and run  
5. Load the sample CSV file from the repository  
6. Click on any point and drag vertically to edit  
7. Press **Export** to save modified data

---

## 📦 Project Structure
