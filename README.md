# Library Management System

This C# application provides a system for managing a school library. This document explains the steps required to run and use the project.

## Getting Started

1. To run the application, you need a MySQL database. Create your MySQL database and configure the connection string in the `DatabaseHelper.cs` file located in the project's root directory.

```
   public MySqlConnection GetDatabaseConnection()
        {
            return new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=your_password");
        }
```
Replace `"your_password"` with your MySQL database password (Default password for XAMPP is `''`. So you can use `Pwd=''`).

For MySQL database service, you can use XAMPP.

**Setting up XAMPP for Library Management System**

1. **Download XAMPP**:
   - Visit [XAMPP website](https://www.apachefriends.org/index.html).
   - Download and install XAMPP.

2. **Start Services**:
   - Launch XAMPP Control Panel.
   - Start Apache and MySQL.

3. **Database Setup**:
   - Access `http://localhost/phpmyadmin`.
   - Create a "library" database.
   - Import SQL script.

2. Open the solution in Visual Studio. Build the project to make sure all the dependencies are resolved.

3. Before running the project, make sure you've installed the necessary libraries. The project uses the MySQL Connector/NET package to interact with the database. You can install this package via NuGet Package Manager.

4. Once the project is built, you can run it using Visual Studio. The main form, `Dashboard` will be displayed, and you can start managing the library.

## Using the Panel

The panel provides various features for library management:

1. **Dashboard**: The main interface provides an overview of the library's daily operations. It displays information about the librarian on duty for the day, the date, and time. It also has quick access buttons for various management functions.

2. **Librarian Management**: The application allows librarians to be assigned for daily duties. Librarians' details such as name, student ID, and class can be added, updated, or deleted. It also ensures that there is always a librarian on duty.

3. **Book Details**: You can view detailed information about the books available in the library. This includes the book's title, author, ISBN, publication date, and other relevant details. It helps librarians keep track of the library's book collection.

4. **Student Management**: The system manages student information, including their name, student ID, class, and the number of books they have checked out. Students can be added, updated, or deleted, ensuring accurate records.

5. **Book Lending**: Librarians can lend books to students, and the system automatically updates the student's checked-out books count. This helps manage the library's inventory and ensures students are accountable for borrowed books.

6. **Book Receiving**: When students return books, librarians can register the return within the system. It updates the book's availability count and the student's records, including the number of books read.

7. **Book Searching**: The system provides search functionality for both students and books. Librarians can quickly find books based on the student's ID or the book's barcode. This feature simplifies the process of finding specific books or student records.

8. **Admin Lock Mode**: The application features an admin lock mode that restricts access to certain features with a password. It provides added security for important admin-level actions.

9. **Data Integrity**: The system ensures data integrity by managing students' records, book availability, and librarian duties. It prevents students from borrowing too many books or returning books that haven't been borrowed.

10. **Database Integration**: The application connects to a MySQL database for data storage and retrieval. This enables the system to maintain an organized and accurate library database.

The Library Management System offers an efficient way to manage a library's daily operations, ensuring that books are properly tracked, students are accountable for their borrowed books, and librarian duties are assigned and maintained. It simplifies the process of book lending, receiving, and maintaining student records.

## Contributing

If you'd like to contribute to this project or encounter any issues, please feel free to open an issue or submit a pull request on the project's GitHub repository.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
