using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.QBFC13;
using salvadorpos.Modelo;
namespace salvadorpos.Modelo
{
    public class Quickbooks : IDisposable
    {

        public IMsgSetRequest request;
        public bool sesion = false;
        public bool conexion = false;
        public QBSessionManager sesionmanager = null;

        public void conectar()
        {

            try
            {

                sesionmanager = new QBSessionManager();
                request = sesionmanager.CreateMsgSetRequest("US", 13, 0);
                request.Attributes.OnError = ENRqOnError.roeContinue;

                sesionmanager.OpenConnection2("pos", "salvador", ENConnectionType.ctLocalQBD);
                conexion = true;

                sesionmanager.BeginSession("", ENOpenMode.omDontCare);
                sesion = true;
            }
            catch (Exception er)
            {

                mensajes.err(er);
            }
        }

        public void Dispose()
        {
            try
            {
                sesionmanager.EndSession();
                sesion = false;
                sesionmanager.CloseConnection();
                conexion = false;

            }
            catch (Exception err)
            {
                mensajes.err(err);

            }
        }
    }
}
