using System;

namespace bancouh1.CapaDatos
{
    public class Cls_Asignaciones
    {
        public int AsignacionID { get; set; }
        public int ReparacionID { get; set; }
        public int TecnicoID { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public Cls_Asignaciones() { }

        public Cls_Asignaciones(int asignacionID, int reparacionID, int tecnicoID, DateTime fechaAsignacion)
        {
            AsignacionID = asignacionID;
            ReparacionID = reparacionID;
            TecnicoID = tecnicoID;
            FechaAsignacion = fechaAsignacion;
        }
    }
}
