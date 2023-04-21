using Bonsai.Harp;
using System.Threading.Tasks;

namespace Harp.VestibularH1
{
    /// <inheritdoc/>
    public partial class Device
    {
        /// <summary>
        /// Initializes a new instance of the asynchronous API to configure and interface
        /// with VestibularH1 devices on the specified serial port.
        /// </summary>
        /// <param name="portName">
        /// The name of the serial port used to communicate with the Harp device.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous initialization operation. The value of
        /// the <see cref="Task{TResult}.Result"/> parameter contains a new instance of
        /// the <see cref="AsyncDevice"/> class.
        /// </returns>
        public static async Task<AsyncDevice> CreateAsync(string portName)
        {
            var device = new AsyncDevice(portName);
            var whoAmI = await device.ReadWhoAmIAsync();
            if (whoAmI != Device.WhoAmI)
            {
                var errorMessage = string.Format(
                    "The device ID {1} on {0} was unexpected. Check whether a VestibularH1 device is connected to the specified serial port.",
                    portName, whoAmI);
                throw new HarpException(errorMessage);
            }

            return device;
        }
    }

    /// <summary>
    /// Represents an asynchronous API to configure and interface with VestibularH1 devices.
    /// </summary>
    public partial class AsyncDevice : Bonsai.Harp.AsyncDevice
    {
        internal AsyncDevice(string portName)
            : base(portName)
        {
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam0Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<bool> ReadCam0EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam0Event.Address));
            return Cam0Event.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam0Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<bool>> ReadTimestampedCam0EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam0Event.Address));
            return Cam0Event.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam1Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<bool> ReadCam1EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam1Event.Address));
            return Cam1Event.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam1Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<bool>> ReadTimestampedCam1EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam1Event.Address));
            return Cam1Event.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam0TriggerFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadCam0TriggerFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam0TriggerFrequency.Address));
            return Cam0TriggerFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam0TriggerFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedCam0TriggerFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam0TriggerFrequency.Address));
            return Cam0TriggerFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Cam0TriggerFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteCam0TriggerFrequencyAsync(ushort value)
        {
            var request = Cam0TriggerFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam0TriggerDuration register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadCam0TriggerDurationAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam0TriggerDuration.Address));
            return Cam0TriggerDuration.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam0TriggerDuration register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedCam0TriggerDurationAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam0TriggerDuration.Address));
            return Cam0TriggerDuration.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Cam0TriggerDuration register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteCam0TriggerDurationAsync(ushort value)
        {
            var request = Cam0TriggerDuration.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam1TriggerFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadCam1TriggerFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam1TriggerFrequency.Address));
            return Cam1TriggerFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam1TriggerFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedCam1TriggerFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam1TriggerFrequency.Address));
            return Cam1TriggerFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Cam1TriggerFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteCam1TriggerFrequencyAsync(ushort value)
        {
            var request = Cam1TriggerFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam1TriggerDuration register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadCam1TriggerDurationAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam1TriggerDuration.Address));
            return Cam1TriggerDuration.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam1TriggerDuration register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedCam1TriggerDurationAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Cam1TriggerDuration.Address));
            return Cam1TriggerDuration.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Cam1TriggerDuration register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteCam1TriggerDurationAsync(ushort value)
        {
            var request = Cam1TriggerDuration.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StartAndStop register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<StartStopFlags> ReadStartAndStopAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartAndStop.Address));
            return StartAndStop.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StartAndStop register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<StartStopFlags>> ReadTimestampedStartAndStopAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartAndStop.Address));
            return StartAndStop.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StartAndStop register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStartAndStopAsync(StartStopFlags value)
        {
            var request = StartAndStop.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the InState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PortState> ReadInStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(InState.Address));
            return InState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the InState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PortState>> ReadTimestampedInStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(InState.Address));
            return InState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Valve0Pulse register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadValve0PulseAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Valve0Pulse.Address));
            return Valve0Pulse.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Valve0Pulse register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedValve0PulseAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Valve0Pulse.Address));
            return Valve0Pulse.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Valve0Pulse register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteValve0PulseAsync(byte value)
        {
            var request = Valve0Pulse.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Valve1Pulse register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadValve1PulseAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Valve1Pulse.Address));
            return Valve1Pulse.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Valve1Pulse register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedValve1PulseAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Valve1Pulse.Address));
            return Valve1Pulse.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Valve1Pulse register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteValve1PulseAsync(byte value)
        {
            var request = Valve1Pulse.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutSet register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutSetAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutSet.Address));
            return OutSet.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutSet register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutSetAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutSet.Address));
            return OutSet.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutSet register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutSetAsync(byte value)
        {
            var request = OutSet.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutClear register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutClearAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutClear.Address));
            return OutClear.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutClear register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutClearAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutClear.Address));
            return OutClear.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutClear register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutClearAsync(byte value)
        {
            var request = OutClear.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutToggle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutToggleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutToggle.Address));
            return OutToggle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutToggle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutToggleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutToggle.Address));
            return OutToggle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutToggle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutToggleAsync(byte value)
        {
            var request = OutToggle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutWrite register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<DO> ReadOutWriteAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutWrite.Address));
            return OutWrite.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutWrite register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<DO>> ReadTimestampedOutWriteAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutWrite.Address));
            return OutWrite.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutWrite register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutWriteAsync(DO value)
        {
            var request = OutWrite.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OpticalTrackingRead register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<short[]> ReadOpticalTrackingReadAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt16(OpticalTrackingRead.Address));
            return OpticalTrackingRead.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OpticalTrackingRead register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<short[]>> ReadTimestampedOpticalTrackingReadAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt16(OpticalTrackingRead.Address));
            return OpticalTrackingRead.GetTimestampedPayload(reply);
        }
    }
}
