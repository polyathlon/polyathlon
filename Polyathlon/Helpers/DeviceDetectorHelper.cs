﻿using System.Management;

namespace Polyathlon.Utils
{
    public class DeviceDetectorHelper
    {
        public enum ChassisTypes
        {
            Other = 1,
            Unknown,
            Desktop,
            LowProfileDesktop,
            PizzaBox,
            MiniTower,
            Tower,
            Portable,
            Laptop,
            Notebook,
            Handheld,
            DockingStation,
            AllInOne,
            SubNotebook,
            SpaceSaving,
            LunchBox,
            MainSystemChassis,
            ExpansionChassis,
            SubChassis,
            BusExpansionChassis,
            PeripheralChassis,
            StorageChassis,
            RackMountChassis,
            SealedCasePC
        }

        private static string[] dellModel = new string[] { "Venue 8 Pro 5830" };
        private static KnownHardwareKind[] dellModelKind = new KnownHardwareKind[] { KnownHardwareKind.DellPro8 };

        private static void ParseKindDell(HardwareInfo res)
        { ParseKindCore(res, dellModel, dellModelKind); }

        private static bool ParseKindCore(HardwareInfo res, string[] model, KnownHardwareKind[] kind)
        {
            int i = Array.IndexOf<string>(model, res.Model);
            if (i < 0) return false;
            res.Kind = kind[i];
            return true;
        }

        private static string[] msModel = new string[] { "Surface with Windows 8 Pro", "Surface Pro 2", "Surface Pro 3" };
        private static KnownHardwareKind[] msModelKind = new KnownHardwareKind[] { KnownHardwareKind.SurfacePro, KnownHardwareKind.SurfacePro2, KnownHardwareKind.SurfacePro3 };

        private static void ParseKindMicrosoft(HardwareInfo res)
        { ParseKindCore(res, msModel, msModelKind); }

        public enum KnownHardwareKind
        { Unknown, SurfacePro, SurfacePro2, SurfacePro3, DellPro8, DellPro10 }

        public class HardwareInfo
        {
            public HardwareInfo()
            {
                Kind = KnownHardwareKind.Unknown;
                Manufacturer = "";
                Model = "";
            }

            public KnownHardwareKind Kind { get; set; }
            public string Manufacturer { get; set; }
            public string Model { get; set; }

            public override string ToString()
            {
                if (Kind == KnownHardwareKind.Unknown)
                {
                    return string.Format("Unknown: {0}/{1}", Manufacturer, Model);
                }
                return string.Format("{0}: {1}/{2}", Kind, Manufacturer, Model);
            }
        }

        private static HardwareInfo deviceHardwareInfo = null;
        private static bool? hasBattery = null;
        private static ChassisTypes? chassis = null;
        private static bool? hasTouchSupport = null;
        private static bool? isWindows8 = null;

        public static bool IsWindows8
        {
            get
            {
                if (isWindows8 == null)
                {
                    isWindows8 = DetectWindows8();
                }
                return isWindows8.Value;
            }
        }

        public static HardwareInfo DetectHardwareInfo()
        {
            if (deviceHardwareInfo == null) deviceHardwareInfo = ParseHardwareInfo();
            return deviceHardwareInfo;
        }

        private static bool DetectWindows8()
        {
            try
            {
                var win8version = new Version(6, 2, 9200, 0);

                if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                    Environment.OSVersion.Version >= win8version)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public static bool IsTablet
        {
            get
            {
                if (!IsWindows8)
                {
                    return false;
                }

                if (!HasTouchSupport)
                {
                    return false;
                }

                return HasBattery;
            }
        }

        public static bool IsTabletChassis
        {
            get
            {
                if (Chassis == ChassisTypes.Handheld || Chassis == ChassisTypes.Portable)
                {
                    return true;
                }
                return false;
            }
        }

        public static bool HasTouchSupport
        {
            get
            {
                if (hasTouchSupport == null)
                {
                    hasTouchSupport = CheckTouch();
                }
                return hasTouchSupport.Value;
            }
        }

        private static bool CheckTouch()
        {
            var device = System.Windows.Input.Tablet.TabletDevices.Cast<System.Windows.Input.TabletDevice>().FirstOrDefault(dev => dev.Type == System.Windows.Input.TabletDeviceType.Touch);
            if (device == null)
            {
                return false;
            }
            return true;
        }

        public static ChassisTypes Chassis
        {
            get
            {
                if (chassis == null)
                {
                    chassis = GetCurrentChassisType();
                }
                return chassis.Value;
            }
        }

        public static ChassisTypes GetCurrentChassisType()
        {
            try
            {
                var systemEnclosures = new ManagementClass("Win32_SystemEnclosure");
                foreach (ManagementObject obj in systemEnclosures.GetInstances())
                {
                    foreach (int i in (UInt16[])(obj["ChassisTypes"]))
                    {
                        if (i > 0 && i < 25)
                        {
                            return (ChassisTypes)i;
                        }
                    }
                }
            }
            catch
            {
            }
            return ChassisTypes.Unknown;
        }

        public static bool HasBattery
        {
            get
            {
                if (hasBattery == null)
                {
                    hasBattery = CheckHasBattery();
                }
                return hasBattery.Value;
            }
        }

        private static bool CheckHasBattery()
        {
            try
            {
                var query = new ObjectQuery("Select * FROM Win32_Battery");
                var searcher = new ManagementObjectSearcher(query);

                var collection = searcher.Get();
                return collection.Count > 0;
            }
            catch
            {
            }
            return false;
        }

        public static bool SuggestHybridDemoParameters(out float touchScale, out float fontSize)
        {
            touchScale = 2f;
            fontSize = 11f;
            var h = DetectHardwareInfo();
            switch (h.Kind)
            {
                case KnownHardwareKind.DellPro8:
                    touchScale = 1.5f;
                    fontSize = 10;
                    return true;

                case KnownHardwareKind.DellPro10:
                case KnownHardwareKind.SurfacePro:
                case KnownHardwareKind.SurfacePro2:
                case KnownHardwareKind.SurfacePro3:
                    touchScale = 2.5f;
                    fontSize = 8.2f;
                    return true;
            }
            if (Screen.PrimaryScreen.WorkingArea.Width < 1500 || Screen.PrimaryScreen.WorkingArea.Height < 800)
            {
                touchScale = 1.5f;
                fontSize = 10;
            }
            return true;
        }

        private static HardwareInfo ParseHardwareInfo()
        {
            HardwareInfo res = new();
            ParseHardwareInfoCore(res);
            return res;
        }

        private static bool ParseHardwareInfoCore(HardwareInfo res)
        {
            try
            {
                var query = new ObjectQuery("Select * FROM Win32_ComputerSystem");
                var searcher = new ManagementObjectSearcher(query);
                var collection = searcher.Get();
                foreach (var c in collection)
                {
                    res.Manufacturer = c["Manufacturer"].ToString();
                    res.Model = c["Model"].ToString();
                }
            }
            catch
            {
                return false;
            }
            ParseKind(res);
            return true;
        }

        private static void ParseKind(HardwareInfo res)
        {
            if (res.Manufacturer == "Microsoft Corporation")
            {
                ParseKindMicrosoft(res);
            }
            if (res.Manufacturer == "DellInc.")
            {
                ParseKindDell(res);
            }
        }
    }
}