using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    struct Vector
    {
        public double x;
        public double y;
        public double z;

        public Vector(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public void printer()
        {
            Console.WriteLine($"{this.x} {this.y} {this.z}");
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            return v3;
        }
        public static Vector operator *(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return v3;
        }
        public static Vector operator *(Vector v1, int ch)
        {
            Vector v2 = new Vector(v1.x * ch, v1.y * ch, v1.z * ch);
            return v2;
        }
        public double LengthSide()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }
        public static Boolean operator >(Vector v1, Vector v2)
        {
            return v1.LengthSide() > v2.LengthSide();
        }
        public static Boolean operator <(Vector v1, Vector v2)
        {
            return v1.LengthSide() < v2.LengthSide();
        }
        public static Boolean operator ==(Vector v1, Vector v2)
        {
            return v1.LengthSide() == v2.LengthSide();
        }
        public static Boolean operator !=(Vector v1, Vector v2)
        {
            return v1.LengthSide() != v2.LengthSide();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(2, 2, 3);
            Vector v2 = new Vector(4, 4, 5);
            v1.printer();
            v2.printer();
            Vector v3 = new Vector();
            int ch = 5;
            v3 = v1 + v2;
            Console.WriteLine($"Summ: {v3.x} {v3.y} {v3.z}");
            v3 = v1 * v2;
            Console.WriteLine($"Umnog: {v3.x} {v3.y} {v3.z}");
            v3 = v1 * ch;
            Console.WriteLine($"Umnog na ch: {v3.x} {v3.y} {v3.z}");
            Console.WriteLine($"Sravnenie <: {v1 < v2}");
            Console.WriteLine($"Sravnenie >: {v1 > v2}");
            Console.WriteLine($"Sravnenie ==: {v1 == v2}");
            Console.WriteLine($"Sravnenie !=: {v1 != v2}");
            Console.ReadLine();
        }
    }
}
