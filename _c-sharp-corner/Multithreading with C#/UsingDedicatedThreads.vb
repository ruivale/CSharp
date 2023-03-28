Imports System.Threading

Module UsingDedicatedThreads

    Sub Main()

        'create thread start delegate instance - contains the method to execute by the thread
        Dim ts As ThreadStart = New ThreadStart(AddressOf run)
        ' create new thread
        Dim t As Thread
        t = New Thread(ts)
        ' start thread
        t.Start()

        ' makes the main thread sleep - let sub thread to run
        Thread.Sleep(1000)

        For i As Integer = 10 To 0 Step -1
            Console.WriteLine("Main thread value is" + i.ToString())
            Thread.Sleep(1000)
        Next i

        Console.WriteLine("Good Bye!!!I'm main Thread")
        Console.ReadKey()

    End Sub

    ' this method executed by a separate thread
    Sub run()

        For i As Integer = 0 To 10
            Console.WriteLine("Sub thread value is" + i.ToString())
            Thread.Sleep(1000)
        Next i

        Console.WriteLine("Good Bye!!!I'm Sub Thread")
    End Sub

End Module
