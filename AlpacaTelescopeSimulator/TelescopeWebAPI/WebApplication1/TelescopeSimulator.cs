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
            get { return true; }
        }
        public bool CanSetDeclinationRate
        {
            get { return true; }
        }
        public bool CanSetGuideRates
        {
            get { return true; }
        }
        public bool CanSetPark
        {
            get { return true; }
        }
        public bool CanSetPierSide
        {
            get { return false; }
        }
        public bool CanSetRightAscensionRate
        {
            get { return true; }
        }
        public bool CanSetTracking
        {
            get { return true; }
        }

        public bool CanSetRightAscension
        {
            get { return true; }
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
            get { return true; }
        }
        public bool CanSyncAltAz
        {
            get { return true; }
        }
        public bool CanUnpark
        {
            get { return true; }
        }
        private double _dec=0;
        public double Declination
        {
            get { return _dec;}
            set { _dec = value; }
        }
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

        private double _ra = 90;
        public double RightAscension
        {
            get { return _ra;}
            set
            {
                if (value>24 || value<0)
                {
                    throw new ASCOM.InvalidValueException();
                }
                _ra = value;
            }
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
                    throw new ASCOM.InvalidValueException();
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
                    throw new ASCOM.InvalidValueException();
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
            set
            {
                if (value>90 || value<-90)
                {
                    throw new ASCOM.InvalidValueException();
                }
                _targetDec = value;
            }
        }

        private double _targetRA = 23;
        public double TargetRightAscension
        {
            get { return _targetRA;}
            set
            {
                if (_targetRA>24  || _targetRA<0)
                {
                    throw new ASCOM.InvalidValueException();
                }
                _targetRA = value;
            }
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
            return "Dummy Action";
        }

        public void CommandBlind(string Command, bool Raw = false)
        {
           
        }

        public bool CommandBool(string Command, bool Raw = false)
        {
            return true;
        }

        public string CommandString(string Command, bool Raw = false)
        {
            return "Dummy Value";
        }

        public void Dispose()
        {
           
        }

        public void AbortSlew()
        {
           
        }

        public IAxisRates AxisRates(TelescopeAxes Axis)
        {
            return null;  //Huh???
        }

        public bool CanMoveAxis(TelescopeAxes Axis)
        {
            return true;
        }

        public PierSide DestinationSideOfPier(double RightAscension, double Declination)
        {

            return PierSide.pierEast;
        }

        public void FindHome()
        {
            
        }

        public void MoveAxis(TelescopeAxes Axis, double Rate)
        {
           
        }

        public void Park()
        {
            
        }

        public void PulseGuide(GuideDirections Direction, int Duration)
        {
            
        }

        public void SetPark()
        {
           
        }

        public void SlewToAltAz(double Azimuth, double Altitude)
        {
           
        }

        public void SlewToAltAzAsync(double Azimuth, double Altitude)
        {
            
        }

        public void SlewToCoordinates(double RightAscension, double Declination)
        {
            //if (RightAscension<0 || RightAscension==25)
            //{
                //throw  new ArgumentException();
            //}

            if (DeclinationRate<0 || DeclinationRate > 90)
            {
                throw new ArgumentException();
            }
        }

        public void SlewToCoordinatesAsync(double RightAscension, double Declination)
        {
          
        }

        public void SlewToTarget()
        {
           // throw new ArgumentException();
        }

        public void SlewToTargetAsync()
        {
           
        }

        public void SyncToAltAz(double Azimuth, double Altitude)
        {
            
        }

        public void SyncToCoordinates(double RightAscension, double Declination)
        {
            
        }

        public void SyncToTarget()
        {
           
        }

        public void Unpark()
        {
            
        }


    }
}
