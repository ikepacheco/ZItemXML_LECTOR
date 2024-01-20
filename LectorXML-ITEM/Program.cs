using System;
using System.Xml;

class Program
{
    static void Main()
    {
        string archivoXml1 = "zitem.xml"; // Reemplaza con la ruta de tu archivo XML
        string archivoXml2 = "zitem_locale.xml"; // Reemplaza con la ruta de tu archivo XML
        LeerXml(archivoXml1, archivoXml2);
    }

    static void LeerXml(string xmlPath1, string xmlPath2)
    {
        List<int> itemID = new List<int>();
        try
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;



            using (XmlReader reader = XmlReader.Create(xmlPath1, settings))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "ITEM"){ 
                                //Console.WriteLine($"Elemento: {reader.Name}");

                                // Iterar a través de los atributos del elemento
                                while (reader.MoveToNextAttribute())
                                {
                                    //Console.WriteLine($"  Atributo: {reader.Name} = {reader.Value}");

                                    if (reader.Name == "id") itemID.Add(int.Parse(reader.Value));


                                }

                                // Mostrar el contenido del elemento si es un nodo de texto
                                //if (reader.NodeType == XmlNodeType.Element)
                                //{
                                //    Console.WriteLine($"  Contenido: {reader.ReadElementContentAsString()}");
                                //}

                                //Console.WriteLine();
                            }
                            break;
                    }
                }
            }
            using (XmlReader reader = XmlReader.Create(xmlPath2, settings))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "ITEM")
                            {
                                //Console.WriteLine($"Elemento: {reader.Name}");

                                // Iterar a través de los atributos del elemento
                                while (reader.MoveToNextAttribute())
                                {
                                    //Console.WriteLine($"  Atributo: {reader.Name} = {reader.Value}");

                                    if (reader.Name == "id") itemID.Add(int.Parse(reader.Value));


                                }

                                // Mostrar el contenido del elemento si es un nodo de texto
                                //if (reader.NodeType == XmlNodeType.Element)
                                //{
                                //    Console.WriteLine($"  Contenido: {reader.ReadElementContentAsString()}");
                                //}

                                //Console.WriteLine();
                            }
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo XML: {ex.Message}");
        }

        //foreach (var id in itemID)
        //{
        //    Console.WriteLine($"ITEM ID='{id}'");
        //}

        Dictionary<int, int> idRepetido = new Dictionary<int, int>();

        // Recorrer la lista y contar la frecuencia de cada elemento
        foreach (int id in itemID)
        {
            if (idRepetido.ContainsKey(id))
            {
                idRepetido[id]++;
            }
            else
            {
                idRepetido[id] = 1;
            }
        }

        Console.WriteLine("Total IDs: "+itemID.Count);
        Console.WriteLine("IDs repetidos:");
        foreach (var par in idRepetido.Where(x => x.Value > 1))
        {
            Console.WriteLine($"id: {par.Key}, repetido: {par.Value}");
        }

        

        using (StreamWriter writer = new StreamWriter("ids.txt"))
        {
            // Escribir cada número de ID en una línea separada
            foreach (int id in itemID)
            {
                writer.WriteLine(id);
            }
        }

        Console.WriteLine("Archivo de texto creado exitosamente.");



        Console.WriteLine();
        Console.ReadKey();
    }
}
