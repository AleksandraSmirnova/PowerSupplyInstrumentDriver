using System;
using System.IO.Ports;

namespace PowerSupplyInstrumentDriver
{
    public class ComPort : ICommunication
    {
        static SerialPort _serialPort;
        static bool isComPortOpen = false;

        public ComPort()
        {
            _serialPort = new SerialPort();
        }

        public void StartListening()
        {
            try
            {
                _serialPort.Open();
                isComPortOpen = true;
            }
            catch (Exception ex) { }
        }

        public string ReceiveData(object command)
        {
            SendCommand(command);
            return (isComPortOpen) ? _serialPort.ReadLine() : "";           
        }

        public void SendCommand(object command)
        {
            if(isComPortOpen)
              _serialPort.Write((string)command);
        }

        public void StopListening()
        {
            _serialPort.Close();
        }

        private string _portName;
        private int _portBaudRate;
        private Parity _portParity;
        private int _portDataBits;
        private StopBits _portStopBits;
        private Handshake _portHandshake;
        private int _readTimeout;
        private int _writeTimeout;

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public int PortBaudRate
        {
            get { return _portBaudRate; }
            set { _portBaudRate = value; }
        }

        public Parity PortParity
        {
            get { return _portParity; }
            set { _portParity = value; }
        }

        public int PortDataBits
        {
            get { return _portDataBits; }
            set { _portDataBits = value; }
        }

        public StopBits PortStopBits
        {
            get { return _portStopBits; }
            set { _portStopBits = value; }
        }

        public Handshake PortHandshake
        {
            get { return _portHandshake; }
            set { _portHandshake = value; }
        }

        public int ReadTimeout
        {
            get { return _readTimeout; }
            set { _readTimeout = value; }
        }

        public int Writeimeout
        {
            get { return _writeTimeout; }
            set { _writeTimeout = value; }
        }

    }
}
