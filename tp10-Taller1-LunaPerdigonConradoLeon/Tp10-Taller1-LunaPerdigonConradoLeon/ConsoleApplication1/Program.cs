using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Propiedad nuevaprop = cargardatos();

            List<string> lalista = File.ReadAllLines(@"..\..\LasPropiedades.csv", Encoding.ASCII).ToList();//Mejor un arreglo(?
            System.Console.WriteLine();
            List<string> nuevalista = File.ReadAllLines(@"..\..\NuevaLista.csv", Encoding.ASCII).ToList();
            foreach (string linea in lalista)
            {
                Propiedad propaux = cargardatos();
                string aux = linea;
                aux = aux + ";" + propaux.Tipooperacion.ToString() + ";";
                aux = aux + propaux.Tamanio.ToString() + ";";
                aux = aux + propaux.CantBanios.ToString() + ";";
                aux = aux + propaux.CantHabitaciones.ToString() + ";";
                aux = aux + propaux.Precio.ToString() + ";";
                aux = aux + propaux.Estado.ToString();
                nuevalista.Add(aux);    
                File.WriteAllLines(@"..\..\NuevaLista.csv", nuevalista.ToArray());
            }
            Console.WriteLine("Se sobreescribieron exitosamente los datos");

            
            string[] discos = System.IO.Directory.GetLogicalDrives();
            foreach (string eldisco in discos)
            {

                Console.WriteLine("Disponible el disco:" + eldisco);
            }

            Console.WriteLine(@"En que disco desea guardar? (COPIE TEXTUALMENTE EL DISCO EJ: E:\)");//YA ANDA
            string discoelegido = Console.ReadLine();
            foreach (string eldiscoelegido in discos)
            {

                try
                {

                    if (Equals(eldiscoelegido.ToLower(), discoelegido.ToLower()))
                    {
                        if (Directory.Exists(eldiscoelegido))
                        {
                            string elbackup = eldiscoelegido + @"\ BackUpDeLasPropiedades";
                            Directory.CreateDirectory(elbackup);
                            //File.Copy("archivoorigonal", "archivodestino.nuevaextension")
                            string fecha = DateTime.Now.ToString(@"hh\mm\Ss");

                            fecha = fecha.Replace(':', '-');
                            fecha = fecha.Replace('\\', '_');
                            string nombreArchivo = @"\BackUpPropiedades" + fecha + ".bk";
                            File.Copy(@"..\..\NuevaLista.csv", elbackup + nombreArchivo);

                            //File.Move(rutadelarchivo, elbackup + ".bk");
                            Console.WriteLine("Se guardo exitosamente!");

                        }
                        else
                        {
                            string elbackup = eldiscoelegido + @"\ BackUp";
                            Directory.CreateDirectory(elbackup);
                            Console.WriteLine("La carpeta no existe, creando una...");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: PROBLEMAS AL BUSCAR LA CARPETA ");
                }
            }
            Console.ReadKey();
        }

        public static Propiedad cargardatos()
        {
            string[] direcciones = { "Direccion1", "Direccion2", "Direccion3", "Direccion4", "Direccion5", "Direccion6" };
           
            Random rnd = new Random();
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            string direccion= direcciones[rnd.Next(0,6)];

            
            int opcion = rnd.Next(1, 3);
            TipoDeOperacion laoperacion;
            switch (opcion)
            {
                case 1:
                    laoperacion = TipoDeOperacion.Venta;
                    break;
                case 2:
                    laoperacion = TipoDeOperacion.Alquiler;
                    break;
                default:
                    laoperacion = TipoDeOperacion.Alquiler;
                    break;
            }

            int opcion1 = rnd1.Next(1, 6);
           TipoDePropiedad lapropiedad;
            switch (opcion1)
            {
                case 1:
                    lapropiedad= TipoDePropiedad.Departamento;
                    break;
                case 2:
                    lapropiedad = TipoDePropiedad.Casa;
                    break;
                case 3:
                    lapropiedad = TipoDePropiedad.Duplex;
                    break;
                case 4:
                    lapropiedad = TipoDePropiedad.Penthhouse;
                    break;
                case 5:
                    lapropiedad = TipoDePropiedad.Terreno;
                    break;
                default:
                    lapropiedad = TipoDePropiedad.Departamento;
                    break;

            }
              
            int habitaciones = rnd.Next(1, 5);
            int banio = rnd.Next(1, 3);
            int elid = rnd.Next(1, 400);
            float eltamanio = rnd1.Next(100, 2000);
            int elprecio = rnd.Next(500000, 10000000);

            bool elestado;
            if (rnd.Next(0, 2) == 0)
            {
                elestado = false;
            }
            else
            {
                elestado = true;
            }

            Propiedad laprop = new Propiedad(elid,lapropiedad,laoperacion,eltamanio, banio, habitaciones, direccion, elprecio, elestado);
            return laprop;
        }
    }
}
