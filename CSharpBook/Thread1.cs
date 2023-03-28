using System.Threading;

public class yyy
{

    public static void abc()
    {

        System.Console.WriteLine("Hi");

    }

}

public class zzz
{

    public static void Main()
    {

        ThreadStart ts = new ThreadStart(yyy.abc);

        Thread t = new Thread(ts);

        System.Console.WriteLine("Before Start");

        t.Start();

    }

}