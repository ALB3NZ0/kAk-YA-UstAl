using System;

public static class ArrowKeysHandler
{
    public static ConsoleKey WaitForArrowKeys()
    {
        ConsoleKeyInfo keyPressed;
        do
        {
            keyPressed = Console.ReadKey(true);
        } while (keyPressed.Key != ConsoleKey.UpArrow && keyPressed.Key != ConsoleKey.DownArrow
              && keyPressed.Key != ConsoleKey.LeftArrow && keyPressed.Key != ConsoleKey.RightArrow
              && keyPressed.Key != ConsoleKey.Escape);
        return keyPressed.Key;
    }
}
