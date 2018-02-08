namespace PowerSupplyInstrumentDriver
{
    public interface ICommunication
    {
        void StartListening();
        void StopListening();
        void SendCommand(object command);
        string ReceiveData(object command);
    }
}
