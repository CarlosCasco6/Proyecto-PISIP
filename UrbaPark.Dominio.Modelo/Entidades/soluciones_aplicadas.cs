﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UrbaPark.Infraestructura.AccesoDatos;

public partial class soluciones_aplicadas
{
    public int id_solucion { get; set; }

    public int id_incidencia { get; set; }

    public string descripcion { get; set; }

    public DateOnly? fecha_ejecucion { get; set; }

    public string resultado { get; set; }

    public virtual incidencias_software id_incidenciaNavigation { get; set; }
}