﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UrbaPark.Infraestructura.AccesoDatos;

public partial class roles
{
    public int id_rol { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public virtual ICollection<usuarios> id_usuario { get; set; } = new List<usuarios>();
}