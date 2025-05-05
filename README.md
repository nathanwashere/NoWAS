# Exam Management System

## Project Overview
This system is designed for managing exams and practice questions, intended for use by both professors and students. It allows professors to create question banks, automatically generate exams, track student performance, and analyze results. Students can take practice exams, receive immediate feedback, and track their progress over time.

## Technologies Used
- **Programming Language**: C#
- **UI Framework**: Windows Forms
- **Database**: SQLite

## Features

### User Authentication
- Login for existing users (professors and students)
- New user registration with validation
- User credentials stored in SQLite database

### Professor Features
- Question management
  - Create new questions with multiple-choice answers
  - Edit or delete existing questions
  - Categorize questions by topic and difficulty level
- Exam creation
  - Automatic generation based on criteria (number of questions, topics, difficulty)
  - View and delete previously created exams
- Student performance analysis
  - View individual student scores
  - Statistical analysis of exam results
  - Identify problematic questions

### Student Features
- Exam taking
  - Select exams by topic and difficulty
  - Answer questions and get immediate feedback
  - Save results to history
- Performance tracking
  - View exam history and scores
  - Track progress over time
  - View personal score averages

## Setup Instructions

### Prerequisites
- Windows operating system
- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or higher (for development)

### Installation
1. Clone the repository:
   ```
   git clone https://github.com/yourusername/exam-management-system.git
   ```

2. Open the solution file in Visual Studio:
   ```
   ExamManagementSystem.sln
   ```

3. Build the solution to restore NuGet packages:
   ```
   Build > Build Solution
   ```

4. Run the application:
   ```
   Debug > Start Debugging
   ```



## Team Structure
The project is divided into three development teams, each consisting of two students:

### Team 1
- Login/Registration Screen
- Exam Creation Screen

### Team 2
- Question Creation Screen
- Student Score Tracking Screen

### Team 3
- Student Performance Analysis Screen
- Exam Taking Screen



