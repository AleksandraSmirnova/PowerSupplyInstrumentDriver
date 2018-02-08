using System;

namespace PowerSupplyInstrumentDriver
{
    public class Sample
    {
        static void Main(string[] args)
        {
            Sample1();
            Sample2();
            Sample3();
        }

        public static void Sample1()
        {
            var voltage = 20;
            IPowerSupply powerSupply = PowerSupplyFactory.BKPrecision9132BComPort();      //Connect BK Precision 9132B to COM port
            powerSupply.EnableOutputs();                                                 //Enable outputs
            powerSupply.SetVoltage(voltage);                                             //Set voltage
            string actualVoltage = powerSupply.ReadActualVoltage();                      //Read voltage
            if ((actualVoltage != "") && (voltage == Convert.ToInt32(actualVoltage)))    //Compare voltages
                Console.WriteLine("Power Supply BKPrecision 9132B over Com port works correctly.");
            else
                Console.WriteLine("The set and actual voltage is not equal.");
            powerSupply.Disconnect();                                                    //Disconect from COM port
        }

        public static void Sample2()
        {
            var current = 1;
            IPowerSupply powerSupply = PowerSupplyFactory.BKPrecision9206ComPort();      //Connect BK Precision 9206 to COM port
            powerSupply.EnableOutputs();                                                //Enable outputs
            powerSupply.SetCurrentOutput(current);                                      //Set Current
            string actualCurrent = powerSupply.ReadCurrentValue();                      //Read Current
            if ((actualCurrent != "") && (current == Convert.ToInt32(actualCurrent)))   //Compare currents
                Console.WriteLine("Power Supply BKPrecision 9206 over Com port works correctly.");
            else
                Console.WriteLine("The set and actual current is not equal.");
            powerSupply.Disconnect();                                                   //Disconect from COM port
        }

        public static void Sample3()
        {
            IPowerSupply powerSupply = PowerSupplyFactory.BKPrecisionComPort();        //Connect some other power supply (e.g. a Sorensen XG 1500) to COM port
            powerSupply.DisableOutputs();                                             //Disable outputs
            string actualVoltage = powerSupply.ReadActualVoltage();                   //Read voltage
            if (actualVoltage == "")                                                  //it is expected that it is impossible to read the voltage
                Console.WriteLine("Power Supply over Com port works correctly.");
            else
                Console.WriteLine("After disabling it's possible read out the outputs.");
            powerSupply.Disconnect();                                                  //Disconect from COM port
        }

       
    }
}
