
﻿<h1 align="center">🧹 CleanDesk — Windows System Optimizer</h1>

<p align="center">
  <b>A lightweight WPF utility to monitor and clean your Windows system.</b><br/>
  Built with <b>.NET 8</b> and <b>WPF (MVVM architecture)</b> 💻
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/WPF-Desktop%20App-blue?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge"/>
</p>

---

## 🧭 Overview

**CleanDesk** is a desktop application built with **C# / .NET 8 / WPF** that provides system monitoring and cleanup features for Windows.  
It displays **live CPU and RAM usage**, and offers **one-click cleanup** to remove temporary files, browser caches, and free unused memory safely.

The project is designed for educational and practical learning purposes — a perfect example of integrating **Win32 API calls**, **performance counters**, and **MVVM pattern** in a modern WPF app.

---

## ✨ Features

| 🔧 Feature | Description |
|------------|-------------|
| 🧠 **Live System Monitoring** | Real-time CPU and RAM usage updates every few seconds |
| 🧹 **System Cleanup** | Deletes temporary and cache files (Windows + browser) |
| ⚡ **Memory Optimization** | Frees unused RAM using Win32 APIs |
| 🪟 **Modern UI** | Clean and minimal interface built with WPF |
| 📊 **MVVM Architecture** | Clear separation between UI and logic |
| 📄 **Logging** | Records cleanup results for transparency |

---

## 🧱 Tech Stack

- **Language:** C# 12  
- **Framework:** .NET 8  
- **UI:** WPF (XAML)  
- **Architecture:** MVVM  
- **APIs:** Win32 (for RAM cleanup), WMI, PerformanceCounter  
- **IDE:** Visual Studio 2022

---

## 🚀 Getting Started

### 1️⃣ Requirements
- Windows 10 or later  
- Visual Studio 2022 (17.6+)  
- .NET 8 SDK  
- “.NET Desktop Development” workload installed

---

### 2️⃣ Clone the repository
```bash
git clone https://github.com/bashar267/CleanDesk.git
cd CleanDesk
