using System;
using GuardXk;

public class Program{
    public static GXK.String Name = new GXK.String("Trevias Xk");
    public static GXK.Int Life = new GXK.Int(100);
    public static GXK.Float Distance = new GXK.Float(10.5f);
    public static string x = "10";

    private static void Main(string[] args){
        Console.WriteLine("Name: {0}", Name.Value);
        Console.WriteLine("Life: {0}", Life.Value);
        Console.WriteLine("Distance: {0}m", Distance.Value);
        GXK.Process.Start();
        GXK.InjectionDLL.Check();
        Console.ReadLine();
    }
}