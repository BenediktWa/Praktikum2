using System;

namespace Praktikum_1
{
    public class RcZweiPolReihe //Klasse RcZweiPolReihe
    {
        //Fields in private auf die von Außen nicht direkt zugegiffen werden kann
        private double f;
        private double r;

        //Member
        private Kondensator ko;

        //Konstruktor
        public RcZweiPolReihe(double fK, double rK, string bauf, double c)
        {
            c = c / 1000000000; //Umrechnung in Nanofarrat
            Ko = new Kondensator(bauf, c); //Initialisierung eines Kondensator Objektes
            f = fK;
            r = rK;

            /*
            if (fK < 0) f = (fK * (-1));
            else f = fK;

            if (fK == 0) f = 1;
            else f = fK;

            if (rK < 0) r = (rK * (-1));
            else r = rK;

            if (rK == 0) r = 1;
            else r = rK;
            */
        }

        //Properties / Eigenschaften, zugriff von Außen auf meine privaten Fields
        public double F 
        { 
          get => f;
            set
            {
                if (value < 0) f = (value * (-1));
                else f = value;

                if (value == 0) f = 1;
                else f = value;
            }
        }
        public double R 
        { 
          get => r;
            set
            {
                if (value < 0) r = (value * (-1));
                else r = value;

                if (value == 0) r = 1;
                else r = value;
            }
        }
        internal Kondensator Ko 
        { 
          get => ko;
          set => ko = value;
        }

        //Methods / Methoden der Klasse
        public double GetZReal()
        {
            double ZReal;

            ZReal = r;

            return ZReal;
        }
        public double GetZImag()
        {
            double ZImag;

            if (f < 0) f = (f*(-1));
            if (ko.Kapazitaet < 0) ko.Kapazitaet = (f * (-1));

            ZImag = 1 / (2 * (Math.PI) * f * ko.Kapazitaet);

            return ZImag;
        }
        public double GetZBetrag()
        {
            double ZBetrag;
            double ZReal = GetZReal();
            double ZImag = GetZImag();

            double tmp = (ZReal * ZReal) + (ZImag * ZImag);
            ZBetrag = Math.Sqrt(tmp);

            return ZBetrag;

        }
        public double GetKreisFrequenz()
        {
            double w; //omega

            w = 2 * (Math.PI) * f; //berechnung der Kreisfrequenz

            return w;

        }

    }//Klasse

}//Namespace
