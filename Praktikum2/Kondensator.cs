using System;

namespace Praktikum_1
{
    internal class Kondensator //Bauplan für Variablen, Eigenschaften und Funktionen
    {
        //Fields / Felder in private auf die von Außen nicht direkt zugegiffen werden kann
        private string bauform;
        private double kapazitaet;
        private string materialDielektrikum;
        private double relDielektrizKonst;

        //Konstruktor
        public Kondensator(string bauformK, double kapazitaetK, string materialDielektrikumK, double relDielektrizKonstK)
        {
            bauform = bauformK;
            kapazitaet = kapazitaetK;
            materialDielektrikum = materialDielektrikumK;
            relDielektrizKonst = relDielektrizKonstK;
        }

        //Weiterer Konstruktor der nur den kap. Wert und Bauform übernimmt, Rest Defaultwerte
        public Kondensator(string bauformK, double kapazitaetK)
        {
            bauform = bauformK;
            kapazitaet = kapazitaetK;
            materialDielektrikum = "default";
            relDielektrizKonst = 1;
        }


        //properties / Eigenschaften (Getter und Setter), zugriff von Außen auf meine privaten Fields
        public string Bauform
        {
            get => bauform; //Gibt Wet der Eigenschaft zurück

            set //weist neuen Wert hinzu
            {
                if (value != null && value.Length > 0)
                    Bauform = value;
                else
                    Bauform = "default";
            }
        }
        public double Kapazitaet
        {
            get => kapazitaet;

            set
            {
                if (value < 0)
                {
                    kapazitaet = (value * (-1));
                }

                if (value == 0)
                {
                    kapazitaet = 1;
                }
            }
        }

        public string MaterialDielektrikum
        {
            get => materialDielektrikum;

            set
            {
                if (value != null && value.Length > 0)
                {
                    materialDielektrikum = value;
                }
                else 
                    materialDielektrikum = "default";
            }
        }

        public double RelDielektrizKonst
        {
            get => relDielektrizKonst;

            set
            {
                if (value < 0)
                {
                    relDielektrizKonst = (value * (-1));
                }

                if (value == 0)
                {
                    relDielektrizKonst = 1;
                }
            }
        }
    }

}
