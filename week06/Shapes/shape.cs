namespace Shapes
{
    public class Shape
    {
        private string _color;

        public Shape(string color)
        {
            _color = color;
        }

        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        // Virtual method to be overridden by derived classes
        public virtual float GetArea()
        {
            // A generic shape's area might not be meaningful, or could be 0 by default.
            // For this exercise, we'll make it virtual and expect derived classes to implement.
            return 0f;
        }
    }
}