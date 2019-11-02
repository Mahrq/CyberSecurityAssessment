using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ServerClass;

namespace AttackSecuritySimulator_Models
{
    /// <summary>
    /// Author:         Mark Mendoza
    /// Based On:       ClientApp.cs by Peter Maxwell
    /// 
    /// Description:    Creates a client object to connect to a server hosted by the defined IP address.
    /// Default IP:     172.30.91.65
    /// </summary>
    public class GameClient
    {
        private TcpChannel currentTcpChannel;
        private myRemoteClass targetServer;
        private bool connectedToServer = false;
        public bool ConnectedToServer { get { return connectedToServer; } }

        //Contructor
        public GameClient(string ipAddress = "172.30.91.65")
        {
            //Create tcp channel
            currentTcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(currentTcpChannel, false);
            //Successful connection to the server sets the bool to true and initialises the myRemoteClass object.
            connectedToServer = GetServerAddress(ipAddress, out targetServer);
        }

        public bool GetServerAddress(string ipAddress, out myRemoteClass remoteServerHost)
        {
            string fullServerName = $"tcp://{ipAddress}:8085/RemoteTest";

            try
            {
                remoteServerHost = (myRemoteClass)Activator.GetObject(typeof(myRemoteClass), fullServerName);
                return remoteServerHost.ConnectedToServer();
            }
            catch (Exception)
            {
                remoteServerHost = null;
                return false;
            }
        }

        public void SendTextFileToServer(string fileContents, string fileName, bool overwriteFileData = true)
        {
            VerifyConnection(connectedToServer);
            if (connectedToServer)
            {
                targetServer.SaveStringToTextFile(fileContents, fileName, overwriteFileData);
            }
        }

        [Conditional("DEBUG")]
        private void VerifyConnection(bool connectionStatus)
        {
            if (connectionStatus == false)
            {
                throw new Exception("The connection to the server was lost");
            }
        }
    }
}
