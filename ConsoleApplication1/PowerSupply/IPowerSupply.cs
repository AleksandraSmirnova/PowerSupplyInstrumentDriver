
namespace PowerSupplyInstrumentDriver
{
    public interface IPowerSupply
    {
        void Connect();
        void Disconnect();
        void SetVoltage(int value);
        void SetCurrentOutput(int value);
        void EnableOutputs();
        void DisableOutputs();
        string ReadActualVoltage();
        string ReadCurrentValue();
        string IDNCommand();
    }
}
