using System;

//Abstract Product
public interface Iandroid
{
    void getdetail(string nama, string prosesor);
}

public interface Iios
{
    void getdetail(string nama, string prosesor);
}
//Concrete Product Android
public class highspecandroid : Iandroid
{
    public void getdetail(string nama, string prosesor)
    {
        Console.WriteLine("Nama HP = " +nama);
        Console.WriteLine("Prosesor = " + prosesor);
    }
}
public class midspecandroid : Iandroid
{
    public void getdetail(string nama, string prosesor)
    {
        Console.WriteLine("Nama HP = " + nama);
        Console.WriteLine("Prosesor = " +prosesor);
    }
}
//Concrete Product IOS
public class highspecios : Iios
{
    public void getdetail(string nama, string prosesor)
    {
        Console.WriteLine("Nama HP = " + nama);
        Console.WriteLine("Prosesor = " + prosesor);
    }
}
public class midspecios : Iios
{
    public void getdetail(string nama, string prosesor)
    {
        Console.WriteLine("Nama HP = " + nama);
        Console.WriteLine("Prosesor = " + prosesor);
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
        Iios Iphone14Pro = HighspecPhone.CreateIos();
        Iphone14Pro.getdetail("Iphone 14 Plus","A14 Bionic");
        Console.WriteLine();
        IPhoneFactory Midspecphone = new MidspecPhoneFactory();
        Iandroid XiaomiX5Pro = Midspecphone.CreateAndroid();
        XiaomiX5Pro.getdetail("Xiaomi X5 Pro","Snapdragon 778");

        Console.ReadLine();
    }
}
