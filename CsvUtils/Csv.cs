using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvUtils
{
    public class Csv
    {
        public string ruta;
        public string[] headers;
        public List<Fila> filas;
        public Csv(string ruta)
        {
            string[] registro= {""};
            this.ruta = ruta;
            this.filas = new List<Fila>();
            const Int32 BufferSize = 128;
            try
            {
                var fileStream = File.OpenRead(ruta);
                var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
                string linea;
                if ((linea = streamReader.ReadLine()) != null)//leo la primer linea con los headers
                {
                    if(!linea.Equals(""))
                    headers = linea.Split(';');
                }
                while ((linea = streamReader.ReadLine()) != null)//leo el resto
                {
                    if(!linea.Equals(""))
                    filas.Add(new Fila(linea.Split(';')));//parseo los registros de la linea
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer el archivo {ruta}",ex);
            }
        }
    }
}
