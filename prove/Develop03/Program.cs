using System;
// This program exceeds the requirements of the assignment by giving the user a test for the verse, which
// asks the user to type the verse from memory. If they get a character wrong, it displays the character in red.
// It will show the current amount of blanked out words, and what isn't blanked out while typing. When the user types over the 
//underscores, it will replace them with the correct character.
// In order to learn how to exceed the requirements of the assignment, I looked things up on google and Gemini, giving me guidance on 
//how to be able to dynamically update only one letter instead of printing out the entire verse after each character typed. I also learned how 
//to hide the cursor and still get what character the user is typing and store the current location in a variable, then put it in the correct position and be able to test that specific character.
// In order to do this, I learned how to intercept keys from the console. I also used it to learn how to change the color being printed out.
class Program
{
    static void Main(string[] args)
    {
        Display display= new Display();
        display.ShowDisplay();
    }
}