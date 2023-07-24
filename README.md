# 401lab 8

## What is it?
This project is a simple implementation of a lending library that allows you to manage a collection of books and borrow/return them using a backpack. It consists of two main components: `Library`, which holds a collection of books, and `Backpack`, which allows you to borrow and return books from the library.

##  Visuals
```
Library:                   Backpack:
----------------         ------------------
| Book 1     |         | Borrowed Book   |
| Book 2     | ----->  ------------------
| Book 3     |               ^
----------------               |
                              |
                          Borrow/Return
```

## How to use

1. Create a new instance of the library.

2. Add books to the library.

3. Display books in the library.

4. Borrow a book from the library.

5. Display books in the library after borrowing.

6. Create a new instance of the backpack.
7. Pack the borrowed book into the backpack.

8. Display books in the backpack.

9. Unpack the book from the backpack and return it to the library.

10. Display books in the library after returning.


## Other Details:
- The library uses a dictionary to store books, and the backpack uses a list to store borrowed books.
- You can easily expand the project by adding more features to the library or backpack, such as search functionalities, book categories, or advanced borrowing rules.
- The code is written in C# and can be integrated into larger C# projects or adapted to other programming languages with similar concepts.
- Feel free to modify the `Book` class to include additional properties or methods to suit your specific needs.