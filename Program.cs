using System;
using System.IO;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o processamento...");

            //var logPath = System.IO.Path.GetTempFileName();
            System.IO.FileStream fileStream = new System.IO.FileStream("file.xml", FileMode.Create);
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            XmlWriter objWriter = XmlWriter.Create(fileStream, settings);

            //quantidades aleatorias
            Random rand = new Random();

            // qtde de CNPJ's
            int qtdeCNPJs = rand.Next(100);




            objWriter.WriteStartDocument();

            objWriter.WriteStartElement("ASCG021");

            ////////Start Grupo_ASCG021_Agend Element///////

            objWriter.WriteStartElement("Grupo_ASCG021_Agend");

            objWriter.WriteStartAttribute("CNPJBaseCreddr");
            objWriter.WriteValue("012345678");
            objWriter.WriteEndAttribute();

            objWriter.WriteStartAttribute("CNPJCreddr");
            objWriter.WriteValue("012345678000123");
            objWriter.WriteEndAttribute();
            objWriter.WriteStartAttribute("ISPBIFCredr");
            objWriter.WriteValue("06259845");
            objWriter.WriteEndAttribute();
            objWriter.WriteStartAttribute("AgCreddr");
            objWriter.WriteValue("0933");
            objWriter.WriteEndAttribute();
            objWriter.WriteStartAttribute("CtCreddr");
            objWriter.WriteValue("00568");
            objWriter.WriteEndAttribute();
            objWriter.WriteStartAttribute("NomCreddr");
            objWriter.WriteValue("LeandroNet");
            objWriter.WriteEndAttribute();


            int contadorMaximoRegistros = 1;
            int maximoRegistros = 5000000;
            int maximoQtdePV = 300;
            int maximoDiasVencimento = 365;
            int maximoRandomDiasVencimento = 366;
            int maxQtdeCentralizadoras = rand.Next(1, 500);

            for (int contadorCentralizadoras = 0; contadorCentralizadoras < maxQtdeCentralizadoras && contadorMaximoRegistros < maximoRegistros; contadorCentralizadoras++)
            {



                ////////Start Grupo_ASCG021_Agend Element///////
                objWriter.WriteStartElement("Grupo_ASCG021_Agend");



                objWriter.WriteStartAttribute("TpPessoaCentrlz");
                objWriter.WriteValue("J");
                objWriter.WriteEndAttribute();
                objWriter.WriteStartAttribute("CNPJ_CPFCentrl");
                objWriter.WriteValue("47851236");
                objWriter.WriteEndAttribute();
                objWriter.WriteStartAttribute("CodCentrlz");
                objWriter.WriteValue("1234567890123456789012345");
                objWriter.WriteEndAttribute();
                objWriter.WriteStartAttribute("AgCentrlz");
                objWriter.WriteValue("0933");
                objWriter.WriteEndAttribute();

                ////////Start Grupo_ASCG021_PontoVenda Element///////

                int maxQtdePV = rand.Next(1, maximoQtdePV);

                for (int contadorPV = 0; contadorPV < maxQtdePV && contadorMaximoRegistros < maximoRegistros; contadorPV++)
                {
                    double codPontoVenda1 = rand.Next(1, 999999999);
                    double codPontoVenda2 = rand.Next(1, 999999999);
                    double codPontoVenda3 = rand.Next(1, 999999999);
                    
                    DateTime startDate = DateTime.Today;
                    for (int diasVcto = rand.Next(1, maximoDiasVencimento); diasVcto < maximoDiasVencimento &  contadorMaximoRegistros < maximoRegistros; diasVcto = rand.Next(diasVcto, maximoRandomDiasVencimento))
                    {

                        objWriter.WriteStartElement("Grupo_ASCG021_PontoVenda");
                        objWriter.WriteStartAttribute("CodInstitdrArrajPgto");
                        objWriter.WriteValue("003");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartAttribute("CodMoeda");
                        objWriter.WriteValue("001");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartAttribute("CodPontoVenda");
                        objWriter.WriteValue(codPontoVenda1.ToString() + codPontoVenda2.ToString() + codPontoVenda3.ToString());
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartAttribute("CNPJ_CPFPontoVenda");
                        objWriter.WriteValue(rand.Next(1000000, 99999999).ToString());
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartAttribute("DtPrevtPgto");
                        objWriter.WriteValue(startDate.AddDays(diasVcto).ToShortDateString());
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartAttribute("VlrLiqdPgtoPrevt");
                        objWriter.WriteValue(rand.Next(10, 999999999));
                        objWriter.WriteEndAttribute();
                        objWriter.WriteEndElement(); //</Grupo_ASCG021_PontoVenda

                       
                        contadorMaximoRegistros++;
                    }
                }

               

                objWriter.WriteEndElement(); //</Grupo_ASCG021_Centrlz
            }
            objWriter.WriteEndElement(); //</Grupo_ASCG021_Agend
            objWriter.WriteEndElement(); //</ASCG021


            
            objWriter.WriteEndDocument();

            objWriter.Flush();
            fileStream.Flush();
        }
    }
}
