# Customer Management Application

**Author**: Musab Kaya  
**Date**: December 21, 2024  
**Version**: 1.0  

## Overview
This is a WinForms-based Customer Management application for .NET Framework 4.8. It provides the following primary features:

- **Home Page (Dashboard)**:  
  - Shows total customers, total orders, total sales, and average order value.
  - Links to Customer Management and Options menus.

- **Customer Management**:  
  - Add, edit, or remove customers (including FirstName, LastName, City, Country, OrderCount, and TotalSales).
  - Automatically saves data to TSV (tab-separated) files (`customers.tsv`, `tiers.tsv`).

- **Options**:
  - **Theme Toggle** (light/dark).
  - **Tier Management** (add, edit, remove tier levels such as Bronze, Silver, Gold).
  - Potential space for additional customization features.

## Project Structure
The solution contains two projects:

1. **CustomerManagementLibrary (Class Library)**  
   - Contains core business logic (`CustomerManager`, `Customer` classes).  
   - Handles data loading, saving, tier logic, etc.

2. **CustomerManagementUI (WinForms App)**  
   - WinForms project for the graphical user interface.  
   - Forms: `HomePageForm`, `MainForm` (customer management), `OptionsForm` (theme, tier management), `AddEditCustomerForm` (dialog to add/edit a single customer).

## Requirements
- **.NET Framework 4.8** (or compatible .NET Framework version).  
- Windows OS (WinForms is Windows-specific).  
- No additional third-party dependencies (unless you added them in code).

## Building & Running
1. **Open in Visual Studio** (or a compatible .NET IDE).  
2. Ensure the solution is set to **Release** mode.  
3. **Build the solution**.  
4. The compiled application will appear in  
   `\CustomerManagementUI\bin\Release\CustomerManagementUI.exe`
5. Copy the **.exe** and any **.dll** files (including `CustomerManagementLibrary.dll`) to a folder on the target machine.
6. Make sure the target machine has **.NET Framework 4.8** installed.
7. **Double-click** `CustomerManagementUI.exe` to run the application—no Visual Studio required.

## Usage
- **Home Page**: Shows high-level metrics about customers. Provides buttons to navigate:
  - **Customer Management**: Manage your customers, add new ones, edit or remove existing ones.
  - **Options**: Switch between light/dark theme, manage tiers, and other future customizations.

- **Data Storage**:  
  - By default, data is saved in `customers.tsv` and `tiers.tsv`, typically located in the same folder as the .exe.
  - Each time you add/edit/remove a customer or tier, changes are automatically saved.

---
All Rights Reserved.
---

Happy Managing!
