using System;

namespace lab2
{
    class Pupil
    {
        public virtual void Study()
        { }

        public virtual void Read()
        { }

        public virtual void Write()
        { }

        public virtual void Relax()
        { }
    }


    class ExcelentPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("ExcelentPupil: Study-exceletn");
        }
        public override void Read()
        {
            Console.WriteLine("ExcelentPupil: Read-exceletn");
        }
        public override void Write()
        {
            Console.WriteLine("ExcelentPupil: Write-exceletn");
        }
        public override void Relax()
        {
            Console.WriteLine("ExcelentPupil: Relax-exceletn");
        }

    }
    class GoodPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("GoodPupil: Study-Good");
        }
        public override void Read()
        {
            Console.WriteLine("GoodPupil: Read-Good");
        }
        public override void Write()
        {
            Console.WriteLine("GoodPupil: Write-Good");
        }
        public override void Relax()
        {
            Console.WriteLine("GoodPupil: Relax-Good");
        }

    }
    class BadPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("BadPupil: Study-Bad");
        }
        public override void Read()
        {
            Console.WriteLine("BadPupil: Read-Bad");
        }
        public override void Write()
        {
            Console.WriteLine("BadPupil: Write-Bad");
        }
        public override void Relax()
        {
            Console.WriteLine("BadPupil: Relax-Bad");
        }

    }
    class ClassRoom
    {
        Pupil[] arrPupil;


        public ClassRoom(Pupil p1, Pupil p2, Pupil p3, Pupil p4)
        {
            arrPupil = new Pupil[] { p1, p2, p3, p4 };
        }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3)
        {
            arrPupil = new Pupil[] { p1, p2, p3 };
        }
        public ClassRoom(Pupil p1, Pupil p2)
        {
            arrPupil = new Pupil[] { p1, p2 };
        }

        public void PrintInfoStudy()
        {
            Console.WriteLine("Study: ");
            foreach (Pupil item in arrPupil)
                item.Study();
        }
        public void PrintInfoRead()
        {
            Console.WriteLine("Read: ");
            foreach (Pupil item in arrPupil)
                item.Read();
        }
        public void PrintInfoWrite()
        {
            Console.WriteLine("Write: ");
            foreach (Pupil item in arrPupil)
                item.Write();
        }
        public void PrintInfoRelax()
        {
            Console.WriteLine("Relax: ");
            foreach (Pupil item in arrPupil)
                item.Relax();
        }
    }

    class Program
    {
        static void Main()
        {
            ClassRoom cRoom = new ClassRoom(new ExcelentPupil(), new GoodPupil(), new BadPupil(), new GoodPupil());

            cRoom.PrintInfoRead();
            cRoom.PrintInfoRelax();
            cRoom.PrintInfoStudy();
            cRoom.PrintInfoWrite();

            Console.ReadKey();
        }
    }
}
