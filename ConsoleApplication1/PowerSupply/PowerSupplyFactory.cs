
using System.IO.Ports;

namespace PowerSupplyInstrumentDriver
{
    public static class PowerSupplyFactory
    {

        public static PowerSupply BKPrecision9132BComPort(string portName = "COM1", int portBaudRate = 9600, Parity portParity = Parity.None,
                                 int portDataBits = 8, StopBits portStopBits = StopBits.One, Handshake portHandshake = Handshake.None,
                                 int readTimeout = 500, int writeTimeout = 500)
        {
            return CreatePowerSupply(new BkPrecision9132BProtocol(), portName, portBaudRate, portParity, portDataBits,
                                     portStopBits, portHandshake, readTimeout, writeTimeout);
        }

        public static PowerSupply BKPrecision9132BUSB()
        {
            return new PowerSupply(new USB(), new BkPrecision9132BProtocol());
        }

        public static PowerSupply BKPrecision9132BGPIB()
        {
            return new PowerSupply(new GPIB(), new BkPrecision9132BProtocol());
        }
        
        public static PowerSupply BKPrecision9206ComPort(string portName = "COM1", int portBaudRate = 9600, Parity portParity = Parity.None,
                                 int portDataBits = 8, StopBits portStopBits = StopBits.One, Handshake portHandshake = Handshake.None,
                                 int readTimeout = 500, int writeTimeout = 500)
        {
            return CreatePowerSupply(new BkPrecision9206Protocol(), portName, portBaudRate, portParity, portDataBits,
                                     portStopBits, portHandshake, readTimeout, writeTimeout);
        }

        public static PowerSupply BKPrecision9206USB()
        {
            return new PowerSupply(new USB(), new BkPrecision9206Protocol());
        }

        public static PowerSupply BKPrecision9206GPIB()
        {
            return new PowerSupply(new GPIB(), new BkPrecision9206Protocol());
        }
        public static PowerSupply BKPrecisionComPort(string portName = "COM1", int portBaudRate = 9600, Parity portParity = Parity.None,
                                 int portDataBits = 8, StopBits portStopBits = StopBits.One, Handshake portHandshake = Handshake.None,
                                 int readTimeout = 500, int writeTimeout = 500)
        {
            return CreatePowerSupply(new BkPrecisionProtocol(), portName, portBaudRate, portParity, portDataBits,
                                     portStopBits, portHandshake, readTimeout, writeTimeout);
        }

        public static PowerSupply BKPrecisionUSB()
        {
            return new PowerSupply(new USB(), new BkPrecisionProtocol());
        }

        public static PowerSupply BKPrecisionGPIB()
        {
            return new PowerSupply(new GPIB(), new BkPrecisionProtocol());
        }

        private static PowerSupply CreatePowerSupply(IProtocol protocol, string portName, int portBaudRate, 
                                                     Parity portParity, int portDataBits, StopBits portStopBits, 
                                                     Handshake portHandshake, int readTimeout, int writeTimeout)
        {
            var comPort = new ComPort();
            comPort.PortName = portName;
            comPort.PortBaudRate = portBaudRate;
            comPort.PortParity = portParity;
            comPort.PortDataBits = portDataBits;
            comPort.PortStopBits = portStopBits;
            comPort.PortHandshake = portHandshake;
            comPort.ReadTimeout = readTimeout;
            comPort.Writeimeout = writeTimeout;
            comPort.StartListening();
            return new PowerSupply(comPort, protocol);
        }        
    }
}
