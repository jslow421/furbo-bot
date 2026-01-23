using System.Device.Gpio;
using System.Text.Json;

// Configuration
const int DispensePin = 18; // GPIO 18 (Physical Pin 12)
const string ZmqAddress = "tcp://vision:5555"; // Matches docker-compose service name

Console.WriteLine($"[Control] Starting... Listening on {ZmqAddress}");

using var gpio = new GpioController();

try
{
    gpio.OpenPin(DispensePin, PinMode.Output);
    gpio.Write(DispensePin, PinValue.Low); // Ensure it starts off
}
catch (Exception ex)
{
    // This helps debug if the container doesn't have permissions
    Console.WriteLine($"[Error] Could not open GPIO: {ex.Message}");
    // Continue anyway so we can at least see network messages for debugging
}
