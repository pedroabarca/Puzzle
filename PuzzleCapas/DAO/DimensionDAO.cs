﻿using Npgsql;
using PuzzleCapas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCapas.DAO
{
    public class DimensionDAO
    {
        public List<Dimension> CargarDimensiones()
        {
            List<Dimension> dimensiones = new List<Dimension>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                string sql = @"select 
                                id_dimension, dimension
                               from 
                                dimension";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dimension d = new Dimension()
                    {
                        Id = reader.GetInt32(0),
                        Descripcion = reader.GetString(1)
                    };
                    dimensiones.Add(d);
                }
            }
            return dimensiones;
        }
    }
}
