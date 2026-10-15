namespace Saveur
{
    public enum Layer
    {
        Default, Terrain, Launch
    }

    public static class LayersExtensions
    {
        public static int ToInt(this Layer layer)
        {
            return layer switch
            {
                Layer.Terrain => 7,
                Layer.Launch => 8,
                Layer.Default or _ => 0
            };
        }

        public static Layer ToLayer(this int layer)
        {
            return layer switch
            {
                7 => Layer.Terrain,
                8 => Layer.Launch,
                0 or _ =>Layer.Default
            };
        }
    }
}