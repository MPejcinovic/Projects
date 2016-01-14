using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.SharePoint.Administration;


namespace ULSLogging
{
    public class LoggingService : SPDiagnosticsServiceBase
    {

        private static LoggingService _current;

        public static string TestDiagnosticAreaName = "Test log - Matea";

        private static class CategoryName
        {
            public const string WARNING = "Warning"; //this could be used when termset already exists, it is not an error, it should be just a warning
            public const string ERROR = "Error";
            public const string RENDERING = "Rendering";
            public const string TAXONOMY_CREATION = "Taxonomy creation";
            public const string GETTING_TAXONOMY = "Getting taxonomy";
            public const string WORKING_WITH_PROPERTY_BAG = "Working with property bag";
        }

        #region TraceSeverity

        public static TraceSeverity TraceSeverity_WARNING
        {
            get
            {
                return TraceSeverity.Monitorable;
            }
        }

        public static TraceSeverity TraceSeverity_ERROR
        {
            get
            {
                return TraceSeverity.High;
            }
        }

        public static TraceSeverity TraceSeverity_RENDERING
        {
            get
            {
                return TraceSeverity.Verbose;
            }
        }

        public static TraceSeverity TraceSeverity_TAXONOMY_CREATION
        {
            get
            {
                return TraceSeverity.Verbose;
            }
        }

        public static TraceSeverity TraceSeverity_GETTING_TAXONOMY
        {
            get
            {
                return TraceSeverity.Verbose;
            }
        }

        public static TraceSeverity TraceSeverity_WORKING_WITH_PROPERTY_BAG
        {
            get
            {
                return TraceSeverity.Verbose;
            }
        }

        #endregion

        #region EventSeverity

        public static EventSeverity EventSeverity_WARNING
        {
            get
            {
                return EventSeverity.Warning;
            }
        }

        public static EventSeverity EventSeverity_ERROR
        {
            get
            {
                return EventSeverity.ErrorCritical;
            }
        }

        public static EventSeverity EventSeverity_RENDERING
        {
            get
            {
                return EventSeverity.Information;
            }
        }

        public static EventSeverity EventSeverity_TAXONOMY_CREATION
        {
            get
            {
                return EventSeverity.Information;
            }
        }

        public static EventSeverity EventSeverity_GETTING_TAXONOMY
        {
            get
            {
                return EventSeverity.Information;
            }
        }

        public static EventSeverity EventSeverity_WORKING_WITH_PROPERTY_BAG
        {
            get
            {
                return EventSeverity.Information;
            }
        }

        #endregion

        public static LoggingService Current
        {
            get
            {
                //singleton object
                if (_current == null)
                {
                    _current = new LoggingService();
                }
                return _current;
            }
        }

        private LoggingService() : base("Matea's Test Logging Service", SPFarm.Local)
        {

        }

        protected override IEnumerable<SPDiagnosticsArea> ProvideAreas()
        {
            List<SPDiagnosticsArea> areas = new List<SPDiagnosticsArea>
            {
                new SPDiagnosticsArea(TestDiagnosticAreaName, new List<SPDiagnosticsCategory>
                {
                    new SPDiagnosticsCategory(CategoryName.WARNING, TraceSeverity_WARNING, EventSeverity_WARNING),
                    new SPDiagnosticsCategory(CategoryName.ERROR, TraceSeverity_ERROR, EventSeverity_ERROR),
                    new SPDiagnosticsCategory(CategoryName.RENDERING, TraceSeverity_RENDERING, EventSeverity_RENDERING),
                    new SPDiagnosticsCategory(CategoryName.TAXONOMY_CREATION, TraceSeverity_TAXONOMY_CREATION, EventSeverity_TAXONOMY_CREATION),
                    new SPDiagnosticsCategory(CategoryName.GETTING_TAXONOMY, TraceSeverity_GETTING_TAXONOMY, EventSeverity_GETTING_TAXONOMY),
                    new SPDiagnosticsCategory(CategoryName.WORKING_WITH_PROPERTY_BAG,TraceSeverity_WORKING_WITH_PROPERTY_BAG, EventSeverity_WORKING_WITH_PROPERTY_BAG),
                })
            };

            return areas;
        }

        public static void GetInfoForLoggingTrace(string categoryName, out TraceSeverity traceSeverity, out SPDiagnosticsCategory category)
        {
            traceSeverity = new TraceSeverity();
            try
            {
                category = LoggingService.Current.Areas[TestDiagnosticAreaName].Categories[categoryName];
            }
            catch (Exception ex)
            {
                category = LoggingService.Current.Areas[TestDiagnosticAreaName].Categories[CategoryName.ERROR];
            }

            switch (categoryName)
            {
                case CategoryName.WARNING:
                    traceSeverity = TraceSeverity_WARNING;
                    break;

                case CategoryName.ERROR:
                    traceSeverity = TraceSeverity_ERROR;
                    break;

                case CategoryName.RENDERING:
                    traceSeverity = TraceSeverity_RENDERING;
                    break;

                case CategoryName.TAXONOMY_CREATION:
                    traceSeverity = TraceSeverity_TAXONOMY_CREATION;
                    break;

                case CategoryName.GETTING_TAXONOMY:
                    traceSeverity = TraceSeverity_GETTING_TAXONOMY;
                    break;

                case CategoryName.WORKING_WITH_PROPERTY_BAG:
                    traceSeverity = TraceSeverity_WORKING_WITH_PROPERTY_BAG;
                    break;

                default:
                    traceSeverity = TraceSeverity.High;
                    break;
            }
        }

        public static void GetInfoForLoggingEvent(string categoryName, out EventSeverity eventSeverity, out SPDiagnosticsCategory category)
        {
            eventSeverity = new EventSeverity();
            try
            {
                category = LoggingService.Current.Areas[TestDiagnosticAreaName].Categories[categoryName];
            }
            catch (Exception ex)
            {
                category = LoggingService.Current.Areas[TestDiagnosticAreaName].Categories[CategoryName.ERROR];
            }

            switch (categoryName)
            {
                case CategoryName.WARNING:
                    eventSeverity = EventSeverity_WARNING;
                    break;

                case CategoryName.ERROR:
                    eventSeverity = EventSeverity_ERROR;
                    break;

                case CategoryName.RENDERING:
                    eventSeverity = EventSeverity_RENDERING;
                    break;

                case CategoryName.TAXONOMY_CREATION:
                    eventSeverity = EventSeverity_TAXONOMY_CREATION;
                    break;

                case CategoryName.GETTING_TAXONOMY:
                    eventSeverity = EventSeverity_GETTING_TAXONOMY;
                    break;

                case CategoryName.WORKING_WITH_PROPERTY_BAG:
                    eventSeverity = EventSeverity_WORKING_WITH_PROPERTY_BAG;
                    break;

                default:
                    eventSeverity = EventSeverity.ErrorCritical;
                    break;
            }
        }

        public static void LoggingTrace(string categoryName, string errorMessage)
        {
            TraceSeverity traceSeverity;

            SPDiagnosticsCategory category;

            GetInfoForLoggingTrace(categoryName, out traceSeverity, out category);

            LoggingService.Current.WriteTrace(0, category, traceSeverity, errorMessage);
        }

        public static void LoggingTrace(string categoryName, string errorMessage, params object[] args)
        {
            TraceSeverity traceSeverity;

            SPDiagnosticsCategory category;

            GetInfoForLoggingTrace(categoryName, out traceSeverity, out category);

            LoggingService.Current.WriteTrace(0, category, traceSeverity, errorMessage, args);
        }

        public static void LoggingEvent(string categoryName, string errorMessage)
        {
            EventSeverity eventSeverity;

            SPDiagnosticsCategory category;

            GetInfoForLoggingEvent(categoryName, out eventSeverity, out category);

            LoggingService.Current.WriteEvent(0, category, eventSeverity, errorMessage);
        }

        public static void LoggingEvent(string categoryName, string errorMessage, params object[] args)
        {
            EventSeverity eventSeverity;

            SPDiagnosticsCategory category;

            GetInfoForLoggingEvent(categoryName, out eventSeverity, out category);

            LoggingService.Current.WriteEvent(0, category, eventSeverity, errorMessage, args);
        }
    }
}
