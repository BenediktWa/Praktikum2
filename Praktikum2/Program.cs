using System;

namespace Praktikum_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            string buffer;
            double r, c, f;
            bool tmp;

            //RcZweiPolReihe rc = null;
            /*
            Deklaration der Variablen für das Einlesen von Daten eines RC-
            Zweipols
            Variablen: r, c, f, buffer (für Eingabeüberprüfung numerischer
            Eingaben), eingabe
            */

            Console.WriteLine("Zum Einspeichern von RC- Zweipolen j eingeben.");
            eingabe = Console.ReadLine();


            while (eingabe.ToLower().Trim() == "j")
            {
                Console.Clear();
                //Benutzer-Interaktion
                //Ausgabe: "Einen neuen RC-Zweipol erzeugen"
                Console.WriteLine("*** Einen neuen RC-Zweipol erzeugen ***");
                do
                {
                    Console.WriteLine("Zweipol-Widerstand R [Ohm]: ");
                    buffer = Console.ReadLine(); //Zuerst in buffer einlesen
                    buffer = buffer.Replace('.', ','); //Vertauschen von Punkt mit Komma, da es ansonsten Stellenprobleme gibt
                    tmp = double.TryParse(buffer, out r); //Überprüfen auf double zahl wenn ja = true
                } while (!tmp);

                do
                {
                    Console.WriteLine("Zweipol-Kapazitaet [nF]: ");
                    buffer = Console.ReadLine();
                    buffer = buffer.Replace('.', ',');
                    tmp = double.TryParse(buffer,out c);
                } while (!tmp);

                do
                {
                    Console.WriteLine("\nZweipol-Frequenz f [Hz]: ");
                    buffer = Console.ReadLine();
                    buffer = buffer.Replace('.', ',');
                    tmp = double.TryParse(buffer, out f);
                }while (!tmp);

                do
                {
                    Console.WriteLine("Kondensator-Bauform: ");
                    buffer = Console.ReadLine();
                    if (buffer.Length < 1) //String darf nicht leer sein
                    {
                        tmp = false;
                    }
                    else
                    {
                        tmp = true;
                    }
                } while (!tmp);

                //Eingaben (s. Abb.) mit do-while-Schleifen zur Überprüfung der
                //numerischen Eingaben.
                //Anlegen einer Objektvariablen der Kind-Klasse RCZweipolReihe
                //Ausgabe der Objekteigenschaften durch Aufruf der Methode
                //Aufruf der statischen Methode ausgabe() über die Objektvariable
                //Abfrage, ob Erzeugung eines RC-Zweipols wiederholt werden soll

                RcZweiPolReihe z = new RcZweiPolReihe(f, r, buffer, c); //Erstellen eines neuen Objektes RcZweiPolReihe

                PrintData(z); //Ausgabe der Daten von dem erstellten Objekt die im vorraus eingegeben wurden

                Console.WriteLine("Einen neuen Zweipol erzeugen [j/n]? "); //wiederholen?
                eingabe = Console.ReadLine();

            }//while

            return;

        }//Main

        //Ausgabe der Daten
        public static void PrintData(RcZweiPolReihe z)
        {
            //Variablen für die Einheiten
            string Ohm = "Ohm";
            string nF = "nF";
            string fre = "1/s";

            //Ausgabe Kopfzeile
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("            Bauelementewerte            ");
            Console.WriteLine("----------------------------------------");

            //Ausgabe der Werte des Objektes inklusive Formatierung und ausgebende Stellen
            Console.WriteLine("Widerstandswert:{0,20:F2}{1,4}", z.R, Ohm);
            Console.WriteLine("Kapazitätswert :{0,20:F2}{1,4}", (z.Ko.Kapazitaet * 1000000000), nF); //Ausgabe Member
            Console.WriteLine("Kreisfrequenz  :{0,20:F2}{1,4}", (z.GetKreisFrequenz()), fre); //Methode der Klasse (return)
            Console.WriteLine();

            //Ausgabe Kopfzeile
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("   Komplexer Widerstand des Zweipols    ");
            Console.WriteLine("----------------------------------------");

            //Ausgabe der Werte des Objektes inklusive Formatierung und ausgebende Stellen
            Console.WriteLine("Betrag :{0,28:F2}{1,4}", (z.GetZBetrag()), Ohm);//Methode der Klasse (return)
            Console.WriteLine("Re-Teil:{0,28:F2}{1,4}", (z.GetZReal()), Ohm);//Methode der Klasse (return)
            Console.WriteLine("Im-Teil:{0,28:F2}{1,4}", (z.GetZImag()), Ohm);//Methode der Klasse (return)
            Console.WriteLine();


        }//PrintData

    }//Program
}
