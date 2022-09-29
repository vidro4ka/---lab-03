using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{   
    interface IEquatable<Car>
    {
         bool Equals(Car other);
    }
    public class Car : IEquatable<Car>
    {
        public string name { get; set; }
        public double engine { get; set; }
        public int max_speed { get; set; }
        public override string ToString()
        {
            return this.name;
        }
        public Car(string _name,double _engine,int _max_speed)
        {
            this.name = _name;
            this.engine = _engine;
            this.max_speed = _max_speed;
        }
        public bool Equals(Car other)
        {
            return this == other;
        }
        public static Boolean operator==(Car ob1, Car ob2)
        {
            return ob1.name == ob2.name && ob1.max_speed == ob2.max_speed && ob1.engine == ob2.engine;
        }
        public static Boolean operator !=(Car ob1, Car ob2)
        {
            return ob1.name != ob2.name && ob1.max_speed != ob2.max_speed && ob1.engine != ob2.engine;
        }
    }
    public class CarCatalog
    {
        public List<Car> cars = new List<Car>();
        public int counter = 0;
        public CarCatalog(params Car[] _cars)
        {
            for(var i = 0; i < _cars.Length; ++i)
            {
                this.cars.Add(new Car(_cars[i].name, _cars[i].engine, _cars[i].max_speed));
                ++counter;
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0) 
                { 
                    return $"{cars[index].name}; V: {cars[index].engine};"; 
                } else
                {
                    return "error";
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CarCatalog first = new CarCatalog(new Car("BMW x6", 4.2, 240), new Car("Audi RS8", 4, 250), new Car("Ford Focus", 2, 200));
            for (int i = 0; i < first.counter; ++i)
            {
                Console.WriteLine(first[i]);
            }
            string name_of_car = first[0].ToString();
            Console.WriteLine(name_of_car);
            Console.WriteLine(Equals(first[0], first[1]));
            Console.WriteLine(Equals(first[0], first[0]));
            Console.ReadLine();
        }
    }
}