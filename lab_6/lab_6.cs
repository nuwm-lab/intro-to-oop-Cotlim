namespace Lab6
{
    interface ISystemVectors
    {
        bool IsLinearIndependent { get; }
        void PrintA();
        void PrintB();
        void PrintC();
        void SetA(float x, float y, float z = 0);
        void SetB(float x, float y, float z = 0);
        void SetC(float x, float y, float z);
    }
    abstract class SystemVectors : ISystemVectors
    {
        protected float Ax;
        protected float Ay;
        protected float Bx;
        protected float By;
        protected float Az;
        protected float Bz;
        protected float Cx;
        protected float Cy;
        protected float Cz;

        public abstract bool IsLinearIndependent { get; }

        public void SetA(float x, float y, float z = 0)
        {
            Ax = x;
            Ay = y;
            Az = z;
        }

        public void SetB(float x, float y, float z = 0)
        {
            Bx = x;
            By = y;
            Bz = z;
        }

        public void SetC(float x, float y, float z)
        {
            Cx = x;
            Cy = y;
            Cz = z;
        }

        public abstract void PrintA();

        public abstract void PrintB();

        public abstract void PrintC();

        public SystemVectors()
        {
            /*Console.WriteLine("SystemVectors created");*/
        }
        ~SystemVectors()
        {
            /*Console.WriteLine("SystemVectors destroyed");*/
        }

    }
    class System2x2 : SystemVectors
    {
        public System2x2(float ax, float ay, float bx, float by)
        {
            Ax = ax;
            Ay = ay;
            Bx = bx;
            By = by;
        }

        public System2x2() { }

        public override bool IsLinearIndependent => Ax * By - Ay * Bx != 0;


        public override void PrintA()
        {
            Console.WriteLine(string.Format("A({0}, {1})", Ax, Ay));
        }

        public override void PrintB()
        {
            Console.WriteLine(string.Format("B({0}, {1})", Bx, By));
        }

        public override void PrintC()
        {
            Console.WriteLine("None");
        }

    }

    class System3x3 : System2x2
    {


        public System3x3(float ax, float ay, float az,
            float bx, float by, float bz,
            float ca, float cb, float cz) : base(ax, ay, bx, by)
        {
            Az = az;
            Bz = bz;
            Cx = ca;
            Cy = cb;
            Cz = cz;
        }

        public System3x3() { }

        public override bool IsLinearIndependent => Ax * By * Cz
                + Bx * Cy * Az
                + Cx * Ay * Bz
                - Az * By * Cx
                - Bz * Cy * Ax
                - Cz * Ay * Bx != 0;

        public override void PrintA()
        {
            Console.WriteLine(string.Format("A({0}, {1}, {2})", Ax, Ay, Az));
        }

        public override void PrintB()
        {
            Console.WriteLine(string.Format("B({0}, {1}, {2})", Bx, By, Bz));
        }

        public override void PrintC()
        {
            Console.WriteLine(string.Format("C({0}, {1}, {2})", Cx, Cy, Cz));
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter mode: ");
            string userChoose = Console.ReadLine();

            if (userChoose == "1")
            {
                Console.WriteLine("System of vectors 2x2:");
                ISystemVectors system = new System2x2();
                system.SetA(1f, 2f);
                system.SetB(3f, 4f);
                system.PrintA();
                system.PrintB();
                Console.WriteLine(system.IsLinearIndependent);
                system.SetB(2f, 4f);
                system.PrintB();
                Console.WriteLine(system.IsLinearIndependent);

            }
            else
            {
                Console.WriteLine("\nSystem of vectors 3x3:");
                ISystemVectors system3x3 = new System3x3(1f, 2f, 3f, 1f, 4f, 6f, 2f, 3f, 4f);
                system3x3.SetA(1f, 2f, 3f);
                system3x3.SetB(1f, 4f, 6f);
                system3x3.SetC(2f, 3f, 4f);
                system3x3.PrintA();
                system3x3.PrintB();
                system3x3.PrintC();
                Console.WriteLine(system3x3.IsLinearIndependent);
                system3x3.SetC(2f, 4f, 6f);
                system3x3.PrintC();
                Console.WriteLine(system3x3.IsLinearIndependent);
            }
            Console.WriteLine("Press to continue.");
            Console.ReadLine();
        }
    }
}
