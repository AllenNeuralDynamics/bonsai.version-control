﻿using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Bonsai;

namespace AllenNeuralDynamics.Zaber
{
    /// <summary>
    /// Represents an operator that instructs a <see cref="ZaberDevice"/> to stop any movement on a selected axis.
    /// </summary>
    [Description("Stops an axis of a Zaber manipulator.")]
    public class StopAxis : Sink
    {
        /// <summary>
        /// Gets or sets the COM port or alias of the target <see cref="ZaberDevice"/>
        /// </summary>
        [TypeConverter(typeof(PortNameConverter))]
        [Description("The name of the serial port used to communicate with the manipulator.")]
        public string PortName { get; set; }

        /// <summary>
        /// Gets or sets the axis of the manipulator to be controlled.
        /// </summary>
        [Description("The index of the axis of the manipulator to be controlled.")]
        public int Axis { get; set; }

        /// <summary>
        /// Halts the movement of a specified axis when a value is received.
        /// </summary>
        /// <returns>
        /// Returns the original input sequence.
        /// </returns>
        public override IObservable<TSource> Process<TSource>(IObservable<TSource> source)
        {
            return Observable.Using(
                cancellationToken => ZaberDeviceManager.ReserveConnectionAsync(PortName),
                (connection, cancellationToken) =>
                {
                    var axis = Axis;
                    return Task.FromResult(source.Do(_ =>
                    {
                        lock (connection.Device)
                        {
                            connection.Device.StopAxis(axis);
                        }
                    }));
                });
        }
    }
}
