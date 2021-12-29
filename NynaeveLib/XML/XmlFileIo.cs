namespace NynaeveLib.XML
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// static class which manages XML serialisation.
    /// </summary>
    public static class XmlFileIo
    {
        /// <summary>
        /// Deserialise an XML file.
        /// </summary>
        /// <typeparam name="T">Root class</typeparam>
        /// <param name="filename">filename (including path) of the file to deserialise</param>
        /// <returns>deserialised file</returns>
        public static T ReadXml<T>(string filename)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(T));
            T result = default(T);
            Stream stream = null;

            try
            {
                stream = File.OpenRead(filename);
                result = (T)serialiser.Deserialize(stream);
            }
            catch (DirectoryNotFoundException ex)
            {
                XmlException exception =
                    new XmlException(
                        $"XML Serialisation: Directory not found: {ex}",
                        ex);
                throw exception;
            }
            catch (FileNotFoundException ex)
            {
                XmlException exception =
                    new XmlException(
                        $"XML Serialisation: Directory not found: {ex}",
                        ex);
                throw exception;
            }
            catch (Exception ex)
            {
                XmlException exception =
                    new XmlException(
                        $"XML Serialisation: Generic Exception: {ex}",
                        ex);
                throw exception;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// Serialise a class to a file.
        /// </summary>
        /// <typeparam name="T">Root class</typeparam>
        /// <param name="root">object to serialise</param>
        /// <param name="filename"></param>
        public static void WriteXml<T>(
          T root,
          string filename)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(T));

            using (Stream stream = File.Create(filename))
            {
                serialiser.Serialize(
                  stream,
                  root);
            }
        }
    }
}
