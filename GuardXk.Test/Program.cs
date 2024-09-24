using System;
using GuardXk;

public class Program{
    public static GXK.Int intGXK = new GXK.Int(100);
    public static GXK.String stringGXK = new GXK.String("Hello World!");
    private static void Main(string[] args){
        Console.WriteLine(stringGXK.Value);
    }
}