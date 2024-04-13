// Goat.cs
namespace TouchGrass;
public class Goat
{
    // Add properties and methods as needed
    private int movementSpeed;

    //Constructor
    public Goat (int speed)
    {
        this.movementSpeed = speed;
    }

    // Method to move the goat
    public void Moved()
    {
        //Implement movement logic here
    }

    // Method for goat to eat grass
    public void EatGrass()
    {
        // Implement eating grass logic here
        Console.WriteLine("Goat eating grass");
    }

    // Method to have dialogue
    public void Speak(string message)
    {
        // Implement dialogue logic here
        Console.WriteLine($"Goat says: {message}")
    }

    // Getter and Setter fro movement speed
    public int MovementSpeed
    {
        get { return this.movementSpeed;}
        set { movementSpeed = value; }
}
