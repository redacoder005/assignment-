namespace assignment_10
{
    using System;
    using System.Collections.Generic;

    class Container<T>
    {
        private T value;

        public void Add(T value)
        {
            this.value = value;
        }

        public T Get()
        {
            return value;
        }
    }

    class Pair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    interface IRepository<T>
    {
        void Add(T item);
        T Get();
    }

    class StructTest<T> where T : struct
    {
        public T Value;

        public StructTest(T value)
        {
            Value = value;
        }
    }

    class ClassTest<T> where T : class
    {
        public T Value;

        public ClassTest(T value)
        {
            Value = value;
        }
    }

    class NewTest<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    interface IPrint
    {
        void Print();
    }

    class InterfaceTest<T> where T : IPrint
    {
        public void PrintItem(T item)
        {
            item.Print();
        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }
    }

    class Dog : Animal
    {
    }

    class BaseClassTest<T> where T : Animal
    {
        public void Test(T item)
        {
            item.Eat();
        }
    }

    class MultipleConstraintTest<T>
        where T : Animal, IPrint, new()
    {
        public void Test(T item)
        {
            item.Eat();
            item.Print();
        }
    }

    class SafeList<T>
    {
        private T[] items;

        public SafeList(T[] items)
        {
            this.items = items;
        }

        public T Get(int index)
        {
            if (index >= 0 && index < items.Length)
            {
                return items[index];
            }

            return default(T);
        }
    }

    interface IProducer<out T>
    {
        T Get();
    }

    interface IConsumer<in T>
    {
        void Consume(T item);
    }

    class Counter<T>
    {
        public static int Count = 0;
    }

    class GenericBox<T>
    {
        public T Value;

        public GenericBox(T value)
        {
            Value = value;
        }
    }

    class IntBox : GenericBox<int>
    {
        public IntBox(int value) : base(value)
        {
        }
    }

    class Cache<TKey, TValue>
    {
        private Dictionary<TKey, TValue> data =
            new Dictionary<TKey, TValue>();

        private Dictionary<TKey, DateTime> expiration =
            new Dictionary<TKey, DateTime>();

        public void Add(TKey key, TValue value, int seconds)
        {
            data[key] = value;
            expiration[key] = DateTime.Now.AddSeconds(seconds);
        }

        public TValue Get(TKey key)
        {
            if (Contains(key))
            {
                return data[key];
            }

            return default(TValue);
        }

        public void Remove(TKey key)
        {
            if (data.ContainsKey(key))
            {
                data.Remove(key);
                expiration.Remove(key);
            }
        }

        public bool Contains(TKey key)
        {
            if (!data.ContainsKey(key))
            {
                return false;
            }

            if (DateTime.Now > expiration[key])
            {
                Remove(key);
                return false;
            }

            return true;
        }
    }

    class Person
    {
        public Person()
        {
            Console.WriteLine("Person Created");
        }
    }

    class Student : Animal, IPrint
    {
        public Student()
        {
        }

        public void Print()
        {
            Console.WriteLine("Student");
        }
    }

    class Program
    {
        static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        static T FindMax<T>(T x, T y)
            where T : IComparable<T>
        {
            if (x.CompareTo(y) > 0)
            {
                return x;
            }

            return y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("===== Q2 Container =====");

            Container<int> container =
                new Container<int>();

            container.Add(10);

            Console.WriteLine(container.Get());

            Console.WriteLine("\n===== Q3 Pair =====");

            Pair<int, string> pair =
                new Pair<int, string>(1, "Mohamed");

            Console.WriteLine("Key : " + pair.Key);
            Console.WriteLine("Value : " + pair.Value);

            Console.WriteLine("\n===== Q4 Swap =====");

            int x = 10;
            int y = 20;

            Console.WriteLine("Before Swap:");
            Console.WriteLine(x);
            Console.WriteLine(y);

            Swap(ref x, ref y);

            Console.WriteLine("After Swap:");
            Console.WriteLine(x);
            Console.WriteLine(y);

            Console.WriteLine("\n===== Q5 FindMax =====");

            int max = FindMax(10, 20);

            Console.WriteLine("Maximum : " + max);

            Console.WriteLine("\n===== Q7 Struct Constraint =====");

            StructTest<int> structTest =
                new StructTest<int>(100);

            Console.WriteLine(structTest.Value);

            Console.WriteLine("\n===== Q8 Class Constraint =====");

            ClassTest<string> classTest =
                new ClassTest<string>("Hello");

            Console.WriteLine(classTest.Value);

            Console.WriteLine("\n===== Q9 new() Constraint =====");

            NewTest<Person> newTest =
                new NewTest<Person>();

            Person person = newTest.Create();

            Console.WriteLine("\n===== Q10 Interface Constraint =====");

            InterfaceTest<Student> interfaceTest =
                new InterfaceTest<Student>();

            Student student =
                new Student();

            interfaceTest.PrintItem(student);

            Console.WriteLine("\n===== Q11 Base Class Constraint =====");

            BaseClassTest<Dog> baseTest =
                new BaseClassTest<Dog>();

            Dog dog =
                new Dog();

            baseTest.Test(dog);

            Console.WriteLine("\n===== Q12 Multiple Constraints =====");

            MultipleConstraintTest<Student> multipleTest =
                new MultipleConstraintTest<Student>();

            multipleTest.Test(student);

            Console.WriteLine("\n===== Q13 default =====");

            int defaultInt = default(int);
            string defaultString = default(string);

            Console.WriteLine("Default int : " + defaultInt);
            Console.WriteLine("Default string : " + defaultString);

            Console.WriteLine("\n===== Q14 SafeList =====");

            int[] numbers = { 10, 20, 30 };

            SafeList<int> list =
                new SafeList<int>(numbers);

            Console.WriteLine("Valid index : " + list.Get(1));
            Console.WriteLine("Invalid index : " + list.Get(10));

            Console.WriteLine("\n===== Q15 Covariance =====");

            IProducer<string> stringProducer = null;

            IProducer<object> objectProducer =
                stringProducer;

            Console.WriteLine("Covariance uses out");

            Console.WriteLine("\n===== Q16 Contravariance =====");

            IConsumer<object> objectConsumer = null;

            IConsumer<string> stringConsumer =
                objectConsumer;

            Console.WriteLine("Contravariance uses in");

            Console.WriteLine("\n===== Q17 Covariance vs Contravariance =====");

            Console.WriteLine("Covariance : out");
            Console.WriteLine("Contravariance : in");

            Console.WriteLine("\n===== Q18 Static Generic =====");

            Counter<int>.Count++;
            Counter<int>.Count++;

            Counter<string>.Count++;

            Console.WriteLine(
                "Counter<int> : "
                + Counter<int>.Count);

            Console.WriteLine(
                "Counter<string> : "
                + Counter<string>.Count);

            Console.WriteLine("\n===== Q19 Generic Inheritance =====");

            IntBox intBox =
                new IntBox(50);

            Console.WriteLine(
                "Value : " + intBox.Value);

            Console.WriteLine("\n===== Q20 Cache =====");

            Cache<int, string> cache =
                new Cache<int, string>();

            cache.Add(1, "Mohamed", 10);

            Console.WriteLine(
                "Contains : "
                + cache.Contains(1));

            Console.WriteLine(
                "Value : "
                + cache.Get(1));

            cache.Remove(1);

            Console.WriteLine(
                "Contains after Remove : "
                + cache.Contains(1));

           
        }
    }
}
