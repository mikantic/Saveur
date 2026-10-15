namespace Saveur
{
    public enum FlavorType
    {
        Savory, Spicy, Salty, Sweet, Bitter, Minty, Sour, Rotten
    }

    public abstract class Flavor
    {
        public abstract FlavorType Type { get; }
    }

    public class Savory : Flavor
    {
        public override FlavorType Type => FlavorType.Savory;
    }
}