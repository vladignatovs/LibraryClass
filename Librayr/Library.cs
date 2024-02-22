using System;
using System.Collections.Generic;
/*Library class contains two data fields: 

  technical data: basically makes the programm be able to run smoothly, these fix various bugs and errors that can occur.
    list of libraries - used to make user be able to pick one of the created libraries;
    counter - used to make the counting process easier without having user add the created libraries into a libraries list first, as well as getting the overall amount (couldve used .Count for that, but it takes more data to implement in main.cs);
    saleCounter - used to monitor whether the sale is on or not, used to prevent the user from setting or ending sales infinitely, capped at 1;

  user data: is avaliable to the user by using get...() methods, yet can't be changed inside of an object by the user manually;
      name - unskippable & unchangable, all the libraries have a name and are not up to change afterwards;
      bookAmount - skippable & changable using donateBooks() & rentBooks() methods, will be set to zero by default and can't be negative;
      passPrice - skippable & changable (limited) using  setSale() & endSale() methods, will be set to zero by default and can't be negative;
      founder - skippable & unchangable, will be set to "Unknown" by default and can't be changed afterwards;
      foundingYear - skippable & unchangable, will be set to 0 by default, can't be negative and can't be changed afterwards;
*/


public class Library {
  public static List<Library> libraries = new List<Library>(); // Used to store different libraries created, which can be later on used in foreach loops and etc.;
  public static int counter;
  int saleCounter;
  
  string name;
  int bookAmount;
  double passPrice;
  string founder;
  int foundationYear;

  // get...() methods that could be used to get the data from the object, are not a necessity;
  public string getName() {
    return this.name;
  }
  public int getBookAmount() {
    return this.bookAmount;
  }
  public double getPassPrice() {
    return this.passPrice;
  }
  public string getFounder() {
    return this.founder;
  }
  public int getFoundationYear() {
    return this.foundationYear;
  }


  //Constructors that include/exclude various data, allows the user to skip the unwanted creation process and fills it in for them automatically, made to make the creaton/testing process easier
  public Library(string name) {
    counter++;
    this.name = name;
    this.founder = "Unknown"; //Default value of a string is "null", so it has to be chanaged to "Unknown" to fit in with the Library class
  }
  public Library(string name, int bookAmount) {
    counter++;
    this.name = name;
    this.bookAmount = bookAmount;
    this.founder = "Unknown";
  }
  public Library(string name, int bookAmount, double passPrice) {
    counter++;
    this.name = name;
    this.bookAmount = bookAmount;
    this.passPrice = passPrice;
    this.founder = "Unknown";
  }
  public Library(string name, int bookAmount, double passPrice, string founder) {
    counter++;
    this.name = name;
    this.bookAmount = bookAmount;
    this.passPrice = passPrice;
    this.founder = founder;
  }
  public Library(string name, int bookAmount, double passPrice, string founder, int foundationYear) {
    counter++;
    this.name = name;
    this.bookAmount = bookAmount;
    this.passPrice = passPrice;
    this.founder = founder;
    this.foundationYear = foundationYear;
  }

  //Main methods, used for various needs of a user
  //Used to allow the user setting a sale for the pass of the library, checks if the sale is on in order to not make the initial price have a weird price, outputs into console whether the sale was put on successfully or not
  public void setSale() {
    if (saleCounter > 0) {
      
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("The Sale was already on!");
      Console.ResetColor(); 
    } else {
      saleCounter += 1;
      passPrice = passPrice * 0.8;
      
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("The Sale is on!");
      Console.ResetColor(); 
    }
  }
  //Works the same as the setSale() method, but instead of setting a sale it ends it
  public void endSale() {
    if (saleCounter == 0) {
      
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("The Sale is off already!");
      Console.ResetColor(); 
    } else {
      saleCounter -= 1;
      passPrice = passPrice / 0.8;
      
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("The Sale is off!");
      Console.ResetColor(); 
    }
  }
  //Used to allow the user to donate books to the library, checks if the inputted number is negative or zero, and if not, adds the given amount of books to the initial bookAmount variable
  public void donateBooks(int books) {
    if (books <= 0) {
      
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("You can't donate this amount of books!");
      Console.ResetColor(); 
    } else {
      bookAmount += books;
    }
  }
  //Works pretty much the same as donateBooks, but it also checks if the bookAmount is smaller or not, and if it is, substracts the given amount of books from the initial bookAmount variable 
  public void rentBooks(int books) {
    if (books < 0 && books > bookAmount) {
      
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("You can't rent this amount of books!");
      Console.ResetColor(); 
    } else {
      bookAmount -= books;
    }
  }
  //Useful for getting a complete information of a certain library, used to make the view() method more efficient
  public void getInfo() {
    Console.WriteLine($"A library called {name} was founded by {founder} in {foundationYear}. It has {bookAmount} books and the price for a pass is {passPrice}.");
  }

  //Other methods, not as used as others due to other methods doing their work better then them
  //Isn't used in the main program as it isnt efficient in rentBooks() method, as it still allows user to enter a bigger number than the book amount, so the usage of it would be forced and unnecessary
  public bool areBooksAvailable() {
    if (bookAmount > 0) {
      return true;
    } else {
      return false;
    }
  }
  //Used to get the amount of libraries created, but isn't used in the main program as it isn't as effective as the view() method already does the counting for it, exists to make the counter variable avaliable to the user as well as making it viable in the main program (Library.counter looks better than Library.libraries.Count)
  public static int getLibraryAmount() {
    return counter;
  }
}