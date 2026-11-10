import win32com.client
import os

db_dir = os.path.abspath("Database")
os.makedirs(db_dir, exist_ok=True)
db_path = os.path.join(db_dir, "SchoolDiary.accdb")

if os.path.exists(db_path):
    os.remove(db_path)

# Create new Access database
access = win32com.client.Dispatch("Access.Application")
access.NewCurrentDatabase(db_path)
access.CloseCurrentDatabase()
access.Quit()

# Connect via ADODB
conn = win32com.client.Dispatch("ADODB.Connection")
conn.Open(f"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={db_path};")

# Create tables
conn.Execute("""
CREATE TABLE Users (
    [UserID] AUTOINCREMENT CONSTRAINT PK_Users PRIMARY KEY,
    [Username] TEXT(50) NOT NULL,
    [Password] TEXT(50) NOT NULL,
    [FullName] TEXT(100),
    [Role] TEXT(50)
)
""")

conn.Execute("""
CREATE TABLE Students (
    [StudentID] AUTOINCREMENT CONSTRAINT PK_Students PRIMARY KEY,
    [FullName] TEXT(100) NOT NULL,
    [ClassGrade] TEXT(20),
    [Phone] TEXT(30)
)
""")

conn.Execute("""
CREATE TABLE Subjects (
    [SubjectID] AUTOINCREMENT CONSTRAINT PK_Subjects PRIMARY KEY,
    [SubjectName] TEXT(100) NOT NULL,
    [TeacherName] TEXT(100)
)
""")

conn.Execute("""
CREATE TABLE Grades (
    [GradeID] AUTOINCREMENT CONSTRAINT PK_Grades PRIMARY KEY,
    [StudentID] INTEGER NOT NULL,
    [SubjectID] INTEGER NOT NULL,
    [LessonDate] DATETIME,
    [GradeValue] INTEGER NOT NULL,
    [Comment] TEXT(255)
)
""")

# Insert initial Users
users = [
    ("admin", "admin123", "Администратор системы", "Администратор"),
    ("teacher", "teacher123", "Шадрина А. Ю. (Преподаватель)", "Учитель"),
    ("student", "12345", "Алексеев Артем (Ученик)", "Ученик")
]
for u in users:
    conn.Execute(f"INSERT INTO Users ([Username], [Password], [FullName], [Role]) VALUES ('{u[0]}', '{u[1]}', '{u[2]}', '{u[3]}')")

# Insert initial Students
students = [
    ("Алексеев Артем Владимирович", "ИС-31", "+7 (912) 345-67-89"),
    ("Иванов Иван Иванович", "ИС-31", "+7 (912) 111-22-33"),
    ("Петров Петр Сергеевич", "ИС-31", "+7 (912) 444-55-66"),
    ("Смирнова Анна Дмитриевна", "ИС-31", "+7 (912) 777-88-99"),
    ("Коканов Денис Александрович", "ИС-31", "+7 (912) 999-00-11")
]
for s in students:
    conn.Execute(f"INSERT INTO Students ([FullName], [ClassGrade], [Phone]) VALUES ('{s[0]}', '{s[1]}', '{s[2]}')")

# Insert Subjects
subjects = [
    ("Разработка программных модулей (ПМ 03)", "Шадрина А. Ю."),
    ("Базы данных", "Смирнов В. А."),
    ("Информационные технологии", "Семенов В. К."),
    ("Математика", "Кузнецова Е. П."),
    ("Иностранный язык", "Белова О. М.")
]
for sub in subjects:
    conn.Execute(f"INSERT INTO Subjects ([SubjectName], [TeacherName]) VALUES ('{sub[0]}', '{sub[1]}')")

# Insert initial Grades for demonstration
grades = [
    (1, 1, "2026-11-01", 5, "Практическая работа №1"),
    (1, 1, "2026-11-03", 5, "Ответ на уроке"),
    (1, 2, "2026-11-02", 5, "Проектирование схемы БД"),
    (1, 3, "2026-11-04", 4, "Тестирование ПО"),
    (1, 4, "2026-11-05", 5, "Контрольная работа"),
    (2, 1, "2026-11-01", 4, "Практическая работа №1"),
    (2, 2, "2026-11-02", 3, "Лабораторная работа"),
    (3, 1, "2026-11-01", 5, "Практическая работа №1"),
    (4, 1, "2026-11-01", 5, "Практическая работа №1"),
    (4, 2, "2026-11-02", 4, "Лабораторная работа"),
    (5, 1, "2026-11-01", 3, "Практическая работа №1")
]
for g in grades:
    conn.Execute(f"INSERT INTO Grades ([StudentID], [SubjectID], [LessonDate], [GradeValue], [Comment]) VALUES ({g[0]}, {g[1]}, #{g[2]}#, {g[3]}, '{g[4]}')")

conn.Close()
print("Database created successfully at:", db_path)
