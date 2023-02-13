using Bonsai;
using Bonsai.Harp;
using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Harp.VestibularH1
{
    /// <summary>
    /// Represents an observable source of messages from the VestibularH1 device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the VestibularH1 device.")]
    public partial class VestibularH1Device
    {
        readonly Device device = new Device(whoAmI: 1224);

        /// <summary>
        /// Gets or sets the name of the serial port used to communicate with the
        /// VestibularH1 device.
        /// </summary>
        [TypeConverter(typeof(PortNameConverter))]
        [Description("The name of the serial port used to communicate with the VestibularH1 device.")]
        public string PortName
        {
            get { return device.PortName; }
            set { device.PortName = value; }
        }

        /// <summary>
        /// Connects to the specified serial port and returns an observable sequence of Harp messages
        /// coming from the device.
        /// </summary>
        /// <returns>The observable sequence of Harp messages produced by the device.</returns>
        public IObservable<HarpMessage> Generate()
        {
            return device.Generate();
        }

        /// <summary>
        /// Connects to the specified serial port and sends the observable sequence of Harp messages.
        /// The return value is an observable sequence of Harp messages coming from the device.
        /// </summary>
        /// <param name="source">An observable sequence of Harp messages to send to the device.</param>
        /// <returns>The observable sequence of Harp messages produced by the device.</returns>
        public IObservable<HarpMessage> Generate(IObservable<HarpMessage> source)
        {
            return device.Generate(source);
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific event messages
    /// reported by the Harp device.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="InState"/>
    /// <seealso cref="OpticalTrackingRead"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(InState))]
    [XmlInclude(typeof(OpticalTrackingRead))]
    public partial class VestibularH1Event : EventBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VestibularH1Event"/> class.
        /// </summary>
        public VestibularH1Event()
        {
            Event = new Cam0Event();
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects a sequence of event messages
    /// that signals when a frame was triggered on camera 0.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Filters and selects a sequence of event messages that signals when a frame was triggered on camera 0.")]
    public partial class Cam0Event : Combinator<HarpMessage, bool>
    {
        /// <summary>
        /// Filters and selects an observable sequence of event messages
        /// that signals when a frame was triggered on camera 0.
        /// </summary>
        /// <param name="source">The sequence of Harp event messages.</param>
        /// <returns>
        /// A sequence of <see cref="bool"/> objects representing the
        /// register payload.
        /// </returns>
        public override IObservable<bool> Process(IObservable<HarpMessage> source)
        {
            return source.Event(address: 32).Select(input => input.GetPayloadByte() != 0);
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects a sequence of event messages
    /// that signals when a frame was triggered on camera 1.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Filters and selects a sequence of event messages that signals when a frame was triggered on camera 1.")]
    public partial class Cam1Event : Combinator<HarpMessage, bool>
    {
        /// <summary>
        /// Filters and selects an observable sequence of event messages
        /// that signals when a frame was triggered on camera 1.
        /// </summary>
        /// <param name="source">The sequence of Harp event messages.</param>
        /// <returns>
        /// A sequence of <see cref="bool"/> objects representing the
        /// register payload.
        /// </returns>
        public override IObservable<bool> Process(IObservable<HarpMessage> source)
        {
            return source.Event(address: 33).Select(input => input.GetPayloadByte() != 0);
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects a sequence of event messages
    /// that contains the state of the lick ports.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Filters and selects a sequence of event messages that contains the state of the lick ports.")]
    public partial class InState : Combinator<HarpMessage, PortState>
    {
        /// <summary>
        /// Filters and selects an observable sequence of event messages
        /// that contains the state of the lick ports.
        /// </summary>
        /// <param name="source">The sequence of Harp event messages.</param>
        /// <returns>
        /// A sequence of <see cref="PortState"/> objects representing the
        /// register payload.
        /// </returns>
        public override IObservable<PortState> Process(IObservable<HarpMessage> source)
        {
            return source.Event(address: 39).Select(input => (PortState)input.GetPayloadByte());
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects a sequence of event messages
    /// from register OpticalTrackingRead.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Filters and selects a sequence of event messages from register OpticalTrackingRead.")]
    public partial class OpticalTrackingRead : Combinator<HarpMessage, short[]>
    {
        /// <summary>
        /// Filters and selects an observable sequence of event messages
        /// from register OpticalTrackingRead.
        /// </summary>
        /// <param name="source">The sequence of Harp event messages.</param>
        /// <returns>
        /// A sequence of <see cref="short[]"/> objects representing the
        /// register payload.
        /// </returns>
        public override IObservable<short[]> Process(IObservable<HarpMessage> source)
        {
            return source.Event(address: 46).Select(input => input.GetPayloadArray<short>());
        }
    }

    /// <summary>
    /// Represents an operator which creates standard command messages for the
    /// Harp device.
    /// </summary>
    /// <seealso cref="Cam0TriggerFrequency"/>
    /// <seealso cref="Cam0TriggerDuration"/>
    /// <seealso cref="Cam1TriggerFrequency"/>
    /// <seealso cref="Cam1TriggerDuration"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="Valve0Pulse"/>
    /// <seealso cref="Valve1Pulse"/>
    /// <seealso cref="OutSet"/>
    /// <seealso cref="OutClear"/>
    /// <seealso cref="OutToggle"/>
    /// <seealso cref="OutWrite"/>
    [XmlInclude(typeof(Cam0TriggerFrequency))]
    [XmlInclude(typeof(Cam0TriggerDuration))]
    [XmlInclude(typeof(Cam1TriggerFrequency))]
    [XmlInclude(typeof(Cam1TriggerDuration))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(Valve0Pulse))]
    [XmlInclude(typeof(Valve1Pulse))]
    [XmlInclude(typeof(OutSet))]
    [XmlInclude(typeof(OutClear))]
    [XmlInclude(typeof(OutToggle))]
    [XmlInclude(typeof(OutWrite))]
    public partial class VestibularH1Command : CommandBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VestibularH1Command"/> class.
        /// </summary>
        public VestibularH1Command()
        {
            Command = new Cam0TriggerFrequency();
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that sets the trigger frequency for camera 0 between 1 and 1000.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that sets the trigger frequency for camera 0 between 1 and 1000.")]
    public partial class Cam0TriggerFrequency : Combinator<ushort, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<ushort> source)
        {
            return source.Select(input => HarpCommand.WriteUInt16(address: 34, (ushort)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.")]
    public partial class Cam0TriggerDuration : Combinator<ushort, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<ushort> source)
        {
            return source.Select(input => HarpCommand.WriteUInt16(address: 35, (ushort)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that sets the trigger frequency for camera 1 between 1 and 1000.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that sets the trigger frequency for camera 1 between 1 and 1000.")]
    public partial class Cam1TriggerFrequency : Combinator<ushort, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<ushort> source)
        {
            return source.Select(input => HarpCommand.WriteUInt16(address: 36, (ushort)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.")]
    public partial class Cam1TriggerDuration : Combinator<ushort, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<ushort> source)
        {
            return source.Select(input => HarpCommand.WriteUInt16(address: 37, (ushort)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that starts or stops the cameras immediately.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that starts or stops the cameras immediately.")]
    public partial class StartAndStop : Combinator<StartStopFlags, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<StartStopFlags> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 38, (byte)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that configures the valve 0 open time in milliseconds.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that configures the valve 0 open time in milliseconds.")]
    public partial class Valve0Pulse : Combinator<byte, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<byte> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 40, (byte)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that configures the valve 1 open time in milliseconds.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that configures the valve 1 open time in milliseconds.")]
    public partial class Valve1Pulse : Combinator<byte, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<byte> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 41, (byte)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that bitmask to set the available outputs.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that bitmask to set the available outputs.")]
    public partial class OutSet : Combinator<byte, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<byte> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 42, (byte)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that bitmask to clear the available outputs.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that bitmask to clear the available outputs.")]
    public partial class OutClear : Combinator<byte, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<byte> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 43, (byte)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that bitmask to toggle the available outputs.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that bitmask to toggle the available outputs.")]
    public partial class OutToggle : Combinator<byte, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<byte> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 44, (byte)input));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of command messages
    /// that bitmask to write the available outputs.
    /// </summary>
    [DesignTimeVisible(false)]
    [Description("Creates a sequence of command messages that bitmask to write the available outputs.")]
    public partial class OutWrite : Combinator<DO, HarpMessage>
    {
        public override IObservable<HarpMessage> Process(IObservable<DO> source)
        {
            return source.Select(input => HarpCommand.WriteByte(address: 45, (byte)input));
        }
    }

    /// <summary>
    /// Bitmask describing the enable or disable commands to send to the cameras.
    /// </summary>
    [Flags]
    public enum StartStopFlags : byte
    {
        StartCam0 = 0x1,
        StartCam1 = 0x2,
        StopCam0 = 0x4,
        StopCam1 = 0x8
    }

    /// <summary>
    /// Bitmask describing the state of the lick ports.
    /// </summary>
    [Flags]
    public enum PortState : byte
    {
        Lick0 = 0x1,
        Lick1 = 0x2,
        Lick0Changed = 0x10,
        Lick1Changed = 0x20
    }

    /// <summary>
    /// Bitmask used to control the available digital outputs.
    /// </summary>
    [Flags]
    public enum DO : byte
    {
        TriggerCam0 = 0x1,
        TriggerCam1 = 0x2,
        Valve0 = 0x4,
        Valve1 = 0x8,
        PulseValve0 = 0x10,
        PulseValve1 = 0x2A
    }
}
