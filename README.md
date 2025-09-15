# 🏥 Clinic Management System

A web-based **Clinic Management System** built with **ASP.NET MVC**, **SQL Server**, and **Entity Framework**.  
The system helps patients book appointments with doctors in different clinics, while administrators and medical assistants manage doctors, services, and users efficiently.  

---

## 🚀 Project Overview

The project aims to connect **clinics, doctors, and patients** in one platform.  
It provides role-based access, appointment booking, user management, and services management for clinics.  

---

## 🎯 Objectives

- Allow patients to **register** and **book appointments** with doctors.  
- Manage doctors, clinics, and medical services.  
- Implement **role-based access control** for Admins, Medical Assistants, and Users.  
- Ensure clean and maintainable code using design patterns.  

---

## 🏗️ System Architecture

**Technologies & Patterns Used:**

- ASP.NET MVC  
- SQL Server  
- Entity Framework (Code First)  
- Generic Repository & Unit of Work  
- AutoMapper (Entity ↔ DTO ↔ ViewModel mapping)  
- Custom Validation  
- Dependency Injection  
- ASP.NET Identity (User & Role Management)  

---

## 🗄️ Database Design

**Main Tables:**

- **Doctors**  
- **Specializations**  
- **Clinics**  
- **ClinicDoctors** (Many-to-Many between Doctors & Clinics)  
- **Services** (linked to Clinics)  
- **Appointments** (linked to Users, Doctors, and Clinics)  
- **AppUser (Identity)**  
- Identity Tables (Roles, Claims, etc.)  

---

## 🔑 Roles & Permissions

| Role               | Permissions |
|--------------------|-------------|
| **Admin**          | Manage users & roles |
| **Medical Assistant** | Add/remove doctors, manage appointments |
| **User (Patient)** | Register & book appointments |

---

## ✨ Features

- **Authentication & Authorization** (ASP.NET Identity)  
- **CRUD Operations** for Doctors, Clinics, and Services  
- **Appointment Booking System**  
- **User Management** (Admin can delete or edit users)  
- **Role Management**  
- **Image Uploads** (e.g., doctor photos, clinic images)  
- **Select Items (Dropdowns)** to display related data  

---

## ⚙️ Implementation Details

- **Generic Repository + UnitOfWork**: Reusable and clean data access layer.  
- **Services Layer**: Handles business logic separate from controllers.  
- **AutoMapper**: Converts between Entities, DTOs, and ViewModels.  
- **Dependency Injection**: Registers all services for easy access.  
- **Custom Validation**: Example – prevent booking duplicate appointments.  

---

## 📸 Screenshots / Demo

*(Add project screenshots here: Login, Appointment Booking, User Management, etc.)*

---

## 🧩 Challenges & Solutions

- **Many-to-Many relationships**  
  *Solved using EF Core with a join table (ClinicDoctors).*  

- **Role Management**  
  *Implemented with ASP.NET Identity.*  

- **Code Organization**  
  *Handled using Repository + Services + AutoMapper.*  

---

## 👨‍💻 Team Members & Contributions

### **Ahmed Noser**  
Designed the architecture and design patterns, implemented authorization (service & controller), and worked on backend integration.  

### **Mohamed Elshabrawy**  
Developed the database schema, handled Entity Framework, and managed data relationships.  

### **Maryam Elmetwally**  
Designed the UI/UX for the system and implemented one module connected with the frontend.  

### **Farida Almekkawi**  
Implemented authentication (service & controller) and contributed to business analysis.  

### **Fatma Attia**  
Developed one module (service & controller) and worked on requirements analysis.  

### **Mohamed Hossam**  
Focused on the frontend, implemented the largest portion of the UI, contributed to business analysis, and built the generic repository.  

### **Nada Eslam**  
Developed one module (service & controller) and supported the frontend development.  

### **Mohamed Ezat**  
Developed one module (service & controller) and supported the frontend development.  

---

## 🏁 Conclusion

The Clinic Management System successfully integrates **clinics, doctors, services, and patients** in one platform.  
It provides a structured and scalable solution with role-based access, appointment booking, and full CRUD functionality.  

---
