
# **BDD Test Suite for Hasti Wallet**

## **📌 Overview**

This repository contains a **Behavior-Driven Development (BDD) test suite** for a multi-company, multi-wallet, multi-user digital wallet system. It ensures the correct functionality of key financial operations, such as payments, deposits, withdrawals, and transfers.

---

## **📝 Project Description**

This BDD test suite is designed to verify the functionality of the Hasti Wallet system using modern testing methodologies. The project is built on **.NET 7** and employs various testing packages to ensure high reliability and accuracy in financial transactions.

---

## **✨ Features Covered in Tests**

- 🔄 **Refund**
- 🔁 **Transfer**
- 💳 **Payment**
- 💰 **Deposit**
- 💸 **Withdrawal**

---

## **🚀 Getting Started**

### **📌 Prerequisites**

Ensure you have installed the following dependencies:

- **.NET 7** ([Download & Install](https://dotnet.microsoft.com/en-us/download/dotnet/7.0))
- **SQL Server**

---

## **📂 Project Structure**

### **📌 1. Models**
Defines core data models used in the test suite.

### **📌 2. Constants**
Stores reusable constant values.

### **📌 3. Shared**

#### **📁 Projects**
- **1.0 Constants**
  - **1.1 Models**

#### **📦 Packages**
- `suzianna.core (1.1.0)`

### **📌 4. Technical.Rest**

#### **📁 Projects**
- **1.0 Shared**
  - **1.1 Constants**
    - **1.1.1 Models**

#### **📦 Packages**
- `suzianna.core (1.1.0)`
- `suzianna.rest (1.1.0)`

### **📌 5. Technical.WebUI**

#### **📁 Projects**
- **1.0 Shared**
  - **1.1 Constants**
    - **1.1.1 Models**

#### **📦 Packages**
- `suzianna.core (1.1.0)`
- `selenium.webdriver (4.7.0)`
- `DotNetSeleniumExtras.WaitHelpers (3.11.0)`
- `selenium.webdriver.chromedriver (108.0.5359.7100)`

### **📌 6. Specs (BDD Tests)**

#### **📁 Projects**
- **1.0 Technical.Rest**
- **2.0 Technical.WebUI**

#### **📦 Packages**
- `xunit (2.4.2)`
- `coverlet.collector (3.2.0)`
- `Microsoft.NET.Test.Sdk (17.4.0)`
- `xunit.runner.visualstudio (2.4.5)`
- `specflow (3.9.74)`
- `restsharp (108.0.3)`
- `suzianna.core (1.1.0)`
- `suzianna.rest (1.1.0)`
- `specflow.xunit (3.9.74)`
- `fluentassertions (6.8.0)`
- `SpecFlow.Tools.MsBuild.Generation (3.9.74)`
- `Microsoft.Extensions.Configuration (7.0.0)`
- `Microsoft.Extensions.Configuration.Json (7.0.0)`
- `Microsoft.Extensions.Configuration.Binder (7.0.0)`
- `Microsoft.Extensions.Configuration.Abstractions (7.0.0)`

#### **🌐 Web Services Tested**
- `Dtat.Wallet`

---
