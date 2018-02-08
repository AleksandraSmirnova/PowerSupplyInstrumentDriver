
using System;

namespace PowerSupplyInstrumentDriver
{
    public class PowerSupply : IPowerSupply
    {
        ICommunication _communicator;
        IProtocol _protocol;

        public PowerSupply(ICommunication communicator, IProtocol protocol)
        {
            _communicator = communicator;
            _protocol = protocol;
        }
        public void Connect()
        {
            _communicator.StartListening();
        }

        public void Disconnect()
        {
            _communicator.StopListening();
        }

        public void DisableOutputs()
        {
            _communicator.SendCommand(_protocol.DisableOutputs());
        }

        public void EnableOutputs()
        {
            _communicator.SendCommand(_protocol.EnableOutputs());
        }


        public string ReadActualVoltage()
        {
            return _communicator.ReceiveData(_protocol.ReadActualVoltage());
        }

        public string ReadCurrentValue()
        {
            return _communicator.ReceiveData(_protocol.ReadCurrentValue());
        }

        public void SetCurrentOutput(int value)
        {
            _communicator.SendCommand(_protocol.SetCurrentOutput(value));
        }

        public void SetVoltage(int value)
        {
            _communicator.SendCommand(_protocol.SetVoltage(value));
        }

        public string IDNCommand()
        {
            throw new NotImplementedException();
        }
    }
}
