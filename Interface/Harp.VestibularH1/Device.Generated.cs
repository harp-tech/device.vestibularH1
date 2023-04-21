using Bonsai;
using Bonsai.Harp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Harp.VestibularH1
{
    /// <summary>
    /// Generates events and processes commands for the VestibularH1 device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the VestibularH1 device.")]
    public partial class Device : Bonsai.Harp.Device, INamedElement
    {
        /// <summary>
        /// Represents the unique identity class of the <see cref="VestibularH1"/> device.
        /// This field is constant.
        /// </summary>
        public const int WhoAmI = 1224;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        public Device() : base(WhoAmI) { }

        string INamedElement.Name => nameof(VestibularH1);

        /// <summary>
        /// Gets a read-only mapping from address to register type.
        /// </summary>
        public static new IReadOnlyDictionary<int, Type> RegisterMap { get; } = new Dictionary<int, Type>
            (Bonsai.Harp.Device.RegisterMap.ToDictionary(entry => entry.Key, entry => entry.Value))
        {
            { 32, typeof(Cam0Event) },
            { 33, typeof(Cam1Event) },
            { 34, typeof(Cam0TriggerFrequency) },
            { 35, typeof(Cam0TriggerDuration) },
            { 36, typeof(Cam1TriggerFrequency) },
            { 37, typeof(Cam1TriggerDuration) },
            { 38, typeof(StartAndStop) },
            { 39, typeof(InState) },
            { 40, typeof(Valve0Pulse) },
            { 41, typeof(Valve1Pulse) },
            { 42, typeof(OutSet) },
            { 43, typeof(OutClear) },
            { 44, typeof(OutToggle) },
            { 45, typeof(OutWrite) },
            { 46, typeof(OpticalTrackingRead) }
        };
    }

    /// <summary>
    /// Represents an operator that groups the sequence of <see cref="VestibularH1"/>" messages by register type.
    /// </summary>
    [Description("Groups the sequence of VestibularH1 messages by register type.")]
    public partial class GroupByRegister : Combinator<HarpMessage, IGroupedObservable<Type, HarpMessage>>
    {
        /// <summary>
        /// Groups an observable sequence of <see cref="VestibularH1"/> messages
        /// by register type.
        /// </summary>
        /// <param name="source">The sequence of Harp device messages.</param>
        /// <returns>
        /// A sequence of observable groups, each of which corresponds to a unique
        /// <see cref="VestibularH1"/> register.
        /// </returns>
        public override IObservable<IGroupedObservable<Type, HarpMessage>> Process(IObservable<HarpMessage> source)
        {
            return source.GroupBy(message => Device.RegisterMap[message.Address]);
        }
    }

    /// <summary>
    /// Represents an operator that filters register-specific messages
    /// reported by the <see cref="VestibularH1"/> device.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="Cam0TriggerFrequency"/>
    /// <seealso cref="Cam0TriggerDuration"/>
    /// <seealso cref="Cam1TriggerFrequency"/>
    /// <seealso cref="Cam1TriggerDuration"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="InState"/>
    /// <seealso cref="Valve0Pulse"/>
    /// <seealso cref="Valve1Pulse"/>
    /// <seealso cref="OutSet"/>
    /// <seealso cref="OutClear"/>
    /// <seealso cref="OutToggle"/>
    /// <seealso cref="OutWrite"/>
    /// <seealso cref="OpticalTrackingRead"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(Cam0TriggerFrequency))]
    [XmlInclude(typeof(Cam0TriggerDuration))]
    [XmlInclude(typeof(Cam1TriggerFrequency))]
    [XmlInclude(typeof(Cam1TriggerDuration))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(InState))]
    [XmlInclude(typeof(Valve0Pulse))]
    [XmlInclude(typeof(Valve1Pulse))]
    [XmlInclude(typeof(OutSet))]
    [XmlInclude(typeof(OutClear))]
    [XmlInclude(typeof(OutToggle))]
    [XmlInclude(typeof(OutWrite))]
    [XmlInclude(typeof(OpticalTrackingRead))]
    [Description("Filters register-specific messages reported by the VestibularH1 device.")]
    public class FilterMessage : FilterMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterMessage"/> class.
        /// </summary>
        public FilterMessage()
        {
            Register = new Cam0Event();
        }

        string INamedElement.Name
        {
            get => $"{nameof(VestibularH1)}.{GetElementDisplayName(Register)}";
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific messages
    /// reported by the VestibularH1 device.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="Cam0TriggerFrequency"/>
    /// <seealso cref="Cam0TriggerDuration"/>
    /// <seealso cref="Cam1TriggerFrequency"/>
    /// <seealso cref="Cam1TriggerDuration"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="InState"/>
    /// <seealso cref="Valve0Pulse"/>
    /// <seealso cref="Valve1Pulse"/>
    /// <seealso cref="OutSet"/>
    /// <seealso cref="OutClear"/>
    /// <seealso cref="OutToggle"/>
    /// <seealso cref="OutWrite"/>
    /// <seealso cref="OpticalTrackingRead"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(Cam0TriggerFrequency))]
    [XmlInclude(typeof(Cam0TriggerDuration))]
    [XmlInclude(typeof(Cam1TriggerFrequency))]
    [XmlInclude(typeof(Cam1TriggerDuration))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(InState))]
    [XmlInclude(typeof(Valve0Pulse))]
    [XmlInclude(typeof(Valve1Pulse))]
    [XmlInclude(typeof(OutSet))]
    [XmlInclude(typeof(OutClear))]
    [XmlInclude(typeof(OutToggle))]
    [XmlInclude(typeof(OutWrite))]
    [XmlInclude(typeof(OpticalTrackingRead))]
    [XmlInclude(typeof(TimestampedCam0Event))]
    [XmlInclude(typeof(TimestampedCam1Event))]
    [XmlInclude(typeof(TimestampedCam0TriggerFrequency))]
    [XmlInclude(typeof(TimestampedCam0TriggerDuration))]
    [XmlInclude(typeof(TimestampedCam1TriggerFrequency))]
    [XmlInclude(typeof(TimestampedCam1TriggerDuration))]
    [XmlInclude(typeof(TimestampedStartAndStop))]
    [XmlInclude(typeof(TimestampedInState))]
    [XmlInclude(typeof(TimestampedValve0Pulse))]
    [XmlInclude(typeof(TimestampedValve1Pulse))]
    [XmlInclude(typeof(TimestampedOutSet))]
    [XmlInclude(typeof(TimestampedOutClear))]
    [XmlInclude(typeof(TimestampedOutToggle))]
    [XmlInclude(typeof(TimestampedOutWrite))]
    [XmlInclude(typeof(TimestampedOpticalTrackingRead))]
    [Description("Filters and selects specific messages reported by the VestibularH1 device.")]
    public partial class Parse : ParseBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parse"/> class.
        /// </summary>
        public Parse()
        {
            Register = new Cam0Event();
        }

        string INamedElement.Name => $"{nameof(VestibularH1)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents an operator which formats a sequence of values as specific
    /// VestibularH1 register messages.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="Cam0TriggerFrequency"/>
    /// <seealso cref="Cam0TriggerDuration"/>
    /// <seealso cref="Cam1TriggerFrequency"/>
    /// <seealso cref="Cam1TriggerDuration"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="InState"/>
    /// <seealso cref="Valve0Pulse"/>
    /// <seealso cref="Valve1Pulse"/>
    /// <seealso cref="OutSet"/>
    /// <seealso cref="OutClear"/>
    /// <seealso cref="OutToggle"/>
    /// <seealso cref="OutWrite"/>
    /// <seealso cref="OpticalTrackingRead"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(Cam0TriggerFrequency))]
    [XmlInclude(typeof(Cam0TriggerDuration))]
    [XmlInclude(typeof(Cam1TriggerFrequency))]
    [XmlInclude(typeof(Cam1TriggerDuration))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(InState))]
    [XmlInclude(typeof(Valve0Pulse))]
    [XmlInclude(typeof(Valve1Pulse))]
    [XmlInclude(typeof(OutSet))]
    [XmlInclude(typeof(OutClear))]
    [XmlInclude(typeof(OutToggle))]
    [XmlInclude(typeof(OutWrite))]
    [XmlInclude(typeof(OpticalTrackingRead))]
    [Description("Formats a sequence of values as specific VestibularH1 register messages.")]
    public partial class Format : FormatBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> class.
        /// </summary>
        public Format()
        {
            Register = new Cam0Event();
        }

        string INamedElement.Name => $"{nameof(VestibularH1)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents a register that signals when a frame was triggered on camera 0.
    /// </summary>
    [Description("Signals when a frame was triggered on camera 0.")]
    public partial class Cam0Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const int Address = 32;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static bool GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte() != 0;
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<bool> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(payload.Value != 0, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam0Event"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0Event"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, bool value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)(value ? 1 : 0));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam0Event"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0Event"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, bool value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)(value ? 1 : 0));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam0Event register.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    [Description("Filters and selects timestamped messages from the Cam0Event register.")]
    public partial class TimestampedCam0Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam0Event.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<bool> GetPayload(HarpMessage message)
        {
            return Cam0Event.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that signals when a frame was triggered on camera 1.
    /// </summary>
    [Description("Signals when a frame was triggered on camera 1.")]
    public partial class Cam1Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const int Address = 33;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static bool GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte() != 0;
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<bool> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(payload.Value != 0, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam1Event"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1Event"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, bool value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)(value ? 1 : 0));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam1Event"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1Event"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, bool value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)(value ? 1 : 0));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam1Event register.
    /// </summary>
    /// <seealso cref="Cam1Event"/>
    [Description("Filters and selects timestamped messages from the Cam1Event register.")]
    public partial class TimestampedCam1Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam1Event.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<bool> GetPayload(HarpMessage message)
        {
            return Cam1Event.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the trigger frequency for camera 0 between 1 and 1000.
    /// </summary>
    [Description("Sets the trigger frequency for camera 0 between 1 and 1000.")]
    public partial class Cam0TriggerFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 34;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam0TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="Cam0TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam0TriggerFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam0TriggerFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam0TriggerFrequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0TriggerFrequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam0TriggerFrequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0TriggerFrequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam0TriggerFrequency register.
    /// </summary>
    /// <seealso cref="Cam0TriggerFrequency"/>
    [Description("Filters and selects timestamped messages from the Cam0TriggerFrequency register.")]
    public partial class TimestampedCam0TriggerFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam0TriggerFrequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam0TriggerFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return Cam0TriggerFrequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.
    /// </summary>
    [Description("Sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.")]
    public partial class Cam0TriggerDuration
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const int Address = 35;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam0TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="Cam0TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam0TriggerDuration"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam0TriggerDuration"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam0TriggerDuration"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0TriggerDuration"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam0TriggerDuration"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0TriggerDuration"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam0TriggerDuration register.
    /// </summary>
    /// <seealso cref="Cam0TriggerDuration"/>
    [Description("Filters and selects timestamped messages from the Cam0TriggerDuration register.")]
    public partial class TimestampedCam0TriggerDuration
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam0TriggerDuration.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam0TriggerDuration"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return Cam0TriggerDuration.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the trigger frequency for camera 1 between 1 and 1000.
    /// </summary>
    [Description("Sets the trigger frequency for camera 1 between 1 and 1000.")]
    public partial class Cam1TriggerFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 36;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam1TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="Cam1TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam1TriggerFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam1TriggerFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam1TriggerFrequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1TriggerFrequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam1TriggerFrequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1TriggerFrequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam1TriggerFrequency register.
    /// </summary>
    /// <seealso cref="Cam1TriggerFrequency"/>
    [Description("Filters and selects timestamped messages from the Cam1TriggerFrequency register.")]
    public partial class TimestampedCam1TriggerFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1TriggerFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam1TriggerFrequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam1TriggerFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return Cam1TriggerFrequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.
    /// </summary>
    [Description("Sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.")]
    public partial class Cam1TriggerDuration
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const int Address = 37;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam1TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="Cam1TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam1TriggerDuration"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam1TriggerDuration"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam1TriggerDuration"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1TriggerDuration"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam1TriggerDuration"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1TriggerDuration"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam1TriggerDuration register.
    /// </summary>
    /// <seealso cref="Cam1TriggerDuration"/>
    [Description("Filters and selects timestamped messages from the Cam1TriggerDuration register.")]
    public partial class TimestampedCam1TriggerDuration
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1TriggerDuration"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam1TriggerDuration.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam1TriggerDuration"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return Cam1TriggerDuration.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that starts or stops the cameras immediately.
    /// </summary>
    [Description("Starts or stops the cameras immediately.")]
    public partial class StartAndStop
    {
        /// <summary>
        /// Represents the address of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const int Address = 38;

        /// <summary>
        /// Represents the payload type of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StartAndStop"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static StartStopFlags GetPayload(HarpMessage message)
        {
            return (StartStopFlags)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StartAndStop"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<StartStopFlags> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((StartStopFlags)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StartAndStop"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartAndStop"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, StartStopFlags value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StartAndStop"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartAndStop"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, StartStopFlags value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StartAndStop register.
    /// </summary>
    /// <seealso cref="StartAndStop"/>
    [Description("Filters and selects timestamped messages from the StartAndStop register.")]
    public partial class TimestampedStartAndStop
    {
        /// <summary>
        /// Represents the address of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const int Address = StartAndStop.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StartAndStop"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<StartStopFlags> GetPayload(HarpMessage message)
        {
            return StartAndStop.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that contains the state of the lick ports.
    /// </summary>
    [Description("Contains the state of the lick ports.")]
    public partial class InState
    {
        /// <summary>
        /// Represents the address of the <see cref="InState"/> register. This field is constant.
        /// </summary>
        public const int Address = 39;

        /// <summary>
        /// Represents the payload type of the <see cref="InState"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="InState"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="InState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PortState GetPayload(HarpMessage message)
        {
            return (PortState)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="InState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PortState> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PortState)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="InState"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="InState"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PortState value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="InState"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="InState"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PortState value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// InState register.
    /// </summary>
    /// <seealso cref="InState"/>
    [Description("Filters and selects timestamped messages from the InState register.")]
    public partial class TimestampedInState
    {
        /// <summary>
        /// Represents the address of the <see cref="InState"/> register. This field is constant.
        /// </summary>
        public const int Address = InState.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="InState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PortState> GetPayload(HarpMessage message)
        {
            return InState.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the valve 0 open time in milliseconds.
    /// </summary>
    [Description("Configures the valve 0 open time in milliseconds.")]
    public partial class Valve0Pulse
    {
        /// <summary>
        /// Represents the address of the <see cref="Valve0Pulse"/> register. This field is constant.
        /// </summary>
        public const int Address = 40;

        /// <summary>
        /// Represents the payload type of the <see cref="Valve0Pulse"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Valve0Pulse"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Valve0Pulse"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Valve0Pulse"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Valve0Pulse"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Valve0Pulse"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Valve0Pulse"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Valve0Pulse"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Valve0Pulse register.
    /// </summary>
    /// <seealso cref="Valve0Pulse"/>
    [Description("Filters and selects timestamped messages from the Valve0Pulse register.")]
    public partial class TimestampedValve0Pulse
    {
        /// <summary>
        /// Represents the address of the <see cref="Valve0Pulse"/> register. This field is constant.
        /// </summary>
        public const int Address = Valve0Pulse.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Valve0Pulse"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return Valve0Pulse.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the valve 1 open time in milliseconds.
    /// </summary>
    [Description("Configures the valve 1 open time in milliseconds.")]
    public partial class Valve1Pulse
    {
        /// <summary>
        /// Represents the address of the <see cref="Valve1Pulse"/> register. This field is constant.
        /// </summary>
        public const int Address = 41;

        /// <summary>
        /// Represents the payload type of the <see cref="Valve1Pulse"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Valve1Pulse"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Valve1Pulse"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Valve1Pulse"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Valve1Pulse"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Valve1Pulse"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Valve1Pulse"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Valve1Pulse"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Valve1Pulse register.
    /// </summary>
    /// <seealso cref="Valve1Pulse"/>
    [Description("Filters and selects timestamped messages from the Valve1Pulse register.")]
    public partial class TimestampedValve1Pulse
    {
        /// <summary>
        /// Represents the address of the <see cref="Valve1Pulse"/> register. This field is constant.
        /// </summary>
        public const int Address = Valve1Pulse.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Valve1Pulse"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return Valve1Pulse.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that bitmask to set the available outputs.
    /// </summary>
    [Description("Bitmask to set the available outputs.")]
    public partial class OutSet
    {
        /// <summary>
        /// Represents the address of the <see cref="OutSet"/> register. This field is constant.
        /// </summary>
        public const int Address = 42;

        /// <summary>
        /// Represents the payload type of the <see cref="OutSet"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutSet"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutSet"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutSet"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutSet"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutSet"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutSet"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutSet"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutSet register.
    /// </summary>
    /// <seealso cref="OutSet"/>
    [Description("Filters and selects timestamped messages from the OutSet register.")]
    public partial class TimestampedOutSet
    {
        /// <summary>
        /// Represents the address of the <see cref="OutSet"/> register. This field is constant.
        /// </summary>
        public const int Address = OutSet.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutSet"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return OutSet.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that bitmask to clear the available outputs.
    /// </summary>
    [Description("Bitmask to clear the available outputs.")]
    public partial class OutClear
    {
        /// <summary>
        /// Represents the address of the <see cref="OutClear"/> register. This field is constant.
        /// </summary>
        public const int Address = 43;

        /// <summary>
        /// Represents the payload type of the <see cref="OutClear"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutClear"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutClear"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutClear"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutClear"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutClear"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutClear"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutClear"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutClear register.
    /// </summary>
    /// <seealso cref="OutClear"/>
    [Description("Filters and selects timestamped messages from the OutClear register.")]
    public partial class TimestampedOutClear
    {
        /// <summary>
        /// Represents the address of the <see cref="OutClear"/> register. This field is constant.
        /// </summary>
        public const int Address = OutClear.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutClear"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return OutClear.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that bitmask to toggle the available outputs.
    /// </summary>
    [Description("Bitmask to toggle the available outputs.")]
    public partial class OutToggle
    {
        /// <summary>
        /// Represents the address of the <see cref="OutToggle"/> register. This field is constant.
        /// </summary>
        public const int Address = 44;

        /// <summary>
        /// Represents the payload type of the <see cref="OutToggle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutToggle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutToggle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutToggle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutToggle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutToggle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutToggle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutToggle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutToggle register.
    /// </summary>
    /// <seealso cref="OutToggle"/>
    [Description("Filters and selects timestamped messages from the OutToggle register.")]
    public partial class TimestampedOutToggle
    {
        /// <summary>
        /// Represents the address of the <see cref="OutToggle"/> register. This field is constant.
        /// </summary>
        public const int Address = OutToggle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutToggle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return OutToggle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that bitmask to write the available outputs.
    /// </summary>
    [Description("Bitmask to write the available outputs.")]
    public partial class OutWrite
    {
        /// <summary>
        /// Represents the address of the <see cref="OutWrite"/> register. This field is constant.
        /// </summary>
        public const int Address = 45;

        /// <summary>
        /// Represents the payload type of the <see cref="OutWrite"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutWrite"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutWrite"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static DO GetPayload(HarpMessage message)
        {
            return (DO)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutWrite"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DO> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((DO)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutWrite"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutWrite"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, DO value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutWrite"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutWrite"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, DO value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutWrite register.
    /// </summary>
    /// <seealso cref="OutWrite"/>
    [Description("Filters and selects timestamped messages from the OutWrite register.")]
    public partial class TimestampedOutWrite
    {
        /// <summary>
        /// Represents the address of the <see cref="OutWrite"/> register. This field is constant.
        /// </summary>
        public const int Address = OutWrite.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutWrite"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DO> GetPayload(HarpMessage message)
        {
            return OutWrite.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that manipulates messages from register OpticalTrackingRead.
    /// </summary>
    [Description("")]
    public partial class OpticalTrackingRead
    {
        /// <summary>
        /// Represents the address of the <see cref="OpticalTrackingRead"/> register. This field is constant.
        /// </summary>
        public const int Address = 46;

        /// <summary>
        /// Represents the payload type of the <see cref="OpticalTrackingRead"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S16;

        /// <summary>
        /// Represents the length of the <see cref="OpticalTrackingRead"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 6;

        /// <summary>
        /// Returns the payload data for <see cref="OpticalTrackingRead"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static short[] GetPayload(HarpMessage message)
        {
            return message.GetPayloadArray<short>();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OpticalTrackingRead"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short[]> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadArray<short>();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OpticalTrackingRead"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OpticalTrackingRead"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, short[] value)
        {
            return HarpMessage.FromInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OpticalTrackingRead"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OpticalTrackingRead"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, short[] value)
        {
            return HarpMessage.FromInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OpticalTrackingRead register.
    /// </summary>
    /// <seealso cref="OpticalTrackingRead"/>
    [Description("Filters and selects timestamped messages from the OpticalTrackingRead register.")]
    public partial class TimestampedOpticalTrackingRead
    {
        /// <summary>
        /// Represents the address of the <see cref="OpticalTrackingRead"/> register. This field is constant.
        /// </summary>
        public const int Address = OpticalTrackingRead.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OpticalTrackingRead"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short[]> GetPayload(HarpMessage message)
        {
            return OpticalTrackingRead.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents an operator which creates standard message payloads for the
    /// VestibularH1 device.
    /// </summary>
    /// <seealso cref="CreateCam0EventPayload"/>
    /// <seealso cref="CreateCam1EventPayload"/>
    /// <seealso cref="CreateCam0TriggerFrequencyPayload"/>
    /// <seealso cref="CreateCam0TriggerDurationPayload"/>
    /// <seealso cref="CreateCam1TriggerFrequencyPayload"/>
    /// <seealso cref="CreateCam1TriggerDurationPayload"/>
    /// <seealso cref="CreateStartAndStopPayload"/>
    /// <seealso cref="CreateInStatePayload"/>
    /// <seealso cref="CreateValve0PulsePayload"/>
    /// <seealso cref="CreateValve1PulsePayload"/>
    /// <seealso cref="CreateOutSetPayload"/>
    /// <seealso cref="CreateOutClearPayload"/>
    /// <seealso cref="CreateOutTogglePayload"/>
    /// <seealso cref="CreateOutWritePayload"/>
    /// <seealso cref="CreateOpticalTrackingReadPayload"/>
    [XmlInclude(typeof(CreateCam0EventPayload))]
    [XmlInclude(typeof(CreateCam1EventPayload))]
    [XmlInclude(typeof(CreateCam0TriggerFrequencyPayload))]
    [XmlInclude(typeof(CreateCam0TriggerDurationPayload))]
    [XmlInclude(typeof(CreateCam1TriggerFrequencyPayload))]
    [XmlInclude(typeof(CreateCam1TriggerDurationPayload))]
    [XmlInclude(typeof(CreateStartAndStopPayload))]
    [XmlInclude(typeof(CreateInStatePayload))]
    [XmlInclude(typeof(CreateValve0PulsePayload))]
    [XmlInclude(typeof(CreateValve1PulsePayload))]
    [XmlInclude(typeof(CreateOutSetPayload))]
    [XmlInclude(typeof(CreateOutClearPayload))]
    [XmlInclude(typeof(CreateOutTogglePayload))]
    [XmlInclude(typeof(CreateOutWritePayload))]
    [XmlInclude(typeof(CreateOpticalTrackingReadPayload))]
    [Description("Creates standard message payloads for the VestibularH1 device.")]
    public partial class CreateMessage : CreateMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        public CreateMessage()
        {
            Payload = new CreateCam0EventPayload();
        }

        string INamedElement.Name => $"{nameof(VestibularH1)}.{GetElementDisplayName(Payload)}";
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that signals when a frame was triggered on camera 0.
    /// </summary>
    [DisplayName("Cam0EventPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that signals when a frame was triggered on camera 0.")]
    public partial class CreateCam0EventPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that signals when a frame was triggered on camera 0.
        /// </summary>
        [Description("The value that signals when a frame was triggered on camera 0.")]
        public bool Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that signals when a frame was triggered on camera 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that signals when a frame was triggered on camera 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Cam0Event.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that signals when a frame was triggered on camera 1.
    /// </summary>
    [DisplayName("Cam1EventPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that signals when a frame was triggered on camera 1.")]
    public partial class CreateCam1EventPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that signals when a frame was triggered on camera 1.
        /// </summary>
        [Description("The value that signals when a frame was triggered on camera 1.")]
        public bool Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that signals when a frame was triggered on camera 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that signals when a frame was triggered on camera 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Cam1Event.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the trigger frequency for camera 0 between 1 and 1000.
    /// </summary>
    [DisplayName("Cam0TriggerFrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the trigger frequency for camera 0 between 1 and 1000.")]
    public partial class CreateCam0TriggerFrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the trigger frequency for camera 0 between 1 and 1000.
        /// </summary>
        [Description("The value that sets the trigger frequency for camera 0 between 1 and 1000.")]
        public ushort Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the trigger frequency for camera 0 between 1 and 1000.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the trigger frequency for camera 0 between 1 and 1000.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Cam0TriggerFrequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.
    /// </summary>
    [DisplayName("Cam0TriggerDurationPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.")]
    public partial class CreateCam0TriggerDurationPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.
        /// </summary>
        [Description("The value that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.")]
        public ushort Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Cam0TriggerDuration.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the trigger frequency for camera 1 between 1 and 1000.
    /// </summary>
    [DisplayName("Cam1TriggerFrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the trigger frequency for camera 1 between 1 and 1000.")]
    public partial class CreateCam1TriggerFrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the trigger frequency for camera 1 between 1 and 1000.
        /// </summary>
        [Description("The value that sets the trigger frequency for camera 1 between 1 and 1000.")]
        public ushort Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the trigger frequency for camera 1 between 1 and 1000.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the trigger frequency for camera 1 between 1 and 1000.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Cam1TriggerFrequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.
    /// </summary>
    [DisplayName("Cam1TriggerDurationPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.")]
    public partial class CreateCam1TriggerDurationPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.
        /// </summary>
        [Description("The value that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.")]
        public ushort Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the duration of the trigger pulse (in microseconds, minimum is 100) for camera 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Cam1TriggerDuration.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that starts or stops the cameras immediately.
    /// </summary>
    [DisplayName("StartAndStopPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that starts or stops the cameras immediately.")]
    public partial class CreateStartAndStopPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that starts or stops the cameras immediately.
        /// </summary>
        [Description("The value that starts or stops the cameras immediately.")]
        public StartStopFlags Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that starts or stops the cameras immediately.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that starts or stops the cameras immediately.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => StartAndStop.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that contains the state of the lick ports.
    /// </summary>
    [DisplayName("InStatePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that contains the state of the lick ports.")]
    public partial class CreateInStatePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that contains the state of the lick ports.
        /// </summary>
        [Description("The value that contains the state of the lick ports.")]
        public PortState Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that contains the state of the lick ports.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that contains the state of the lick ports.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => InState.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that configures the valve 0 open time in milliseconds.
    /// </summary>
    [DisplayName("Valve0PulsePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that configures the valve 0 open time in milliseconds.")]
    public partial class CreateValve0PulsePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that configures the valve 0 open time in milliseconds.
        /// </summary>
        [Description("The value that configures the valve 0 open time in milliseconds.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that configures the valve 0 open time in milliseconds.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that configures the valve 0 open time in milliseconds.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Valve0Pulse.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that configures the valve 1 open time in milliseconds.
    /// </summary>
    [DisplayName("Valve1PulsePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that configures the valve 1 open time in milliseconds.")]
    public partial class CreateValve1PulsePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that configures the valve 1 open time in milliseconds.
        /// </summary>
        [Description("The value that configures the valve 1 open time in milliseconds.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that configures the valve 1 open time in milliseconds.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that configures the valve 1 open time in milliseconds.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Valve1Pulse.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that bitmask to set the available outputs.
    /// </summary>
    [DisplayName("OutSetPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that bitmask to set the available outputs.")]
    public partial class CreateOutSetPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that bitmask to set the available outputs.
        /// </summary>
        [Description("The value that bitmask to set the available outputs.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that bitmask to set the available outputs.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that bitmask to set the available outputs.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => OutSet.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that bitmask to clear the available outputs.
    /// </summary>
    [DisplayName("OutClearPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that bitmask to clear the available outputs.")]
    public partial class CreateOutClearPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that bitmask to clear the available outputs.
        /// </summary>
        [Description("The value that bitmask to clear the available outputs.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that bitmask to clear the available outputs.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that bitmask to clear the available outputs.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => OutClear.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that bitmask to toggle the available outputs.
    /// </summary>
    [DisplayName("OutTogglePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that bitmask to toggle the available outputs.")]
    public partial class CreateOutTogglePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that bitmask to toggle the available outputs.
        /// </summary>
        [Description("The value that bitmask to toggle the available outputs.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that bitmask to toggle the available outputs.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that bitmask to toggle the available outputs.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => OutToggle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that bitmask to write the available outputs.
    /// </summary>
    [DisplayName("OutWritePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that bitmask to write the available outputs.")]
    public partial class CreateOutWritePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that bitmask to write the available outputs.
        /// </summary>
        [Description("The value that bitmask to write the available outputs.")]
        public DO Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that bitmask to write the available outputs.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that bitmask to write the available outputs.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => OutWrite.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// for register OpticalTrackingRead.
    /// </summary>
    [DisplayName("OpticalTrackingReadPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads for register OpticalTrackingRead.")]
    public partial class CreateOpticalTrackingReadPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value for register OpticalTrackingRead.
        /// </summary>
        [Description("The value for register OpticalTrackingRead.")]
        public short[] Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// for register OpticalTrackingRead.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// for register OpticalTrackingRead.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => OpticalTrackingRead.FromPayload(MessageType, Value));
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
