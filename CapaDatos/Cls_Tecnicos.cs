using System;

namespace bancouh1.CapaDatos
{
    public class Cls_Tecnicos
    {
        private int tecnicoID;
        public int TecnicoID
        {
            get { return tecnicoID; }
            set { tecnicoID = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string especialidad;
        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public Cls_Tecnicos(int tecnicoID, string nombre, string especialidad)
        {
            this.tecnicoID = tecnicoID;
            this.nombre = nombre;
            this.especialidad = especialidad;
        }

        public Cls_Tecnicos() { }
    }
}
