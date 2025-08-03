# Advanced-School-Management_System
A simple yet structured **School Management System** built in **C#**, designed using **Object-Oriented Programming (OOP)** principles and inspired by **SOLID** design practices.

This project simulates the core functions of a school administration interface where students can be registered, enrolled in courses, and their information managed through a clean, console-based user interface.

---

## 📝 Project Overview

The **Advanced School Management System** is a console application aimed at demonstrating how fundamental school management operations can be implemented using clean and maintainable code architecture.

The system uses OOP concepts such as **classes, inheritance, interfaces**, and **data encapsulation** to represent real-world entities like students and courses. It also applies core ideas from the **SOLID** principles to ensure modularity and reusability.

The main goal is **educational**—to show how a basic system like this can be built cleanly and efficiently using best practices.

---

## 🎯 Main Functionalities

1. **Add a New Student**  
   - The system allows the user to input a new student's ID, name, and password.
   - Inputs are validated to ensure uniqueness and correctness.

2. **Enroll Student in Courses**  
   - A student can be enrolled in a set of predefined courses.
   - Prevents duplicate course enrollment.
   - Shows available course options clearly.

3. **Remove Course from Student**  
   - A specific course can be removed from a student’s enrolled courses.
   - Only valid course IDs can be removed.

4. **Display Student Information**  
   - Allows users to search for a student by ID.
   - Displays all student data, including a list of enrolled courses and course durations.

5. **Delete a Student**  
   - Entire student records can be removed from the system by ID.

6. **Input Validation**  
   - The system includes dedicated logic for verifying ID format, uniqueness, and valid options.
   - Helps prevent common user input errors.

---

## 💡 Educational Purpose

This project was created mainly for **learning and demonstration purposes**, especially for those who are:

- Practicing C# with a real use case
- Learning the principles of clean architecture and design
- Exploring OOP and SOLID implementation in small-to-medium-sized systems
- Preparing for academic or bootcamp projects

It serves as a good starting point for developers who want to build larger systems later by adding features like teacher management, grading, attendance tracking, login/authentication, and data persistence (e.g., using databases or files).

---

## 🏗️ Structure and Design Highlights

- **Single Responsibility Principle**: Each class is responsible for one task only.
- **Interface Usage**: All courses follow a common interface, promoting abstraction.
- **Separation of Concerns**: Input validation, student management, and course display are handled by separate classes.
- **Extensibility**: You can easily add new types of courses or expand student features.

---

## ✍️ Author & License

This is an open educational project built for practice.  
Feel free to use, extend, or adapt it in your own academic or learning projects.

---
