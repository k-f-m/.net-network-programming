using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Diagnostics;

namespace client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Sends a GET request to the specified endpoint.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event data.</param>
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        // Create a new socket object by specifying the addressing scheme, socket type, and protocol that an instance of the Socket class represents.
        using Socket client = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);

        // Set the IP address and port number.
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipEndPoint = new(ipAddress, 5142);

        try
        {
            // Connect to the specified endpoint.
            await client.ConnectAsync(ipEndPoint);

            // Create a GET request.
            string request = "GET /WeatherForecast HTTP/1.1\r\n" +
                             "Host: localhost\r\n" +
                             "Connection: close\r\n\r\n";

            // Convert the request to a byte array.
            byte[] requestBytes = Encoding.UTF8.GetBytes(request);

            // Send the request to the server.
            await client.SendAsync(requestBytes, SocketFlags.None);

            // Receive the response from the server and convert the response to a string using UTF8 encoding.
            byte[] responseBytes = new byte[1024];
            int bytesReceived = await client.ReceiveAsync(responseBytes, SocketFlags.None);
            string response = Encoding.UTF8.GetString(responseBytes, 0, bytesReceived);

            // Print the response to the IDE's debug window and display it inside the text block.
            Debug.WriteLine($"Response: {response}");
            ResponseTextBox.Text = response;

            // Disconnect client from the server and release all managed and unmanaged resources associated with the Socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        catch (Exception ex)
        {
            // Print the exception to the IDE's debug window and display its message inside the text block.
            Debug.WriteLine($"{ex}");
            ResponseTextBox.Text = ex.Message;
        }
    }
}
