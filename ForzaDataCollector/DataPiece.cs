using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ForzaDataCollector
{
    /// <summary>
    /// In case of UDP slip-up all of the values are nullable. Consider this during this struct usage!
    /// </summary>
    public struct DataPiece
    {
        /// <summary>
        /// 1 when race is on; 0 when menus/race stopped.
        /// </summary>
        public int? IsRaceOn { get; private set; }

        /// <summary>
        /// Can overflow to 0 eventually.
        /// </summary>
        public uint? TimestampMS { get; private set; }

        public float? EngineMaxRpm { get; private set; }
        public float? EngineIdleRpm { get; private set; }
        public float? CurrentEngineRpm { get; private set; }

        /// <summary>
        /// In the car's local space; right.
        /// </summary>
        public float? AccelerationX { get; private set; }
        /// <summary>
        /// In the car's local space; up.
        /// </summary>
        public float? AccelerationY { get; private set; }
        /// <summary>
        /// In the car's local space; forward.
        /// </summary>
        public float? AccelerationZ { get; private set; }

        /// <summary>
        /// In the car's local space; right.
        /// </summary>
        public float? VelocityX { get; private set; }
        /// <summary>
        /// In the car's local space; up.
        /// </summary>
        public float? VelocityY { get; private set; }
        /// <summary>
        /// In the car's local space; forward.
        /// </summary>
        public float? VelocityZ { get; private set; }

        /// <summary>
        /// In the car's local space; pitch.
        /// </summary>
        public float? AngularVelocityX { get; private set; }
        /// <summary>
        /// In the car's local space; yaw.
        /// </summary>
        public float? AngularVelocityY { get; private set; }
        /// <summary>
        /// In the car's local space; roll.
        /// </summary>
        public float? AngularVelocityZ { get; private set; }

        public float? Yaw { get; private set; }
        public float? Pitch { get; private set; }
        public float? Roll { get; private set; }

        /// <summary>
        /// 0.0f max stretch; 1.0f max compression;
        /// </summary>
        public float? NormalizedSuspensionTravelFrontLeft { get; private set; }
        /// <summary>
        /// 0.0f max stretch; 1.0f max compression;
        /// </summary>
        public float? NormalizedSuspensionTravelFrontRight { get; private set; }
        /// <summary>
        /// 0.0f max stretch; 1.0f max compression;
        /// </summary>
        public float? NormalizedSuspensionTravelRearLeft { get; private set; }
        /// <summary>
        /// 0.0f max stretch; 1.0f max compression;
        /// </summary>
        public float? NormalizedSuspensionTravelRearRight { get; private set; }

        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipRatioFrontLeft { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipRatioFrontRight { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipRatioRearLeft { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipRatioRearRight { get; private set; }

        /// <summary>
        /// Radians/second.
        /// </summary>
        public float? WheelRotationSpeedFrontLeft { get; private set; }
        /// <summary>
        /// Radians/second.
        /// </summary>
        public float? WheelRotationSpeedFrontRight { get; private set; }
        /// <summary>
        /// Radians/second.
        /// </summary>
        public float? WheelRotationSpeedRearLeft { get; private set; }
        /// <summary>
        /// Radians/second.
        /// </summary>
        public float? WheelRotationSpeedRearRight { get; private set; }

        /// <summary>
        /// 1 when wheel is on rubmle strip; 0 when off.
        /// </summary>
        public int? WheelOnRumbleStripFrontLeft { get; private set; }
        /// <summary>
        /// 1 when wheel is on rubmle strip; 0 when off.
        /// </summary>
        public int? WheelOnRumbleStripFrontRight { get; private set; }
        /// <summary>
        /// 1 when wheel is on rubmle strip; 0 when off.
        /// </summary>
        public int? WheelOnRumbleStripRearLeft { get; private set; }
        /// <summary>
        /// 1 when wheel is on rubmle strip; 0 when off.
        /// </summary>
        public int? WheelOnRumbleStripRearRight { get; private set; }

        /// <summary>
        /// 1 = deepest puddle; 0 when off.
        /// </summary>
        public float? WheelInPuddleDepthFrontLeft { get; private set; }
        /// <summary>
        /// 1 = deepest puddle; 0 when off.
        /// </summary>
        public float? WheelInPuddleDepthFrontRight { get; private set; }
        /// <summary>
        /// 1 = deepest puddle; 0 when off.
        /// </summary>
        public float? WheelInPuddleDepthRearLeft { get; private set; }
        /// <summary>
        /// 1 = deepest puddle; 0 when off.
        /// </summary>
        public float? WheelInPuddleDepthRearRight { get; private set; }

        /// <summary>
        /// Non-dimensional surface rumble value passed to controller force feedback
        /// </summary>
        public float? SurfaceRumbleFrontLeft { get; private set; }
        /// <summary>
        /// Non-dimensional surface rumble value passed to controller force feedback
        /// </summary>
        public float? SurfaceRumbleFrontRight { get; private set; }
        /// <summary>
        /// Non-dimensional surface rumble value passed to controller force feedback
        /// </summary>
        public float? SurfaceRumbleRearLeft { get; private set; }
        /// <summary>
        /// Non-dimensional surface rumble value passed to controller force feedback
        /// </summary>
        public float? SurfaceRumbleRearRight { get; private set; }

        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipAngleFrontLeft { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipAngleFrontRight { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipAngleRearLeft { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireSlipAngleRearRight { get; private set; }

        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireCombinedSlipFrontLeft { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireCombinedSlipFrontRight { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireCombinedSlipRearLeft { get; private set; }
        /// <summary>
        /// 0.0f = 100% grip; > 1.0f loss of grip;
        /// </summary>
        public float? TireCombinedSlipRearRight { get; private set; }

        /// <summary>
        /// Meters.
        /// </summary>
        public float? SuspensionTravelMetersFrontLeft { get; private set; }
        /// <summary>
        /// Meters.
        /// </summary>
        public float? SuspensionTravelMetersFrontRight { get; private set; }
        /// <summary>
        /// Meters.
        /// </summary>
        public float? SuspensionTravelMetersRearLeft { get; private set; }
        /// <summary>
        /// Meters.
        /// </summary>
        public float? SuspensionTravelMetersRearRight { get; private set; }

        /// <summary>
        /// UqId of car make/model
        /// </summary>
        public int? CarOrdinal { get; private set; }
        /// <summary>
        /// Between 0 and 7 inclusive.
        /// </summary>
        public int? CarClass { get; private set; }
        /// <summary>
        /// Between 100 and 999 inclusive.
        /// </summary>
        public int? CarPerformanceIndex { get; private set; }
        /// <summary>
        /// 0 = FWD, 1 = RWD, 2 = AWD.
        /// </summary>
        public int? DrivetrainType { get; private set; }
        /// <summary>
        /// Number of engine cylinders
        /// </summary>
        public int? NumCylinders { get; private set; }

        /// <summary>
        /// Meters.
        /// </summary>
        public float? PositionX { get; private set; }
        /// <summary>
        /// Meters.
        /// </summary>
        public float? PositionY { get; private set; }
        /// <summary>
        /// Meters.
        /// </summary>
        public float? PositionZ { get; private set; }

        /// <summary>
        /// m/s.
        /// </summary>
        public float? Speed { get; private set; }
        /// <summary>
        /// Watts.
        /// </summary>
        public float? Power { get; private set; }
        /// <summary>
        /// Nm.
        /// </summary>
        public float? Torque { get; private set; }

        public float? TireTempFrontLeft { get; private set; }
        public float? TireTempFrontRight { get; private set; }
        public float? TireTempRearLeft { get; private set; }
        public float? TireTempRearRight { get; private set; }
                    
        public float? Boost { get; private set; }
        public float? Fuel { get; private set; }
        public float? DistanceTraveled { get; private set; }
        public float? BestLap { get; private set; }
        public float? LastLap { get; private set; }
        public float? CurrentLap { get; private set; }
        public float? CurrentRaceTime { get; private set; }

        public ushort? LapNumber { get; private set; }
        public byte? RacePosition { get; private set; }

        public byte? Accel { get; private set; }
        public byte? Brake { get; private set; }
        public byte? Clutch { get; private set; }
        public byte? HandBrake { get; private set; }
        public byte? Gear { get; private set; }
        public sbyte? Steer { get; private set; }

        public sbyte? NormalizedDrivingLine { get; private set; }
        public sbyte? NormalizedAIBrakeDifference { get; private set; }

        public DataPiece(byte[] rawData) : this()
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(rawData))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        IsRaceOn = reader.ReadInt32();

                        TimestampMS = reader.ReadUInt32();

                        EngineMaxRpm = reader.ReadSingle();
                        EngineIdleRpm = reader.ReadSingle();
                        CurrentEngineRpm = reader.ReadSingle();

                        AccelerationX = reader.ReadSingle();
                        AccelerationY = reader.ReadSingle();
                        AccelerationZ = reader.ReadSingle();

                        VelocityX = reader.ReadSingle();
                        VelocityY = reader.ReadSingle();
                        VelocityZ = reader.ReadSingle();

                        AngularVelocityX = reader.ReadSingle();
                        AngularVelocityY = reader.ReadSingle();
                        AngularVelocityZ = reader.ReadSingle();

                        Yaw = reader.ReadSingle();
                        Pitch = reader.ReadSingle();
                        Roll = reader.ReadSingle();

                        NormalizedSuspensionTravelFrontLeft = reader.ReadSingle();
                        NormalizedSuspensionTravelFrontRight = reader.ReadSingle();
                        NormalizedSuspensionTravelRearLeft = reader.ReadSingle();
                        NormalizedSuspensionTravelRearRight = reader.ReadSingle();

                        TireSlipRatioFrontLeft = reader.ReadSingle();
                        TireSlipRatioFrontRight = reader.ReadSingle();
                        TireSlipRatioRearLeft = reader.ReadSingle();
                        TireSlipRatioRearRight = reader.ReadSingle();

                        WheelRotationSpeedFrontLeft = reader.ReadSingle();
                        WheelRotationSpeedFrontRight = reader.ReadSingle();
                        WheelRotationSpeedRearLeft = reader.ReadSingle();
                        WheelRotationSpeedRearRight = reader.ReadSingle();

                        WheelOnRumbleStripFrontLeft = reader.ReadInt32();
                        WheelOnRumbleStripFrontRight = reader.ReadInt32();
                        WheelOnRumbleStripRearLeft = reader.ReadInt32();
                        WheelOnRumbleStripRearRight = reader.ReadInt32();

                        WheelInPuddleDepthFrontLeft = reader.ReadSingle();
                        WheelInPuddleDepthFrontRight = reader.ReadSingle();
                        WheelInPuddleDepthRearLeft = reader.ReadSingle();
                        WheelInPuddleDepthRearRight = reader.ReadSingle();

                        SurfaceRumbleFrontLeft = reader.ReadSingle();
                        SurfaceRumbleFrontRight = reader.ReadSingle();
                        SurfaceRumbleRearLeft = reader.ReadSingle();
                        SurfaceRumbleRearRight = reader.ReadSingle();

                        TireSlipAngleFrontLeft = reader.ReadSingle();
                        TireSlipAngleFrontRight = reader.ReadSingle();
                        TireSlipAngleRearLeft = reader.ReadSingle();
                        TireSlipAngleRearRight = reader.ReadSingle();

                        TireCombinedSlipFrontLeft = reader.ReadSingle();
                        TireCombinedSlipFrontRight = reader.ReadSingle();
                        TireCombinedSlipRearLeft = reader.ReadSingle();
                        TireCombinedSlipRearRight = reader.ReadSingle();

                        SuspensionTravelMetersFrontLeft = reader.ReadSingle();
                        SuspensionTravelMetersFrontRight = reader.ReadSingle();
                        SuspensionTravelMetersRearLeft = reader.ReadSingle();
                        SuspensionTravelMetersRearRight = reader.ReadSingle();

                        CarOrdinal = reader.ReadInt32();
                        CarClass = reader.ReadInt32();
                        CarPerformanceIndex = reader.ReadInt32();
                        DrivetrainType = reader.ReadInt32();
                        NumCylinders = reader.ReadInt32();

                        PositionX = reader.ReadSingle();
                        PositionY = reader.ReadSingle();
                        PositionZ = reader.ReadSingle();

                        Speed = reader.ReadSingle();
                        Power = reader.ReadSingle();
                        Torque = reader.ReadSingle();

                        TireTempFrontLeft = reader.ReadSingle();
                        TireTempFrontRight = reader.ReadSingle();
                        TireTempRearLeft = reader.ReadSingle();
                        TireTempRearRight = reader.ReadSingle();

                        Boost = reader.ReadSingle();
                        Fuel = reader.ReadSingle();
                        DistanceTraveled = reader.ReadSingle();
                        BestLap = reader.ReadSingle();
                        LastLap = reader.ReadSingle();
                        CurrentLap = reader.ReadSingle();
                        CurrentRaceTime = reader.ReadSingle();

                        LapNumber = reader.ReadUInt16();
                        RacePosition = reader.ReadByte();

                        Accel = reader.ReadByte();
                        Brake = reader.ReadByte();
                        Clutch = reader.ReadByte();
                        HandBrake = reader.ReadByte();
                        Gear = reader.ReadByte();
                        Steer = reader.ReadSByte();

                        NormalizedDrivingLine = reader.ReadSByte();
                        NormalizedAIBrakeDifference = reader.ReadSByte();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Exception {0} caught during data stream read.", e.Message));
                Console.WriteLine(e.InnerException);
            }
        }
    }
}
