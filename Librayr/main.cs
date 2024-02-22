using System;

class Program {
  static void Main(string[] args) {
    bool run = true; //Used to make while loop controllable, by making the boolean value changable (makes the while loop be able to be stopped in switch)
    while(run) { // Uses while loop to keep the programm running after making a single request
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("ADD | VIEW | DONATE | RENT | SET SALE | END SALE | EXIT");
      Console.Write("Choose a command above that you want to execute: ");
      
      Console.ForegroundColor = ConsoleColor.DarkGray;
      string choice = Console.ReadLine();
      Console.ResetColor(); 
      switch(choice.ToLower()) {
      //Case Add is used to create a library object and add it into the libraries list
      case "add":
        Console.Write("Please enter the name of the library (unskippable): ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string name = Console.ReadLine();
        Console.ResetColor(); 
        
        Console.Write("Please enter the amount of books in the library (press ENTER to skip): ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string temp = Console.ReadLine();
        Console.ResetColor(); 
        if (temp == "") { 
          // This makes it so that the input of ENTER and 0 would count as different inputs, as you could possibly want to make a library with 0 books and not skip the further registration.
          Library library = new Library(name);
          Library.libraries.Add(library); // Adds library to the list of libraries so that you could furthermore change it by choosing it from the list.
        } else {
          int amount = CheckIntNeg(temp); //Uses CheckIntNeg method which return int value that is 0 or higher
          
          Console.Write("Please enter the price of a pass (press ENTER to skip): ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          temp = Console.ReadLine();
          Console.ResetColor(); 
          if (temp == "") {
            Library library = new Library(name, amount);
            Library.libraries.Add(library);
          } else {
            double passPrice = CheckDoubleNeg(temp); //Uses CheckDoubleNeg method which works the same as CheckIntNeg method, but returns double instead of an int.
            
            Console.Write("Please enter founders name (press ENTER to skip): ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string founder = Console.ReadLine(); //Instead of creating a temp variable, it is possible to work with founder instead as it doesnt need converting from string, which would make the if (string == "") statement not work.
            Console.ResetColor(); 
            if (founder == "") {
              Library library = new Library(name, amount, passPrice);
              Library.libraries.Add(library);
            } else {
              
              Console.Write("Please enter the foundation year (press ENTER to skip): ");
              Console.ForegroundColor = ConsoleColor.DarkGray;
              temp = Console.ReadLine();
              if (temp == "") {
                Library library = new Library(name, amount, passPrice, founder);
                Library.libraries.Add(library);
              } else {
                int foundationYear = CheckIntNeg(temp);
                Library library = new Library(name, amount, passPrice, founder, foundationYear);
                Library.libraries.Add(library);
              }
            }
          }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Library successfully added!");
        break;

      //Case View is used to view all the libraries in the libraries list, uses a foreach loop to go through all the libraries in the list and a counter to count the libraries in order to ease the further choosing process.
      case "view":
        if (Library.counter == 0) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("There are no libraries to view!");
          Console.ResetColor(); 
        } else {
          int i = 0;
          foreach(Library lib in Library.libraries) {
            i++;
            Console.Write($"{i}. ");
            lib.getInfo();
          }
        }
        break;

      //Case Donate is used to donate books to a library. It first asks for the number of the library (shown in case view ) and then the amount of books to donate
      case "donate":
        if (Library.counter == 0) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("There are no libraries to donate to!");
          Console.ResetColor(); 
        } else {
          Console.Write($"Please enter what library you want to donate from 1 to {Library.counter}: ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          int number = int.Parse(Console.ReadLine());
          Console.ResetColor(); 
          Console.Write("Please enter the amount of books you want to donate: ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          int books = int.Parse(Console.ReadLine());
          Console.ResetColor(); 
          Library.libraries[number-1].donateBooks(books);
          Console.WriteLine($"{books} books donated successfully!");
        }
        break;

      //Case Rent is similar to case donate, but instead of donating books, it rents them. 
      case "rent": 
        if (Library.counter == 0) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("There are no libraries to rent the books from!");
          Console.ResetColor(); 
        } else {
          Console.Write($"Please enter what library you want to rent from 1 to {Library.counter}: ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          int number = int.Parse(Console.ReadLine());
          Console.ResetColor(); 
          Console.Write("Please enter the amount of books you want to rent: ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          int books = int.Parse(Console.ReadLine());
          Console.ResetColor(); 
          Library.libraries[number-1].rentBooks(books);
          Console.WriteLine($"{books} books rented successfully!");
        }
        break;

      //Case SetSale is used to set the sale for a pass of a library. The choosing sequence works the same as in case donate and rent
      case "set sale":
        if (Library.counter == 0) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("There are no libraries to set a sale of!");
          Console.ResetColor(); 
        } else {
          Console.Write($"Please enter what library you want to set a sale for from 1 to {Library.counter}: ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          int number = int.Parse(Console.ReadLine());
          Console.ResetColor(); 
          Library.libraries[number-1].setSale();
        }
        break;

      //Case EndSale works same as setsale, but ends the sale of a pass.
      case "end sale":
        if (Library.counter == 0) {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("There are no libraries to end a sale of!");
          Console.ResetColor(); 
        } else {
          Console.Write($"Please enter what library you want to end the sale for from 1 to {Library.counter}: ");
          Console.ForegroundColor = ConsoleColor.DarkGray;
          int number = int.Parse(Console.ReadLine());
          Console.ResetColor(); 
          Library.libraries[number-1].endSale();
        }
        break;

      //Case Exit is used to end the programm. Changes the run boolean to false, making the while loop stop.
      case "exit":
        run = false;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Thanks for using our programm!");
        break;

      //Used to write something when the user makes an error
      default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No such command found.");
        break;
      }
      Console.Clear();
    }
  }
  //Used to mainly optimize code, returns 0 if the input is negative, returns converted value if not.
  public static int CheckIntNeg(String temp) {
    if (int.Parse(temp) < 0) {
      return 0;
    } else {
      return int.Parse(temp);
    }
  }
  //Same as the CheckIntNeg method, but returns double instead of int
  public static double CheckDoubleNeg(String temp) {
    if (double.Parse(temp) < 0) {
      return 0;
    } else {
      return double.Parse(temp);
    }
  }
}