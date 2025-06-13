namespace Shapes
{
    public class Square : Shape
    {
        private float _side;

        public Square(string color, float side) : base(color)
        {
            _side = side;
        }

        // Override the GetArea method for Square
        public override float GetArea()
        {
            return _side * _side;
        }
    }
}