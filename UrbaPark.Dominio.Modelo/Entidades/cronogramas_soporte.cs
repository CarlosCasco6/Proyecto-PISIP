﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UrbaPark.Infraestructura.AccesoDatos;

public partial class cronogramas_soporte
{
    public int id_cronograma { get; set; }

    public int id_parqueadero { get; set; }

    public string nombre_cronograma { get; set; }

    public DateOnly fecha_inicio { get; set; }

    public DateOnly? fecha_fin { get; set; }

    public string frecuencia { get; set; }

    public string tipo { get; set; }

    public string observaciones { get; set; }

    public virtual parqueaderos id_parqueaderoNavigation { get; set; }

    public virtual ICollection<rel_cronogramas_tecnicos> rel_cronogramas_tecnicos { get; set; } = new List<rel_cronogramas_tecnicos>();
}