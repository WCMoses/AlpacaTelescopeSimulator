using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;

namespace ASCOMCore
{
    public class TelescopeSimulator : ASCOM.DeviceInterface.ITelescopeV3
    {

        public bool Connected { get; set; }
        public string Description
        {
            get
            {
                throw new ASCOM.PropertyNotImplementedException("Description", false);
            }
        }
        public string DriverInfo => "ASCOM .NET Core telescope simulator driver v 1.0.0.0";

        public string DriverVersion => "1.0.0.0";
        public short InterfaceVersion => 3;
        public string Name => "ASCOM .NET Core telescope simulator";
        public ArrayList SupportedActions { get; }
        public AlignmentModes AlignmentMode { get; }
        public double Altitude { get; }
        public double ApertureArea { get; }
        public double ApertureDiameter { get; }
        public bool AtHome { get; }
        public bool AtPark { get; }
        public double Azimuth { get; }
        public bool CanFindHome { get; }
        public bool CanPark { get; }
        public bool CanPulseGuide { get; }
        public bool CanSetDeclinationRate { get; }
        public bool CanSetGuideRates { get; }
        public bool CanSetPark { get; }
        public bool CanSetPierSide { get; }
        public bool CanSetRightAscensionRate { get; }
        public bool CanSetTracking { get; }
        public bool CanSlew { get; }
        public bool CanSlewAltAz { get; }
        public bool CanSlewAltAzAsync { get; }
        public bool CanSlewAsync { get; }
        public bool CanSync { get; }
        public bool CanSyncAltAz { get; }
        public bool CanUnpark { get; }
        public double Declination { get; }
        public double DeclinationRate { get; set; }
        public bool DoesRefraction { get; set; }
        public EquatorialCoordinateType EquatorialSystem { get; }
        public double FocalLength { get; }
        public double GuideRateDeclination { get; set; }
        public double GuideRateRightAscension { get; set; }
        public bool IsPulseGuiding { get; }
        public double RightAscension { get; }
        public double RightAscensionRate { get; set; }
        public PierSide SideOfPier { get; set; }
        public double SiderealTime { get; }
        public double SiteElevation { get; set; }
        public double SiteLatitude { get; set; }
        public double SiteLongitude { get; set; }
        public bool Slewing { get; }
        public short SlewSettleTime { get; set; }
        public double TargetDeclination { get; set; }
        public double TargetRightAscension { get; set; }
        public bool Tracking { get; set; }
        public DriveRates TrackingRate { get; set; }
        public ITrackingRates TrackingRates { get; }
        public DateTime UTCDate { get; set; }
        public void SetupDialog()
        {
            throw new ASCOM.MethodNotImplementedException("SetupDialog");
        }

        public string Action(string ActionName, string ActionParameters)
        {
            throw new ASCOM.MethodNotImplementedException("Action");
        }

        public void CommandBlind(string Command, bool Raw = false)
        {
            throw new ASCOM.MethodNotImplementedException("CommandBlind");
        }

        public bool CommandBool(string Command, bool Raw = false)
        {
            throw new ASCOM.MethodNotImplementedException("CommandBool");
        }

        public string CommandString(string Command, bool Raw = false)
        {
            throw new ASCOM.MethodNotImplementedException("CommandString");
        }

        public void Dispose()
        {
            throw new ASCOM.MethodNotImplementedException("Dispose");
        }

        public void AbortSlew()
        {
            throw new ASCOM.MethodNotImplementedException("AbortSlew");
        }

        public IAxisRates AxisRates(TelescopeAxes Axis)
        {
            throw new ASCOM.MethodNotImplementedException("IAxisRates");
        }

        public bool CanMoveAxis(TelescopeAxes Axis)
        {
            throw new ASCOM.MethodNotImplementedException("CanMoveAxis");
        }

        public PierSide DestinationSideOfPier(double RightAscension, double Declination)
        {
            throw new ASCOM.MethodNotImplementedException("DestinationSideOfPier");
        }

        public void FindHome()
        {
            throw new ASCOM.MethodNotImplementedException("FindHome");
        }

        public void MoveAxis(TelescopeAxes Axis, double Rate)
        {
            throw new ASCOM.MethodNotImplementedException("MoveAxis");
        }

        public void Park()
        {
            throw new ASCOM.MethodNotImplementedException("Park");
        }

        public void PulseGuide(GuideDirections Direction, int Duration)
        {
            throw new ASCOM.MethodNotImplementedException("PulseGuide");
        }

        public void SetPark()
        {
            throw new ASCOM.MethodNotImplementedException("SetPark");
        }

        public void SlewToAltAz(double Azimuth, double Altitude)
        {
            throw new ASCOM.MethodNotImplementedException("SlewToAltAz");
        }

        public void SlewToAltAzAsync(double Azimuth, double Altitude)
        {
            throw new ASCOM.MethodNotImplementedException("SlewToAltAzAsync");
        }

        public void SlewToCoordinates(double RightAscension, double Declination)
        {
            throw new ASCOM.MethodNotImplementedException("SlewToCoordinates");
        }

        public void SlewToCoordinatesAsync(double RightAscension, double Declination)
        {
            throw new ASCOM.MethodNotImplementedException("SlewToCoordinatesAsync");
        }

        public void SlewToTarget()
        {
            throw new ASCOM.MethodNotImplementedException("SlewToTarget");
        }

        public void SlewToTargetAsync()
        {
            throw new ASCOM.MethodNotImplementedException("SlewToTargetAsync");
        }

        public void SyncToAltAz(double Azimuth, double Altitude)
        {
            throw new ASCOM.MethodNotImplementedException("SyncToAltAz");
        }

        public void SyncToCoordinates(double RightAscension, double Declination)
        {
            throw new ASCOM.MethodNotImplementedException("SyncToCoordinates");
        }

        public void SyncToTarget()
        {
            throw new ASCOM.MethodNotImplementedException("SyncToTarget");
        }

        public void Unpark()
        {
            throw new ASCOM.MethodNotImplementedException("Unpark");
        }


    }
}
