// Proxy design pattern

using System;


//Example-1
// Subject interface
interface IRealSubject
{
    void Request();
}

// RealSubject class (resource-intensive object)
class RealSubject : IRealSubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling request");
    }
}

// Proxy class
class Proxy : IRealSubject
{
    private RealSubject realSubject;

    public void Request()
    {
        // Create the RealSubject only when necessary
        if (realSubject == null)
        {
            Console.WriteLine("Proxy: Creating RealSubject");
            realSubject = new RealSubject();
        }

        // Proxy forwards the request to the RealSubject
        realSubject.Request();
    }
}



//Example-2

// Subject interface
interface ISensitiveSubject
{
    void Request();
}

// RealSubject class (sensitive object)
class SensitiveSubject : ISensitiveSubject
{
    public void Request()
    {
        Console.WriteLine("SensitiveSubject: Handling request");
    }
}

// Proxy class with access control
class ProtectionProxy : ISensitiveSubject
{
    private SensitiveSubject realSubject;
    private string password;

    public ProtectionProxy(string password)
    {
        this.password = password;
    }

    public void Authenticate(string inputPassword)
    {
        if (inputPassword == password)
        {
            realSubject = new SensitiveSubject();
        }
        else
        {
            Console.WriteLine("ProtectionProxy: Authentication failed");
        }
    }

    public void Request()
    {
        if (realSubject != null)
        {
            // Proxy forwards the request to the RealSubject
            realSubject.Request();
        }
        else
        {
            Console.WriteLine("ProtectionProxy: Authentication required");
        }
    }
}

class Program
{
    static void Main()
    {
        //Example-1
        // Client uses the Proxy
        IRealSubject proxy = new Proxy();

        // The RealSubject is only created when the Request is called
        proxy.Request();
        Console.WriteLine();

        //Example-2

        // Client uses the ProtectionProxy
        ISensitiveSubject proxy2 = new ProtectionProxy("secret");

        // Authentication is required before accessing the RealSubject
        (proxy2 as ProtectionProxy)?.Authenticate("wrong_password");
        proxy2.Request(); // Authentication failed, no access

        (proxy2 as ProtectionProxy)?.Authenticate("secret");
        proxy2.Request(); // Authentication successful, access granted
    }
}
