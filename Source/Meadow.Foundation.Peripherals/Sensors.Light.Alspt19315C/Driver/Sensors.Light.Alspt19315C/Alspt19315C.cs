﻿using System.Threading.Tasks;
using Meadow.Hardware;

namespace Meadow.Foundation.Sensors.Light
{
    //TODO: this class needs the StartUpdating/StopUpdating/IOBservable pattern
    public class Alspt19315C
    {
        /// <summary>
        ///     Analog port connected to the sensor.
        /// </summary>
        private readonly IAnalogInputPort sensor;

        /// <summary>
        ///     Voltage being output by the sensor.
        /// </summary>
        public Task<float> GetVoltage()
        {
            return sensor.Read();
        }

        /// <summary>
        ///     Create a new light sensor object using a static reference voltage.
        /// </summary>
        /// <param name="pin">AnalogChannel connected to the sensor.</param>
        public Alspt19315C(IAnalogInputController device, IPin pin)
        {
            sensor = device.CreateAnalogInputPort(pin);
        }
    }
}