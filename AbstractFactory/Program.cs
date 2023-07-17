using System;

//Abstract Product
public interface Iandroid
{
    void getdetail();
}

public interface Iios
{
    void getdetail();
}
//Concrete Product Android
public class highspecandroid : Iandroid
{
    public void getdetail()
    {
        Console.WriteLine("Snapdragon 8+ Gen 1");
    }
}
public class midspecandroid : Iandroid
{
    public void getdetail()
    {
        Console.WriteLine("Snapdragon 778");
    }
}
//Concrete Product IOS
public class highspecios : Iios
{
    public void getdetail()
    {
        Console.WriteLine("A14 Bionic");
    }
}
public class midspecios : Iios
{
    public void getdetail()
    {
        Console.WriteLine("A11 Bionic");
    }
}
//Abstract Factory
public interface IPhoneFactory
{
    Iandroid CreateAndroid();
    Iios CreateIos();
}
//Concrete Factory Mid Specification Phone
public class MidspecPhoneFactory : IPhoneFactory
{
    public Iandroid CreateAndroid()
    {
        return new midspecandroid();
    }
    public Iios CreateIos()
    {
        return new midspecios();
    }
}
//Concrete Factory High Specification Phone
public class HighspecPhoneFactory : IPhoneFactory
{
    public Iandroid CreateAndroid()
    {
        return new highspecandroid();
    }
    public Iios CreateIos()
    {
        return new highspecios();
    }
}
//Client
public class Program
{
    public static void Main()
    {
        IPhoneFactory HighspecPhone = new HighspecPhoneFactory();
        Iios highspec = HighspecPhone.CreateIos();
        highspec.getdetail();

        IPhoneFactory Midspecphone = new MidspecPhoneFactory();
        Iandroid midspec = Midspecphone.CreateAndroid();
        midspec.getdetail();

        Console.ReadLine();
    }
}
