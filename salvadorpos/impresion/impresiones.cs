using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using salvadorpos.Modelo;
using salvadorpos.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.impresion
{
    class impresiones
    {
       
     
        Spire.Pdf.PdfDocument documentoparaimprimir = new Spire.Pdf.PdfDocument();

       
        string path = "";

        public void crearhtml(objetoimpresion obi)
        {
            try
            {
                File.WriteAllText("mihtml.html", "\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n</head>\r\n<style>\r\n    body{\r\n        background-color: #f6e58d;\r\n        \r\n    }\r\n.img1{\r\n    display: inline-block;\r\n    width: 250px;\r\n        height: 90px;\r\n}\r\n    .ele1 {\r\n        display: inline-block;\r\n        background-color: #f6e58d;\r\n        font-size: 13px;\r\n        width: 260px;\r\n        height: 90px;\r\n        text-align: center;\r\n        align-items: center;\r\n       padding:3px;\r\n    }\r\n\r\n    .ele11 {\r\n        margin-left: 35px;\r\n        display: inline-block;\r\n        background-color: #f6e58d;\r\n        font-size: 10px;\r\n        width: 250px;\r\n        text-align: center;\r\n        border: red 2px solid;\r\n        height: 90px;\r\n        padding: 3px;\r\n        border-radius: 12px;\r\n    }\r\n    .tabla2{\r\n        border: black 2px solid;\r\n        border-radius: 10px;\r\n    }\r\n    .segundafila{\r\n        font-size: 13px;\r\n        margin-right: 85px;\r\n    }\r\n    .segundafilatd1{\r\n        border-left:black 1px solid;\r\n    }\r\n    .tdtercerafila{\r\n        background-color: #dfe4ea;\r\n        border-right: black 1px solid;\r\n        border-bottom: black 1px solid;\r\n        border-left: black 1px solid;\r\n        \r\n    }\r\n    .tercerafila{\r\n        \r\n        font-size: 15px;\r\n        margin-right: 66px;\r\n        \r\n    }\r\n    .datos{\r\n        border-right: black 1px solid;\r\n        height: 35px;\r\n        width: 156px;\r\n        border-left: black 1px solid;\r\n    }\r\n    .cuartafila{\r\n        border-top: black 1px solid;\r\n        border-bottom: black 1px solid;\r\n        height: 17px;\r\n        width: 266px;\r\n    }\r\n    .trcuartafila{\r\n        border-left: black 1px solid;\r\n        \r\n    }\r\n    .trcuartafila2{\r\n        border-right: black 1px solid;\r\n        font-size: 8px;\r\n        \r\n    }\r\n    .ultima{\r\n        \r\n        \r\n        font-size: 10px;\r\n        height: 35px;\r\n        width: 156px;\r\n       \r\n    }\r\n    .unborde{\r\n        border-right: black 1px solid;\r\n    }\r\n   \r\n    .tablaultima{\r\n        border-bottom: black 2px solid;\r\n        border-radius: 10px;\r\n        border-right: black 2px solid;\r\n        border-left: black 2px solid;\r\n    }\r\n    .derecha{\r\n        text-align: left;\r\n        font-size: 8px;\r\n    }\r\n    .soloabajo{\r\n        border-bottom: black 1px solid;\r\n    }\r\n   \r\n</style>\r\n<body>\r\n\r\n    <table>\r\n        <tr>\r\n            <td>\r\n                    <img class=\"img1\" src=\"C:\\Users\\ITCO\\Pictures\\logo.png\" />\r\n            </td>\r\n            <td>\r\n                    <div class=\"ele1\">\r\n\r\n                            Prolongación Alameda Juan Pablo II,No.349,<br>\r\n                            Frente al Complejo Industrial San Jorge,S.S.<br>\r\n                            www.coopergroupint.com<br>\r\n                            Venta al por mayor de otro tipo de maquinaria y<br>\r\n                            equipo con sus accesorios y partes.\r\n                        </div>\r\n                </td>\r\n                <td>\r\n                        <div class=\"ele11\">\r\n                                FACTURA DE EXPORTACION<BR>\r\n                                <p class=\"derecha\"><BR>No. Numero<br></p>\r\n                                    <p class=\"derecha\"> <br>NIT: </p>\r\n                                        <p class=\"derecha\">  NCR:</p>\r\n                                        </div>\r\n                    </td>\r\n\r\n        </tr>\r\n\r\n    </table>\r\n    <table class=\"tabla2\">\r\n<tr>\r\n       <td>\r\n            <div class=\"segundafila\">CLIENTE: " + obi.Cliente + "</div>\r\n            <div class=\"segundafila\">DIRECCION: " + obi.Direccion + "</div>\r\n            <div class=\"segundafila\"><BR></div>\r\n            <div class=\"segundafila\">NIT:" + obi.Nit + "</div>\r\n            <div class=\"segundafila\"><br></div>\r\n       </td>\r\n       <td>\r\n          <div class=\"segundafila\">GIRO: aqui el giro</div>\r\n          <div class=\"segundafila\"><br></div>\r\n          <div class=\"segundafila\"><br></div>\r\n          <div class=\"segundafila\"><br></div>\r\n          <div class=\"segundafila\">NCR: aqui el ncr</div>\r\n       </td>\r\n       <td class=\"segundafilatd1\">\r\n            <div class=\"segundafila\">FECHA: aqui la fecha</div>\r\n            <div class=\"segundafila\">ORDEN No: aqui el no</div>\r\n            <div class=\"segundafila\">VENDEDOR: aqui el vendedor</div>\r\n            <div class=\"segundafila\">VENTA A CLIENTE DE:</div>\r\n            <div class=\"segundafila\">CONDICIONES DE PAGO: aqui la condicion de pago</div>\r\n       </td>\r\n</tr>\r\n    </table>\r\n\r\n    <table>\r\n            <tr>\r\n                    <td class=\"datos soloabajo\">CANT.</td>\r\n                    <td class=\"datos soloabajo\">CODIGO</td>\r\n                    <td class=\"datos soloabajo\">DESCRIPCION</td>\r\n                    <td class=\"datos soloabajo\">PRECIO UNITARIO</td>\r\n                    <td class=\"datos soloabajo\">VENTAS TOTALES</td>\r\n            </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n        <tr>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n                <td class=\"datos\"></td>\r\n        </tr>\r\n       \r\n    </table>\r\n    <table>\r\n        <tr >\r\n                <td class=\"cuartafila trcuartafila\"></td>\r\n                <td class=\"cuartafila\"></td>\r\n                <td class=\"cuartafila trcuartafila2\">SUBTOTAL:</td>\r\n               \r\n                \r\n\r\n        </tr>\r\n       \r\n    </table>\r\n    <table class=\"tablaultima\">\r\n            <tr >\r\n                    <td class=\"ultima primera unborde\">NOS RESERVAMOS DEL DERECHODE ACEPTAR CAMBIOS Y/O<br>\r\n                    DEVOLUCIONES DESPUES DE ENTREGADA A CONFORMIDAD LA MERCADERIA.<BR>\r\n                        LA GARANTIA EN EQUIPO ES APLICADA UNICAMENTE EN LA PARTE DAÑADA.\r\n                    </td>\r\n                    <td class=\"ultima unborde\">\r\n                        ENTREGADO POR:<BR>\r\n                            DUI/NIT:<BR><br>\r\n                                f:\r\n\r\n                    </td>\r\n                    <td class=\"ultima unborde\">\r\n                            ENTREGADO POR:<BR>\r\n                                DUI/NIT:<BR><br>\r\n                                    f:\r\n\r\n                    </td>\r\n                    <td class=\"ultima unborde\">\r\n                        <strong>VENTA TOTAL:</strong>\r\n                    </td>\r\n                    <td class=\"ultima ult\"></td>\r\n    \r\n            </tr>\r\n           \r\n        </table>\r\n  \r\n\r\n</body>\r\n</html>");
            }
            catch (Exception i)
            {
                mensajes.err(i);

            }
           
        }
         
        public void convertirhtmlapdf()
        {
            try
            {
                path = AppDomain.CurrentDomain.BaseDirectory + "wkl/wkhtmltopdf.exe";
                ProcessStartInfo onprocess = new ProcessStartInfo();
                onprocess.UseShellExecute = false;
                onprocess.FileName = path;
                onprocess.Arguments = "mihtml.html mipdf.pdf";

                using (Process mipro = Process.Start(onprocess))
                {
                    mipro.WaitForExit();

                }
            }
            catch (Exception  n)
            {
                mensajes.err(n);
            }
           
        }

        public void imprimirpdf(string fullDestinyFilePath)
        {
            try
            {
                documentoparaimprimir.LoadFromFile(fullDestinyFilePath);    
              
                documentoparaimprimir.PrintDocument.Print();
                documentoparaimprimir.Close();
            }
            catch (Exception t)
            {

                mensajes.err(t);
            }
        }


       





    }
}
