using System;

namespace CSharp.LabExercise4
{
    interface IShape
    {
        public string ShapeName { get; set; }
        void ComputeArea();
        void DisplayArea();
    }
    abstract class BaseShape
    {
        public string ShapeName { get; set; }
        public decimal Area { get; set; }

        public void DisplayArea()
        {
            Console.WriteLine($"{ShapeName} Area: {Area}\n");
        }
    }
    class Circle : BaseShape, IShape
    {
        decimal radius;
        public Circle(decimal radius)
        {
            this.ShapeName = "Circle";
            this.radius = radius;
            this.ComputeArea();
        }
        public void ComputeArea()
        {
            this.Area = Math.Round(Convert.ToDecimal(Math.PI) * (this.radius * this.radius), 2);
        }
    }
    class Square : BaseShape, IShape
    {
        decimal side;
        public Square(decimal side)
        {
            this.ShapeName = "Square";
            this.side = side;
            ComputeArea();
        }
        public void ComputeArea()
        {
            this.Area = this.side * this.side;
        }
    }
    class Rectangle : BaseShape, IShape
    {
        decimal length;
        decimal width;
        public Rectangle(decimal length, decimal width)
        {
            this.ShapeName = "Rectangle";
            this.length = length;
            this.width = width;
            ComputeArea();
        }
        public void ComputeArea()
        {
            this.Area = this.length * this.width;
        }
    }

    class Program
    {
        public static void ShapeAreaCalculator()
        {
            Console.Clear();
            Console.WriteLine("Welcome To Shape Area Calculator!");
            Console.WriteLine("\nPlease Select Shape:");
            Console.WriteLine("[1] - Circle");
            Console.WriteLine("[2] - Square");
            Console.WriteLine("[3] - Rectangle");
            Console.WriteLine("[4] - Clear Console");
            Console.WriteLine("[5] - Exit");
            bool isLooping = true;
            while (isLooping)
            {
                Console.Write("Enter Selection: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nEnter Radius: ");
                        decimal radius = Convert.ToDecimal(Console.ReadLine());
                        IShape circle = new Circle(radius);
                        circle.DisplayArea();
                        break;
                    case "2":
                        Console.Write("\nEnter Side: ");
                        decimal side = Convert.ToDecimal(Console.ReadLine());
                        IShape square = new Square(side);
                        square.DisplayArea();
                        break;
                    case "3":
                        Console.Write("\nEnter Length: ");
                        decimal length = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Width: ");
                        decimal width = Convert.ToDecimal(Console.ReadLine());
                        IShape rectangle = new Rectangle(length, width);
                        rectangle.DisplayArea();
                        break;
                    case "4":
                        ShapeAreaCalculator();
                        break;
                    case "5":
                        Console.WriteLine("\nShape Area Calculator Terminated!");
                        isLooping = false;
                        break;
                    default:
                        Console.Write("\nInvalid Selection! Try Again! . . .\n\n");
                        break;
                }
            }

            Console.Write("Press any key to return in Main Menu . . . ");
            Console.ReadKey();
            Main();

        }
        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome To My Lab Exercise 4 Application!");
                Console.WriteLine("\nPlease Select Exercise:");
                Console.WriteLine("[1] - Shape Area Calculator");
                Console.WriteLine("[2] - Arithmetic Calculator");
                Console.WriteLine("[3] - Exit Application");
                Console.Write("Enter Selection: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        ShapeAreaCalculator();
                        break;
                    case "2":
                        Console.Clear();
                        ArithmeticCalculator();
                        break;
                    case "3":
                        Console.WriteLine("\nApplication Terminated!");
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.Write("\nInvalid Selection! Press Any Key To Try Again! . . . ");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void ArithmeticCalculator()
        {
            Console.Clear();
            Console.WriteLine("Welcome To Arithmetic Calculator!");
            Console.WriteLine("\nPlease Select Operation:");
            Console.WriteLine("[1] - Addition");
            Console.WriteLine("[2] - Subtraction");
            Console.WriteLine("[3] - Multiplication");
            Console.WriteLine("[4] - Division");
            Console.WriteLine("[5] - Clear Console");
            Console.WriteLine("[6] - Exit");
            bool isLooping = true;
            decimal firstValue;
            decimal secondValue;
            while (isLooping)
            {
                Console.Write("Enter Selection: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nEnter First Value: ");
                        firstValue = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter SEcond Value: ");
                        secondValue = Convert.ToDecimal(Console.ReadLine());
                        IOperators add = new AdditionOperator();
                        add.Compute(firstValue, secondValue);
                        break;
                    case "2":
                        Console.Write("\nEnter First Value: ");
                        firstValue = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Second Value: ");
                        secondValue = Convert.ToDecimal(Console.ReadLine());
                        IOperators subtract = new SubtractionOperator();
                        subtract.Compute(firstValue, secondValue);
                        break;
                    case "3":
                        Console.Write("\nEnter First Value: ");
                        firstValue = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Second Value: ");
                        secondValue = Convert.ToDecimal(Console.ReadLine());
                        IOperators multiply = new MultiplicationOperator();
                        multiply.Compute(firstValue, secondValue);
                        break;
                    case "4":
                        Console.Write("\nEnter First Value: ");
                        firstValue = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Second Value: ");
                        secondValue = Convert.ToDecimal(Console.ReadLine());
                        IOperators divide = new DivisionOperator();
                        divide.Compute(firstValue, secondValue);
                        break;
                    case "5":
                        ArithmeticCalculator();
                        break;
                    case "6":
                        Console.WriteLine("\nShape Area Calculator Terminated!");
                        isLooping = false;
                        break;
                    default:
                        Console.Write("\nInvalid Selection! Try Again! . . .\n\n");
                        break;
                }
            }

            Console.Write("Press any key to return in Main Menu . . . ");
            Console.ReadKey();
            Main();

        }
    }

    interface IOperators
    {
        void Compute(decimal firstValue, decimal secondValue);
    }

    class AdditionOperator : IOperators
    {
        public void Compute(decimal firstValue, decimal secondValue)
        {
            decimal result = firstValue + secondValue;
            Console.WriteLine($" => {firstValue} plus {secondValue} is equal to {result}\n");
        }
    }

    class SubtractionOperator : IOperators
    {
        public void Compute(decimal firstValue, decimal secondValue)
        {
            decimal result = firstValue - secondValue;
            Console.WriteLine($" => {firstValue} minus {secondValue} is equal to {result}\n");
        }

    }

    class MultiplicationOperator : IOperators
    {
        public void Compute(decimal firstValue, decimal secondValue)
        {
            decimal result = firstValue * secondValue;
            Console.WriteLine($" => {firstValue} times {secondValue} is equal to {result}\n");
        }

    }

    class DivisionOperator : IOperators
    {
        public void Compute(decimal firstValue, decimal secondValue)
        {
            decimal result = firstValue / secondValue;
            Console.WriteLine($" => {firstValue} divided by {secondValue} is equal to {result}\n");
        }

    }
}
