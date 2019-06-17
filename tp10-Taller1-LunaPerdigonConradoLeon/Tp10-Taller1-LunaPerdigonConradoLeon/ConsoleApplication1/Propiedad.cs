using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum TipoDeOperacion
    {
        Venta,Alquiler
    }
    public enum TipoDePropiedad
    {
        Departamento, Casa, Duplex, Penthhouse, Terreno
    }

    public class Propiedad
    {
        int id;
        TipoDePropiedad tipopropiedad;
        TipoDeOperacion tipooperacion;
        float tamanio;
        int cantBanios;
        int cantHabitaciones;
        string domicilio;
        int precio;
        bool estado;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public Propiedad(int _id, TipoDePropiedad _tipopropiedad, TipoDeOperacion _tipooperacion, float _tamanio, int _cantBanios, int _cantHabitaciones,string _domicilio, int _precio,bool _estado) { 
            id = _id;
            tipopropiedad = _tipopropiedad;
            tipooperacion = _tipooperacion;
            tamanio = _tamanio;
            cantBanios = _cantBanios;
            domicilio = _domicilio;
            cantHabitaciones = _cantHabitaciones;
            precio = _precio;
            estado = _estado;

        }



        public void mostrar()
        {
            Console.WriteLine(Id);
            Console.WriteLine(Tipopropiedad);
            Console.WriteLine(Tipooperacion);
            Console.WriteLine(Tamanio);
            Console.WriteLine(CantBanios);
            Console.WriteLine(CantHabitaciones);
            Console.WriteLine(Domicilio);
            Console.WriteLine(Precio);
            Console.WriteLine(Estado);
            Console.WriteLine("--------------");
        }

        public TipoDePropiedad Tipopropiedad
        {
            get
            {
                return tipopropiedad;
            }

            set
            {
                tipopropiedad = value;
            }
        }

        public TipoDeOperacion Tipooperacion
        {
            get
            {
                return tipooperacion;
            }

            set
            {
                tipooperacion = value;
            }
        }

        public float Tamanio
        {
            get
            {
                return tamanio;
            }

            set
            {
                tamanio = value;
            }
        }

        public int CantBanios
        {
            get
            {
                return cantBanios;
            }

            set
            {
                cantBanios = value;
            }
        }

        public int CantHabitaciones
        {
            get
            {
                return cantHabitaciones;
            }

            set
            {
                cantHabitaciones = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public int Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public bool Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public void ValorDelInmueble()
        {

        double elprecio;
            if (Tipooperacion == TipoDeOperacion.Venta)
            {
             
                elprecio = precio + (precio*0.21) + (precio*0.10) + 10000;
                int elprecioenint=Convert.ToInt32(elprecio);
                Console.WriteLine("El valor del inmueble es {0}", elprecioenint);

            }
            else
            {
                elprecio =precio*0.02 + precio*0.005;
                int elprecioenint = Convert.ToInt32(elprecio);
                Console.WriteLine("El valor del inmueble es {0}", elprecioenint);

            }
        }
    }
}
