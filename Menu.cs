public class Menu{



    public static void Menu1()
    {

        string request = "hello";
        string ServerAddress = "127.0.0.1";
        Int32 TCPPort = 6336;
        int menu = 0;
        while (true)
        {

            // Type your username and press enter
            Console.WriteLine("Enter opcion:");
            Console.WriteLine("1 - Iniciar Sesion");
            Console.WriteLine("2 - Registrar Usuario");
            Console.WriteLine("Enter opcion:");
            // Create a string variable and get user input from the keyboard and store it in the variable
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:

                    string LoginName = "null";
                    string LoginResult = LoginMenu(ServerAddress, TCPPort, ref LoginName);
                    Console.WriteLine(LoginResult);

                    if(LoginResult == "acceso permitido"){
                        UserSubMenu(LoginName,ServerAddress,TCPPort);

                    }

                    break;
                case 2:
                    string RegistrationResult = RegisterUserMenu(ServerAddress, TCPPort);
                    Console.WriteLine(RegistrationResult);
                    break;

                default:
                    // code block
                    break;
            }


        }

    }


     public static string LoginMenu(string ServerAddress, Int32 TCPPort, ref string LoginName)
    {
        //Metodo para loguear usuario. Retorna el string recibido del server app 

        Console.WriteLine("--> Ingrese Nombre \n");

        LoginName = Console.ReadLine(); //ingreso de nombre

        Console.WriteLine("\n--> Ingrese Password \n");

        string LoginPassword = Console.ReadLine(); //ingreso de contraseña

        User LoginUser = new User(LoginName,LoginPassword,"NULL","NULL"); // se crea nuevo objeto de NewUser

        string request = $"LOGIN_USER,{LoginUser.Name},{LoginUser.Password}";

        string ServerReply = "null";

        SocketClient.StartClient(request, ServerAddress, TCPPort, ref ServerReply); //envio de solicitud al server

        return ServerReply;
    }

    public static string RegisterUserMenu(string ServerAddress, Int32 TCPPort)


    {
        //Metodo para registrar usuario. Retorna el string recibido del server app 

        Console.WriteLine("--> Ingrese Nombre a Registrar \n");

        string NewName = Console.ReadLine(); //ingreso de nombre

        Console.WriteLine("\n--> Ingrese Password a Registrar\n");

        string NewPassword = Console.ReadLine(); //ingreso de contraseña

        Console.WriteLine("\n--> Ingrese Teléfono a Registrar \n");

        string NewPhone = Console.ReadLine(); //ingreo de contraseña

        Console.WriteLine("\n--> Ingrese ID a Registrar\n");

        string NewID = Console.ReadLine(); //ingreo de contraseña

        User NewUser = new User(NewName,NewPassword,NewPhone,NewID); // se crea nuevo objeto de NewUser

        string request = $"ADD_USER,{NewUser.Name},{NewUser.Password},{NewUser.Phone},{NewUser.ID}";

        string ServerReply = "null";

        SocketClient.StartClient(request, ServerAddress, TCPPort, ref ServerReply); //envio de solicitud al server

        return ServerReply;
    }


    public static string UserSubMenu(string LoginName, string ServerAddress, Int32 TCPPort)
    {
        Console.WriteLine("Enter opcion:");
        Console.WriteLine("1 - Cerrar Session");
        Console.WriteLine("Enter opcion:");
        string request = $"LOGout_USER,{LoginName}";

        string ServerReply = "null";

        SocketClient.StartClient(request, ServerAddress, TCPPort, ref ServerReply); //envio de solicitud al server
        
        return ServerReply;

    }   




}