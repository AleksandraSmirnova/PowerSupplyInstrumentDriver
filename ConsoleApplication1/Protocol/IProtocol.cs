namespace PowerSupplyInstrumentDriver
{
    public interface IProtocol
    {
        object SetVoltage(int value);
        object SetCurrentOutput(int value);
        object EnableOutputs();
        object DisableOutputs();
        object ReadActualVoltage();
        object ReadCurrentValue();
        object IDNCommand();
    }
}
