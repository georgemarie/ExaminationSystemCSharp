# Examination Management System
---

---

## 📖 Detailed Project Explanation
This system is designed as a comprehensive toolkit for academic evaluation, focusing on three main pillars: Question Management, Exam Logic, and Automated Notification.

### 1. The Question Engine
The system supports three distinct question types, all inheriting from a base `Question` class to ensure polymorphic behavior:
* **True/False Questions**: Basic binary choice questions with pre-defined "True" and "False" answers.
* **Choose One (MCQ)**: Standard multiple-choice where only a single `AnswerId` is valid for points.
* **Choose All (Multi-Select)**: Advanced questions where students must provide all correct `AnswerIds` separated by commas. The system uses string splitting and array sorting to validate that the student's set matches the master key exactly.

### 2. Examination Workflows
The system differentiates between how a student interacts with an exam based on its type:
* **Practice Exam**: Designed for learning. After completion, the system iterates through the `QuestionAnswerDictionary`, compares inputs, and immediately shows the correct answer for every question to provide instant feedback.
* **Final Exam**: Designed for formal assessment. It collects all answers silently. While it still calculates the grade internally, it prioritizes a clean submission process without revealing the key.

### 3. Real-Time Interactions & Logging
* **Student Notifications**: When an exam's state changes to `Starting`, the `Exam` class fires an `ExamStarted` event. The `Subject` class acts as the mediator, notifying all enrolled `Student` objects that the test is live.
* **Persistent Audit Trail**: Every question created is physically written to a text file via the `QuestionList`. This provides a permanent record (log) of the exam content that exists even after the application is closed.
---

## 📌 Project Overview
The **Examination Management System** is a sophisticated console-based application designed to manage educational workflows. It allows for the creation of various question types, handles student enrollments, and executes different exam modes (Practice vs. Final). 

The project serves as a demonstration of:
* **High-level OOP Principles** (Inheritance, Polymorphism, Encapsulation)
* **Advanced C# Patterns** (Generics, Events, Delegates)
* **Persistence** (File I/O Logging)

---

## 🏗️ Core Design Decisions

### 1. Advanced Encapsulation
To ensure data integrity, the system uses **Strict Encapsulation**:
* **Backing Fields**: Critical data (like `time` and `marks`) is stored in `private` fields.
* **Controlled Access**: Properties include validation logic to prevent invalid states.
* **Protected Members**: Constructors are `protected` to ensure abstract classes cannot be instantiated directly.

### 2. Polymorphic Architecture
The system is built on a "Base-Child" hierarchy:
* **Questions**: Using an abstract `Question` class allows the system to treat all question types identically while they execute unique display and grading logic.
* **Exams**: `PracticeExam` and `FinalExam` override the `CorrectExam()` method to provide different feedback levels to the user.



### 3. Observer Pattern (Events & Delegates)
We implemented a real-time notification system to decouple the **Exam** from the **Students**.

```csharp
// When the Exam status changes to 'Starting', all students are notified
public event ExamStartedHandler ExamStarted;
