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
            get { return "My telescope driver"; }
        }

        public string DriverInfo => "ASCOM .NET Core telescope simulator driver v 1.0.0.0";

        public string DriverVersion => "1.0.0.0";
        public short InterfaceVersion => 1;
        public string Name => "ASCOM .NET Core telescope simulator";
        public ArrayList SupportedActions { get; }

        public AlignmentModes AlignmentMode
        {
            get { return AlignmentModes.algPolar; }
        }

        public double Altitude
        {
            get { return 85; }
        }


        public double ApertureArea
        {
            get { return 100; }
        }
        public double ApertureDiameter
        {
            get { return 100; }
        }
        public bool AtHome
        {
            get { return false; }
        }
        public bool AtPark
        {
            get { return false; }
        }
        public double Azimuth
        {
            get { return 100; }
        }
        public bool CanFindHome
        {
            get { return false; }
        }
        public bool CanPark
        {
            get { return true; }
        }
        public bool CanPulseGuide
        {
            get { return false; }
        }
        public bool CanSetDeclinationRate
        {
            get { return false; }
        }
        public bool CanSetGuideRates
        {
            get { return false; }
        }
        public bool CanSetPark
        {
            get { return false; }
        }
        public bool CanSetPierSide
        {
            get { return false; }
        }
        public bool CanSetRightAscensionRate
        {
            get { return false; }
        }
        public bool CanSetTracking
        {
            get { return false; }
        }

        public bool CanSetRightAscension
        {
            get { return false; }
        }
        public bool CanSlew
        {
            get { return true; }
        }
        public bool CanSlewAltAz
        {
            get { return false; }
        }
        public bool CanSlewAltAzAsync
        {
            get { return false; }
        }
        public bool CanSlewAsync
        {
            get { return true; }
        }
        public bool CanSync
        {
            get { return false; }
        }
        public bool CanSyncAltAz
        {
            get { return false; }
        }
        public bool CanUnpark
        {
            get { return false; }
        }
        public double Declination { get; }
        public double DeclinationRate { get; set; }
        public bool DoesRefraction { get; set; }
        public EquatorialCoordinateType EquatorialSystem { get; }
        public double FocalLength { get; }
        public double GuideRateDeclination { get; set; }
        public double GuideRateRightAscension { get; set; }
        public bool IsPulseGuiding
        {
            get { return true; }
        }

        public double RightAscension
        {
            get { return (double)12.1234; }
        }
        public double RightAscensionRate { get; set; }
        public PierSide SideOfPier { get; set; }

        public double SiderealTime
        {
            get
            { //return Convert.ToDouble(DateTime.Now.Ticks);
                return (double)100.4;
            }
        }

        private double _siteElevation = 0;
        public double SiteElevation
        {
            get { return _siteElevation;}
            set
            {
                if (_siteElevation<= -300)
                {
                    throw new ArgumentException();
                }
                _siteElevation = value;
            }
        }

        private double _siteLatitude = 45;
        public double SiteLatitude
        {
            get { return _siteLatitude;}
            set
            {
                if (_siteLatitude>90 || _siteLatitude <-90)
                {
                    throw new ArgumentException();
                }
                _siteLatitude = value;
            }
        }
        public double SiteLongitude { get; set; }

        public bool Slewing
        {
            get { return false; }
        }
        public short SlewSettleTime { get; set; }

        private double _targetDec = 10;
        public double TargetDeclination
        {
            get { return _targetDec;}
            set { _targetDec = value; }
        }

        private double _targetRA = 23;
        public double TargetRightAscension
        {
            get { return _targetRA;}
            set { _targetRA = value; }
        }
        public bool Tracking { get; set; }
        public DriveRates TrackingRate { get; set; }
        public ITrackingRates TrackingRates { get; }

        private DateTime _utc = DateTime.UtcNow;
        public DateTime UTCDate
        {
            get { return _utc; }
            set { _utc = value; }
        }

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
            // throw new ASCOM.MethodNotImplementedException("Park");
        }

        public void PulseGuide(GuideDirections Direction, int Duration)
        {
            
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
            if (RightAscension<0 || RightAscension==25)
            {
                throw  new ArgumentException();
            }

            if (DeclinationRate<-99 || DeclinationRate > 99)
            {
                throw new ArgumentException();
            }
        }

        public void SlewToCoordinatesAsync(double RightAscension, double Declination)
        {
           
        }

        public void SlewToTarget()
        {
            
        }

        public void SlewToTargetAsync()
        {
           
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
