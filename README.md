# Examination System (Final & Practical)
---

## 📌 Overview

A lightweight, object‑oriented **Examination System** built in C# as a console application. It models questions, answers, and two exam types (**Final** and **Practical**) while following the given business case and demonstrating core OOP concepts:

* Base/derived classes & constructor chaining
* Interfaces: **ICloneable**, **IComparable**
* Overriding **ToString**
* Composition (Subject → Exam → Questions → Answers)

> The project answers the full specification of **Exam 02** (see *Business Requirements* below).

---

## 🗂 Repository Structure (suggested)

```
C44-G00-EX02/
├─ src/
│  ├─ Models/
│  │  ├─ Question.cs
│  │  ├─ MCQQuestion.cs
│  │  ├─ TrueFalseQuestion.cs
│  │  ├─ Answer.cs
│  │  ├─ Exam.cs
│  │  ├─ PracticalExam.cs
│  │  ├─ FinalExam.cs
│  │  └─ Subject.cs
│  └─ Program.cs
├─ docs/
│  └─ uml-diagram.png      # (exported from the .drawio file)
├─ uml diagram.drawio      # original diagram (edit in draw.io)
├─ README.md
└─ C44-G00-EX02.sln / .csproj
```

> **Note:** If you only have the `.drawio` diagram, export it to `docs/uml-diagram.png` and the image link below will render on GitHub.

---

## 🧭 UML (High‑Level)

![UML Diagram](docs/uml-diagram.png)

> Source: [`uml diagram.drawio`](./uml%20diagram.drawio)

---

## 🧑‍🏫 Business Requirements Coverage

1. **Question Class** with:

   * `Header`
   * `Body`
   * `Mark`

2. **Two Exam Types**:

   * `FinalExam`
   * `PracticalExam`

3. **Question Types**:

   * For **Final**: `TrueFalseQuestion`, `MCQQuestion`
   * For **Practical**: `MCQQuestion`
   * A base abstract `Question` class; each type inherits from it.

4. **Answer Class**:

   * `AnswerId`
   * `AnswerText`

5. **Question → Answers\[] & RightAnswer** association.

6. **Exam (Base) Class**:

   * `Time` (duration)
   * `NumberOfQuestions`
   * `ShowExam()` (polymorphic: implemented differently per exam type)

7. **Subject Class** contains:

   * `SubjectId`
   * `SubjectName`
   * `Exam` (associated exam)
   * Functionality to **create** and attach the subject’s exam

8. **Practical Exam** shows **right answers** after finishing.

9. **Final Exam** shows **questions, answers, and grade**.

10. **Main** declares a `Subject` and creates **one exam type**.

> Interfaces & OOP niceties: Implements **ICloneable**, **IComparable**, overrides **ToString**, and uses constructor chaining where sensible.

---

## 🧩 Key Classes (Conceptual)

### `Question` (abstract)

* **Props:** `Header`, `Body`, `Mark`, `AnswerList: Answer[]`, `RightAnswer: Answer`
* **Methods:** `Clone()`, `CompareTo(Question)`, `ToString()`

### `MCQQuestion` : `Question`

* Multiple choices in `AnswerList`, `RightAnswer` is one of them

### `TrueFalseQuestion` : `Question`

* `AnswerList` holds `True`/`False` options; `RightAnswer` matches

### `Answer`

* **Props:** `AnswerId` (int), `AnswerText` (string)
* **Methods:** `ToString()`

### `Exam` (abstract)

* **Props:** `Time`, `NumberOfQuestions`, `Questions: List<Question>`
* **Methods:** `ShowExam()` (abstract), `Grade()` (optional helper)

### `PracticalExam` : `Exam`

* **ShowExam():** Displays questions and (after submission) **reveals right answers**

### `FinalExam` : `Exam`

* **ShowExam():** Displays questions, choices, and computes **grade** at the end

### `Subject`

* **Props:** `SubjectId`, `SubjectName`, `Exam`
* **Methods:** `CreateExam()` (factory/initializer), `ToString()`

---

## 🚀 Getting Started

### Prerequisites

* **.NET SDK 7/8**
* C# 10/11

### Build & Run

```bash
# clone the repo
git clone https://github.com/yasmin2624/C44-G00-EX02.git
cd C44-G00-EX02

# restore & build
dotnet restore
dotnet build -c Release

# run console app
dotnet run --project src
```

> If your `.csproj` is at root, use `dotnet run` directly.

---

## 🖥 Sample Run (illustrative)

```
Subject: OOP Fundamentals (ID: 101)
Exam Type: Final Exam | Time: 30 min | Questions: 3

Q1 [2 marks] True/False:
Polymorphism allows different implementations under one interface.
  1) True
  2) False
Your answer: 1

Q2 [3 marks] MCQ:
Which interface is used to provide a deep copy contract?
  1) IDisposable
  2) ICloneable
  3) IFormattable
Your answer: 2

...

=== Result ===
Correct: 2 / 3 | Grade: 5 / 7
```

---

## 🧪 Design Notes

* **ICloneable** used on entities where cloning makes sense (e.g., `Question`, `Answer`).
* **IComparable** (e.g., by `Mark` or `Header`) to allow sorting collections of questions.
* **ToString()** overridden for friendly printing (debug & logs).
* **Constructor chaining** to avoid duplication in derived classes.
* **Polymorphism**: `ShowExam()` is abstract on `Exam` and specialized by `FinalExam` vs `PracticalExam`.

---

## 🧱 Extensibility

* Add new types like `EssayQuestion` by inheriting `Question`.
* Support multiple correct answers by changing `RightAnswer` → `RightAnswers`.
* Persist exams to files/DB (serialization layer).
* Plug a UI (WinForms/WPF/Web) on top of the domain model.

---

## ✅ Checklist (Spec → Implementation)

* [x] Base `Question` with header/body/mark
* [x] `Answer` with id/text
* [x] `Question.Answers[]` + `RightAnswer`
* [x] `Exam` base with time, count, and `ShowExam()`
* [x] `FinalExam` (TF + MCQ) with grade
* [x] `PracticalExam` (MCQ) reveals correct answers at end
* [x] `Subject` holds/exposes exam, can create it
* [x] Implemented **ICloneable**, **IComparable**, `ToString`

---

## 🧰 Tools

* Language: **C# / .NET**
* Diagram: **draw\.io** (`uml diagram.drawio`)

---

## 📄 License

This project is for educational purposes. You may adapt and reuse with attribution.

---

## 🙌 Acknowledgments

* Course mentors & colleagues
* draw\.io for diagramming

