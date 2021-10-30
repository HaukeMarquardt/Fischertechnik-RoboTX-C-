using System;
using FishFaceTX;

namespace HaukeTest
{
    class Program
    {
        static FishFace tx = new FishFace();
        static int motorSpeed = 0;

        private static void Accelerate(int vMax, int increment, Dir direction)
        {
            for(int i = 0; i + increment <= vMax; i += increment)
            {
                motorSpeed = i;
                tx.SetMotor(MotNr: Mot.M1, Direction: direction, Speed: motorSpeed);
                tx.Pause(mSek: 20);
            }
        }

        private static void Deccelerate(int vMin, int increment, Dir direction)
        {
            for (int i = motorSpeed; i - increment >= vMin; i -= increment)
            {
                motorSpeed = i;
                tx.SetMotor(MotNr: Mot.M1, Direction: direction, Speed: motorSpeed);
                tx.Pause(mSek: 50);
            }
        }

        static void Main(string[] args)
        {
            var control = new FishControl();
            Console.WriteLine($"ftMscLib version: {control.LibVersion}");
            try
            {
                tx.OpenController("COM5");
                int increment = 25;
                while (true)
                {
                    Accelerate(200, increment, Dir.Left);

                    tx.Pause(mSek: 200);

                    Deccelerate(0, increment, Dir.Left);

                    tx.Pause(mSek: 200);

                    Accelerate(200, increment, Dir.Right);

                    tx.Pause(mSek: 200);

                    Deccelerate(0, increment, Dir.Right);

                    tx.Pause(mSek: 200);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
