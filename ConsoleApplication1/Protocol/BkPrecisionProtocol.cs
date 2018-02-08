using System;

namespace PowerSupplyInstrumentDriver
{
    public class BkPrecisionProtocol : IProtocol
    {
        public object DisableOutputs()
        {
            return "OUTP OFF\n";
        }

        public object EnableOutputs()
        {
            return "OUTP ON\n";
        }
             
        public object ReadActualVoltage()
        {
            return "MEAS:VOLT?\n";
        }

        public object ReadCurrentValue()
        {
            return "MEAS:CURR?\n";
        }

        public object SetCurrentOutput(int value)
        {
            return "CURR " + value + "\n";
        }

        public object SetVoltage(int value)
        {
            return "VOLT " + value + "\n"; 
        }

        public object IDNCommand()
        {
            throw new NotImplementedException();
        }
    }
}
